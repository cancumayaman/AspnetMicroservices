using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ordering.API.Extensions;
using Ordering.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var host= CreateHostBuilder(args).Build();
            host.MigrateDatabase<OrderContext>(
                (context, services) =>
                {
                    var logger = services.GetService<ILogger<OrderContextSeed>>();
                    OrderContextSeed.SeedAsync(context, logger).Wait();
                }
                );
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
