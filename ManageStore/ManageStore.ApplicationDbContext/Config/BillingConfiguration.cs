using ManageStore.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManageStore.ApplicationDbContext.Config
{
    public class BillingConfiguration : IEntityTypeConfiguration<Billing>
    {
        public void Configure(EntityTypeBuilder<Billing> producBuilder)
        {
            producBuilder.HasKey(x => x.Id);
            producBuilder.Property(x => x.Id).ValueGeneratedOnAdd();

            producBuilder.HasOne(x => x.CreatedBy);
            producBuilder.HasOne(x => x.ModifiedBy);

            producBuilder.Property(x => x.CustomerName).HasMaxLength(80);
            producBuilder.Property(x => x.CustomerName).IsRequired();
            producBuilder.Property(x => x.CustomerLastName).HasMaxLength(80);
            producBuilder.Property(x => x.CustomerLastName).IsRequired();
        }
    }
}
