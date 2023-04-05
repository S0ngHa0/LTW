namespace WebDocSach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumToTableBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "NgayTao", c => c.DateTime(nullable: false));
            AddColumn("dbo.Books", "Nguon", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Nguon");
            DropColumn("dbo.Books", "NgayTao");
        }
    }
}
