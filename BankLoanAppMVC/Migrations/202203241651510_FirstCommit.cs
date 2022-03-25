 namespace BankLoanAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstCommit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdminName = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 20),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                        City = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        LoanID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        VehicleBrand = c.String(nullable: false, maxLength: 30),
                        VehicleModel = c.String(nullable: false, maxLength: 20),
                        OnRoadPrice = c.Int(nullable: false),
                        Status = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.LoanID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Loans");
            DropTable("dbo.Customers");
            DropTable("dbo.Admins");
        }
    }
}
