using Cbiz.PreAutoBilling.Core.Models;

namespace Cbiz.PreAutoBilling.Core.Interfaces.Data
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer?> GetCustomerByIdAsync(int id);
    }
} 