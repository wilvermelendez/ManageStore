using ManageStore.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        /// The billing Voucher Number
        /// </summary>
        public string VoucherNumber { get; set; }

        /// <summary>
        /// The billing receipt type
        /// </summary>
        public ReceiptType ReceiptType { get; set; }

        /// <summary>
        /// The name of the buyer
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// The lastname of the buyer
        /// </summary>
        public string CustomerLastName { get; set; }

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
        /// Automatic generated Modified datetime when a product is modified
        /// </summary>
        public DateTime? ModifieDateTime { get; set; }
        /// <summary>
        /// Automatic generated Modified user id when a product is modified
        /// </summary>
        public User ModifiedBy { get; set; }

        public IEnumerable<BillingDetail> BillingDetails { get; set; }

    }
}
