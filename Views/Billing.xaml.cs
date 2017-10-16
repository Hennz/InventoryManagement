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

            lblBillNo.Content = GetBillNumber();

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

            if (existingItemByBarcode != null)
            {
                tbxProductName.Text = existingItemByBarcode.Name;
                tbxPrice.Text = existingItemByBarcode.SellingPrice.ToString();
                tbxQuantity.Text = "1";
                tbxDiscount.Text = existingItemByBarcode.Discount.ToString();
            }
            else
            {
                tbxProductName.Text = string.Empty;
                tbxPrice.Text = string.Empty;
                tbxQuantity.Text = string.Empty;
                tbxDiscount.Text = string.Empty;
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            float actualPrice = float.Parse(tbxPrice.Text);
            int quantity = int.Parse(tbxQuantity.Text);
            float discount = float.Parse(tbxDiscount.Text);
            BillItemDto billItemDto = new BillItemDto()
            {
                Barcode = existingItemByBarcode.Barcode,
                Name = tbxProductName.Text,
                Rate = actualPrice,
                Quantity = quantity,
                Discount=discount.ToString()+"%",
                Total = (actualPrice - ((actualPrice * discount) / 100))*quantity, //calculation of total amount after discount
            };
            observableCollectionItem.Add(billItemDto);
            datagridBill.ItemsSource = observableCollectionItem;

            float billTotal=0;
            foreach (var item in observableCollectionItem)
            {
                billTotal += item.Total;
            }
            txtTotal.Text = String.Format("{0:0.00}", billTotal);
        }
        private void DeleteCurrentItem(object sender, RoutedEventArgs e)
        {
           
            BillItemDto selectedItem = (BillItemDto)datagridBill.SelectedItem;

            var currentRowIndex = datagridBill.Items.IndexOf(datagridBill.CurrentItem);

            observableCollectionItem.Remove(observableCollectionItem.ElementAt(currentRowIndex));

            txtTotal.Text = (float.Parse(txtTotal.Text) - selectedItem.Total).ToString();
        }
        private int GetBillNumber()
        {
            using (var context = new InventoryDBContext())
            {
                int currentBillId = context.Bills.ToList().LastOrDefault().BillId;

                return ++currentBillId;
            }
        }
    }
   
}
