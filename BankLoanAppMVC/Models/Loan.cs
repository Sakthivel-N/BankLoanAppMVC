using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BankLoanAppMVC.Models
{
    public class Loan
    {
        
        [Key]
        public int LoanID { get; set; }
        [Required]
        public int CustomerID { get; set; }
        [Required, MaxLength(30)]
        public string VehicleBrand { get; set; }
        [Required, MaxLength(20)]
        public string VehicleModel { get; set; }
        [Required]
        public int OnRoadPrice { get; set; }
        [Required, MaxLength(20)]
        public string Status { get; set; } = "Processing";


    }
}