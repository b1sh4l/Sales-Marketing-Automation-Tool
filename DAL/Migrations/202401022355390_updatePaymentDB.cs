namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePaymentDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "PaymentStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "PaymentStatus");
        }
    }
}
