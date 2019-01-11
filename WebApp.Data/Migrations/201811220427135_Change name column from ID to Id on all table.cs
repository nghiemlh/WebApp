namespace WebApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangenamecolumnfromIDtoIdonalltable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.ProductTags", new[] { "ProductID" });
            DropIndex("dbo.ProductTags", new[] { "TagID" });
            DropIndex("dbo.Posts", new[] { "CategoryID" });
            DropIndex("dbo.PostTags", new[] { "PostID" });
            DropIndex("dbo.PostTags", new[] { "TagID" });
            CreateIndex("dbo.OrderDetails", "OrderId");
            CreateIndex("dbo.OrderDetails", "ProductId");
            CreateIndex("dbo.Products", "CategoryId");
            CreateIndex("dbo.ProductTags", "ProductId");
            CreateIndex("dbo.ProductTags", "TagId");
            CreateIndex("dbo.Posts", "CategoryId");
            CreateIndex("dbo.PostTags", "PostId");
            CreateIndex("dbo.PostTags", "TagId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PostTags", new[] { "TagId" });
            DropIndex("dbo.PostTags", new[] { "PostId" });
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            DropIndex("dbo.ProductTags", new[] { "TagId" });
            DropIndex("dbo.ProductTags", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            CreateIndex("dbo.PostTags", "TagID");
            CreateIndex("dbo.PostTags", "PostID");
            CreateIndex("dbo.Posts", "CategoryID");
            CreateIndex("dbo.ProductTags", "TagID");
            CreateIndex("dbo.ProductTags", "ProductID");
            CreateIndex("dbo.Products", "CategoryID");
            CreateIndex("dbo.OrderDetails", "ProductID");
            CreateIndex("dbo.OrderDetails", "OrderID");
        }
    }
}
