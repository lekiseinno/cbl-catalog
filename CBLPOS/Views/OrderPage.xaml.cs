using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CBLPOS.Models;
using Xamarin.Forms;

namespace CBLPOS.Views
{

    public partial class OrderPage : ContentPage
    {
        public ObservableCollection<OrderList> orderLists;

        public OrderPage()
        {

            InitializeComponent();

            Getitem();
        }


        public async void Getitem()
        {


            orderLists = new ObservableCollection<OrderList>();

            var items = await Helpers.Service.GetOrderAll();

            if (items != null)
            {
                foreach (var item in items)
                {
                    orderLists.Add(item);

                }
                OrderListview.ItemsSource = orderLists;
            }
            else await DisplayAlert("Product", "There are no items in the shop", "OK");




        }

    }
}
