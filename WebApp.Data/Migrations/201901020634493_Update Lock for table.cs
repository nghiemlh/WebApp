namespace WebApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateLockfortable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Colors", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Colors", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Colors", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Colors", "UpdatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Colors", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.ContactDetails", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.ContactDetails", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.ContactDetails", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.ContactDetails", "UpdatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Members", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Members", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Members", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Members", "UpdatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Members", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Objects", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Objects", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Objects", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Objects", "UpdatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Objects", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.ObjectCategories", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.ObjectCategories", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.ObjectCategories", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.ObjectCategories", "UpdatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.ObjectCategories", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.OrderDetails", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.OrderDetails", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.OrderDetails", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.OrderDetails", "UpdatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.OrderDetails", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tags", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Tags", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Tags", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Tags", "UpdatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Tags", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Sizes", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Sizes", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Sizes", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Sizes", "UpdatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Sizes", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProductImages", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.ProductImages", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.ProductImages", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.ProductImages", "UpdatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.ProductImages", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProductQuantities", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.ProductQuantities", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.ProductQuantities", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.ProductQuantities", "UpdatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.ProductQuantities", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Slides", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Slides", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Slides", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Slides", "UpdatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.SupportOnlines", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.SupportOnlines", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.SupportOnlines", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.SupportOnlines", "UpdatedBy", c => c.String(maxLength: 256));
            AlterColumn("dbo.Orders", "CreatedBy", c => c.String(maxLength: 256));
            AlterColumn("dbo.Orders", "UpdatedBy", c => c.String(maxLength: 256));
            DropColumn("dbo.ProductCategories", "MetaKeyword");
            DropColumn("dbo.ProductCategories", "MetaDescription");
            DropColumn("dbo.Pages", "MetaKeyword");
            DropColumn("dbo.Pages", "MetaDescription");
            DropColumn("dbo.PostCategories", "MetaKeyword");
            DropColumn("dbo.PostCategories", "MetaDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PostCategories", "MetaDescription", c => c.String(maxLength: 256));
            AddColumn("dbo.PostCategories", "MetaKeyword", c => c.String(maxLength: 256));
            AddColumn("dbo.Pages", "MetaDescription", c => c.String(maxLength: 256));
            AddColumn("dbo.Pages", "MetaKeyword", c => c.String(maxLength: 256));
            AddColumn("dbo.ProductCategories", "MetaDescription", c => c.String(maxLength: 256));
            AddColumn("dbo.ProductCategories", "MetaKeyword", c => c.String(maxLength: 256));
            AlterColumn("dbo.Orders", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Orders", "CreatedBy", c => c.String());
            DropColumn("dbo.SupportOnlines", "UpdatedBy");
            DropColumn("dbo.SupportOnlines", "UpdatedDate");
            DropColumn("dbo.SupportOnlines", "CreatedBy");
            DropColumn("dbo.SupportOnlines", "CreatedDate");
            DropColumn("dbo.Slides", "UpdatedBy");
            DropColumn("dbo.Slides", "UpdatedDate");
            DropColumn("dbo.Slides", "CreatedBy");
            DropColumn("dbo.Slides", "CreatedDate");
            DropColumn("dbo.ProductQuantities", "Status");
            DropColumn("dbo.ProductQuantities", "UpdatedBy");
            DropColumn("dbo.ProductQuantities", "UpdatedDate");
            DropColumn("dbo.ProductQuantities", "CreatedBy");
            DropColumn("dbo.ProductQuantities", "CreatedDate");
            DropColumn("dbo.ProductImages", "Status");
            DropColumn("dbo.ProductImages", "UpdatedBy");
            DropColumn("dbo.ProductImages", "UpdatedDate");
            DropColumn("dbo.ProductImages", "CreatedBy");
            DropColumn("dbo.ProductImages", "CreatedDate");
            DropColumn("dbo.Sizes", "Status");
            DropColumn("dbo.Sizes", "UpdatedBy");
            DropColumn("dbo.Sizes", "UpdatedDate");
            DropColumn("dbo.Sizes", "CreatedBy");
            DropColumn("dbo.Sizes", "CreatedDate");
            DropColumn("dbo.Tags", "Status");
            DropColumn("dbo.Tags", "UpdatedBy");
            DropColumn("dbo.Tags", "UpdatedDate");
            DropColumn("dbo.Tags", "CreatedBy");
            DropColumn("dbo.Tags", "CreatedDate");
            DropColumn("dbo.OrderDetails", "Status");
            DropColumn("dbo.OrderDetails", "UpdatedBy");
            DropColumn("dbo.OrderDetails", "UpdatedDate");
            DropColumn("dbo.OrderDetails", "CreatedBy");
            DropColumn("dbo.OrderDetails", "CreatedDate");
            DropColumn("dbo.ObjectCategories", "Status");
            DropColumn("dbo.ObjectCategories", "UpdatedBy");
            DropColumn("dbo.ObjectCategories", "UpdatedDate");
            DropColumn("dbo.ObjectCategories", "CreatedBy");
            DropColumn("dbo.ObjectCategories", "CreatedDate");
            DropColumn("dbo.Objects", "Status");
            DropColumn("dbo.Objects", "UpdatedBy");
            DropColumn("dbo.Objects", "UpdatedDate");
            DropColumn("dbo.Objects", "CreatedBy");
            DropColumn("dbo.Objects", "CreatedDate");
            DropColumn("dbo.Members", "Status");
            DropColumn("dbo.Members", "UpdatedBy");
            DropColumn("dbo.Members", "UpdatedDate");
            DropColumn("dbo.Members", "CreatedBy");
            DropColumn("dbo.Members", "CreatedDate");
            DropColumn("dbo.ContactDetails", "UpdatedBy");
            DropColumn("dbo.ContactDetails", "UpdatedDate");
            DropColumn("dbo.ContactDetails", "CreatedBy");
            DropColumn("dbo.ContactDetails", "CreatedDate");
            DropColumn("dbo.Colors", "Status");
            DropColumn("dbo.Colors", "UpdatedBy");
            DropColumn("dbo.Colors", "UpdatedDate");
            DropColumn("dbo.Colors", "CreatedBy");
            DropColumn("dbo.Colors", "CreatedDate");
        }
    }
}
