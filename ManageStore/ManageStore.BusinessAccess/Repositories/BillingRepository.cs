using ManageStore.Models.Models;

namespace ManageStore.BusinessAccess.Repositories
{
    public class BillingRepository : BaseRepository<Billing>, IBillingRepository
    {
        public BillingRepository(ApplicationDbContext.ApplicationDbContext context) : base(context)
        {

        }


    }
}
