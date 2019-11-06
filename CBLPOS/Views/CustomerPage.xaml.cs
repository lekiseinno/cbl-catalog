using System;
using System.Collections.Generic;
using System.Linq;
using CBLPOS.Helpers;
using CBLPOS.Models;
using MvvmHelpers;
using Xamarin.Forms;

namespace CBLPOS.Views
{
    public partial class CustomerPage : ContentPage
    {
        public List<Customer> tempdata;
        public CustomerPage()
        {
            InitializeComponent();


            btnselect.Clicked += Btnselect_Clicked;
        }

        async void Btnselect_Clicked(object sender, EventArgs e)
        {

            GlobalClass.myGlobalCustomer = lblcus_Code.Text;
            GlobalClass.myGlobalCustomername = lblcus_name.Text;

            //var masterDetailPage = Application.Current.MainPage as MasterDetailPage;
            //if (masterDetailPage != null)
            //{
            //    masterDetailPage.Detail = new NavigationPage(new CoverPage());

            //}

            // await Navigation.PushModalAsync(new MainPage());

            await Navigation.PopModalAsync();

        }




        protected async override void OnAppearing()
        {
            base.OnAppearing();



            tempdata = await Helpers.Service.GetCustomer();

            CustomerListView.ItemsSource = tempdata;
        }



        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            //thats all you need to make a search  

            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                CustomerListView.ItemsSource = tempdata;
            }

            else
            {


                CustomerListView.ItemsSource = tempdata.Where(x => x.Customer_Fname.StartsWith(e.NewTextValue) || x.Customer_Tel.StartsWith(e.NewTextValue) || x.Customer_IDCard.StartsWith(e.NewTextValue));


            }
        }


        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {

            var item = (Customer)e.SelectedItem;


            lblcus_Code.Text = item.Customer_code;
            lblcus_name.Text = item.Customer_Fname + " " + item.Customer_Lname;
            lblcus_IDCard.Text = item.Customer_IDCard;
            lblcus_Tel.Text = item.Customer_Tel;
            lblcus_Email.Text = item.Customer_Email;
            lblcus_Region.Text = item.Customer_region;

        }
       
    }
}