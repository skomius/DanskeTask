using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Linq;
using System.Globalization;
using CsvHelper;

namespace Producer
{
    public class Worker : BackgroundService
    {
        protected override async System.Threading.Tasks.Task ExecuteAsync(CancellationToken stoppingToken)
        {
            const int PORT_NO = 8899;

            TcpListener listener = new TcpListener(IPAddress.Any, PORT_NO);
            listener.Start();
            while (!stoppingToken.IsCancellationRequested)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();

                Console.WriteLine("client connected");

                NetworkStream stream = client.GetStream();
                while (!stoppingToken.IsCancellationRequested)
                {
                    byte[] data = new byte[4096];
                    int read = await stream.ReadAsync(data, 0, 4096, stoppingToken);

                    var request = await new StreamReader(new MemoryStream(data.Take(read).ToArray())).ReadToEndAsync();

                    Console.WriteLine($"request \"{request}\"");

                    var reply = string.Empty;

                    try
                    {
                        reply = PrepareReply(request);
                    }
                    catch (Exception e)
                    {
                        reply = $"Incorrect request format \"{request}\"";
                    }

                    var buffer = Encoding.ASCII.GetBytes(reply);

                    await stream.WriteAsync(buffer, 0, buffer.Length, stoppingToken);
                }
            }
        }

        string PrepareReply(string request)
        {
            var paramsArray = request.Split(" ").Select(x => x.Trim());

            var command = paramsArray.First();

            switch (command)
            {
                case "show":
                    return ShowTaxes(paramsArray.Skip(1));
                case "import":
                    return Import(paramsArray.Skip(1));
                case "insert":
                    return Insert(paramsArray.Skip(1));
                default:
                    return $"Incorrect command \"{command}\"";
            }
        }

        private string ShowTaxes(IEnumerable<string> enumerable)
        {
            var date = DateTime.Parse(enumerable.Skip(1).FirstOrDefault());
            ScheduledTax scheduledTax = null; 

            using (var context = new ScheduledTaxContext())
            {
                scheduledTax = context.ScheduledTaxes.Where(x => x.Municipality == enumerable.First()
                    && x.From <= date && x.To >= date)
                    .OrderBy(x => x.To - x.From).SingleOrDefault();
            }

            return scheduledTax != null ? 
                $"{scheduledTax.Municipality} tax rate is {scheduledTax.Rate} scheduled {scheduledTax.TaxType} from {scheduledTax.From} to {scheduledTax.To}"
                : $"No entry with parameters {enumerable.First()} and {date}";
        }

        private string Import(IEnumerable<string> enumerable)
        {
            if (File.Exists(enumerable.First()))
                return $"File not exist in path \"{enumerable.First()}\"";

            IEnumerable<ScheduledTax> records = null;

            using (var reader = new StreamReader(enumerable.First()))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                records = csv.GetRecords<ScheduledTax>();
            }

            using (var context = new ScheduledTaxContext())
            {
                context.ScheduledTaxes.AddRange(records);
                context.SaveChanges();
            }

            return "Operation successful";
        }

        private string Insert(IEnumerable<string> enumerable)
        {
            using (var context = new ScheduledTaxContext())
            {
                context.ScheduledTaxes.Add(
                    new ScheduledTax
                    {
                        ScheduledTaxId = Guid.NewGuid(),
                        Municipality = enumerable.FirstOrDefault(),
                        TaxType = enumerable.Skip(1).FirstOrDefault(),
                        Rate = double.Parse(enumerable.Skip(2).FirstOrDefault()),
                        From = DateTime.Parse(enumerable.Skip(3).FirstOrDefault()),
                        To = DateTime.Parse(enumerable.Skip(4).FirstOrDefault())
                    });

                context.SaveChanges();
            }

            return "Operation successful";
        }
    }
}
