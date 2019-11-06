using System;
using System.Collections.Generic;
using CBLPOS.Helpers;
using CBLPOS.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CBLPOS.ContentView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class CustomNavigationBar : Xamarin.Forms.ContentView
    {
        public CustomNavigationBar()
        {


            InitializeComponent();


        }

        public Label FirstNameLabel
        {
            get
            {
                return labelText;
            }
        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            //Navigation.PopAsync();
            //MessagingCenter.Send(this, "presentMenu");
            Navigation.PopModalAsync();
        }

        public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(
        "Title",
        typeof(string),
        typeof(CustomNavigationBar),
        "this is Title",
        propertyChanged: OnTitlePropertyChanged
        );

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        private static void OnTitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var thisView = bindable as CustomNavigationBar;
            var title = newValue.ToString();

            //thisView.lblTitle.Text = title;
        }

        private async void Tapcart_OnTapped(object sender, EventArgs e)
        {


            // Navigation.PushAsync(new CartDetailPage());


            // await Application.Current.MainPage.Navigation.PushModalAsync(new CartDetailPage());

            // await Navigation.PushModalAsync(new CartDetailPage());

            //  Application.Current.MainPage = new Xamarin.Forms.NavigationPage(new CartDetailPage());


            //var mp = new MasterDetailPage();
            //mp.Master = new MasterPage();
            //mp.Detail = new NavigationPage(new IndexPage());

            //Application.Current.MainPage = mp;

            //await mp.PushAsync(new CartDetailPage());



            var navPage = new NavigationPage(new MainPage());
            Application.Current.MainPage = navPage;

            await navPage.PushAsync(new CartDetailPage());


        }
    }

}