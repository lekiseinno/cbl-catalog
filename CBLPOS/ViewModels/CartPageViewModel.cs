using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmHelpers;
using CBLPOS.Helpers;
using Xamarin.Forms;
using CBLPOS.Models;

namespace CBLPOS.ViewModels
{
    public class CartPageViewModel : BaseViewModel
    {

        public static string iscreen = "";
        public static string icatalog = "";
        public static string imsqreturn = "";

        public ObservableRangeCollection<ItemList> ShoppingItems { get; } = new ObservableRangeCollection<ItemList>();

        public string cartCounter;

        public string CartCounter
        {
            get { return cartCounter; }
            set { SetProperty(ref cartCounter, value); }
        }

        public string buttonText;

        public string ButtonText
        {
            get { return buttonText; }
            set { SetProperty(ref buttonText, value); }
        }

        public Command GetData { get; set; }

        public Command OnItemButtonClickedCommand { get; set; }



        public CartPageViewModel(string vscreen, string vcatalog, string vmsqreturn)
        {

            iscreen = vscreen;
            icatalog = vcatalog;
            imsqreturn = vmsqreturn;

            GetData = new Command(async () => await GetDataCommand());


            OnItemButtonClickedCommand = new Command((e) => ExecuteButtonClick(e));
        }

        private void ExecuteButtonClick(Object e)
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var selectedItem = (ItemList)e;

                List<ItemList> ItemsList = new List<ItemList>(ShoppingItems);

                // var index = selectedItem.Index;

                //for (int i = 0; i < ItemsList.Count; i +)
                //{
                //    if (index == i)
                //        Settings.ItemStatus = !Settings.ItemStatus;
                //}



                CartCounter = GenericMethods.CartCount().ToString();

                ShoppingItems.Clear();

                //if (selectedItem.Status)
                //    ItemsList[index - 1].ButtonText = "Add to cart";
                //else
                //    ItemsList[index - 1].ButtonText = "Remove";

                //selectedItem.Status = !selectedItem.Status;

                ShoppingItems.ReplaceRange(ItemsList);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception is " + ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task GetDataCommand()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;

                List<ItemList> ItemsList = await Helpers.Service.GetScreenList(iscreen, icatalog, imsqreturn);


                //for (int i = 0; i < ItemsList.Count; i++)
                //{
                //    if (ItemsList[i].Status)

                //        ItemsList[i].ButtonText = "Remove";
                //    else
                //        ItemsList[i].ButtonText = "Add to cart";
                //}


                ShoppingItems.Clear();

                ShoppingItems.ReplaceRange(ItemsList);

                CartCounter = GenericMethods.CartCount().ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception is : " + e);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}