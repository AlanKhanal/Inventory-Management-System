using InventoryManagementSystem.DTOs;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services.Interface
{
    public interface IProductService
    {
        Task<Product> AddProductAsync(CreateProductDto dto);
        Task<List<Product>> GetAllProductAsync();

        Task<Product> GetByIdAsync(int id);
        Task<Product> UpdateProductASync(int id, CreateProductDto dto);
        Task<bool> DeleteProductAsync(int id);
    }
}
