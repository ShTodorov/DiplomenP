using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomenP.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        public string? OrderDescription { get; set; }

        [Required]
        public double TotalOrderPrice { get; set; }

        [ForeignKey("OrderCart")]
        public int OrderCartId { get; set; }
        public virtual Cart OrderCart { get; set; }

        [ForeignKey("OrderCustomer")]
        public string OrderCustomerId { get; set; }
        public virtual User OrderCustomer { get; set; }

    }

}
