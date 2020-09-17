using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseWindowsService()
            //.ConfigureAppConfiguration((hostingContext, config) =>
            //{
            //    config.AddJsonFile("./appSettings.json");
            //})
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<Worker>();
            });
    }
}
