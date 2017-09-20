using InventoryManagement.Context;
using InventoryManagement.ServiceInterfaces;
using InventoryManagement.Services;
using SimpleInjector;
using System;
using System.Collections.Generic;
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
       
        public LoginWindow()
        {
            InitializeComponent();

            //Create a timer with interval of 2 secs
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
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
            var context = new InventoryDBContext();
            var user = context.Users.FirstOrDefault();
            var loginValidationService = new LoginValidation();

            var result = loginValidationService.UsernameValidation(tbUserName.Text.ToString());

            if (user.Username == tbUserName.Text && user.Password == tbxPassword.Password)
            {
                //MessageBox.Show("Login Successfull!");
                MessageBox.Show(result);
            }
            else
            {
                //Things which happen before the timer starts
                lableWrongPassword.Visibility = Visibility.Visible;

                //Start the timer
                dispatcherTimer.Start();
            }
        }
    }
}
