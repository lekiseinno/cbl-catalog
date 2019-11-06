using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CBLPOS.Helpers;
using CBLPOS.Models;
using CBLPOS.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CBLPOS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class CartDetailPage : ContentPage
    {
        public CartDetailPageViewModel _ViewModel;

        public CartDetailPage()
        {

            InitializeComponent();


            BindingContext = _ViewModel = new CartDetailPageViewModel();


            btnRemoveAll.Clicked += BtnRemoveAll_Clicked;
            btnConfirm.Clicked += BtnConfirm_ClickedAsync;


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            lblcusname.Text = GlobalClass.myGlobalCustomername;

            lblempname.Text = GlobalClass.myGlobalEmployeename;

            _ViewModel.GetData.Execute(null);
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        async void BtnConfirm_ClickedAsync(object sender, EventArgs e)
        {

            var isOk = await DisplayAlert("Confirm Order", "Do you want to save?", "Yes", "No");



            if (isOk)
            {


                if (GlobalClass.myGlobalCustomer != "")

                {
                    indicator.IsVisible = true;

                    var CfOrder = await Helpers.Service.ConfirmOrders(GlobalClass.myGlobalCustomer, GlobalClass.myGlobalIsession, GlobalClass.myGlobalEmployee);


                    indicator.IsVisible = false;

                    if (CfOrder == true) //ถ้า Insert ได้ ค่าจะเป็น 1
                    {
                        await DisplayAlert("Completed", "Create Order success", "OK");


                        await Navigation.PushModalAsync(new MainPage());
                    }
                    else await DisplayAlert("Warning", "Something wrong", "OK");

                }

                else
                {
                    await DisplayAlert("Warning", "Please select a customer.", "OK");



                    await Navigation.PushModalAsync(new CustomerPage());

                }



            }



        }


        async void BtnRemoveAll_Clicked(object sender, EventArgs e)
        {


            var isOk = await DisplayAlert("Cancel Order", "Do you want to cancel All?", "Yes", "No");
            if (isOk)
            {

                await Helpers.Service.DeleteAllcart(GlobalClass.myGlobalIsession);
                GlobalClass.myGlobalClick = 0;

                var cartList = new List<CartList>();
                ItemsListView.ItemsSource = cartList;
                cartList.Clear();


                await Navigation.PushModalAsync(new MainPage());

            }

            else
            {
                await Navigation.PopModalAsync();
            }



        }



        private void BtnRemove_OnClicked(object sender, EventArgs e)
        {


            var button = sender as Button;
            var product = button.BindingContext as CartList;
            var vm = BindingContext as CartDetailPageViewModel;
            vm.RemoveCommand.Execute(product);

        }

        private void BtnUpdate_OnClicked(object sender, EventArgs e)
        {


            var button = sender as Button;
            var product = button.BindingContext as CartList;
            var vm = BindingContext as CartDetailPageViewModel;
            vm.UpdateCommand.Execute(product);


            DisplayAlert("Update", "Success", "OK");

        }

        //private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    ((ListView)sender).SelectedItem = null;
        //}


    }



}
