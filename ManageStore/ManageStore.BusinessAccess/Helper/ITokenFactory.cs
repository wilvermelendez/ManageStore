using ManageStore.Models.Enum;

namespace ManageStore.BusinessAccess.Helper
{
    public interface ITokenFactory
    {
        string UserIdClaim { get; }
        string RoleClaim { get; }
        string GenerateToken(string userId, UserRole role);
        string GetUser();
        string GetRole();
    }
}