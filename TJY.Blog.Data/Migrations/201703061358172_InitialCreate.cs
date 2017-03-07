namespace TJY.Blog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LoginName = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        NickName = c.String(nullable: false, maxLength: 20),
                        Image = c.String(),
                        Email = c.String(),
                        Motto = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Article",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Content = c.String(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        LastModifiedTime = c.DateTime(),
                        ReaderNumber = c.Int(nullable: false),
                        Like = c.Int(nullable: false),
                        StateID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Category", t => t.CategoryID)
                .ForeignKey("dbo.ArticleState", t => t.StateID)
                .Index(t => t.StateID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NickName = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false),
                        Content = c.String(nullable: false, maxLength: 500),
                        CreateTime = c.DateTime(nullable: false),
                        IsArticleComment = c.Boolean(nullable: false),
                        ArticleID = c.Int(nullable: false),
                        ParentID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Article", t => t.ArticleID)
                .ForeignKey("dbo.Comment", t => t.ParentID)
                .Index(t => t.ArticleID)
                .Index(t => t.ParentID);
            
            CreateTable(
                "dbo.ArticleState",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OperationLog",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LogLevel = c.String(nullable: false),
                        OperateSQL = c.String(nullable: false),
                        LogTime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Article", "StateID", "dbo.ArticleState");
            DropForeignKey("dbo.Comment", "ParentID", "dbo.Comment");
            DropForeignKey("dbo.Comment", "ArticleID", "dbo.Article");
            DropForeignKey("dbo.Article", "CategoryID", "dbo.Category");
            DropIndex("dbo.Comment", new[] { "ParentID" });
            DropIndex("dbo.Comment", new[] { "ArticleID" });
            DropIndex("dbo.Article", new[] { "CategoryID" });
            DropIndex("dbo.Article", new[] { "StateID" });
            DropTable("dbo.OperationLog");
            DropTable("dbo.ArticleState");
            DropTable("dbo.Comment");
            DropTable("dbo.Category");
            DropTable("dbo.Article");
            DropTable("dbo.Account");
        }
    }
}
