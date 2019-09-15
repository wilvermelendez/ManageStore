using ManageStore.BusinessAccess.Repositories;
using System.Threading.Tasks;

namespace ManageStore.BusinessAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext.ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext.ApplicationDbContext context)
        {
            _context = context;
            Products = new ProductRepository(context);
        }


        public IProductRepository Products { get; }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
