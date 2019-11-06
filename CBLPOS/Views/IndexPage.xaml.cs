using System;
using System.Collections.Generic;
using CBLPOS.ViewModels;
using Xamarin.Forms;

namespace CBLPOS.Views
{
    public partial class IndexPage : ContentPage
    {
        public IndexPageViewModel _ViewModel;

        public IndexPage()
        {


            InitializeComponent();

            BindingContext = _ViewModel = new IndexPageViewModel();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();


            _ViewModel.GetData.Execute(null);
        }



    }
}
