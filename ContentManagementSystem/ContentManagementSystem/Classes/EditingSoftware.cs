using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentManagementSystem.Classes
{
    public class EditingSoftware : INotifyPropertyChanged
    {
        private bool delete;
        public bool Delete
        {
            get { return delete; }
            set
            {
                if (delete != value)
                {
                    delete = value;
                    OnPropertyChanged(nameof(Delete));
                }
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        private int releaseDate;
        public int ReleaseDate
        {
            get { return releaseDate; }
            set
            {
                if (releaseDate != value)
                {
                    releaseDate = value;
                    OnPropertyChanged(nameof(ReleaseDate));
                }
            }
        }

        private string imagePath;
        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                if (imagePath != value)
                {
                    imagePath = value;
                    OnPropertyChanged(nameof(ImagePath));
                }
            }
        }

        private string rtfFilePath;
        public string RTFFilePath
        {
            get { return rtfFilePath; }
            set
            {
                if (rtfFilePath != value)
                {
                    rtfFilePath = value;
                    OnPropertyChanged(nameof(RTFFilePath));
                }
            }
        }

        private DateTime dateAdded;
        public DateTime DateAdded
        {
            get { return dateAdded; }
            set
            {
                if (dateAdded != value)
                {
                    dateAdded = value;
                    OnPropertyChanged(nameof(DateAdded));
                }
            }
        }

        public EditingSoftware()
        {
            DateAdded = DateTime.Now;
            Delete = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
  
}
