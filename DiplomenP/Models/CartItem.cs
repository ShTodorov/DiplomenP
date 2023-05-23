using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace DiplomenP.Models
{
    public class CartItem
    {

        [Key]
        public int CartItemId { get; set; }

        [Required]
        public int Quantity { get; set; }
        public virtual Product CartItemProduct { get; set; }
        public int CartItemProductId { get; set; }
        public virtual Cart Cart { get; set; }
        public int CartId { get; set; }


    }
}
