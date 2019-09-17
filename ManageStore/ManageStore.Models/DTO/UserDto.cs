using ManageStore.Models.Enum;

namespace ManageStore.Models.DTO
{
    /// <summary>
    /// User with Name, LastName, UserName, Password and UserRole
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Name of the owner of the account
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Last Name of the owner of the account
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// UserName of the owner of the account
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Password of the owner of the account
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Name of the owner of the account, 1 is Admin and 2 is User
        /// </summary>
        public UserRole UserRole { get; set; }
    }
}
