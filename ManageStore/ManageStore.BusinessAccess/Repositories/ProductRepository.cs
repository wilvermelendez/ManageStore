using ManageStore.Models.Models;

namespace ManageStore.BusinessAccess.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext.ApplicationDbContext context) : base(context)
        {

        }
    }
}
