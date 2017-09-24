using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.ServiceInterfaces
{
    public interface IRoleRepository
    {
        IQueryable<Role> GetAllActiveRoles();
        Role GetRoleByName(string name);
    }
}
