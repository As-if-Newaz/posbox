namespace DALWHOLEPOS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Db7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DiscardApplications", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.DiscardApplications", "CreatedBy", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AddColumn("dbo.DiscardApplications", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.DiscardApplications", "UpdatedBy", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.DiscardApplications", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.DiscardApplications", "DeletedBy", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.DiscardApplications", "DeletedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DiscardApplications", "DeletedAt");
            DropColumn("dbo.DiscardApplications", "DeletedBy");
            DropColumn("dbo.DiscardApplications", "UpdatedAt");
            DropColumn("dbo.DiscardApplications", "UpdatedBy");
            DropColumn("dbo.DiscardApplications", "CreatedAt");
            DropColumn("dbo.DiscardApplications", "CreatedBy");
            DropColumn("dbo.DiscardApplications", "IsDeleted");
        }
    }
}
