using Microsoft.AspNetCore.Mvc;
using OrderFlow.API.DTOs;
using OrderFlow.API.Models;
using OrderFlow.API.Services.Interfaces;
namespace OrderFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService) { _productService = productService; }
    
    [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto) {
            var ProductId = await _productService.CreateProductAsync(productDto);
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
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id,[FromBody] ProductDto productdto)
        {
            var updated = await _productService.UpdateProductByIdAsync(id, productdto);
            if (updated==null) { return NotFound(); };
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct( int id ) {
            var deleted = await _productService.DeleteProductByIdAsync(id);
            if (!deleted) { return NotFound(); };
            return NoContent();
        }
    } 
}
