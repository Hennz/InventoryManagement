namespace InventoryManagement.Migrations
{
    using InventoryManagement.Models;
    using System;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.History;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<InventoryManagement.Context.InventoryDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());

            SetHistoryContextFactory("MySql.Data.MySqlClient", (conn, schema) => new MySqlHistoryContext(conn, schema));

        }

        protected override void Seed(InventoryManagement.Context.InventoryDBContext context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            User adminUser = new User()
            {
                AccessFailedCount = 0,
                Address = "Wakad, Pune 411057",
                Email = "dipak.a.akhade9192@gmail.com",
                IsDisabled = false,
                LastLoginTime = DateTime.Now,
                PhoneNumber = 8007227997,
                UserId = 1,
                Username = "dipakakhade",
                Password = "password",
                RoleId = 1
            };
            User cashierUser = new User()
            {
                AccessFailedCount = 0,
                Address = "Wakad, Pune 411057",
                Email = "dipak.a.akhade9192@gmail.com",
                IsDisabled = false,
                LastLoginTime = DateTime.Now,
                PhoneNumber = 8007227997,
                UserId = 2,
                Username = "dipakakhade1",
                Password = "password",
                RoleId = 2
            };

            Role adminRole = new Role()
            {
                Name = "Admin",
                Description = "Administrator",
                IsActive = true,
            };
            Role cashierRole = new Role()
            {
                Name = "Cashier",
                Description = "Employee as a cashier",
                IsActive = true,
            };
            context.Roles.AddOrUpdate(adminRole);
            context.Roles.AddOrUpdate(cashierRole);
            context.Users.AddOrUpdate(adminUser);
            context.Users.AddOrUpdate(cashierUser);
            context.SaveChanges();

        }
        public class MySqlHistoryContext : HistoryContext
        {
            public MySqlHistoryContext(DbConnection connection, string defaultSchema) : base(connection, defaultSchema)
            {
            }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<HistoryRow>().Property(h => h.MigrationId)
                    .HasMaxLength(100)
                    .IsRequired();

                modelBuilder.Entity<HistoryRow>().Property(h => h.ContextKey)
                    .HasMaxLength(200)
                    .IsRequired();
            }
        }

    }
}
