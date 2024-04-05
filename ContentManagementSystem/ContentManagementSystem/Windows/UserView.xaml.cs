using ContentManagementSystem.Classes;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace ContentManagementSystem.Windows
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : Page
    {
        User currentUser;
        public UserView(User user, EditingSoftware selectedSoftware = null)
        {
            InitializeComponent();
            currentUser = user;
            if (selectedSoftware != null)
            {
                txtName.Text = selectedSoftware.Name;
                txtReleaseYearView.Text = selectedSoftware.ReleaseDate.ToString();
                imgView.Source = new BitmapImage(new System.Uri(selectedSoftware.ImagePath.ToString(), UriKind.Absolute));
                string filePath = selectedSoftware.RTFFilePath;
                if (File.Exists(filePath))
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Open))
                    {
                        TextRange range = new TextRange(flowDocumentViewer.Document.ContentStart, flowDocumentViewer.Document.ContentEnd);
                        range.Load(fs, DataFormats.Rtf);
                    }
                }

            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            CustomMB cmb = new CustomMB();
            cmb.cmbText.Text = "Are you sure you want to go back to the homepage?";
            cmb.btnCancel.Content = "No";
            cmb.btnOKCenter.Visibility = Visibility.Hidden;
            cmb.btnOK.Content = "Yes";
            cmb.ShowDialog();

            if (cmb.MBResult)
            {
                HomePage homePage = new HomePage(currentUser);
                MainWindow main = (MainWindow)Application.Current.MainWindow;
                main.FrameHolder.Content = homePage;
            }
        }
    }
}
