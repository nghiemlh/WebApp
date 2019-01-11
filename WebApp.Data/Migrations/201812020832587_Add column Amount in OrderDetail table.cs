namespace WebApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddcolumnAmountinOrderDetailtable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "Amount");
        }
    }
}
