namespace IBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Like : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Makaleler", "Like", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Makaleler", "Like");
        }
    }
}
