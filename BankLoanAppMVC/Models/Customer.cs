using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankLoanAppMVC.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required, MaxLength(20)]
        public string CustomerName { get; set; }
        [Required, MaxLength(20)]
        public string Email { get; set; }
        [Required, MaxLength(20)]
        public string PhoneNumber { get; set; }
        [Required, MaxLength(20)]
        public string City { get; set; }
        [Required, MaxLength(20)]
        public string Password { get; set; }
    }
}