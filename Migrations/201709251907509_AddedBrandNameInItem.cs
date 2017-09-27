namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBrandNameInItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "BrandName", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Item", "BrandName");
        }
    }
}
