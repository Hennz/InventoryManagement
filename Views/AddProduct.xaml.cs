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
        public List<string> ProductUnits = new List<string>() { "gm", "kg", "lit", "ml", "meter", "cm","pcs" };
        private GeneralService generalService;
        private bool isExistingProduct = false;
        private Item existingItemByBarcode;

        public AddProduct()
        {
            InitializeComponent();

            comboBoxUnit.ItemsSource = ProductUnits;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            ItemRepository itemRepository = new ItemRepository();


            if (isExistingProduct)
            {
                //Update existing product with new stock
                existingItemByBarcode.BrandName = tbxBrandName.Text;
                existingItemByBarcode.Name = tbxProductName.Text;
                existingItemByBarcode.Description = tbxDescription.Text;
                existingItemByBarcode.SellingPrice = float.Parse(tbxSellingPrice.Text);
                existingItemByBarcode.Stock = existingItemByBarcode.Stock + int.Parse(tbxStock.Text);//old stock + new stock
                existingItemByBarcode.Unit = tbxUnit.Text + " " + comboBoxUnit.Text;
                existingItemByBarcode.WholeSalePrice = float.Parse(tbxWholeSalePrice.Text);
                existingItemByBarcode.Discount = int.Parse(tbxDiscount.Text);

                using (var context = new InventoryDBContext())
                {
                    //3. Mark entity as modified
                    context.Entry(existingItemByBarcode).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
                tbxBarcode.Text = string.Empty;

                MessageBox.Show("Product updated successfully!", "APNA SUPER MARKET");
            }
            else
            {
                //Add new product with new stock
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
                    Discount = float.Parse(tbxDiscount.Text),
                };

                using (var context = new InventoryDBContext())
                {
                    context.Items.Add(item);
                    context.SaveChanges();
                }
                tbxBarcode.Text = string.Empty;

                MessageBox.Show("Product added successfully!", "APNA SUPER MARKET");

            }

            //clear all fields
            generalService = new GeneralService();
            generalService.TraverseVisualTree(this);

        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            //clear all fields

            generalService = new GeneralService();
            generalService.TraverseVisualTree(this);

            isExistingProduct = false;
        }

        private void tbxBarcode_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;

            string inputBarcode = textbox.Text;

            InventoryDBContext inventoryDBContext = new InventoryDBContext();

            ItemRepository itemRepository = new ItemRepository();

            existingItemByBarcode = itemRepository.GetItemByBarcodeNumber(inventoryDBContext, inputBarcode);

            if (existingItemByBarcode != null)
            {
                tbxProductName.Text = existingItemByBarcode.Name;
                tbxBrandName.Text = existingItemByBarcode.BrandName;

                tbxUnit.Text = existingItemByBarcode.Unit.Split(null)[0].ToString();

                comboBoxUnit.Text = existingItemByBarcode.Unit.Split(null)[1].ToString();

                tbxStock.Text = existingItemByBarcode.Stock.ToString();
                tbxSellingPrice.Text = existingItemByBarcode.SellingPrice.ToString();
                tbxWholeSalePrice.Text = existingItemByBarcode.WholeSalePrice.ToString();
                tbxDescription.Text = existingItemByBarcode.Description;
                tbxDiscount.Text = existingItemByBarcode.Discount.ToString();

                isExistingProduct = true;
            }
            else
            {
                //clear all fields

                generalService = new GeneralService();
                generalService.TraverseVisualTree(this);

                isExistingProduct = false;
            }
        }
    }
}
