namespace BankLoanAppMVC.Migrations
{
    using BankLoanAppMVC.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BankLoanAppMVC.Models.AppDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BankLoanAppMVC.Models.AppDBContext context)
        {
            var admins = new List<Admin> {
            new Admin { AdminName = "Admin", Password = "Admin123" },
};
            admins.ForEach(s => context.Admins.Add(s));
            context.SaveChanges();
        }
    }
}
