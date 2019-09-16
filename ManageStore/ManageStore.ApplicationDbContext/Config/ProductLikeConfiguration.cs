using ManageStore.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManageStore.ApplicationDbContext.Config
{
    public class ProductLikeConfiguration : IEntityTypeConfiguration<ProductLike>
    {
        public void Configure(EntityTypeBuilder<ProductLike> producBuilder)
        {
            producBuilder.HasKey(x => new { x.ProductId, x.UserId });
            producBuilder.HasOne(x => x.Product);
            producBuilder.HasOne(x => x.User);

        }
    }
}
