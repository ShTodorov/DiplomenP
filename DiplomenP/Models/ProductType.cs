using System.ComponentModel.DataAnnotations;

namespace DiplomenP.Models
{
    public class ProductType
    {
        public int ProductTypeId { get; set; }

        [Required(ErrorMessage = "Product type name is required")]
        [StringLength(50, ErrorMessage = "Product type name cannot be longer than 50 characters")]
        public string Name { get; set; }
    }
}
