using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class UserDTO
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; } //TODO: Hash

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string Address { get; set; }

        [Required, StringLength(20)]
        public string Role { get; set; }
    }
}
