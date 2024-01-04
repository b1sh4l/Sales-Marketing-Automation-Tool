using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public enum LeadStatusEnum
    {
        Contacted,
        Ongoing,
        ClosedWon,
        ClosedLost
    }
    public class LeadDTO
    {
        [Key]
        public int Id { get; set; }
        [StringLength(60)]
        public string LeadName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [ StringLength(11)]
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public LeadStatus LeadStatus { get; set; }
        public String ContactedBy { get; set; }
        public DateTime ContactedOn { get; set; }
    }
}
