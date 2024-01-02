namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paymentDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CardNumber = c.String(nullable: false),
                    CardHolderName = c.String(nullable: false),
                    ExpirationDate = c.String(nullable: false),
                    CVV = c.String(nullable: false),
                    BillingAddress = c.String(nullable: false),
                    City = c.String(nullable: false),
                    StateProvince = c.String(nullable: false),
                    ZipPostalCode = c.String(nullable: false),
                    Country = c.String(nullable: false),
                    PhoneNumber = c.String(nullable: false),
                    EmailAddress = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Payments");
        }
    }
}
