using ManageStore.Models.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace ManageStore.Models.Models
{
    public class ProductLog
    {
        /// <summary>
        /// The id of the productLog
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// The product that has changed it price.
        /// </summary>
        public Product Product { get; set; }
        /// <summary>
        /// The product that has changed it price.
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// The price of the product
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// The new price of the product
        /// </summary>
        public decimal NewPrice { get; set; }
        /// <summary>
        /// The status according to the called actions
        /// </summary>
        public RegisterStatus RegisterStatus { get; set; }
        /// <summary>
        /// Automatic generated creation Datetime when a product is created
        /// </summary>
        public DateTime CreatedDateTime { get; set; }
        /// <summary>
        /// Automatic generated creation user id when a product is created
        /// </summary>
        public User CreatedBy { get; set; }
    }
}
