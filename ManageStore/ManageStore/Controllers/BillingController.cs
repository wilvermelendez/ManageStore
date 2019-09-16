using AutoMapper;
using ManageStore.BusinessAccess;
using ManageStore.Models.DTO;
using ManageStore.Models.Enum;
using ManageStore.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor that required Unit of Work dependency injection
        /// </summary>
        /// <param name="unitOfWork">Unit of work pattern</param>
        /// <param name="mapper"></param>
        public BillingController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Get one Bill by voucher number
        /// </summary>
        /// /// <param name="voucherNumber">String voucher param</param>
        /// <returns>Bill if it exists</returns>
        [HttpGet]
        [Route("GetBillByVoucherNumber/{voucherNumber}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetBillById(string voucherNumber)
        {
            var bill = await _unitOfWork.Billings.GetByVoucherNumberAsync(voucherNumber);
            if (bill == null)
                return NotFound($"Bill with voucher number: {voucherNumber} not found.");
            var billDto = _mapper.Map<BillingDto>(bill);
            return Ok(billDto);

        }

        /// <summary>
        /// Get bills
        /// </summary>
        /// <returns>List of bills</returns>
        [HttpGet]
        [Route("GetBills")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetBills()
        {
            var bills = await _unitOfWork.Billings.GetBillsAsync();
            var billsDto = _mapper.Map<IEnumerable<BillingDto>>(bills);
            return Ok(billsDto);

        }

        /// <summary>
        /// Add a new product like with fields productId and userId
        /// </summary>
        /// <param name="billingDto"></param>
        /// <returns>Return ok if it was possible to save the product like</returns>
        [HttpPost]
        [Route("AddBill")]
        [Authorize]
        public async Task<IActionResult> AddBill([FromBody]BillingDto billingDto)
        {
            //verifying if product and user exists on database
            var existingBilling = await _unitOfWork.Billings.GetByVoucherNumberAsync(billingDto.VoucherNumber);
            if (existingBilling != null)
                return BadRequest($"Bill with Id: {billingDto.VoucherNumber} is already saved.");
            var user = await _unitOfWork.Users.GetAsync(1);

            //mapping BillingDto to Billing
            var bill = _mapper.Map<Billing>(billingDto);

            bill.CreatedDateTime = DateTime.Now;
            bill.CreatedBy = user;
            bill.RegisterStatus = RegisterStatus.Enabled;
            var billDetail = new List<BillingDetail>();
            foreach (var item in bill.BillingDetails)
            {
                var product = await _unitOfWork.Products.GetAsync(item.ProductId);
                item.Product = product;
                product.Stock -= item.Quantity;
                billDetail.Add(item);

                if (product.Stock < 0)
                    return BadRequest($"The product: {product.Name} has not enough stock.");
            }

            bill.BillingDetails = billDetail;
            //Adding bill
            if (!bill.BillingDetails.Any())
                return BadRequest($"Bill does not contain valid products.");
            _unitOfWork.Billings.Add(bill);
            await _unitOfWork.Complete();
            return Ok();
        }
    }
}