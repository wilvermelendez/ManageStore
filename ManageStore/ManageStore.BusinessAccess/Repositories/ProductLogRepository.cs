using ManageStore.Models.Models;

namespace ManageStore.BusinessAccess.Repositories
{
    public class ProductLogRepository : BaseRepository<ProductLog>, IProductLogRepository
    {
        public ProductLogRepository(ApplicationDbContext.ApplicationDbContext context) : base(context)
        {

        }


    }
}
