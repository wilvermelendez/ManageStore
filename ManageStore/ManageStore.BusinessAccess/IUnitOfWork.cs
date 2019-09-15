using ManageStore.BusinessAccess.Repositories;
using System;
using System.Threading.Tasks;

namespace ManageStore.BusinessAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        Task<int> Complete();

    }
}
