using InventoryManagement.Context;
using InventoryManagement.Dtos;
using InventoryManagement.Models;
using InventoryManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Billing.xaml
    /// </summary>
    public partial class Billing : Window
    {
        private bool isExistingProduct = false;
        private Item existingItemByBarcode;
        ObservableCollection<BillItemDto> observableCollectionItem = new ObservableCollection<BillItemDto>();

        public Billing()
        {
            InitializeComponent();
           
           // datagridBill.ItemsSource = users;
        }
        void Window_Closing(object sender, CancelEventArgs e)
        {
            CashierHome cashierHome = new CashierHome();
            cashierHome.Show();
        }

        private void tbxToScan_TextChanged(object sender, TextChangedEventArgs e)
        {

            var textbox = sender as TextBox;

            string inputBarcode = textbox.Text;

            InventoryDBContext inventoryDBContext = new InventoryDBContext();


            ItemRepository itemRepository = new ItemRepository();

            existingItemByBarcode = itemRepository.GetItemByBarcodeNumber(inventoryDBContext, inputBarcode);

            if (existingItemByBarcode == null)
            {

            }
            //MessageBox.Show("Invalid item!");
            else
            {
                BillItemDto billItemDto = new BillItemDto()
                {
                    Barcode=existingItemByBarcode.Barcode,
                    Name = existingItemByBarcode.Name,
                    Unit = existingItemByBarcode.Unit,
                    Rate = existingItemByBarcode.WholeSalePrice
                };
                observableCollectionItem.Add(billItemDto);

            }

            datagridBill.ItemsSource = observableCollectionItem;
        }
    }
   
}
