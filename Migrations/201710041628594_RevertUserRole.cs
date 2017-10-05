namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevertUserRole : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.UserRole1", newName: "UserRole");
            //DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            //DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            //DropIndex("dbo.UserRole", new[] { "UserId" });
            //DropIndex("dbo.UserRole", new[] { "RoleId" });
            //DropTable("dbo.UserRole");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
            CreateIndex("dbo.UserRole", "RoleId");
            CreateIndex("dbo.UserRole", "UserId");
            AddForeignKey("dbo.UserRole", "UserId", "dbo.User", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.UserRole", "RoleId", "dbo.Role", "RoleId", cascadeDelete: true);
            RenameTable(name: "dbo.UserRole", newName: "UserRole1");
        }
    }
}
