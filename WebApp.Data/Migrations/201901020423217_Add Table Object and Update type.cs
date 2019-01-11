namespace WebApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableObjectandUpdatetype : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 15, unicode: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        Image = c.String(maxLength: 256),
                        Type = c.String(nullable: false, maxLength: 50),
                        ObjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Objects", t => t.ObjectId, cascadeDelete: true)
                .Index(t => t.ObjectId);
            
            CreateTable(
                "dbo.Objects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Alias = c.String(nullable: false, maxLength: 256),
                        CategoryId = c.Int(nullable: false),
                        Image = c.String(maxLength: 256),
                        Description = c.String(maxLength: 500),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ObjectCategories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ObjectCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Alias = c.String(nullable: false, maxLength: 256, unicode: false),
                        Description = c.String(maxLength: 500),
                        ParentId = c.Int(),
                        DisplayOrder = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "IconCss", c => c.String(maxLength: 256));
            AlterColumn("dbo.Functions", "IconCss", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "ObjectId", "dbo.Objects");
            DropForeignKey("dbo.Objects", "CategoryId", "dbo.ObjectCategories");
            DropIndex("dbo.Objects", new[] { "CategoryId" });
            DropIndex("dbo.Members", new[] { "ObjectId" });
            AlterColumn("dbo.Functions", "IconCss", c => c.String());
            DropColumn("dbo.Products", "IconCss");
            DropTable("dbo.ObjectCategories");
            DropTable("dbo.Objects");
            DropTable("dbo.Members");
        }
    }
}
