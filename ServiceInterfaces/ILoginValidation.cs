using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.ServiceInterfaces
{
    public interface ILoginValidation
    {
        string UsernamePasswordValidation(string userName, string password);
        bool IsUsernameAvailable(string username);
    }
}
