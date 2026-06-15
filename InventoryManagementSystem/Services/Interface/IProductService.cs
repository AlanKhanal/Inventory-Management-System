using InventoryManagementSystem.DTOs;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services.Interface
{
    public interface IProductService
    {
        Task<Product> AddProductAsync(CreateProductDto dto);
        Task<List<Product>> GetAllProductAsync();
    }
}
