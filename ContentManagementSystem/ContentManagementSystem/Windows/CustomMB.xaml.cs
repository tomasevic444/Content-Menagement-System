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

namespace ContentManagementSystem.Windows
{
    /// <summary>
    /// Interaction logic for CustomMB.xaml
    /// </summary>
    public partial class CustomMB : Window
    {
        private bool mbresult;
        public bool MBResult { get => mbresult; set => mbresult = value; }
        public CustomMB()
        {
            InitializeComponent();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            mbresult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            mbresult = false;
            Close();
        }

        private void btnOKCenter_Click(object sender, RoutedEventArgs e)
        {
            mbresult = true;
            Close();
        }
    }
}
