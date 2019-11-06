using System;
using System.Collections.Generic;
using CBLPOS.ViewModels;
using Xamarin.Forms;

namespace CBLPOS.Views
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();


        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            NavigationPage.SetHasNavigationBar(this, false);


        }


    }




}

