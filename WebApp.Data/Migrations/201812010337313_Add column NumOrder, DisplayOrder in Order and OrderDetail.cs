namespace WebApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddcolumnNumOrderDisplayOrderinOrderandOrderDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "DisplayOrder", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "NumOrder", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "NumOrder");
            DropColumn("dbo.OrderDetails", "DisplayOrder");
        }
    }
}
