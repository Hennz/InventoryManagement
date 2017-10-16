namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DiscountChangesToFloat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Item", "Discount", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Item", "Discount", c => c.Int(nullable: false));
        }
    }
}
