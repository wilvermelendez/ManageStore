namespace ManageStore.Models.Models
{
    /// <summary>
    /// Detail of the billing, list of products with price and quantity 
    /// </summary>
    public class BillingDetailDto
    {
        /// <summary>
        /// The id of the product
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the product
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
