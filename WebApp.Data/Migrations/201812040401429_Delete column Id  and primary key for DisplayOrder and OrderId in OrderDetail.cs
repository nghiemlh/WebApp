namespace WebApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletecolumnIdandprimarykeyforDisplayOrderandOrderIdinOrderDetail : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.OrderDetails");
            AddPrimaryKey("dbo.OrderDetails", new[] { "DisplayOrder", "OrderId" });
            DropColumn("dbo.OrderDetails", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.OrderDetails");
            AddPrimaryKey("dbo.OrderDetails", "Id");
        }
    }
}
