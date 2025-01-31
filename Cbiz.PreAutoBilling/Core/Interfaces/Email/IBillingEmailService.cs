using Cbiz.PreAutoBilling.Core.Models;

namespace Cbiz.PreAutoBilling.Core.Interfaces.Email
{
    public interface IBillingEmailService
    {
        Task SendBillingEmailsAsync(IEnumerable<Customer> customers);
        Task SendBillingEmailAsync(Customer customer);
    }
} 