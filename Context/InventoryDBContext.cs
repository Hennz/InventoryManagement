using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using InventoryManagement.Models;
using MySql.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace InventoryManagement.Context
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class InventoryDBContext : DbContext
    {
        public InventoryDBContext()
            :base("name=InventoryDBContext")
        {
			Database.SetInitializer<InventoryDBContext>(new InventoryDBInitializer());

        }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Customer> Customers{ get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

}
