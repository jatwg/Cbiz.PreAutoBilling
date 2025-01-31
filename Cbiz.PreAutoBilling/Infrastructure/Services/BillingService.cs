using Cbiz.PreAutoBilling.Core.Interfaces.Services;
using Cbiz.PreAutoBilling.Core.Interfaces.Data;
using Cbiz.PreAutoBilling.Core.Interfaces.Email;

namespace Cbiz.PreAutoBilling.Infrastructure.Services
{
    public class BillingService : IBillingService
    {
        private readonly ICustomerService _customerService;
        private readonly IBillingEmailService _billingEmailService;

        public BillingService(
            ICustomerService customerService,
            IBillingEmailService billingEmailService)
        {
            _customerService = customerService;
            _billingEmailService = billingEmailService;
        }

        public async Task ProcessBillingEmailsAsync()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            await _billingEmailService.SendBillingEmailsAsync(customers);
        }
    }
} 