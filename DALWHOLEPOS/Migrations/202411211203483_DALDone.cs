namespace DALWHOLEPOS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DALDone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Cost", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Cost");
        }
    }
}
