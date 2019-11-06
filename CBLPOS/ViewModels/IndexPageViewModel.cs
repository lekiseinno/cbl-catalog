using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CBLPOS.Views;
using Xamarin.Forms;
using Xamvvm;

namespace CBLPOS.ViewModels
{
    public class IndexPageViewModel : BasePageModel
    {
        public static string ifloder = "";


        public Command GetData { get; set; }


        public IndexPageViewModel()
        {


            GetData = new Command(async () => await GetDataCommand());

            ItemTappedCommand = new BaseCommand(async (param) =>
           {

               var item = LastTappedItem as ItemModel;

               if (item != null)
               {

                   await App.Current.MainPage.Navigation.PushModalAsync(new CatalogPage(item.FileName));


                   // Application.Current.MainPage = new NavigationPage(new ScreenPage(item.FileName));



                   var navPage = new NavigationPage(new MainPage());

                   Application.Current.MainPage = navPage;

                   await navPage.PushAsync(new CatalogPage(item.FileName));








                   //var masterDetail = Application.Current.MainPage as MasterDetailPage;

                   //var navigationPage = masterDetail.Detail as NavigationPage;

                   //masterDetail.Detail = new NavigationPage(new MainPage());








                   //await navigationPage.Navigation.PushAsync(new CatalogPage(item.FileName));





               }


           });

        }



        private async Task GetDataCommand()
        {

            var list = new ObservableCollection<ItemModel>();

            var images = await Helpers.Service.GetImageList("pattern/index");

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

                //    iscreen = photo.Substring(photo.Length > 8 ? photo.Length - 8 : 0);


                // icut = icut.Substring(icut.Length > 4 ? icut.Length - 4 : 0);

                int position = icut.IndexOf(".");

                icut = icut.Substring(0, position);


                var item = new ItemModel()
                {
                    ImageUrl = photo,

                    FileScreen = icut,

                    FileName = icut,

                };


                list.Add(item);

            }
            Items = list;




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
