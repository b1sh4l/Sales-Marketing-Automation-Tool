namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateLeadDB1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Leads", new[] { "Email" });
            DropIndex("dbo.Leads", new[] { "PhoneNumber" });
            DropIndex("dbo.Payments", new[] { "CardNumber" });
            DropIndex("dbo.Payments", new[] { "PhoneNumber" });
            DropIndex("dbo.Payments", new[] { "EmailAddress" });
            DropIndex("dbo.Users", new[] { "Email" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Users", "Email", unique: true);
            CreateIndex("dbo.Payments", "EmailAddress", unique: true);
            CreateIndex("dbo.Payments", "PhoneNumber", unique: true);
            CreateIndex("dbo.Payments", "CardNumber", unique: true);
            CreateIndex("dbo.Leads", "PhoneNumber", unique: true);
            CreateIndex("dbo.Leads", "Email", unique: true);
        }
    }
}
