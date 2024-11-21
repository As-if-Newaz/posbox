namespace DALWHOLEPOS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DALComplete : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Businesses", "Name", c => c.String(nullable: false, maxLength: 200, unicode: false));
            AlterColumn("dbo.Businesses", "Address", c => c.String(nullable: false, maxLength: 200, unicode: false));
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 200, unicode: false));
            AlterColumn("dbo.Customers", "Address", c => c.String(nullable: false, maxLength: 200, unicode: false));
            AlterColumn("dbo.Customers", "Remarks", c => c.String(nullable: false, maxLength: 200, unicode: false));
            AlterColumn("dbo.Invoices", "Comment", c => c.String(nullable: false, maxLength: 200, unicode: false));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 200, unicode: false));
            AlterColumn("dbo.Products", "Comment", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.Suppliers", "Name", c => c.String(nullable: false, maxLength: 200, unicode: false));
            AlterColumn("dbo.Suppliers", "Address", c => c.String(nullable: false, maxLength: 200, unicode: false));
            AlterColumn("dbo.Suppliers", "Remarks", c => c.String(nullable: false, maxLength: 200, unicode: false));
            AlterColumn("dbo.QuickSells", "ProductName", c => c.String(nullable: false, maxLength: 200, unicode: false));
            AlterColumn("dbo.Reports", "BusinessName", c => c.String(nullable: false, maxLength: 200, unicode: false));
            AlterColumn("dbo.Transactions", "Reason", c => c.String(nullable: false, maxLength: 200, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "Reason", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.Reports", "BusinessName", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.QuickSells", "ProductName", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Suppliers", "Remarks", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Suppliers", "Address", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Suppliers", "Name", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Products", "Comment", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Invoices", "Comment", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Customers", "Remarks", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Customers", "Address", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Businesses", "Address", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Businesses", "Name", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
    }
}
