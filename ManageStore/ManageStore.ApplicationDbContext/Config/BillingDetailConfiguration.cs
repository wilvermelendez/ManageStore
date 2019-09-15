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

            producBuilder.HasOne(x => x.Billing)
                .WithMany()
                .HasForeignKey(x => x.BillingId);
            producBuilder.HasOne(x => x.Product);
            producBuilder.HasOne(x => x.CreatedBy);
            producBuilder.HasOne(x => x.ModifiedBy);

            producBuilder.Property(x => x.Quantity).IsRequired();
            producBuilder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,4)");
        }
    }
}
