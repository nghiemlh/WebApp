namespace WebApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddcolumnUpdatedDateUpdatedByfromOrdertable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Orders", "UpdatedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "UpdatedBy");
            DropColumn("dbo.Orders", "UpdatedDate");
        }
    }
}
