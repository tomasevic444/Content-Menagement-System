using ContentManagementSystem.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContentManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnLogfdbfin_Click(object sender, RoutedEventArgs e)
        {
            CustomMB cmb = new CustomMB();
            cmb.cmbText.Text = "Are you sure you want to exit app?";
            cmb.btnCancel.Content = "No";
            cmb.btnOKCenter.Visibility = Visibility.Hidden;
            cmb.btnOK.Content = "Yes";
            cmb.ShowDialog();
            if (cmb.MBResult)
            {
                this.Close();
            }
        }
    }
 
}
