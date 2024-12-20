namespace DALWHOLEPOS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _211224 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Businesses", "BuName", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Businesses", "BuName");
        }
    }
}
