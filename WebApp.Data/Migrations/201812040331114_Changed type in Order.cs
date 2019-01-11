namespace WebApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedtypeinOrder : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "CustomerAddress", c => c.String(maxLength: 512));
            AlterColumn("dbo.Orders", "CustomerEmail", c => c.String(maxLength: 256));
            AlterColumn("dbo.Orders", "CustomerMobile", c => c.String(maxLength: 50));
            AlterColumn("dbo.Orders", "CustomerMessage", c => c.String(maxLength: 512));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "CustomerMessage", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Orders", "CustomerMobile", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Orders", "CustomerEmail", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Orders", "CustomerAddress", c => c.String(nullable: false, maxLength: 256));
        }
    }
}
