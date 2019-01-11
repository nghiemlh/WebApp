namespace WebApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddcolumnIsLastforCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ObjectCategories", "IsLast", c => c.Boolean());
            AddColumn("dbo.ProductCategories", "IsLast", c => c.Boolean());
            AddColumn("dbo.PostCategories", "IsLast", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostCategories", "IsLast");
            DropColumn("dbo.ProductCategories", "IsLast");
            DropColumn("dbo.ObjectCategories", "IsLast");
        }
    }
}
