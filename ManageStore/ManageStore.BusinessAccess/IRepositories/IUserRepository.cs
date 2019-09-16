using ManageStore.Models.Models;
using System.Threading.Tasks;

namespace ManageStore.BusinessAccess.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByUserNameAsync(string name);
        Task<User> FindByCredentials(string userName, string password);
    }
}