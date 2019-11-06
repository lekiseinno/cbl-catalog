using System;
using System.Collections.Generic;
using CBLPOS.Helpers;
using CBLPOS.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CBLPOS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {

        private string myStringProperty;
        public string MyStringProperty
        {
            get { return myStringProperty; }
            set
            {
                myStringProperty = value;
                OnPropertyChanged(nameof(MyStringProperty)); // Notify that there was a change on this property
            }
        }


        public MasterPage()
        {
            InitializeComponent();

            BindingContext = this;

            MyStringProperty = "Hello," + GlobalClass.myGlobalEmployeename;

            var menus = new List<MasterPageItem>();

            menus.Add(new MasterPageItem { Id = 1, Title = "Home", ImageName = "home" });
            menus.Add(new MasterPageItem { Id = 2, Title = "Cart", ImageName = "Cart" });
            menus.Add(new MasterPageItem { Id = 3, Title = "Order", ImageName = "order" });
            menus.Add(new MasterPageItem { Id = 4, Title = "Customer", ImageName = "customers" });



            menus.Add(new MasterPageItem { Id = 99, Title = "Logout", ImageName = "logout" });

            listView.ItemsSource = menus;

            listView.ItemTapped += ListView_ItemTapped;

        }




        async private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var menu = e.Item as MasterPageItem;
            var mp = Parent as MasterDetailPage;

            switch (menu.Id)
            {
                case 1:
                    mp.Detail = new NavigationPage(new IndexPage());
                    break;
                case 2:
                    mp.Detail = new NavigationPage(new CartDetailPage());
                    break;
                case 3:
                    mp.Detail = new NavigationPage(new OrderPage());
                    break;
                case 4:
                    mp.Detail = new NavigationPage(new CustomerPage());
                    break;


                case 99:
                    var result = await DisplayActionSheet("Confirm?", "Cancel", null, "Logout");

                    if (result == "Logout")
                    {
                        //Helpers.Settings.IsLoggedIn = false;

                        var app = mp.Parent as App;
                        app.MainPage = new LoginPage();

                    }

                    break;

                default:
                    break;
            }

            listView.SelectedItem = null;

            mp.IsPresented = false; //เป็นคำสั่งปิดเมนู

        }
    }
}