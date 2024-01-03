namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class amountColumnPaymentDBAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "Amount", c => c.Double(nullable: false));
            AlterColumn("dbo.Payments", "PaymentStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Payments", "PaymentStatus", c => c.String());
            DropColumn("dbo.Payments", "Amount");
        }
    }
}
