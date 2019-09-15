using ManageStore.Models.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace ManageStore.Models.Models
{
    /// <summary>
    /// A product with Id, Name, Description, RegisterStatus, CreatedDateTime, CreatedBy, ModifieDateTime, ModifiedBy
    /// </summary>
    public class Product
    {
        /// <summary>
        /// The id of the product
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// The name of the product
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The description of the product
        /// </summary>
        public string Description { get; set; }
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
        /// <summary>
        /// Automatic generated modified Datetime when a product is modified
        /// </summary>
        public DateTime ModifieDateTime { get; set; }
        /// <summary>
        /// Automatic generated Modified user id when a product is modified
        /// </summary>
        public User ModifiedBy { get; set; }
    }
}
