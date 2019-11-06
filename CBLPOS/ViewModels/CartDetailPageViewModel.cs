using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CBLPOS.Helpers;
using CBLPOS.Models;
using Microsoft.AppCenter.Analytics;
using MvvmHelpers;
using Xamarin.Forms;

namespace CBLPOS.ViewModels
{
    public class CartDetailPageViewModel : BaseViewModel
    {


        public ObservableRangeCollection<CartList> Shopingcarts { get; } = new ObservableRangeCollection<CartList>();

        public bool itemsInCart;

        public bool ItemsInCart
        {
            get { return itemsInCart; }
            set { SetProperty(ref itemsInCart, value); }
        }



        public bool noItemsInCart;

        public bool NoItemsInCart
        {
            get { return noItemsInCart; }
            set { SetProperty(ref noItemsInCart, value); }
        }


        public Command GetData { get; set; }

        public CartDetailPageViewModel()
        {



            GetData = new Command(async () => await GetDataCommand());

        }


        private async Task GetDataCommand()
        {

            var cartlist = await Helpers.Service.Getitemcart(GlobalClass.myGlobalIsession);

            List<CartList> CartList;

            if (cartlist == null)
            {

                Shopingcarts.Clear();


                NoItemsInCart = true;
                ItemsInCart = false;

            }
            else
            {
                CartList = cartlist;
                SetItems(CartList);
                Shopingcarts.ReplaceRange(CartList);

            }




        }




        public Command<CartList> RemoveCommand
        {
            get
            {
                return new Command<CartList>(async (CartList) =>
                {

                    Shopingcarts.Remove(CartList);

                    await Helpers.Service.Deletecart(CartList.Orders_tmp_session, CartList.Orders_tmp_Item_no);

                    //  GlobalClass.myGlobalClick = GlobalClass.myGlobalClick - CartList.Orders_tmp_Qty;

                    GetQty();

                });
            }
        }


        public Command<CartList> UpdateCommand
        {
            get
            {
                return new Command<CartList>(async (CartList) =>
                {


                    await Helpers.Service.Updatecart(CartList.Orders_tmp_session, CartList.Orders_tmp_Item_no, CartList.Orders_tmp_Qty.ToString());

                    GetQty();

                    //  GlobalClass.myGlobalClick = GlobalClass.myGlobalClick + CartList.Orders_tmp_Qty;


                });
            }
        }




        public void GetQty()
        {
            int gtotal = 0;

            foreach (CartList lstItem in Shopingcarts)
            {
                gtotal += lstItem.Orders_tmp_Qty;

            }
            GlobalClass.myGlobalClick = gtotal;

        }



        public void SetItems(List<CartList> CartList)
        {
            if (CartList.Count > 0)
            {
                ItemsInCart = true;
                NoItemsInCart = false;

            }
            else
            {

                ItemsInCart = false;
                NoItemsInCart = true;


            }
        }




    }





}
