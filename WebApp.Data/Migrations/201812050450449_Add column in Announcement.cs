namespace WebApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddcolumninAnnouncement : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Announcements", "CreatedBy", c => c.String());
            AddColumn("dbo.Announcements", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Announcements", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Announcements", "CreatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Announcements", "CreatedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Announcements", "UpdatedBy");
            DropColumn("dbo.Announcements", "UpdatedDate");
            DropColumn("dbo.Announcements", "CreatedBy");
        }
    }
}
