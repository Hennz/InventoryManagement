using InventoryManagement.Context;
using InventoryManagement.Repositories;
using InventoryManagement.ServiceInterfaces;
using InventoryManagement.Services;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace InventoryManagement.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private DispatcherTimer dispatcherTimer;
        private string AppPath;

        public LoginWindow()
        {
            InitializeComponent();

            //Create a timer with interval of 2 secs
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 2);

            //set the source for hideShowImage
            AppPath = Directory.GetCurrentDirectory();
            ImgShowHide.Source = new BitmapImage(new Uri("F:\\InventoryManagement\\InventoryManagement\\Images\\Show.jpg"));
            ImgShowHide.Visibility = Visibility.Hidden;

        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            //Things which happen after 1 timer interval
            lableWrongPassword.Visibility = Visibility.Collapsed;

            //Disable the timer
            dispatcherTimer.IsEnabled = false;
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {                
                var loginValidationService = new LoginValidation();

                string userRole = loginValidationService.UsernamePasswordValidation(tbUserName.Text.ToString(), tbxPassword.Password.ToString());
                if (userRole == "Admin")
                {
                    AdminHome adminHome = new AdminHome();
                    adminHome.Show();
                    this.Close();
                }
                else if (userRole == "Cashier")
                {
                    CashierHome cashierHome = new CashierHome();
                    cashierHome.Show();
                    this.Close();
                }
                else
                {
                    //Things which happen before the timer starts
                    lableWrongPassword.Visibility = Visibility.Visible;
                    //Start the timer
                    dispatcherTimer.Start();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),"Error");
            }
        }

        private void ImgShowHide_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowPassword();
        }
        private void ImgShowHide_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            HidePassword();
        }
        private void ImgShowHide_MouseLeave(object sender, MouseEventArgs e)
        {
            HidePassword();
        }
        private void ShowPassword()
        {
            ImgShowHide.Source = new BitmapImage(new Uri("F:\\InventoryManagement\\InventoryManagement\\Images\\Hide.jpg"));
            txtVisiblePasswordbox.Visibility = Visibility.Visible;
            tbxPassword.Visibility = Visibility.Hidden;
            txtVisiblePasswordbox.Text = tbxPassword.Password;
        }
        private void HidePassword()
        {
            ImgShowHide.Source = new BitmapImage(new Uri("F:\\InventoryManagement\\InventoryManagement\\Images\\Show.jpg"));
            txtVisiblePasswordbox.Visibility = Visibility.Hidden;
            tbxPassword.Visibility = Visibility.Visible;
            tbxPassword.Focus();
        }

        private void tbxPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (tbxPassword.Password.Length > 0)
                ImgShowHide.Visibility = Visibility.Visible;
            else
                ImgShowHide.Visibility = Visibility.Hidden;
        }

     
    }
}
