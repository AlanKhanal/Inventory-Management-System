using InventoryManagementSystem.DTOs;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services.Interface;

namespace InventoryManagementSystem.Services
{
    public class CategoryService : ICategoryService
    {
        public Task<Category> AddCategoryAsync(CreateCategoryDto category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> UpdateCategoryAsync(int id, CreateCategoryDto category)
        {
            throw new NotImplementedException();
        }
    }
}
