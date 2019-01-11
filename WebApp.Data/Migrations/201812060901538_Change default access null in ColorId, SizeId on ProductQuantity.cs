namespace WebApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedefaultaccessnullinColorIdSizeIdonProductQuantity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductQuantities", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.ProductQuantities", "SizeId", "dbo.Sizes");
            DropIndex("dbo.ProductQuantities", new[] { "SizeId" });
            DropIndex("dbo.ProductQuantities", new[] { "ColorId" });
            AlterColumn("dbo.ProductQuantities", "SizeId", c => c.Int());
            AlterColumn("dbo.ProductQuantities", "ColorId", c => c.Int());
            CreateIndex("dbo.ProductQuantities", "SizeId");
            CreateIndex("dbo.ProductQuantities", "ColorId");
            AddForeignKey("dbo.ProductQuantities", "ColorId", "dbo.Colors", "Id");
            AddForeignKey("dbo.ProductQuantities", "SizeId", "dbo.Sizes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductQuantities", "SizeId", "dbo.Sizes");
            DropForeignKey("dbo.ProductQuantities", "ColorId", "dbo.Colors");
            DropIndex("dbo.ProductQuantities", new[] { "ColorId" });
            DropIndex("dbo.ProductQuantities", new[] { "SizeId" });
            AlterColumn("dbo.ProductQuantities", "ColorId", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductQuantities", "SizeId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductQuantities", "ColorId");
            CreateIndex("dbo.ProductQuantities", "SizeId");
            AddForeignKey("dbo.ProductQuantities", "SizeId", "dbo.Sizes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductQuantities", "ColorId", "dbo.Colors", "Id", cascadeDelete: true);
        }
    }
}
