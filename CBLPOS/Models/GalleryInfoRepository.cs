using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace CBLPOS.Models
{
    public class ListViewGalleryInfoRepository
    {
        #region Constructor

        public ListViewGalleryInfoRepository()
        {

        }

        #endregion

        #region GetGalleryInfo

        internal async System.Threading.Tasks.Task<ObservableCollection<ListViewGalleryInfo>> GetGalleryInfo()
        {
            var galleryInfo = new ObservableCollection<ListViewGalleryInfo>();



            var images = await Helpers.Service.GetImageList("pattern/SX");

            foreach (var photo in images.Photos)
            {
                var image = new Image
                {




                };


                string iname = image.Source.ToString();


                string iscreen = iname.Substring(iname.Length > 8 ? iname.Length - 8 : 0);

                iscreen = iscreen.Substring(0, 4);




                for (int i = 1; i <= 100; i++)
                {
                    var gallery = new ListViewGalleryInfo()
                    {
                        Image = ImageSource.FromUri(new Uri(photo)),
                        ImageTitle = iscreen

                    };
                    galleryInfo.Add(gallery);
                }


            }


            return galleryInfo;
        }


        #endregion


    }
}