namespace WebApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddcolumnIdonProductQuantity : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ProductQuantities");
            AddColumn("dbo.ProductQuantities", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ProductQuantities", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ProductQuantities");
            DropColumn("dbo.ProductQuantities", "Id");
            AddPrimaryKey("dbo.ProductQuantities", new[] { "ProductId", "SizeId", "ColorId" });
        }
    }
}
