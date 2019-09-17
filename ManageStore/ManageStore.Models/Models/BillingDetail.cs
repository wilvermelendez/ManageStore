using System.ComponentModel.DataAnnotations;

namespace ManageStore.Models.Models
{
    /// <summary>
    /// Detail of the billing, list of products with price and quantity 
    /// </summary>
    public class BillingDetail
    {
        /// <summary>
        /// The id of the product
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// The billing parent
        /// </summary>
        public Billing Billing { get; set; }
        /// <summary>
        /// The billing parent id
        /// </summary>
        public int BillingId { get; set; }
        /// <summary>
        /// The name of the product
        /// </summary>
        public Product Product { get; set; }
        /// <summary>
        /// The product that has changed it price.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// The product quantity for the bill
        /// </summary>
        public double Quantity { get; set; }
        /// <summary>
        /// The product price for the bill
        /// </summary>
        public decimal Price { get; set; }


    }
}
