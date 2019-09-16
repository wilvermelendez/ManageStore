using ManageStore.BusinessAccess.Repositories;
using System;
using System.Threading.Tasks;

namespace ManageStore.BusinessAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IProductLogRepository ProductLogs { get; }
        IBillingRepository Billings { get; }
        IUserRepository Users { get; }
        Task<int> Complete();

    }
}
