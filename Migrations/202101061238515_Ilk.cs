namespace IBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ilk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Yorumlar", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Yorumlar", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Yorumlar", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Yorumlar", "ApplicationUserId");
            AddForeignKey("dbo.Yorumlar", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Yorumlar", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Yorumlar", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Yorumlar", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Yorumlar", "ApplicationUserId");
            AddForeignKey("dbo.Yorumlar", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
