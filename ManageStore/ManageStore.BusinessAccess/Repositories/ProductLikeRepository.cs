using ManageStore.Models.Models;

namespace ManageStore.BusinessAccess.Repositories
{
    public class ProductLikeRepository : BaseRepository<ProductLike>, IProductLikeRepository
    {
        public ProductLikeRepository(ApplicationDbContext.ApplicationDbContext context) : base(context)
        {

        }


    }
}
