﻿namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TokenDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tokens",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    TKey = c.String(nullable: false, maxLength: 100),
                    CreatedAt = c.DateTime(nullable: false),
                    ExpiresAt = c.DateTime(nullable: false),
                    UserId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserId); 

        }

        public override void Down()
        {
            DropIndex("dbo.Tokens", new[] { "UserId" });
            DropTable("dbo.Tokens");
        }
    }
}
