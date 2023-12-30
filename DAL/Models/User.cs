using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    internal class User
    {
        [Key] 
        public int Id { get; set; }

        [Required, StringLength(20)]
        public string Uname { get; set; }


        [Required, StringLength(20)]
        public string Password { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, StringLength(11)]
        public string MobileNo { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(20)]
        public string Type { get; set; }
    }
}
