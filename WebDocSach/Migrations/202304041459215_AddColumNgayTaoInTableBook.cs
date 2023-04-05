namespace WebDocSach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumNgayTaoInTableBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "NgayTao", c => c.String());

        }

        public override void Down()
        {
            DropColumn("dbo.Books", "NgayTao");
        }
    }
}
