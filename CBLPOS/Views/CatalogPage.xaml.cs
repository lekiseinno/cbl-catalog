using System;
using System.Collections.Generic;
using CBLPOS.ViewModels;
using Xamarin.Forms;
using Xamvvm;

namespace CBLPOS.Views
{
    public partial class CatalogPage : ContentPage
    {
        public static string ifloder = "";

        public CatalogPageModel _ViewModel;


        public CatalogPage(string vfloder)
        {
            ifloder = vfloder;


            InitializeComponent();



            BindingContext = _ViewModel = new CatalogPageModel(ifloder);



        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            _ViewModel.GetData.Execute(null);
        }


    }
}