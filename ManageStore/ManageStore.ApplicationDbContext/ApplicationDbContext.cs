using ManageStore.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace ManageStore.ApplicationDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Billing> Billing { get; set; }
        public DbSet<ProductLog> ProductLogs { get; set; }
        public DbSet<User> Users { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }
    }
}
