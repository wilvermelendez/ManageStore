using ManageStore.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageStore.BusinessAccess.Repositories
{
    public interface IBillingRepository : IBaseRepository<Billing>
    {
        Task<Billing> GetByVoucherNumberAsync(string voucherNumber);
        Task<IEnumerable<Billing>> GetBillsAsync();
    }
}