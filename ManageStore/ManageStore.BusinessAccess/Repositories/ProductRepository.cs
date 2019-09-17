using ManageStore.Models.Enum;
using ManageStore.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await GetByExpression(x => x.RegisterStatus == RegisterStatus.Enabled)
                .Include(x => x.CreatedBy)
                .Include(x => x.ModifiedBy)
                .ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetProductsOrderedByAsync(string name)
        {
            var products = await GetByExpression(x => x.RegisterStatus == RegisterStatus.Enabled)
                .Include(x => x.CreatedBy)
                .Include(x => x.ModifiedBy)
                .Include(x => x.ProductLikes)
                .ToListAsync();
            //TODO is pending to order by popularity
            var result = name == "name"
                ? products.OrderBy(x => x.Name)
                : products.OrderByDescending(x => x.ProductLikes.Count());

            return result;
        }
    }
}
