using InventoryManagement.Context;
using InventoryManagement.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services
{
    public class LoginValidation: ILoginValidation
    {
        
        public bool UsernamePasswordValidation(string userName, string password)
        {
            InventoryDBContext inventoryDBContext = new InventoryDBContext();

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                throw new Exception("Invalid username or password!");

            var user = inventoryDBContext.Users.ToList().Where(x=>x.Username.ToLower()==userName.ToLower()).FirstOrDefault();

            return (user.Username.ToLower() == userName.ToLower() && user.Password == password) ? true : false;
            
        }
        public bool IsUsernameAvailable(string username)
        {
            if (string.IsNullOrEmpty(username))
                return false;

            InventoryDBContext inventoryDBContext = new InventoryDBContext();
            var user = inventoryDBContext.Users.ToList().Select(x => x.Username.ToLower() == username.ToLower()).FirstOrDefault();

            return !user;//if user is exist, return false otherwise true
        }
    }
}
