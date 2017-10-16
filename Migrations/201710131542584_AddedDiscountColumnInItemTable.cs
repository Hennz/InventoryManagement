namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDiscountColumnInItemTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "Discount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Item", "Discount");
        }
    }
}
