using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CBLPOS.Views
{
    public partial class CustomPage : ContentPage
    {

        public static string ifloder = "";

        public CustomPage(string vfloder)
        {
            InitializeComponent();

            ifloder = vfloder;
        }

        static readonly int imageDimension = Device.RuntimePlatform == Device.iOS ||
                                                   Device.RuntimePlatform == Device.Android ? 240 : 180;
        static readonly string urlSuffix =
            String.Format("?width={0}&height={0}&mode=max", imageDimension);

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            wrapLayout.Children.Clear();

            //  var images = await Helpers.Service.GetImageList("pattern/D");

            var images = await Helpers.Service.GetImageList("pattern/" + ifloder);

            foreach (var photo in images.Photos)
            {
                var image = new Image
                {

                    //   Source = ImageSource.FromUri(new Uri(photo + string.Format("?width={0}&height={0}&mode=max", imageDimension))),

                    Source = ImageSource.FromUri(new Uri(photo)),
                    // Aspect = string.Format("{0}ll", "AspectFi")
                    WidthRequest = 250,
                    MinimumWidthRequest = 250,
                    HeightRequest = 300,
                    MinimumHeightRequest = 300



                };


                wrapLayout.Children.Add(image);


                string iname = image.Source.ToString();


                string iscreen = iname.Substring(iname.Length > 8 ? iname.Length - 8 : 0);

                iscreen = iscreen.Substring(0, 4);

                //var lblscreen = new Label
                //{
                //    Text = iscreen
                //};

                //wrapLayout.Children.Add(lblscreen);

                var tapGestureRecognizer = new TapGestureRecognizer();

                tapGestureRecognizer.Tapped += async (s, e) =>
                {


                    await Navigation.PushModalAsync(new CartPage(iscreen, ifloder, photo));

                    //     new NavigationPage(new MyPage(iscreen, ifloder));

                };

                image.GestureRecognizers.Add(tapGestureRecognizer);


            }
        }



    }
}
