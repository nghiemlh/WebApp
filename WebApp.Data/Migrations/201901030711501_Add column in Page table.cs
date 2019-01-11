namespace WebApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddcolumninPagetable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "Description", c => c.String(maxLength: 500));
            AddColumn("dbo.Pages", "Image", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pages", "Image");
            DropColumn("dbo.Pages", "Description");
        }
    }
}
