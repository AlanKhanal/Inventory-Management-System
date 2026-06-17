using InventoryManagementSystem.DTOs;
using InventoryManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }


        //Create
        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductDto dto)
        {
            var result = await _service.AddProductAsync(dto);
            return Ok(result);
        }

        //Read
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllProductAsync();
            return Ok(result);
        }


        //Update
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, CreateProductDto dto)
        {
            var product = await _service.UpdateProductASync(id,dto);
            if(product == null)
            {
                return NotFound($"Product with Id{id} not found.");

            }
            return Ok(product); 
        }


        //Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deleted = await _service .DeleteProductAsync(id);
            if(!deleted)
            {
                return NotFound($"Product with Id {id} not found");
            }
            return NoContent();
        }

    }
}
