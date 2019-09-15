using System;
using System.Threading.Tasks;

namespace ManageStore.BusinessAccess
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Complete();

    }
}
