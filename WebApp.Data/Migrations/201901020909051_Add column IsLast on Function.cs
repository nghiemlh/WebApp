namespace WebApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddcolumnIsLastonFunction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Functions", "IsLast", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Functions", "IsLast");
        }
    }
}
