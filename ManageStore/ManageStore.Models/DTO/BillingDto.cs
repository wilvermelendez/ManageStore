using ManageStore.Models.Models;
using System;
using System.Collections.Generic;

namespace ManageStore.Models.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class BillingDto
    {/// <summary>
     /// The id of the product
     /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The billing Voucher Number
        /// </summary>
        public string VoucherNumber { get; set; }

        /// <summary>
        /// The billing receipt type: Invoice = 1 and FiscalCredit = 2
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
        /// Automatic generated creation Datetime when a product is created
        /// </summary>
        public DateTime CreatedDateTime { get; set; }
        /// <summary>
        /// Automatic generated creation user id when a product is created
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Automatic generated modified Datetime when a product is modified
        /// </summary>
        public DateTime? ModifieDateTime { get; set; }
        /// <summary>
        /// Automatic generated Modified user id when a product is modified
        /// </summary>
        public string ModifiedBy { get; set; }


        public IEnumerable<BillingDetailDto> BillingDetails { get; set; }
    }
}
