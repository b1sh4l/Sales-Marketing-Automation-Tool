namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqueEmailDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leads", "ContactedBy", c => c.String());
            AddColumn("dbo.Leads", "ContactedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Leads", "ContactedOn");
            DropColumn("dbo.Leads", "ContactedBy");
        }
    }
}
