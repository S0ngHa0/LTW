namespace WebDocSach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumToTableBook1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "NgayTao");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "NgayTao", c => c.DateTime(nullable: false));
        }
    }
}
