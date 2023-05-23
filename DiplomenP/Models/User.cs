using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomenP.Models
{
    public class User : IdentityUser
    {

        [NotMapped]
        public int Role { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public Cart Cart { get; set; }

    }
}

