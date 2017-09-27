using InventoryManagement.Context;
using InventoryManagement.Models;
using InventoryManagement.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InventoryManagement.Services
{
    public class GeneralService : IGeneralService
    {
        public void TraverseVisualTree(Visual myMainWindow)
        {
            int childrenCount = VisualTreeHelper.GetChildrenCount(myMainWindow);
            for (int i = 0; i < childrenCount; i++)
            {
                var visualChild = (Visual)VisualTreeHelper.GetChild(myMainWindow, i);
                if (visualChild is TextBox)
                {
                    TextBox tb = (TextBox)visualChild;
                    tb.Clear();
                }
                if (visualChild is PasswordBox)
                {
                    PasswordBox pb = (PasswordBox)visualChild;
                    pb.Clear();
                }
                if (visualChild is ComboBox)
                {
                    ComboBox cb = (ComboBox)visualChild;
                    cb.Text=string.Empty;
                }
                TraverseVisualTree(visualChild);
            }
        }
    }
}
