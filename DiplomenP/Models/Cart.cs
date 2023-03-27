using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomenP.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CustomerId { get; set; }

        [InverseProperty("Cart")]
        public virtual ICollection<CartItem> CartItems { get; set; }

        [ForeignKey("CustomerId")]
        public string UserId { get; set; }
        public virtual User Customer { get; set; }
    }


}
