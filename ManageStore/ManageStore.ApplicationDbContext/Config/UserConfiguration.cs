using ManageStore.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManageStore.ApplicationDbContext.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> userBuilder)
        {
            userBuilder.HasKey(x => x.Id);
            userBuilder.Property(x => x.Id).ValueGeneratedOnAdd();

            userBuilder.HasOne(x => x.CreatedBy);
            userBuilder.HasOne(x => x.ModifiedBy);

            userBuilder.Property(x => x.Name).HasMaxLength(80);
            userBuilder.Property(x => x.Name).IsRequired();
            userBuilder.Property(x => x.LastName).HasMaxLength(80);
            userBuilder.Property(x => x.LastName).IsRequired();
            userBuilder.Property(x => x.Email).HasMaxLength(150);
            userBuilder.Property(x => x.Email).IsRequired();




        }
    }
}
