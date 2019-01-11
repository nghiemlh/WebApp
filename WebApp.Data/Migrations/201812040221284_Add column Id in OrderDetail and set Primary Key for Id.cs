namespace WebApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddcolumnIdinOrderDetailandsetPrimaryKeyforId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.OrderDetails", "SizeId", "dbo.Sizes");
            DropIndex("dbo.OrderDetails", new[] { "ColorId" });
            DropIndex("dbo.OrderDetails", new[] { "SizeId" });
            DropPrimaryKey("dbo.OrderDetails");
            AddColumn("dbo.OrderDetails", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.OrderDetails", "ColorId", c => c.Int());
            AlterColumn("dbo.OrderDetails", "SizeId", c => c.Int());
            AddPrimaryKey("dbo.OrderDetails", "Id");
            CreateIndex("dbo.OrderDetails", "ColorId");
            CreateIndex("dbo.OrderDetails", "SizeId");
            AddForeignKey("dbo.OrderDetails", "ColorId", "dbo.Colors", "Id");
            AddForeignKey("dbo.OrderDetails", "SizeId", "dbo.Sizes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "SizeId", "dbo.Sizes");
            DropForeignKey("dbo.OrderDetails", "ColorId", "dbo.Colors");
            DropIndex("dbo.OrderDetails", new[] { "SizeId" });
            DropIndex("dbo.OrderDetails", new[] { "ColorId" });
            DropPrimaryKey("dbo.OrderDetails");
            AlterColumn("dbo.OrderDetails", "SizeId", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "ColorId", c => c.Int(nullable: false));
            DropColumn("dbo.OrderDetails", "Id");
            AddPrimaryKey("dbo.OrderDetails", new[] { "OrderId", "ProductId" });
            CreateIndex("dbo.OrderDetails", "SizeId");
            CreateIndex("dbo.OrderDetails", "ColorId");
            AddForeignKey("dbo.OrderDetails", "SizeId", "dbo.Sizes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetails", "ColorId", "dbo.Colors", "Id", cascadeDelete: true);
        }
    }
}
