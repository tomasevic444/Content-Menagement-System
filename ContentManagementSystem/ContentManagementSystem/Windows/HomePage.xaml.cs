using ContentManagementSystem.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Xml.Linq;

namespace ContentManagementSystem.Windows
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public ObservableCollection<EditingSoftware> softwareList { get; set; }

        private User currentUser;
        public HomePage(User user)
        {
            InitializeComponent();
            currentUser = user;


            if (currentUser != null && currentUser.Role == UserRole.Admin)
            {
                adminSP.Visibility = System.Windows.Visibility.Visible;
                CBDelete.IsReadOnly = false;
            }
            else
            {
                adminSP.Visibility = System.Windows.Visibility.Collapsed;
                CBDelete.IsReadOnly = true;
            }
            softwareList = new ObservableCollection<EditingSoftware>();
            LoadDataFromXML();
            DataContext = this;

        }

        private void btnlogout_Click(object sender, RoutedEventArgs e)
        {

            CustomMB cmb = new CustomMB();
            cmb.cmbText.Text = "Are you sure you want to log out?";
            cmb.btnCancel.Content = "No";
            cmb.btnOKCenter.Visibility = Visibility.Hidden;
            cmb.btnOK.Content = "Yes";
            cmb.ShowDialog();
            if (cmb.MBResult)
            {
                Login login = new Login();
                MainWindow main = (MainWindow)Application.Current.MainWindow;
                main.FrameHolder.Content = login;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddPage addpage = new AddPage(currentUser);
            MainWindow main = (MainWindow)Application.Current.MainWindow;
            main.FrameHolder.Content = addpage;
        }
        private string xmlFilePath = "ContentObjects.xml";
        private void LoadDataFromXML()
        {
            if (File.Exists(xmlFilePath))
            {
                XDocument doc = XDocument.Load(xmlFilePath);
                foreach (XElement element in doc.Descendants("EditingSoftware"))
                {
                    EditingSoftware software = new EditingSoftware
                    {
                        Name = element.Element("Name").Value,
                        ReleaseDate = int.Parse(element.Element("ReleaseDate").Value),
                        ImagePath = element.Element("ImagePath").Value,
                        RTFFilePath = element.Element("RTFFilePath").Value,
                        DateAdded = DateTime.Parse(element.Element("DateAdded").Value)

                    };
                    softwareList.Add(software);
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!softwareList.Any(s => s.Delete))
            {
                CustomMB cmbNothing = new CustomMB();
                cmbNothing.cmbText.Text = "No items selected for deletion!";
                cmbNothing.btnOKCenter.Content = "OK";
                cmbNothing.btnCancel.Visibility = Visibility.Hidden;
                cmbNothing.btnOK.Visibility = Visibility.Hidden;
                cmbNothing.ShowDialog();
                return;
            }
            List<EditingSoftware> softwaresToRemove = new List<EditingSoftware>();
            CustomMB cmb = new CustomMB();
            cmb.cmbText.Text = "Are you sure you want to delete the selected rows? This action cannot be undone.";
            cmb.btnCancel.Content = "Cancel";
            cmb.btnOKCenter.Visibility = Visibility.Hidden;
            cmb.btnOK.Content = "Delete";
            cmb.ShowDialog();

            if (cmb.MBResult)
            {
                foreach (EditingSoftware software in softwareList)
                {
                    if (software.Delete)
                    {
                        softwaresToRemove.Add(software);
                    }
                }

                foreach (EditingSoftware software in softwaresToRemove)
                {
                    softwareList.Remove(software);
                    RemoveFromXML(software);

                    DeleteRTFFile(software.RTFFilePath);
                }
            }
        }

        private void RemoveFromXML(EditingSoftware softwareToRemove)
        {
            if (File.Exists(xmlFilePath))
            {
                XDocument doc = XDocument.Load(xmlFilePath);

                // Find the corresponding XML element and remove it
                XElement elementToRemove = doc.Descendants("EditingSoftware")
                    .FirstOrDefault(el => el.Element("Name").Value == softwareToRemove.Name);

                if (elementToRemove != null)
                {
                    elementToRemove.Remove();
                    doc.Save(xmlFilePath);

                }
            }
        }
        private void DataGridHyperlinkColumn_Click(object sender, RoutedEventArgs e)
        {
            EditingSoftware selectedSoftware = (sender as FrameworkElement)?.DataContext as EditingSoftware;
            if (currentUser != null && currentUser.Role == UserRole.Admin)
            {
                if (selectedSoftware != null) { 

                    AddPage addPage = new AddPage(currentUser, selectedSoftware);
                MainWindow main = (MainWindow)Application.Current.MainWindow;
                main.FrameHolder.Content = addPage;
            } }
            else
            {
                UserView userview = new UserView(currentUser,selectedSoftware);
                MainWindow main = (MainWindow)Application.Current.MainWindow;
                main.FrameHolder.Content = userview;
            }


        }
        private void DeleteRTFFile(string rtfFilePath)
        {
            if (File.Exists(rtfFilePath))
            {
                File.Delete(rtfFilePath);
            }
        }


    }
}
