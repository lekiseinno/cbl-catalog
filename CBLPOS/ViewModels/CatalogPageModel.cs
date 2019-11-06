using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CBLPOS.Views;
using FFImageLoading.Forms;
using DLToolkit.Forms.Controls;
using Xamarin.Forms;
using Xamvvm;

namespace CBLPOS.ViewModels
{
    public class CatalogPageModel : BasePageModel
    {
        public static string ifloder = "";


        public Command GetData { get; set; }

        public CatalogPageModel(string vfloder)
        {

            ifloder = vfloder;


            GetData = new Command(async () => await GetDataCommand());

            ItemTappedCommand = new BaseCommand(async (param) =>
            {

                var item = LastTappedItem as ItemModel;

                if (item != null)
                {

                    await App.Current.MainPage.Navigation.PushModalAsync(new CartPage(item.FileScreen, ifloder, item.ImageUrl));

                }


            });

        }



        private async Task GetDataCommand()
        {

            var list = new ObservableCollection<ItemModel>();

            var images = await Helpers.Service.GetImageList("pattern/" + ifloder);

            String iscreen = "";

            foreach (var photo in images.Photos)
            {


                Char delimiter = '/';
                String[] substrings = photo.Split(delimiter);
                foreach (var substring in substrings)
                {
                    string ic = substring;
                    iscreen = ic;


                }

                string icut = iscreen;

                iscreen = photo.Substring(photo.Length > 8 ? photo.Length - 8 : 0);


                iscreen = iscreen.Substring(0, 4);


                var item = new ItemModel()
                {
                    ImageUrl = photo,

                    FileScreen = iscreen,

                    FileName = icut,

                };


                list.Add(item);

            }
            Items = list;



            //var list = new ObservableCollection<ItemModel>();

            //var images = await Helpers.Service.GetImageList("pattern/" + ifloder);


            //foreach (var photo in images.Photos)
            //{

            //  string iscreen = photo.Substring(photo.Length > 8 ? photo.Length - 8 : 0);


            //    iscreen = iscreen.Substring(0, 4);


            //    var item = new ItemModel()
            //    {
            //        ImageUrl = photo,

            //        FileScreen = iscreen,

            //        FileName = ifloder + "-" + iscreen,

            //    };


            //    list.Add(item);

            //}
            //Items = list;
        }


        public ICommand ItemTappedCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }



        public object LastTappedItem
        {
            get { return GetField<object>(); }
            set { SetField(value); }
        }

        public ObservableCollection<ItemModel> Items
        {
            get { return GetField<ObservableCollection<ItemModel>>(); }
            set { SetField(value); }
        }

        public class ItemModel : BaseModel
        {
            string imageUrl;
            public string ImageUrl
            {
                get { return imageUrl; }
                set { SetField(ref imageUrl, value); }
            }

            string fileName;
            public string FileName
            {
                get { return fileName; }
                set { SetField(ref fileName, value); }
            }


            string fileScreen;
            public string FileScreen
            {
                get { return fileScreen; }
                set { SetField(ref fileScreen, value); }
            }
        }


    }
}
