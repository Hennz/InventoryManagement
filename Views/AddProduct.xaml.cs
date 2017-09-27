using InventoryManagement.Context;
using InventoryManagement.Models;
using InventoryManagement.Repositories;
using InventoryManagement.Services;
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

namespace InventoryManagement.Views
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        public List<string> ProductUnits = new List<string>(){"gm","kg","lit","ml","meter","cm",};
        private GeneralService generalService;

        public AddProduct()
        {
            InitializeComponent();

            comboBoxUnit.ItemsSource = ProductUnits;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Item item = new Item()
            {
                Barcode = tbxBarcode.Text,
                BrandName = tbxBrandName.Text,
                Name = tbxProductName.Text,
                Description = tbxDescription.Text,
                SellingPrice = float.Parse(tbxSellingPrice.Text),
                Stock = int.Parse(tbxStock.Text),
                Unit = tbxUnit.Text + " " + comboBoxUnit.Text,
                WholeSalePrice = float.Parse(tbxWholeSalePrice.Text),
            };
            InventoryDBContext inventoryDBContext = new InventoryDBContext();
            inventoryDBContext.Items.Add(item);
            inventoryDBContext.SaveChanges();

            //clear all fields
            generalService = new GeneralService();
            generalService.TraverseVisualTree(this);

            MessageBox.Show("Product added successfully!");
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            //clear all fields

            generalService = new GeneralService();
            generalService.TraverseVisualTree(this);
        }

        private void tbxBarcode_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;

            string inputBarcode = textbox.Text;

            InventoryDBContext inventoryDBContext = new InventoryDBContext();

            ItemRepository itemRepository = new ItemRepository();

            var existingItemByBarcode  = itemRepository.GetItemByBarcodeNumber(inventoryDBContext,inputBarcode);

            if (existingItemByBarcode != null)
            {
                tbxProductName.Text = existingItemByBarcode.Name;
                tbxBrandName.Text = existingItemByBarcode.BrandName;
                tbxUnit.Text = existingItemByBarcode.Unit;
                tbxStock.Text = existingItemByBarcode.Stock.ToString();
                tbxSellingPrice.Text = existingItemByBarcode.SellingPrice.ToString();
                tbxWholeSalePrice.Text = existingItemByBarcode.WholeSalePrice.ToString();
                tbxDescription.Text = existingItemByBarcode.Description;
            }
            else
            {
                generalService = new GeneralService();
                generalService.TraverseVisualTree(this);
            }
        }
    }
}
