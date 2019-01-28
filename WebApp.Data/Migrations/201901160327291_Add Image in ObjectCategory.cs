namespace WebApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageinObjectCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ObjectCategories", "Image", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ObjectCategories", "Image");
        }
    }
}
