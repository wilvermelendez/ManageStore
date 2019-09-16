using ManageStore.Models.Models;

namespace ManageStore.BusinessAccess.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext.ApplicationDbContext context) : base(context)
        {

        }


    }
}
