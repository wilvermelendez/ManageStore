namespace ManageStore.Models.DTO
{
    /// <summary>
    /// A product with ProductId and UserId
    /// </summary>
    public class ProductLikeDto
    {
        /// <summary>
        /// The id of the product liked
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// The id of the User who likes this product
        /// </summary>
        public int UserId { get; set; }
    }
}
