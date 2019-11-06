using System;
using CBLPOS.Views;
using DLToolkit.Forms.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace CBLPOS
{
    public partial class App : Application
    {
        public App()
        {
            FlowListView.Init();

            InitializeComponent();


            // bp = new NavigationPage(new CartDetailPage());

            MainPage = new LoginPage();







            //var mp = new MasterDetailPage();
            //mp.Master = new MenuPage();
            //mp.Detail = new NavigationPage(new MainPage());
            //MainPage = mp;
        }



        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
