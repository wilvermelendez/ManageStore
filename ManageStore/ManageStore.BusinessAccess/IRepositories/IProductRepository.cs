using ManageStore.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageStore.BusinessAccess.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product> GetByNameAsync(string name);
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<IEnumerable<Product>> GetProductsOrderedByAsync(string name);
    }
}