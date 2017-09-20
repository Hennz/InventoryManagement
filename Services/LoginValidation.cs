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
        
        public void UsernamePasswordValidation(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                throw new Exception("Invalid username or password!");

            InventoryDBContext inventoryDBContext = new InventoryDBContext();
            var users = inventoryDBContext.Users.ToList().Select(x=>x.Username==userName).FirstOrDefault();

            if(!users)
            {
                throw new Exception("User identificaion failed!");
            }
        }
    }
}
