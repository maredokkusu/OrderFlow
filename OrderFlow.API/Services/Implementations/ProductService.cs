using OrderFlow.API.DTOs;
using OrderFlow.API.Models;
using OrderFlow.API.Services.Interfaces;
using OrderFlow.API.Data;
using Microsoft.EntityFrameworkCore;
namespace OrderFlow.API.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            {
                _context = context;
            }
        }
            public async Task<int > CreateProductAsync(ProductDto productDto,int OwnerId) {
            var product = new Product
            {
                ProductName = productDto.ProductName,
                Description = productDto.Description,
                OwnerId=productDto.OwnerId,
                Price= productDto.Price,
                Stock= productDto.Stock,
                ProductCategory = productDto.ProductCategory, 
                ProductType = productDto.ProductType,

            };
        _context.Products.Add( product );
            await _context.SaveChangesAsync();
               return product.Id;

        }
        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            return await _context.Products.Select(p=>new ProductDto { Id=p.Id,
                ProductName=p.ProductName,
                Description=p.Description,
                Price=p.Price,
                Stock=p.Stock,
                ProductCategory=p.ProductCategory,
                ProductType=p.ProductType,
            }).ToListAsync();
        }
        public async Task<ProductDto?> GetProductByIdAsync(int id) {
            var product = await _context.Products.FindAsync(id);
        if (product == null) {return null;}
            return new ProductDto
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                ProductCategory = product.ProductCategory,
                ProductType = product.ProductType,
            };
        }
        public async Task<ProductDto?> UpdateProductByIdAsync(int id, ProductDto productDto)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return null;
            product.ProductName = productDto.ProductName;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.Stock = productDto.Stock;
            product.ProductCategory = productDto.ProductCategory;
            product.ProductType = productDto.ProductType;

            await _context.SaveChangesAsync();
            return new ProductDto
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                ProductCategory = product.ProductCategory,
                ProductType = product.ProductType
            };
        }
        public async Task<bool> DeleteProductByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
