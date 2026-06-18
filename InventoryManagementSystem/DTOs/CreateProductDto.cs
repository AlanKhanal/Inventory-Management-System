using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.DTOs
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set;}
        [Range(1,100000)]
        public decimal Price {  get; set;}
        [Range(0, 100000)]
        public int Stock { get; set; }
    }
}
