using ManageStore.BusinessAccess.Repositories;
using System.Threading.Tasks;

namespace ManageStore.BusinessAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext.ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext.ApplicationDbContext context, IProductLogRepository productLogs, IBillingRepository billings, IProductRepository products, IUserRepository users)
        {
            _context = context;
            ProductLogs = productLogs;
            Billings = billings;
            Products = products;
            Users = users;
        }


        public IProductRepository Products { get; }
        public IProductLogRepository ProductLogs { get; }
        public IBillingRepository Billings { get; }
        public IUserRepository Users { get; }

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
