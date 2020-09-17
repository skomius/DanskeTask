using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Linq;

namespace Producer
{
    public class Worker: BackgroundService
    {
        protected override async System.Threading.Tasks.Task ExecuteAsync(CancellationToken stoppingToken)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 8899);
            listener.Start();
            while (!stoppingToken.IsCancellationRequested)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                NetworkStream stream = client.GetStream();

                Console.WriteLine("test");

                while (!stoppingToken.IsCancellationRequested)
                {
                    byte[] data = new byte[1024];
                    int read = await stream.ReadAsync(data, 0, 1024, stoppingToken);

                    var request = await new StreamReader(new MemoryStream(data)).ReadToEndAsync();

                    Console.WriteLine($"request \"{request}\"");

                    PrepareReply(request);

                    await stream.WriteAsync(data, 0, read, stoppingToken);
                }
            }
        }

        string PrepareReply(string request)
        {
            var paramsArray = request.Split(" ").Select(x => x.Trim());

            var command = paramsArray.First();
          
            switch (command)
            {
                case "Show":
                    return ShowTaxes(paramsArray.Skip(1));
                case "Import":
                    return Import(paramsArray.Skip(1));
                case "Insert":
                    return Insert(paramsArray.Skip(1));
                default:
                    return $"Incorrect command \"{command}\"";
            }
        }

        private string ShowTaxes(IEnumerable<string> enumerable)
        {
            using (var context = new ScheduledTaxContext())
            {
                context.ScheduledTaxes.Where(x => x.Municipality == enumerable.First()  )
            }
        }

        private string Import(IEnumerable<string> enumerable)
        {
            if (File.Exists(enumerable.First()))
                return $"File not exist in path \"{enumerable.First()}\"";

            using (StreamReader file = new StreamReader(enumerable.First()))
            {
                while (file.ReadLine() != null)
                {

                }
            }
        }

        private string Insert(IEnumerable<string> enumerable)
        {
            using (var context = new ScheduledTaxContext())
            {
                context.ScheduledTaxes.Add(
                    new ScheduledTax
                    {
                        ScheduledTaxId = Guid.NewGuid(),
                        Municipality = enumerable.Skip(1).FirstOrDefault(),
                        Rate = double.Parse(enumerable.Skip(2).FirstOrDefault()),
                    });
            }
        }
    }
}
