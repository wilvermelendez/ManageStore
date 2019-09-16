using System;
using System.ComponentModel.DataAnnotations;

namespace ManageStore.Models.Models
{
    public class ProductLike
    {
        [Key]
        public Product Product { get; set; }
        public int ProductId { get; set; }

        [Key]
        public User User { get; set; }
        public int UserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

    }
}
