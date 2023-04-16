using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomenP.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        [ForeignKey("CartCustomerId")]
        public virtual User CartCustomer { get; set; }
        public string CartCustomerId { get; set; }

        public virtual ICollection<CartItem> Items { get; set; }

        public Order Order { get; set; }

    }


}
