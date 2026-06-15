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

        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductDto dto)
        {
            var result = await _service.AddProductAsync(dto);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllProductAsync();
            return Ok(result);
        }


    }
}
