using OrderFlow.API.Models;
using OrderFlow.API.DTOs;
using OrderFlow.API.Services.Implementations;
namespace OrderFlow.API.Services.Interfaces
{
    public interface IProductService
    {
        Task<int> CreateProductAsync(ProductDto ProductDto, int OwnerId);
        Task<List<ProductDto>>GetAllProductsAsync();
        Task<ProductDto?> GetProductByIdAsync(int id);

        Task<ProductDto?> UpdateProductByIdAsync(int id, ProductDto ProductDto);

        Task<bool> DeleteProductByIdAsync(int id);
    }
}
