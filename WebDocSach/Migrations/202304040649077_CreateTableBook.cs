namespace WebDocSach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "TheLoai_Id", c => c.Byte());
            CreateIndex("dbo.Books", "TheLoai_Id");
            AddForeignKey("dbo.Books", "TheLoai_Id", "dbo.TheLoais", "Id");
            DropColumn("dbo.Books", "TheLoai");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "TheLoai", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Books", "TheLoai_Id", "dbo.TheLoais");
            DropIndex("dbo.Books", new[] { "TheLoai_Id" });
            DropColumn("dbo.Books", "TheLoai_Id");
        }
    }
}
