using Cbiz.PreAutoBilling.Core.Interfaces.Email;
using Cbiz.PreAutoBilling.Core.Interfaces.Templates;
using Cbiz.PreAutoBilling.Core.Models;

namespace Cbiz.PreAutoBilling.Infrastructure.Services
{
    public class BillingEmailService : IBillingEmailService
    {
        private readonly IEmailService _emailService;
        private readonly ITemplateService _templateService;
        private const string BillingTemplateFile = "BillingEmail";

        public BillingEmailService(
            IEmailService emailService,
            ITemplateService templateService)
        {
            _emailService = emailService;
            _templateService = templateService;
        }

        public async Task SendBillingEmailsAsync(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                await SendBillingEmailAsync(customer);
            }
        }

        public async Task SendBillingEmailAsync(Customer customer)
        {
            var emailBody = await _templateService.RenderTemplateAsync(
                BillingTemplateFile, 
                new { customer.FirstName, customer.LastName, customer.Email }
            );

            await _emailService.SendEmailAsync(
                customer.Email,
                "Your Billing Information",
                emailBody);
        }
    }
} 