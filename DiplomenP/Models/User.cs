using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomenP.Models
{
    public class User : IdentityUser
    {

        [NotMapped]
        public int Role { get; set; }

        public Order Order { get; set; }

        public Cart Cart { get; set; }

    }
}

