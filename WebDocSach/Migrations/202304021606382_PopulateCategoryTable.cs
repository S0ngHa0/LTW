namespace WebDocSach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateCategoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO THELOAIS (ID,NAME) VALUES (1,N'Khoa học công nghệ – Kinh tế')");
            Sql("INSERT INTO THELOAIS (ID,NAME) VALUES (2,N'Chính trị – pháp luật')");
            Sql("INSERT INTO THELOAIS (ID,NAME) VALUES (3,N'Truyện, tiểu thuyết')");
            Sql("INSERT INTO THELOAIS (ID,NAME) VALUES (4,N'Văn học nghệ thuật')");
            Sql("INSERT INTO THELOAIS (ID,NAME) VALUES (5,N'Tâm lý, tâm linh, tôn giáo')");
            Sql("INSERT INTO THELOAIS (ID,NAME) VALUES (6,N'Sách thiếu nhi')");
            Sql("INSERT INTO THELOAIS (ID,NAME) VALUES (7,N'Giáo trình')");
            Sql("INSERT INTO THELOAIS (ID,NAME) VALUES (8,N'Văn hóa xã hội – Lịch sử')");
        }

        public override void Down()
        {
        }
    }
}
