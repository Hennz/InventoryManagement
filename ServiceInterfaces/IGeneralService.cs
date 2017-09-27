using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;


namespace InventoryManagement.ServiceInterfaces
{
    public interface IGeneralService
    {
        void TraverseVisualTree(Visual myMainWindow);
    }
}
