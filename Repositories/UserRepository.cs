using InventoryManagement.Context;
using InventoryManagement.Models;
using InventoryManagement.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User GetUser(string userName, string password)
        {
            InventoryDBContext inventoryDBContext = new InventoryDBContext();

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                throw new Exception("Invalid username or password!");

            var user = inventoryDBContext.Users.ToList().Where(x => x.Username.ToLower() == userName.ToLower()).FirstOrDefault();

            if (user == null)
                throw new Exception("Invalid username or password!");

            return user;
        }
    }
}
