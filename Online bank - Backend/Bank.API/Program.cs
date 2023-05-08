using Microsoft.AspNetCore;
using NLog.Web;
using Microsoft.EntityFrameworkCore;
using Bank.API.Data;

namespace Bank.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder
                    .ConfigureNLog("nlog.config")
                    .GetCurrentClassLogger();

            try
            {
                logger.Info("Initializing application...");
                var host = CreateWebHostBuilder(args).Build();

                using(var scope = host.Services.CreateScope()) 
                {
                    try 
                    {
                        var context = scope.ServiceProvider.GetService<AccountInfoContext>();

                        context.Database.EnsureDeleted();
                        context.Database.Migrate();
                    }
                    catch(Exception ex)
                    {
                        logger.Error(ex, "An error occurred while migrating the database!");
                    }
                }

                host.Run();
            }
            catch (Exception ex) 
            { 
                logger.Error(ex,"Application stopped because of exception.");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseNLog();
    }
}
