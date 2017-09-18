namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bill",
                c => new
                    {
                        BillId = c.Int(nullable: false, identity: true),
                        BillDate = c.DateTime(nullable: false, precision: 0),
                        Discount = c.Single(nullable: false),
                        PaymentMode = c.Int(nullable: false),
                        Total = c.Single(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BillId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CotegoryName = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustName = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Address = c.String(unicode: false),
                        PhoneNumber = c.Long(nullable: false),
                        Gender = c.Int(nullable: false),
                        City = c.String(unicode: false),
                        Country = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        Unit = c.String(unicode: false),
                        Stock = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        Status = c.Int(nullable: false),
                        Barcode = c.String(unicode: false),
                        MinStock = c.Int(nullable: false),
                        MaxStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Sale",
                c => new
                    {
                        SaleId = c.Int(nullable: false, identity: true),
                        BillId = c.Int(nullable: false),
                        ItemName = c.String(unicode: false),
                        QuantitySold = c.Int(nullable: false),
                        Unit = c.String(unicode: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.SaleId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        RoleId = c.Int(nullable: false),
                        PhoneNumber = c.Long(nullable: false),
                        PasswordChangedDate = c.DateTime(nullable: false, precision: 0),
                        Email = c.String(unicode: false),
                        AccessFailedCount = c.Int(nullable: false),
                        LastLoginTime = c.DateTime(nullable: false, precision: 0),
                        IsDisabled = c.Boolean(nullable: false),
                        Address = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
            DropTable("dbo.Sale");
            DropTable("dbo.Role");
            DropTable("dbo.Item");
            DropTable("dbo.Customer");
            DropTable("dbo.Category");
            DropTable("dbo.Bill");
        }
    }
}
