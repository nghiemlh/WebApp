namespace WebApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Roundback : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AppUsers", "Gender", c => c.String(maxLength: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AppUsers", "Gender", c => c.String(maxLength: 6));
        }
    }
}
