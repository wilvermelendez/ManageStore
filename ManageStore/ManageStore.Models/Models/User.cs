using ManageStore.Models.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace ManageStore.Models.Models
{
    public class User
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; }

        public RegisterStatus RegisterStatus { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public User CreatedBy { get; set; }
        public DateTime? ModifieDateTime { get; set; }
        public User ModifiedBy { get; set; }
    }
}