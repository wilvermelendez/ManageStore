using ManageStore.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManageStore.ApplicationDbContext.Config
{
    public class ProductLogConfiguration : IEntityTypeConfiguration<ProductLog>
    {
        public void Configure(EntityTypeBuilder<ProductLog> producBuilder)
        {
            producBuilder.HasKey(x => x.Id);
            producBuilder.Property(x => x.Id).ValueGeneratedOnAdd();

            producBuilder.HasOne(x => x.Product);
            producBuilder.HasOne(x => x.CreatedBy);
            producBuilder.HasOne(x => x.ModifiedBy);

            producBuilder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,4)");
            producBuilder.Property(x => x.NewPrice).IsRequired().HasColumnType("decimal(18,4)");

        }
    }
}
