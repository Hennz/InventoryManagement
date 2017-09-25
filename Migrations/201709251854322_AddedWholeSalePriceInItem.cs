namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedWholeSalePriceInItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "SellingPrice", c => c.Single(nullable: false));
            AddColumn("dbo.Item", "WholeSalePrice", c => c.Single(nullable: false));
            DropColumn("dbo.Item", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Item", "Price", c => c.Single(nullable: false));
            DropColumn("dbo.Item", "WholeSalePrice");
            DropColumn("dbo.Item", "SellingPrice");
        }
    }
}
