using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace CBLPOS.Models
{
    public class ListViewGalleryInfo : INotifyPropertyChanged
    {
        #region Fields

        private ImageSource image;
        private string imageTitle;
        private string createdData;
        private bool isSelected;

        #endregion

        #region Constructor

        public ListViewGalleryInfo()
        {

        }

        #endregion

        #region Properties

        public ImageSource Image
        {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged("Image");
            }
        }

        public string ImageTitle
        {
            get { return imageTitle; }
            set
            {
                imageTitle = value;
                OnPropertyChanged("ImageTitle");
            }
        }

        public string CreatedDate
        {
            get { return createdData; }
            set
            {
                createdData = value;
                OnPropertyChanged("CreatedDate");
            }
        }

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        #endregion

        #region Interface Member

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
