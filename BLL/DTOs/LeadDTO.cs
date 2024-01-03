using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class LeadDTO
    {
        [Key, Required]
        public int Id { get; set; }
        [Required, StringLength(60)]
        public string LeadName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, StringLength(11)]
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public LeadStatus LeadStatus { get; set; }
    }
}
