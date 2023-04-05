namespace WebDocSach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollowingsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Follows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        FolloweeId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId)
                .ForeignKey("dbo.AspNetUsers", t => t.FolloweeId)
                .Index(t => t.BookId)
                .Index(t => t.FolloweeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Follows", "FolloweeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Follows", "BookId", "dbo.Books");
            DropIndex("dbo.Follows", new[] { "FolloweeId" });
            DropIndex("dbo.Follows", new[] { "BookId" });
            DropTable("dbo.Follows");
        }
    }
}
