namespace Catman.Education.WebApi
{
    using System;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Serilog;

    public class Program
    {
        private static IConfiguration EnvironmentVariables =>
            new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();
        
        private static IConfiguration AppSettings =>
            new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{EnvironmentVariables["ASPNETCORE_ENVIRONMENT"]}.json", optional: true)
                .Build();
        
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(AppSettings)
                .CreateLogger();

            try
            {
                CreateHostBuilder(args).Build().Run();
                Log.Information("Web host started");
            }
            catch (Exception exception)
            {
                Log.Fatal(exception, "Web host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host
                .CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
                .UseSerilog();
    }
}
