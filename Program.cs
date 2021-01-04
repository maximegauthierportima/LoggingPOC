using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace LoggingPOC
{
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // ASP.NET Core 3.0+:
        // The UseServiceProviderFactory call attaches the
        // Autofac provider to the generic hosting mechanism.
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog(((hostingContext, provider, loggerConfiguration) => //You can use the UseSerilog method to initialized the configuration of Serilog
                                 loggerConfiguration
                                    .ReadFrom.Configuration(hostingContext.Configuration) //This allows you to put the configuration of Serilog inside the appsettings.json
                            )
                          , writeToProviders: true) //This will create a new log file every day
                .ConfigureWebHostDefaults(webBuilder =>
                                          {
                                              webBuilder.UseStartup<Startup>();
                                          });
    }
}
