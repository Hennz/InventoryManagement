using InventoryManagement.Context;
using InventoryManagement.Models;
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
            GeneralService generalService = new GeneralService();
            generalService.TraverseVisualTree(this);

            MessageBox.Show("Product added successfully!");
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            //clear all fields

            GeneralService generalService = new GeneralService();
            generalService.TraverseVisualTree(this);
        }
        
    }
}
