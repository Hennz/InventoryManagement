using InventoryManagement.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Models;
using InventoryManagement.Context;

namespace InventoryManagement.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public IQueryable<Role> GetAllActiveRoles()
        {
            InventoryDBContext context = new InventoryDBContext();

            var roles = context.Roles.ToList().Where(x=>x.IsActive==true).AsQueryable();

            return roles;
        }
        public Role GetRoleByName(string name)
        {
            InventoryDBContext context = new InventoryDBContext();
            return context.Roles.FirstOrDefault(x=>x.Name==name);            
        }
    }
}
