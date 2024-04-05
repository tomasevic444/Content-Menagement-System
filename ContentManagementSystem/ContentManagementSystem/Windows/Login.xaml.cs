using ContentManagementSystem.Classes;
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
using ContentManagementSystem.Windows;
using ContentManagementSystem;

namespace ContentManagementSystem.Windows
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                Message.Content = "Please enter both username and password.";
                return;
            }
            User user = UserDataProvider.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
              
                HomePage homePage = new HomePage(user);
                MainWindow main = (MainWindow)Application.Current.MainWindow;
                main.FrameHolder.Content = homePage;
                CustomMB cmb = new CustomMB();
                cmb.cmbText.Text = "Welcome " + user.Username + "!";
                cmb.btnCancel.Visibility = Visibility.Hidden;
                cmb.btnOK.Visibility = Visibility.Hidden;
                cmb.btnOKCenter.Content = "OK";
                cmb.ShowDialog();

            }
            else
            {
                Message.Content = "Invalid username or password!";
            }
        }
    }
}
