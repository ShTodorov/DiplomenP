using System.ComponentModel.DataAnnotations;

namespace DiplomenP.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Името на продукта е задължително")]
        [StringLength(50, ErrorMessage = "Името на продукта не може да бъде по-дълго от 50 символа")]
        public string ProductName { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price is required")]
        [Range(0, 1000000, ErrorMessage = "Price must be between 0 and 1000000")]
        public double Price { get; set; }

        [Display(Name = "Type")]
        [Required(ErrorMessage = "Type is required")]
        [StringLength(50, ErrorMessage = "Type cannot be longer than 50 characters")]
        public string Type { get; set; }

        [Display(Name = "Product Count")]
        [Required(ErrorMessage = "Product count is required")]
        [Range(0, 999, ErrorMessage = "Product count must be between 0 and 999")]
        public int ProductCount { get; set; }

        [Display(Name = "Image")]
        public byte[] Image { get; set; }

        [Display(Name = "Description")]
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters")]
        public string Description { get; set; }

        [Display(Name = "Brand")]
        [StringLength(50, ErrorMessage = "Brand cannot be longer than 50 characters")]
        public string Brand { get; set; }

        [Display(Name = "SKU")]
        [StringLength(50, ErrorMessage = "SKU cannot be longer than 50 characters")]
        public string SKU { get; set; }
    }

}
