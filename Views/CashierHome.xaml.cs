using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace InventoryManagement.Views
{
    /// <summary>
    /// Interaction logic for CashierHome.xaml
    /// </summary>
    public partial class CashierHome : Window
    {
        public CashierHome()
        {
            InitializeComponent();
        }

        private void btnBill_Click(object sender, RoutedEventArgs e)
        {
            Billing billing = new Billing();
            billing.Show();
            this.Close();
        }
       
    }
}
