using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Cbiz.PreAutoBilling.Core.Models;
using Cbiz.PreAutoBilling.Core.Interfaces.Email;
using Cbiz.PreAutoBilling.Core.Interfaces.Data;
using Cbiz.PreAutoBilling.Core.Interfaces.Services;
using Cbiz.PreAutoBilling.Core.Interfaces.Templates;
using Cbiz.PreAutoBilling.Infrastructure.Data;
using Cbiz.PreAutoBilling.Infrastructure.Services;

namespace Cbiz.PreAutoBilling.Infrastructure.Configuration
{
    public static class StartupService
    {
        public static IServiceProvider ConfigureServices()
        {
            var configuration = BuildConfiguration();
            var services = new ServiceCollection();

            services.AddConfiguration(configuration);
            services.AddApplicationServices();

            return services.BuildServiceProvider();
        }

        private static IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfiguration(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.Configure<EmailSettings>(
                configuration.GetSection("EmailSettings"));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            return services;
        }

        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IBillingEmailService, BillingEmailService>();
            services.AddScoped<IBillingService, BillingService>();
            services.AddSingleton<ITemplateService, TemplateService>();

            return services;
        }
    }
} 