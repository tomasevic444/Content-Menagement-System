using ContentManagementSystem.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {

        User currentUser;
        private EditingSoftware editingSoftware =null;
        public static int index;
        public AddPage(User user, EditingSoftware selectedSoftware = null)
        {
            InitializeComponent();
            currentUser = user;
            CBSize.ItemsSource = new List<double> { 8, 9, 10, 11, 13, 15, 18, 20, 24, 28, 32, 36 };
            CBSize.SelectedIndex = 5;
            CBFamily.SelectedIndex = 2;
            CBColor.SelectedIndex = 1;
            CBFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            CBColor.ItemsSource = typeof(Colors).GetProperties();
            if (selectedSoftware != null)
            {
                editingSoftware = selectedSoftware;
                txtName.Text = selectedSoftware.Name;
                txtReleaseDate.Text = selectedSoftware.ReleaseDate.ToString();
                imgPreview.Source = new BitmapImage(new System.Uri(selectedSoftware.ImagePath.ToString(), UriKind.Absolute));

                if (File.Exists(selectedSoftware.RTFFilePath))
                {
                    using (FileStream fs = new FileStream(selectedSoftware.RTFFilePath, FileMode.Open))
                    {
                        TextRange range = new TextRange(rtDetails.Document.ContentStart, rtDetails.Document.ContentEnd);
                        range.Load(fs, DataFormats.Rtf);
                    }
                }
          
            }
            else
            {
                editingSoftware = new EditingSoftware();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
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

        private void CBFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextSelection text = rtDetails.Selection;
            rtDetails.Focus();
            text.ApplyPropertyValue(TextElement.FontFamilyProperty, CBFamily.SelectedItem);
        }

        private void CBColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            TextSelection text = rtDetails.Selection;
            rtDetails.Focus();
            ComboBoxItem selectedComboBoxItem = CBColor.ItemContainerGenerator.ContainerFromItem(CBColor.SelectedItem) as ComboBoxItem;

            if (selectedComboBoxItem != null)
            {
                TextBlock txtColor = FindVisualChild<TextBlock>(selectedComboBoxItem, "txtColor");

                if (txtColor != null)
                {
                    text.ApplyPropertyValue(Inline.ForegroundProperty, txtColor.Text);
                }
            }

        }

        private void CBSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            TextSelection text = rtDetails.Selection;
            rtDetails.Focus();
            text.ApplyPropertyValue(Inline.FontSizeProperty, CBSize.SelectedValue);

        }
        private T FindVisualChild<T>(DependencyObject parent, string name) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                string childName = (child as FrameworkElement)?.Name;
                if (childName == name && child is T)
                {
                    return (T)child;
                }
                else
                {
                    T childOfChild = FindVisualChild<T>(child, name);
                    if (childOfChild != null)
                    {
                        return childOfChild;
                    }
                }
            }
            return null;
        }

        private void btnChooseImg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog() == true)
            {
                string selectedImagePath = openFileDialog.FileName;
                imgPreview.Source = new BitmapImage(new Uri(selectedImagePath));
            }
        }

        private void btnAddConf_Click(object sender, RoutedEventArgs e)
        {
            string text = StringFromRichTextBox(rtDetails);
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtReleaseDate.Text) || string.IsNullOrWhiteSpace(text) || !int.TryParse(txtReleaseDate.Text, out int releaseYear) || releaseYear < 1980 || releaseYear > 2024 || imgPreview.Source.ToString() == "pack://application:,,,/Images/scenery_12195694.png")
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                    ReqMessageName.Content = "*This field is required.";
                else
                    ReqMessageName.Content = "";
               if (string.IsNullOrWhiteSpace(txtReleaseDate.Text))
                    MessageReleseDate.Content = "*This field is required.";
                else if(!int.TryParse(txtReleaseDate.Text, out int releaseYearCheck) || releaseYearCheck < 1980 || releaseYearCheck > 2024)
                    MessageReleseDate.Content = "*Year must be between 1900 and 2024.";
                else
                    MessageReleseDate.Content = "";
                if (string.IsNullOrWhiteSpace(text))
                    ReqMessageDetails.Content = "*This field is required.";
                else
                    ReqMessageDetails.Content = "";
                if (imgPreview.Source.ToString() == "pack://application:,,,/Images/scenery_12195694.png")
                    ReqMessageImage.Content = "*An image is required.";
                else
                    ReqMessageImage.Content = "";

                return;
            }
            else if (!string.IsNullOrEmpty(editingSoftware.Name))
            {
                string name = txtName.Text;
                int releaseDate = int.Parse(txtReleaseDate.Text);
                string imagePath = imgPreview.Source.ToString();
                string rtfFilePath = editingSoftware.RTFFilePath;

                EditingSoftware newObject = new EditingSoftware
                {
                    Name = name,
                    ReleaseDate = releaseDate,
                    ImagePath = imagePath,
                    RTFFilePath = rtfFilePath
                };
                UpdateXmlData(newObject);
                UpdateRtfFile(editingSoftware); 
                HomePage homePage = new HomePage(currentUser);
                MainWindow main = (MainWindow)Application.Current.MainWindow;
                main.FrameHolder.Content = homePage;

                CustomMB cmb = new CustomMB();
                cmb.cmbText.Text = "Object edited successfully!";
                cmb.btnOKCenter.Content = "OK";
                cmb.btnCancel.Visibility = Visibility.Hidden;
                cmb.btnOK.Visibility = Visibility.Hidden;
                cmb.ShowDialog();
            }
            else
            {
                string name = txtName.Text;
                int releaseDate = int.Parse(txtReleaseDate.Text);
                string imagePath = imgPreview.Source.ToString();
                string rtfFilePath = SaveRTFContent();

                EditingSoftware newObject = new EditingSoftware
                {
                    Name = name,
                    ReleaseDate = releaseDate,
                    ImagePath = imagePath,
                    RTFFilePath = rtfFilePath
                };
                AddObjectToXML(newObject);
                HomePage homePage = new HomePage(currentUser);
                MainWindow main = (MainWindow)Application.Current.MainWindow;
                main.FrameHolder.Content = homePage;

                CustomMB cmb = new CustomMB();
                cmb.cmbText.Text = "Object added successfully!";
                cmb.btnOKCenter.Content = "OK";
                cmb.btnCancel.Visibility = Visibility.Hidden;
                cmb.btnOK.Visibility = Visibility.Hidden;
                cmb.ShowDialog();

            }      
        }

        private string SaveRTFContent()
        {
            string fileName = $"richText_{DateTime.Now:yyyyMMddHHmmss}.rtf";
            string filePath = System.IO.Path.Combine(Environment.CurrentDirectory, fileName);

            TextRange range = new TextRange(rtDetails.Document.ContentStart, rtDetails.Document.ContentEnd);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                range.Save(fileStream, DataFormats.Rtf);
            }

            return filePath;
        }

        private string xmlFilePath = "ContentObjects.xml";

        private void AddObjectToXML(EditingSoftware newObject)
        {
            XDocument doc = null;
            if (File.Exists(xmlFilePath))
            {
                doc = XDocument.Load(xmlFilePath);
            }
            else
            {
                doc = new XDocument(new XElement("ContentObjects"));
            }

            XElement newElement = new XElement("EditingSoftware",
             new XElement("Name", newObject.Name),
             new XElement("ReleaseDate", newObject.ReleaseDate),
             new XElement("ImagePath", newObject.ImagePath),
             new XElement("RTFFilePath", newObject.RTFFilePath),
             new XElement("DateAdded", newObject.DateAdded));

            doc.Element("ContentObjects").Add(newElement);
            doc.Save(xmlFilePath);
        }
        string StringFromRichTextBox(RichTextBox rtb)
        {
            TextRange range = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
            return range.Text;
        }
        private void UpdateXmlData(EditingSoftware editedSoftware)
        {
            if (File.Exists(xmlFilePath))
            {
                XDocument doc = XDocument.Load(xmlFilePath);

                // Find the corresponding XML element and update it
                XElement elementToUpdate = doc.Descendants("EditingSoftware")
            .FirstOrDefault(el => el.Element("Name").Value == editingSoftware.Name);

                if (elementToUpdate != null)
                {
                    // Update XML element properties
                    elementToUpdate.Element("Name").Value = editedSoftware.Name;
                    elementToUpdate.Element("ReleaseDate").Value = editedSoftware.ReleaseDate.ToString();
                    elementToUpdate.Element("ImagePath").Value = editedSoftware.ImagePath;
                    // Update other properties similarly
                }

                doc.Save(xmlFilePath);
            }
        }

        private void UpdateRtfFile(EditingSoftware editedSoftware)
        {
            TextRange range = new TextRange(rtDetails.Document.ContentStart, rtDetails.Document.ContentEnd);
            using (FileStream fileStream = new FileStream(editedSoftware.RTFFilePath, FileMode.Create))
            {
                range.Save(fileStream, DataFormats.Rtf);
            }
        }

        private void rtDetails_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (rtDetails.Selection != null && rtDetails.Selection.GetPropertyValue(TextElement.FontWeightProperty) != DependencyProperty.UnsetValue)
            {
                FontWeight fontWeight = (FontWeight)rtDetails.Selection.GetPropertyValue(TextElement.FontWeightProperty);
                btnBold.IsChecked = fontWeight == FontWeights.Bold;
            }
            else
            {
                btnBold.IsChecked = false;
            }

            // Check for italic
            if (rtDetails.Selection != null && rtDetails.Selection.GetPropertyValue(TextElement.FontStyleProperty) != DependencyProperty.UnsetValue)
            {
                FontStyle fontStyle = (FontStyle)rtDetails.Selection.GetPropertyValue(TextElement.FontStyleProperty);
                btnItalic.IsChecked = fontStyle == FontStyles.Italic;
            }
            else
            {
                btnItalic.IsChecked = false;
            }

            // Check for underline
            if (rtDetails.Selection != null && rtDetails.Selection.GetPropertyValue(Inline.TextDecorationsProperty) != DependencyProperty.UnsetValue)
            {
                TextDecorationCollection textDecorations = (TextDecorationCollection)rtDetails.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
                btnUnderline.IsChecked = textDecorations.Any(t => t.Location == TextDecorationLocation.Underline);
            }
            else
            {
                btnUnderline.IsChecked = false;
            }
          
            CBFamily.SelectionChanged -= CBFamily_SelectionChanged;
            // Update font family combobox
            if (rtDetails.Selection != null && rtDetails.Selection.GetPropertyValue(TextElement.FontFamilyProperty) != DependencyProperty.UnsetValue)
            {
                FontFamily fontFamily = (FontFamily)rtDetails.Selection.GetPropertyValue(TextElement.FontFamilyProperty);
                CBFamily.SelectedItem = fontFamily;
            }
            else
            {
                CBFamily.SelectedIndex = -1;
            }

            CBFamily.SelectionChanged += CBFamily_SelectionChanged;
          
            CBSize.SelectionChanged -= CBSize_SelectionChanged;
            // Update font size combobox
            if (rtDetails.Selection != null && rtDetails.Selection.GetPropertyValue(TextElement.FontSizeProperty) != DependencyProperty.UnsetValue)
            {
                double fontSize = (double)rtDetails.Selection.GetPropertyValue(TextElement.FontSizeProperty);
                CBSize.SelectedItem = fontSize;
            }
            else
            {
                CBSize.SelectedIndex = -1;
            }
            CBSize.SelectionChanged += CBSize_SelectionChanged;
            
            CBColor.SelectionChanged -= CBColor_SelectionChanged;

            // Update font color combobox
            if (rtDetails.Selection != null && rtDetails.Selection.GetPropertyValue(TextElement.ForegroundProperty) != DependencyProperty.UnsetValue)
            {
                Brush foreground = (Brush)rtDetails.Selection.GetPropertyValue(TextElement.ForegroundProperty);
                if (foreground is SolidColorBrush solidColorBrush)
                {
                    CBColor.SelectedItem = typeof(Colors).GetProperties().FirstOrDefault(p => p.GetValue(null).Equals(solidColorBrush.Color));
                }
            }
            else
            {
                CBColor.SelectedIndex = -1;
            }
            CBColor.SelectionChanged += CBColor_SelectionChanged;

        }
    }
}