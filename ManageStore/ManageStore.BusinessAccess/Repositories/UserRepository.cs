using ManageStore.Models.Models;
using System.Threading.Tasks;

namespace ManageStore.BusinessAccess.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext.ApplicationDbContext context) : base(context)
        {

        }


        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await SingleOrDefaultAsync(x => x.UserName == userName);
        }
        public async Task<User> FindByCredentials(string userName, string password)
        {
            return await SingleOrDefaultAsync(p => p.UserName == userName && p.Password == password);
        }
    }
}
