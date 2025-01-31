using Cbiz.PreAutoBilling.Core.Interfaces.Services;
using Cbiz.PreAutoBilling.Infrastructure.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cbiz.PreAutoBilling
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var serviceProvider = StartupService.ConfigureServices();

                using (var scope = serviceProvider.CreateScope())
                {
                    var billingService = scope.ServiceProvider
                        .GetRequiredService<IBillingService>();

                    await billingService.ProcessBillingEmailsAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
