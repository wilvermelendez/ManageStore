using ManageStore.Models.Models;
using System.Threading.Tasks;

namespace ManageStore.BusinessAccess.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product> GetByNameAsync(string name);
    }
}