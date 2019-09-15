using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ManageStore.Models.Enum;

namespace ManageStore.Models.Models
{
    /// <summary>
    /// A billing With: Id
    /// </summary>
    public class Billing
    {
        /// <summary>
        /// The id of the product
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// The name of the product
        /// </summary>
        public Product Product { get; set; }
        /// <summary>
        /// The product that has changed it price.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// The name of the buyer
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The lastname of the buyer
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// The product quantity for the bill
        /// </summary>
        public double Quantity { get; set; }
        /// <summary>
        /// The product price for the bill
        /// </summary>
        public decimal Price { get; set; }
      
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
