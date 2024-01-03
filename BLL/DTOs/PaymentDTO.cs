using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PaymentDTO
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public string CardHolderName { get; set; }

        [Required]
        public string ExpirationDate { get; set; }

        [Required]
        public string CVV { get; set; }

        [Required]
        public string BillingAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string StateProvince { get; set; }

        [Required]
        public string ZipPostalCode { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public double Amount { get; set; }

        public PaymentStatus PaymentStatus { get; set; }
    }
}
