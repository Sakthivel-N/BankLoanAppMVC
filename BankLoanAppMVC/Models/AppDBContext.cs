using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BankLoanAppMVC.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() : base("LoanDBConfig")
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Loan> Loans { get; set; }
    }
}