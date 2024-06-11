using Microsoft.EntityFrameworkCore;
using pr3_tradecompany_aspnet_mvc.Models.Enitites;

namespace pr3_tradecompany_aspnet_mvc.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
