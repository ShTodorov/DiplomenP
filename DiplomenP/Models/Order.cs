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

        [ForeignKey("OrderCartId")]
        public virtual Cart OrderCart { get; set; }
        public int? OrderCartId { get; set; }

        [ForeignKey("OrderCustomerId")]
        public virtual User OrderCustomer { get; set; }
        public string OrderCustomerId { get; set; }

    }

}
