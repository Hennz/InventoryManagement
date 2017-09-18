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

            User user = new User()
            {
                AccessFailedCount=0, Address="Wakad, Pune 411057", Email="dipak.a.akhade9192@gmail.com",
                IsDisabled=false, LastLoginTime=DateTime.Now, PhoneNumber=8007227997, UserId=1,
                Username ="dipakakhade", Password="password"
            };
            context.Users.AddOrUpdate(user);
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
