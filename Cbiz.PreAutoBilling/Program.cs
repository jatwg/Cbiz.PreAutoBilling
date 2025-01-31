using Cbiz.PreAutoBilling.Core.Interfaces.Services;
using Cbiz.PreAutoBilling.Infrastructure.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;

namespace Cbiz.PreAutoBilling
{
    internal class Program
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        static async Task Main(string[] args)
        {
            // Load NLog configuration
            LogManager.Setup().LoadConfigurationFromFile("nlog.config");
            
            try
            {
                Logger.Info("Application starting...");
                
                var serviceProvider = StartupService.ConfigureServices();
                Logger.Debug("Services configured successfully");

                using (var scope = serviceProvider.CreateScope())
                {
                    Logger.Debug("Creating service scope");
                    var billingService = scope.ServiceProvider
                        .GetRequiredService<IBillingService>();

                    Logger.Info("Starting billing email processing");
                    await billingService.ProcessBillingEmailsAsync();
                    Logger.Info("Billing email processing completed successfully");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "An error occurred during application execution");
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally 
            {
                // Ensure all logs are written
                LogManager.Shutdown();
            }

            Logger.Info("Application shutting down");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
