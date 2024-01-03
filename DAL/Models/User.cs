using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User
    {
        [Key] 
        public int Id { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, StringLength(20)]
        public string Password { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string Address { get; set; }

        [Required, StringLength(20)]
        public string Role { get; set; }
    }
}
