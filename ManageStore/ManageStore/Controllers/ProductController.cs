using AutoMapper;
using ManageStore.BusinessAccess;
using ManageStore.Models.DTO;
using ManageStore.Models.Enum;
using ManageStore.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageStore.Controllers
{

    /// <summary>
    /// Controller API that represent information about products
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor that required Unit of Work dependency injection
        /// </summary>
        /// <param name="unitOfWork">Unit of work pattern</param>
        /// <param name="mapper"></param>
        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        /// <summary>
        /// Get all enabled products
        /// </summary>
        /// <returns>List of Products</returns>
        [HttpGet]
        [Route("GetProducts")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProductsAsync()
        {
            var products = await _unitOfWork.Products.GetProductsAsync();
            var productDto = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productDto);

        }

        /// <summary>
        /// Get all products ordered by name or popularity
        /// </summary>
        /// <param name="orderBy">Set order by "name" or "popularity"</param>
        /// <returns>List of Products</returns>
        [HttpGet]
        [Route("GetProductsOrderedBy")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProductsOrderedByAsync(string orderBy)
        {
            var products = await _unitOfWork.Products.GetProductsOrderedByAsync(orderBy);
            var productDto = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productDto);

        }

        /// <summary>
        /// Get one product searching by it name
        /// </summary>
        /// <param name="name">Product Name</param>
        /// <returns>Return the product if it exists, if not it return not found</returns>
        [HttpGet]
        [Route("GetByName")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByNameAsync(string name)
        {

            var products = await _unitOfWork.Products.GetByNameAsync(name);
            if (products == null)
                return NotFound($"Product with Name: {name} not found.");
            var productDto = _mapper.Map<ProductDto>(products);

            return Ok(productDto);
        }
        /// <summary>
        /// Add a new product with fields Name, description, InitialStock, price
        /// </summary>
        /// <param name="productDto"></param>
        /// <returns>Return ok if it was possible to save the product</returns>
        [HttpPost]
        [Route("AddProduct")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PostAsync([FromBody]ProductDto productDto)
        {
            var existingProduct = await _unitOfWork.Products.GetByNameAsync(productDto.Name);
            if (existingProduct != null)
                return BadRequest("Error: the product is registered");
            var product = _mapper.Map<Product>(productDto);
            product.CreatedDateTime = DateTime.Now;
            product.RegisterStatus = RegisterStatus.Enabled;
            product.CreatedBy = await _unitOfWork.Users.GetAsync(1);
            _unitOfWork.Products.Add(product);
            await _unitOfWork.Complete();
            return Ok();
        }
        /// <summary>
        /// Delete a existent product
        /// </summary>
        /// <param name="id">Int id of existing product</param>
        /// <returns>IAction Result Ok if is possible to delete</returns>
        [HttpDelete]
        [Route("DeleteProduct")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var product = await _unitOfWork.Products.GetAsync(id);
            if (product == null)
                return NotFound($"Product with Id: {id} not found.");

            _unitOfWork.Products.Remove(product);
            await _unitOfWork.Complete();
            return Ok();
        }


        /// <summary>
        /// Update product stock
        /// </summary>
        /// <param name="productDto">Is required product Id and Stock</param>
        /// <returns>IAction Result Ok if is possible to update</returns>
        [HttpPatch]
        [Route("UpdateStock")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStockAsync([FromBody]ProductDto productDto)
        {

            var existingProduct = await _unitOfWork.Products.GetAsync(productDto.Id);
            if (existingProduct == null)
                return NotFound($"Product with Id: {productDto.Id} not found.");
            existingProduct.Stock = productDto.Stock;
            existingProduct.ModifieDateTime = DateTime.Now;
            existingProduct.ModifiedBy = await _unitOfWork.Users.GetAsync(1);
            await _unitOfWork.Complete();
            return Ok();
        }

        /// <summary>
        /// Update product price and log the price change
        /// </summary>
        /// <param name="productDto">Is required product Id and price</param>
        /// <returns>IAction Result Ok if is possible to update</returns>
        [HttpPatch]
        [Route("UpdatePrice")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePriceAsync([FromBody]ProductDto productDto)
        {
            var existingProduct = await _unitOfWork.Products.GetAsync(productDto.Id);
            if (existingProduct == null)
                return NotFound($"Product with Id: {productDto.Id} not found.");
            //obtaining logged user
            var loggedUser = await _unitOfWork.Users.GetAsync(1);
            //preparing product log instance
            var productLog = _mapper.Map<ProductLog>(existingProduct);
            productLog.NewPrice = productDto.Price;
            productLog.Id = 0;
            productLog.CreatedDateTime = DateTime.Now;
            productLog.CreatedBy = loggedUser;
            productLog.ModifieDateTime = null;
            productLog.ModifiedBy = null;
            productLog.Product = existingProduct;
            productLog.ProductId = existingProduct.Id;

            existingProduct.Price = productDto.Price;
            existingProduct.ModifieDateTime = DateTime.Now;
            existingProduct.ModifiedBy = loggedUser;
            //add product log
            _unitOfWork.ProductLogs.Add(productLog);
            await _unitOfWork.Complete();
            return Ok();
        }

        /// <summary>
        /// Add a new product like with fields productId and userId
        /// </summary>
        /// <param name="productLikeDto">Is required a productId and userId</param>
        /// <returns>Return ok if it was possible to save the product like</returns>
        [HttpPost]
        [Route("ProductLike")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> ProductLikeAsync([FromBody]ProductLikeDto productLikeDto)
        {
            //verifying if product and user exists on database
            var existingProduct = await _unitOfWork.Products.GetAsync(productLikeDto.ProductId);
            if (existingProduct == null)
                return NotFound($"Product with Id: {productLikeDto.ProductId} not found.");
            var user = await _unitOfWork.Users.GetAsync(productLikeDto.UserId);
            if (user == null)
                return NotFound($"User with Id: {productLikeDto.UserId} not found.");
            //mapping productLikeDto to ProductLike
            var productLike = _mapper.Map<ProductLike>(productLikeDto);
            productLike.Product = existingProduct;
            productLike.User = user;
            productLike.CreatedDateTime = DateTime.Now;
            //Adding product like
            _unitOfWork.ProductLikes.Add(productLike);
            await _unitOfWork.Complete();
            return Ok();
        }
    }
}