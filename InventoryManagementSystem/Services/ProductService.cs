using InventoryManagementSystem.Data;
using InventoryManagementSystem.DTOs;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context=context;
        }
        public async Task<Product> AddProductAsync(CreateProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock,
                CreatedAt = DateTime.Now,
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if(product == null) {
                return false;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Product>> GetAllProductAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> UpdateProductASync(int id, CreateProductDto dto)
        {
            var product = await _context.Products.FindAsync(id);
            if(product == null)
            {
                return null;
            }
            product.Name=dto.Name;
            product.Price=dto.Price;
            product.Stock=dto.Stock;

            await _context.SaveChangesAsync();
            return product;
        }
    }
}
