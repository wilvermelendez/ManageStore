using ManageStore.Models.Enum;
using ManageStore.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageStore.BusinessAccess.Repositories
{
    public class BillingRepository : BaseRepository<Billing>, IBillingRepository
    {
        public BillingRepository(ApplicationDbContext.ApplicationDbContext context) : base(context)
        {

        }


        public async Task<Billing> GetByVoucherNumberAsync(string voucherNumber)
        {
            return await GetByExpression(x => x.VoucherNumber == voucherNumber)
                .Include(x => x.BillingDetails)
                .LastOrDefaultAsync();
        }
        public async Task<IEnumerable<Billing>> GetBillsAsync()
        {
            return await GetByExpression(x => x.RegisterStatus == RegisterStatus.Enabled)
                .Include(x => x.BillingDetails)
                .ToListAsync();
        }
    }
}
