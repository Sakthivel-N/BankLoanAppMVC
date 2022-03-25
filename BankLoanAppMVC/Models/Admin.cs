using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankLoanAppMVC.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [Required, MaxLength(20)]
        public string AdminName { get; set; }
        [Required, MaxLength(20)]
        public string Password { get; set; }
    }
}