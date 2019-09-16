using ManageStore.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManageStore.ApplicationDbContext.Config
{
    public class BillingDetailConfiguration : IEntityTypeConfiguration<BillingDetail>
    {
        public void Configure(EntityTypeBuilder<BillingDetail> producBuilder)
        {
            producBuilder.HasKey(x => x.Id);
            producBuilder.Property(x => x.Id).ValueGeneratedOnAdd();

            producBuilder.HasOne(x => x.Billing);
            producBuilder.HasOne(x => x.Product);
            producBuilder.Property(x => x.Quantity).IsRequired();
            producBuilder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,4)");
        }
    }
}
