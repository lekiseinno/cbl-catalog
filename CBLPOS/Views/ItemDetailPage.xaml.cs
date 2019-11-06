using System;
using System.Collections.Generic;
using CBLPOS.Models;
using CBLPOS.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CBLPOS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        private ItemDetailPageViewModel _viewModel;

        public ItemDetailPage(ItemList ShoppingItem)
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemDetailPageViewModel(ShoppingItem);
        }
    }
}
