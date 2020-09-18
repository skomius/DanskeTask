using System;
using System.Net.Sockets;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            const int PORT_NO = 8899;
            const string SERVER_IP = "127.0.0.1";

            while (true)
            {
                try
                {
                    TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
                    Console.WriteLine("Connected !!!");
                    Console.WriteLine();
                    Console.WriteLine("Commands examples:");
                    Console.WriteLine("show vilnius 2014-12-02");
                    Console.WriteLine("insert vilnius weekly 0.2 2014-12-01 2014-12-07");
                    Console.WriteLine("import c://import.csv");

                    while (true)
                    { 
                        Console.WriteLine("Enter command:");

                        var request = Console.ReadLine();

                        Byte[] data = Encoding.ASCII.GetBytes(request);

                        NetworkStream stream = client.GetStream();

                        stream.Write(data, 0, data.Length);

                        Console.WriteLine("Sent: {0}", request);

                        data = new Byte[2048];
                        String responseData = String.Empty;

                        Int32 bytes = stream.Read(data, 0, data.Length);
                        responseData = Encoding.ASCII.GetString(data, 0, bytes);
                        Console.WriteLine("Received: {0}", responseData);
                    }
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("ArgumentNullException: {0}", e);
                }
                catch (SocketException e)
                {
                    Console.WriteLine("Fail to connect. Press enter try again.");
                } 
                
                Console.Read();
            }
        }
    }
}
