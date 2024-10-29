namespace DALWHOLEPOS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Businesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Address = c.String(nullable: false, maxLength: 50, unicode: false),
                        Phone = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Role = c.String(nullable: false, maxLength: 50, unicode: false),
                        IsActive = c.Boolean(nullable: false),
                        Password = c.String(nullable: false, maxLength: 50, unicode: false),
                        Cash = c.Int(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 50, unicode: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 50, unicode: false),
                        UpdatedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 50, unicode: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Address = c.String(nullable: false, maxLength: 50, unicode: false),
                        Due = c.Int(nullable: false),
                        Remarks = c.String(nullable: false, maxLength: 50, unicode: false),
                        Phone = c.String(nullable: false, maxLength: 50, unicode: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 50, unicode: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 50, unicode: false),
                        UpdatedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 50, unicode: false),
                        DeletedAt = c.DateTime(),
                        BusinessId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Businesses", t => t.BusinessId, cascadeDelete: true)
                .Index(t => t.BusinessId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GrossAmount = c.Int(nullable: false),
                        NetAmount = c.Int(nullable: false),
                        DiscountTk = c.Int(nullable: false),
                        Due = c.Int(nullable: false),
                        InvoiceDateTime = c.DateTime(nullable: false),
                        PaymentMethod = c.String(nullable: false, maxLength: 50, unicode: false),
                        Comment = c.String(nullable: false, maxLength: 50, unicode: false),
                        Cost = c.Int(nullable: false),
                        Profit = c.Int(nullable: false),
                        Status = c.String(nullable: false, maxLength: 50, unicode: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 50, unicode: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 50, unicode: false),
                        UpdatedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 50, unicode: false),
                        DeletedAt = c.DateTime(),
                        BusinessId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Businesses", t => t.BusinessId, cascadeDelete: true)
                .Index(t => t.BusinessId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        CostCode = c.String(nullable: false, maxLength: 50, unicode: false),
                        stock = c.Int(nullable: false),
                        Barcode = c.String(maxLength: 50, unicode: false),
                        AddingDate = c.DateTime(nullable: false),
                        ExpireDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 50, unicode: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 50, unicode: false),
                        UpdatedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 50, unicode: false),
                        DeletedAt = c.DateTime(),
                        BusinessId = c.Int(nullable: false),
                        SupplierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Businesses", t => t.BusinessId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.BusinessId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Address = c.String(nullable: false, maxLength: 50, unicode: false),
                        PaymentDue = c.Int(nullable: false),
                        Remarks = c.String(nullable: false, maxLength: 50, unicode: false),
                        Phone = c.String(nullable: false, maxLength: 50, unicode: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 50, unicode: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 50, unicode: false),
                        UpdatedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 50, unicode: false),
                        DeletedAt = c.DateTime(),
                        BusinessId = c.Int(nullable: false),
                        Business_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Businesses", t => t.BusinessId)
                .ForeignKey("dbo.Businesses", t => t.Business_Id)
                .Index(t => t.BusinessId)
                .Index(t => t.Business_Id);
            
            CreateTable(
                "dbo.QuickSells",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceId = c.Int(nullable: false),
                        ProductName = c.String(nullable: false, maxLength: 50, unicode: false),
                        CustomerId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 50, unicode: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 50, unicode: false),
                        UpdatedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 50, unicode: false),
                        DeletedAt = c.DateTime(),
                        BusinessId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Businesses", t => t.BusinessId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId)
                .Index(t => t.InvoiceId)
                .Index(t => t.CustomerId)
                .Index(t => t.BusinessId);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BusinessName = c.String(nullable: false, maxLength: 50, unicode: false),
                        NetSell = c.Int(nullable: false),
                        NetCost = c.Int(nullable: false),
                        NetProfit = c.Int(nullable: false),
                        SellNo = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 50, unicode: false),
                        UpdatedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 50, unicode: false),
                        DeletedAt = c.DateTime(),
                        BusinessId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Businesses", t => t.BusinessId, cascadeDelete: true)
                .Index(t => t.BusinessId);
            
            CreateTable(
                "dbo.Sells",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 50, unicode: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 50, unicode: false),
                        UpdatedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 50, unicode: false),
                        DeletedAt = c.DateTime(),
                        BusinessId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Businesses", t => t.BusinessId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.InvoiceId)
                .Index(t => t.ProductId)
                .Index(t => t.CustomerId)
                .Index(t => t.BusinessId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 50, unicode: false),
                        Reason = c.String(nullable: false, maxLength: 100, unicode: false),
                        TransactionTime = c.DateTime(nullable: false),
                        Amount = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 50, unicode: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 50, unicode: false),
                        UpdatedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 50, unicode: false),
                        DeletedAt = c.DateTime(),
                        BusinessId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Businesses", t => t.BusinessId, cascadeDelete: true)
                .Index(t => t.BusinessId);
            
            CreateTable(
                "dbo.LoginTokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(nullable: false, maxLength: 15),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ExpiredAt = c.DateTime(precision: 7, storeType: "datetime2"),
                        IsValid = c.Boolean(nullable: false),
                        BusinessId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Businesses", t => t.BusinessId, cascadeDelete: true)
                .Index(t => t.BusinessId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoginTokens", "BusinessId", "dbo.Businesses");
            DropForeignKey("dbo.Transactions", "BusinessId", "dbo.Businesses");
            DropForeignKey("dbo.Suppliers", "Business_Id", "dbo.Businesses");
            DropForeignKey("dbo.Sells", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Sells", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Sells", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Sells", "BusinessId", "dbo.Businesses");
            DropForeignKey("dbo.Reports", "BusinessId", "dbo.Businesses");
            DropForeignKey("dbo.QuickSells", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.QuickSells", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.QuickSells", "BusinessId", "dbo.Businesses");
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Suppliers", "BusinessId", "dbo.Businesses");
            DropForeignKey("dbo.Products", "BusinessId", "dbo.Businesses");
            DropForeignKey("dbo.Invoices", "BusinessId", "dbo.Businesses");
            DropForeignKey("dbo.Customers", "BusinessId", "dbo.Businesses");
            DropIndex("dbo.LoginTokens", new[] { "BusinessId" });
            DropIndex("dbo.Transactions", new[] { "BusinessId" });
            DropIndex("dbo.Sells", new[] { "BusinessId" });
            DropIndex("dbo.Sells", new[] { "CustomerId" });
            DropIndex("dbo.Sells", new[] { "ProductId" });
            DropIndex("dbo.Sells", new[] { "InvoiceId" });
            DropIndex("dbo.Reports", new[] { "BusinessId" });
            DropIndex("dbo.QuickSells", new[] { "BusinessId" });
            DropIndex("dbo.QuickSells", new[] { "CustomerId" });
            DropIndex("dbo.QuickSells", new[] { "InvoiceId" });
            DropIndex("dbo.Suppliers", new[] { "Business_Id" });
            DropIndex("dbo.Suppliers", new[] { "BusinessId" });
            DropIndex("dbo.Products", new[] { "SupplierId" });
            DropIndex("dbo.Products", new[] { "BusinessId" });
            DropIndex("dbo.Invoices", new[] { "BusinessId" });
            DropIndex("dbo.Customers", new[] { "BusinessId" });
            DropTable("dbo.LoginTokens");
            DropTable("dbo.Transactions");
            DropTable("dbo.Sells");
            DropTable("dbo.Reports");
            DropTable("dbo.QuickSells");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Products");
            DropTable("dbo.Invoices");
            DropTable("dbo.Customers");
            DropTable("dbo.Businesses");
        }
    }
}
