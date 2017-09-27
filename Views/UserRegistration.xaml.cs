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
    /// Interaction logic for AddCashier.xaml
    /// </summary>
    public partial class UserRegistration : Window
    {
        private int pwPolicyValidation;
        private List<string> roles=new List<string>();
        bool gotPhoneNumber, gotFname, gotLname, gotUsername, gotPassword, gotConfirmPassword, gotEmail, gotAddress, gotRole;

        public UserRegistration()
        {
            InitializeComponent();
            GetAllActiveRolesInComboBox();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if(gotPhoneNumber && gotFname && gotLname && gotUsername && gotPassword && gotConfirmPassword &&
                gotEmail && gotAddress && comboBoxRoles.SelectedItem!=null)
            {
                InventoryDBContext inventoryDBContext = new InventoryDBContext();
                RoleRepository roleRepository = new RoleRepository();
                User user = new User()
                {
                    Username = tbxUsername.Text,
                    Address = tbxAddress.Text,
                    Email = tbxEmail.Text,
                    IsDisabled = false,
                    Password = tbxPassword.Password,
                    PhoneNumber = long.Parse(tbxPhoneNumber.Text),
                    RoleId = roleRepository.GetRoleByName(comboBoxRoles.Text.ToString()).RoleId,
                };
                inventoryDBContext.Users.Add(user);
                inventoryDBContext.SaveChanges();
                MessageBox.Show("User created successfully!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Please, Check all fields!");
            }
        }

        private void tbxAddress_LostFocus(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(tbxAddress.Text))
            {
                gotAddress = true;
                tbxAddress.Background = Brushes.Transparent;
            }
            else
            {
                gotAddress = true;
                tbxAddress.Background = Brushes.Red;
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            //clear all fields
            GeneralService generalService = new GeneralService();
            generalService.TraverseVisualTree(this);
        }

        private void tbxEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;

            if (string.IsNullOrEmpty(textbox.Text))
            {
                tbxEmail.Background = Brushes.Transparent;
            }
        }

        private void GetAllActiveRolesInComboBox()
        {
            RoleRepository roleRepository = new RoleRepository();

            roles = roleRepository.GetAllActiveRoles().Select(x => x.Name).ToList();

            comboBoxRoles.ItemsSource = roles;
        }

        private void tbxPhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            //need to add this code in lost focus event
            var textbox = sender as TextBox;
            var input = textbox.Text;
            int length = input.Length;
            long n;
            if (!long.TryParse(input, out n) && length!=10)
            {
                MessageBox.Show("Invalid Mobile Number");
                gotPhoneNumber = false;
            }
            else
                gotPhoneNumber = true;
        }

        private void tbxPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordPolicyValidation passwordPolicyValidation = new PasswordPolicyValidation();

            var passwordBox = sender as PasswordBox;

            string inputPassword = passwordBox.Password;

            pwPolicyValidation = passwordPolicyValidation.GetPasswordValidation(inputPassword);

            if (pwPolicyValidation == 0)
            {
                tbxPassword.Background = Brushes.Red;
                labelPasswordPolicy.Visibility = Visibility.Visible;
                gotPassword = false;
            }
            if (pwPolicyValidation == 1)
            {
                tbxPassword.Background = Brushes.Orange;
                gotPassword = false;
            }
            if (pwPolicyValidation == 2)
            {
                tbxPassword.Background = Brushes.LimeGreen;
                labelPasswordPolicy.Visibility = Visibility.Hidden;
                gotPassword = true;
            }
            if (inputPassword.Length == 0)
            {
                tbxPassword.Background = Brushes.Transparent;
                labelPasswordPolicy.Visibility = Visibility.Hidden;
                gotPassword = false;
            }
        }

        private void tbxConfirmPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;

            string inputConfirmPassword = passwordBox.Password;

            if (pwPolicyValidation == 2 && tbxPassword.Password == tbxConfirmPassword.Password)
            {
                tbxConfirmPassword.Background = Brushes.LimeGreen;
                gotConfirmPassword = true;
            }
            if (!(pwPolicyValidation == 2 && tbxPassword.Password == tbxConfirmPassword.Password))
            {
                tbxConfirmPassword.Background = Brushes.Red;
                gotConfirmPassword = false;
            }
            if (inputConfirmPassword.Length == 0)
            {
                tbxConfirmPassword.Background = Brushes.Transparent;
                gotConfirmPassword = false;
            }
        }

        private void tbxUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;

            var input = textbox.Text;

            LoginValidation loginValidation = new LoginValidation();
            bool isUsernameAvailable =true;
            try
            {
                 isUsernameAvailable = loginValidation.IsUsernameAvailable(input);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            if (isUsernameAvailable)
            {
                ImgAcceptMark.Visibility = Visibility.Visible;
                tbxUsername.Foreground = Brushes.Black;
                gotUsername = true;
            }
            else
            {
                ImgAcceptMark.Visibility = Visibility.Hidden;
                tbxUsername.Foreground = Brushes.Red;
                gotUsername = false;
            }
        }

        private void txbLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbxUsername.Text = tbxFirstName.Text + txbLastName.Text;
            gotLname = true;
        }

        private void tbxFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbxUsername.Text = tbxFirstName.Text + txbLastName.Text;
            gotFname = true;
        }

        private void tbxEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            var textbox = sender as TextBox;
            string inputEmail = textbox.Text;
            try
            {
                var addr = new System.Net.Mail.MailAddress(inputEmail);
                tbxEmail.Background = Brushes.Transparent;
                gotEmail = true;
            }
            catch
            {
                tbxEmail.Background = Brushes.Red;
            }
            
        }


    }
}
