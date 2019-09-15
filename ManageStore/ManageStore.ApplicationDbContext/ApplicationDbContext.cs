using ManageStore.ApplicationDbContext.Config;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BillingConfiguration());
            modelBuilder.ApplyConfiguration(new BillingDetailConfiguration());
            modelBuilder.ApplyConfiguration(new ProductLogConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
