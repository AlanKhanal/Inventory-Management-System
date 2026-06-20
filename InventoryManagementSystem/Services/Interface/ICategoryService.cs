using InventoryManagementSystem.DTOs;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services.Interface
{
    public interface ICategoryService
    {
        Task<Category> GetByIdAsync(string id);
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category> AddCategoryAsync(CreateCategoryDto category);
        Task<Category> UpdateCategoryAsync(int id, CreateCategoryDto category); 
        Task<bool> DeleteCategoryAsync(int id);
    }
}
