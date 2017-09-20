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
        
        public string UsernameValidation(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return string.Format("Invalid username!");
            return string.Format("Valid username!");

            //InventoryDBContext inventoryDBContext = new InventoryDBContext();
            //inventoryDBContext.Users.
        }
    }
}
