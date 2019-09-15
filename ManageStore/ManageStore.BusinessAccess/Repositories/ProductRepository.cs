using ManageStore.Models.Models;
using System.Threading.Tasks;

namespace ManageStore.BusinessAccess.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext.ApplicationDbContext context) : base(context)
        {

        }

        public async Task<Product> GetByNameAsync(string name)
        {
            return await SingleOrDefaultAsync(x => x.Name == name);
        }

    }
}
