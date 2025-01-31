using Cbiz.PreAutoBilling.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Cbiz.PreAutoBilling.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; } = null!;
    }
} 