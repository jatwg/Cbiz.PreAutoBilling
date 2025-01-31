using Cbiz.PreAutoBilling.Core.Interfaces.Data;
using Cbiz.PreAutoBilling.Core.Models;
using Cbiz.PreAutoBilling.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Cbiz.PreAutoBilling.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            return await _dbContext.Customers.FindAsync(id);
        }
    }
} 