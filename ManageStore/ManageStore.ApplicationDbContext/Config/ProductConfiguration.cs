using ManageStore.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManageStore.ApplicationDbContext.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> producBuilder)
        {
            producBuilder.HasKey(x => x.Id);
            producBuilder.Property(x => x.Id).ValueGeneratedOnAdd();

            producBuilder.HasOne(x => x.CreatedBy);
            producBuilder.HasOne(x => x.ModifiedBy);

            producBuilder.Property(x => x.Name).HasMaxLength(80);
            producBuilder.Property(x => x.Name).IsRequired();
            producBuilder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,4)");
            producBuilder.Property(x => x.Description).HasMaxLength(150);

        }
    }
}
