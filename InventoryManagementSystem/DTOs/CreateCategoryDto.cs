using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.DTOs
{
    public class CreateCategoryDto
    {
        [Required]
        public string Name {  get; set; }
    }
}
