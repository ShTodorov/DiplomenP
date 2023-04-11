using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomenP.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        [ForeignKey("CartProduct")]
        public int CartProductId { get; set; }
        public virtual Product CartProduct { get; set; }

        [ForeignKey("CartCustomer")]
        public string CartCustomerId { get; set; }
        public virtual User CartCustomer { get; set; }

        public Order Order { get; set; }

    }


}
