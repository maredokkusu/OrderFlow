using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderFlow.API.DTOs;
using OrderFlow.API.Models;
using OrderFlow.API.Services.Interfaces;
using System.Security.Claims;
namespace OrderFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService) { _productService = productService; }
    [Authorize]
    [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto) {

            var userIdFromToken = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var ProductId = await _productService.CreateProductAsync(productDto, userIdFromToken);
            return CreatedAtAction(nameof(GetProductById), new { id = ProductId }, null);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts(int id)
        {
            var products = await _productService.GetProductByIdAsync(id);
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) { return NotFound(); }
            return Ok(product);
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id,[FromBody] ProductDto productdto)
        {
            var userIdFromToken = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var product = await _productService.GetProductByIdAsync(id);
            if (product==null)return NotFound();
            if (product.OwnerId != userIdFromToken) {
                return Forbid("YOU AREN´T THE OWNER YOU CAN'T UPDATE THIS PRODUCT");
            };
            var updated = await _productService.UpdateProductByIdAsync(id, productdto);
            return NoContent();

        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct( int id ) {
            var userIdFromToken = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var product = await _productService.GetProductByIdAsync(id);
            if (product==null) return NotFound();
            if (userIdFromToken != product.OwnerId)
            {
                return Forbid("YOU AREN´T THE OWNER YOU CAN´T DELETE THIS PRODUCT");
            }
            var deleted = await _productService.DeleteProductByIdAsync(id);
            if (!deleted) { return NotFound(); };
            return NoContent();
        }
    } 
}
