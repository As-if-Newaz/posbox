namespace DALWHOLEPOS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transfers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        TransferTime = c.DateTime(nullable: false),
                        Comment = c.String(nullable: false, maxLength: 100, unicode: false),
                        TransferCost = c.Int(nullable: false),
                        Status = c.String(nullable: false, maxLength: 50, unicode: false),
                        FromBusinessId = c.Int(nullable: false),
                        ToBusinessId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 50, unicode: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 50, unicode: false),
                        UpdatedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 50, unicode: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Businesses", t => t.FromBusinessId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Businesses", t => t.ToBusinessId)
                .Index(t => t.ProductId)
                .Index(t => t.FromBusinessId)
                .Index(t => t.ToBusinessId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transfers", "ToBusinessId", "dbo.Businesses");
            DropForeignKey("dbo.Transfers", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Transfers", "FromBusinessId", "dbo.Businesses");
            DropIndex("dbo.Transfers", new[] { "ToBusinessId" });
            DropIndex("dbo.Transfers", new[] { "FromBusinessId" });
            DropIndex("dbo.Transfers", new[] { "ProductId" });
            DropTable("dbo.Transfers");
        }
    }
}
