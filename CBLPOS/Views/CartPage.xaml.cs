using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using CBLPOS.Helpers;
using CBLPOS.Models;
using CBLPOS.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;

namespace CBLPOS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage : ContentPage
    {
        //   public ObservableCollection<ImageList> imgselect;

        public ObservableCollection<SizeList> sizeselect;
        public ObservableCollection<TypeList> typeselect;
        public ObservableCollection<ColorList> colorselect;
        public ObservableCollection<ItemList> itemLists;

        public ObservableCollection<CartList> cartLists;


        //   private IList<ImageList> selectedItemsImg = new List<ImageList>();

        private IList<SizeList> selectedItemsSize = new List<SizeList>();
        private IList<TypeList> selectedItemsType = new List<TypeList>();
        private IList<ColorList> selectedItemsCol = new List<ColorList>();
        private IList<ItemList> selectedItemsCart = new List<ItemList>();


        private bool _selectitempad;
        private int _selectitemindex;

        public static string iscreen = "";
        public static string iphoto = "";
        public static string icatalog = "";
        public static string msqreturn = "";
        public string idatabasename = "[CBL-POS]";

        //  public CartPageViewModel _ViewModel;


        public CartPage(string vscreen, string vcatalog, string vphoto)
        {

            iscreen = vscreen;
            icatalog = vcatalog;
            iphoto = vphoto;



            InitializeComponent();



            imageview.Source = ImageSource.FromUri(new Uri(iphoto));


            //  BindingContext = _ViewModel = new CartPageViewModel(iscreen, icatalog, msqreturn);


            btnselect.Clicked += Btnselect_Clicked;

        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        protected override void OnAppearing()
        {

            base.OnAppearing();

            // _ViewModel.GetData.Execute(null);


            NavigationBarView.FirstNameLabel.Text = GlobalClass.myGlobalClick.ToString();


            Getitem();

            ItemsListView.IsRefreshing = false;



        }


        void ListView_Refreshing(object sender, EventArgs e)
        {


            Getitem();

            ItemsListView.IsRefreshing = false;
        }



        void Btnselect_Clicked(object sender, EventArgs e)
        {


            msqreturn = CheckString();
            Getitem();
        }

        public async void Getitem()
        {


            itemLists = new ObservableCollection<ItemList>();

            //     cartLists = new ObservableCollection<CartList>();

            var items = await Helpers.Service.GetScreenList(iscreen, icatalog, msqreturn);

            var carts = await Helpers.Service.Getitemcart(GlobalClass.myGlobalIsession);




            if (items != null)
            {

                foreach (var item in items)
                {

                    itemLists.Add(item);


                    for (int i = 0; i < itemLists.Count; i++)
                    {
                        if (carts != null)
                        {

                            for (int j = 0; j < carts.Count; j++)
                            {

                                if (items[i].No_ == carts[j].Orders_tmp_Item_no)
                                {
                                    items[i].ButtonText = "Remove";
                                    items[i].Qty = carts[j].Orders_tmp_Qty;
                                    items[i].ColorText = "Red";
                                    break;

                                }

                                else
                                {
                                    items[i].ButtonText = "Add to cart";
                                    items[i].Qty = 1;
                                    items[i].ColorText = "Gray";
                                }

                            }

                        }


                        else
                        {

                            items[i].ButtonText = "Add to cart";
                            items[i].Qty = 1;
                            items[i].ColorText = "Gray";

                            //if (items[i].Status)
                            //{
                            //    items[i].ButtonText = "Remove";
                            //    items[i].Qty = 1;
                            //}

                            //else
                            //{
                            //    items[i].ButtonText = "Add to cart";
                            //    items[i].Qty = 1;
                            //    items[i].ColorText = "Gray";
                            //}

                        }
                    }

                }

                ItemsListView.ItemsSource = itemLists;






                sizeselect = new ObservableCollection<SizeList>();

                var sizeselectitem = await Helpers.Service.GetGroupSize(iscreen, icatalog);

                foreach (var item in sizeselectitem)
                {
                    sizeselect.Add(item);
                }
                SizeListView.ItemsSource = sizeselect;



                typeselect = new ObservableCollection<TypeList>();

                var typeselectitem = await Helpers.Service.GetGroupType(iscreen, icatalog);

                foreach (var item in typeselectitem)
                {
                    typeselect.Add(item);
                }

                TypeListView.ItemsSource = typeselect;




                colorselect = new ObservableCollection<ColorList>();

                var colselectitem = await Helpers.Service.GetGroupColor(iscreen, icatalog);

                foreach (var item in colselectitem)
                {
                    colorselect.Add(item);
                }
                ColorListView.ItemsSource = colorselect;


            }
            else await DisplayAlert("Product", "There are no items in the shop", "OK");




            //if (BtnIncrement.Text == "Remove")
            //{
            //    BtnIncrement.BackgroundColor = Color.Red;
            //}



            //if (items != null)
            //{

            //    foreach (var item in items)
            //    {

            //        itemLists.Add(item);


            //        if (carts != null)
            //        {
            //            for (int i = 0; i < itemLists.Count; i++)
            //            {

            //                for (int j = 0; j < carts.Count; j++)
            //                {

            //                    if (items[i].No_ == carts[j].Orders_tmp_Item_no)
            //                    {
            //                        items[i].ButtonText = "Remove";

            //                    }

            //                    else items[i].ButtonText = "Add to cart";
            //                }

            //            }

            //        }

            //        //  ItemsListView.ItemsSource = itemLists;



            //        else
            //        {

            //            for (int i = 0; i < itemLists.Count; i++)
            //            {

            //                if (items[i].Status)
            //                {
            //                    items[i].ButtonText = "Remove";
            //                }

            //                else
            //                {
            //                    items[i].ButtonText = "Add to cart";
            //                }

            //            }
            //        }
            //        //    ItemsListView.ItemsSource = itemLists;


            //    }

            //    ItemsListView.ItemsSource = itemLists;


            //}
            //else await DisplayAlert("Product", "There are no items in the shop", "OK");




        }


        public string CheckString()
        {


            string msg = "";

            int icounttype = 0;

            for (int i = 0; i < typeselect.Count; i++)
            {

                if (typeselect[i].IsSelected.Equals(true))
                {

                    icounttype += 1;

                    if (icounttype == 1)
                    {
                        msg += " AND ( ";
                        selectedItemsType.Add(typeselect[i]);
                        //  msg += idatabasename + ".[dbo].[item].[Item_type] = " + typeselect[i].Item_Type_Code;

                        msg += "SUBSTRING([Item No_], 1, 1) = " + typeselect[i].Item_Type_Code;

                        //SUBSTRING([Item No_], 1, 1)


                    }

                    if (icounttype > 1)
                    {

                        msg += " OR ";
                        selectedItemsType.Add(typeselect[i]);
                        // msg += idatabasename + ".[dbo].[item].[Item_type] = " + typeselect[i].Item_Type_Code;
                        msg += "SUBSTRING([Item No_], 1, 1) = " + typeselect[i].Item_Type_Code;


                    }

                }

                if (icounttype >= 1 && i == typeselect.Count - 1)
                {

                    msg += " )";

                }
            }



            int icountsize = 0;

            for (int i = 0; i < sizeselect.Count; i++)
            {


                if (sizeselect[i].IsSelected.Equals(true))

                {

                    icountsize += 1;


                    if (icountsize == 1)
                    {
                        msg += " AND ( ";
                        selectedItemsSize.Add(sizeselect[i]);
                   //     msg += idatabasename + ".[dbo].[item].[Item_size] = " + sizeselect[i].Item_Size_Code;
                        msg += "SUBSTRING([Item No_], 19, 2)=" + sizeselect[i].Item_Size_Code;

                    }


                    if (icountsize > 1)
                    {

                        msg += " OR ";
                        selectedItemsSize.Add(sizeselect[i]);
                        // msg += idatabasename + ".[dbo].[item].[Item_size] = " + sizeselect[i].Item_Size_Code;
                        msg += "SUBSTRING([Item No_], 19, 2)=" + sizeselect[i].Item_Size_Code;

                    }

                }

                if (icountsize >= 1 && i == sizeselect.Count - 1)
                {

                    msg += " )";

                }


            }





            int icountcolor = 0;

            for (int i = 0; i < colorselect.Count; i++)
            {



                if (colorselect[i].IsSelected.Equals(true))
                {

                    icountcolor += 1;
                    if (icountcolor == 1)
                    {
                        msg += " AND ( ";

                        selectedItemsCol.Add(colorselect[i]);
                     //   msg += idatabasename + ".[dbo].[item].[Item_color] = " + colorselect[i].Item_Color_Code;

                        msg += "SUBSTRING([Item No_], 3, 2)=" + colorselect[i].Item_Color_Code;

                    }


                    if (icountcolor > 1)
                    {

                        msg += " OR ";

                        selectedItemsCol.Add(colorselect[i]);
                        // msg += idatabasename + ".[dbo].[item].[Item_color] = " + colorselect[i].Item_Color_Code;
                        msg += "SUBSTRING([Item No_], 3, 2)=" + colorselect[i].Item_Color_Code;
                    }

                }

                if (icountcolor >= 1 && i == colorselect.Count - 1)
                {

                    msg += " )";


                }

            }



            return msg;

            // DisplayAlert("Item on selected = ", msg, "Close");

        }


        private void OnItemSizeSelected(object sender, SelectedItemChangedEventArgs args)
        {
            _selectitempad = true;
            _selectitemindex = sizeselect.IndexOf((SizeList)args.SelectedItem);
            sizeselect[_selectitemindex].IsSelected = sizeselect[_selectitemindex].IsSelected.Equals(true) ? false : true;

        }


        private void OnItemSizeTapped(object sender, ItemTappedEventArgs itemTappedEventArgs)
        {
            if (!_selectitempad && null != itemTappedEventArgs.Item)
            {
                sizeselect.IndexOf((SizeList)itemTappedEventArgs.Item);
                sizeselect[_selectitemindex].IsSelected = sizeselect[_selectitemindex].IsSelected.Equals(true) ? false : true;

            }



            SizeListView.ItemsSource = null;

            SizeListView.ItemsSource = sizeselect;

            _selectitempad = false;


        }


        private void OnItemTypeSelected(object sender, SelectedItemChangedEventArgs args)
        {
            _selectitempad = true;
            _selectitemindex = typeselect.IndexOf((TypeList)args.SelectedItem);
            typeselect[_selectitemindex].IsSelected = typeselect[_selectitemindex].IsSelected.Equals(true) ? false : true;

        }


        private void OnItemTypeTapped(object sender, ItemTappedEventArgs itemTappedEventArgs)
        {
            if (!_selectitempad && null != itemTappedEventArgs.Item)
            {
                typeselect.IndexOf((TypeList)itemTappedEventArgs.Item);
                typeselect[_selectitemindex].IsSelected = typeselect[_selectitemindex].IsSelected.Equals(true) ? false : true;

            }



            TypeListView.ItemsSource = null;

            TypeListView.ItemsSource = typeselect;

            _selectitempad = false;


        }


        private void OnItemColSelected(object sender, SelectedItemChangedEventArgs args)
        {
            _selectitempad = true;
            _selectitemindex = colorselect.IndexOf((ColorList)args.SelectedItem);
            colorselect[_selectitemindex].IsSelected = colorselect[_selectitemindex].IsSelected.Equals(true) ? false : true;

        }


        private void OnItemColTapped(object sender, ItemTappedEventArgs itemTappedEventArgs)
        {
            if (!_selectitempad && null != itemTappedEventArgs.Item)
            {
                colorselect.IndexOf((ColorList)itemTappedEventArgs.Item);
                colorselect[_selectitemindex].IsSelected = colorselect[_selectitemindex].IsSelected.Equals(true) ? false : true;

            }



            ColorListView.ItemsSource = null;

            ColorListView.ItemsSource = colorselect;

            _selectitempad = false;


        }



        private async void BtnIncrement_OnClicked(object sender, EventArgs e)
        {


            var button = sender as Button;

            Grid itemlistview = (Grid)button.Parent;

            Label label = (Label)itemlistview.Children[0];
            Label labelno = (Label)itemlistview.Children[1];
            //  Label labelstatus = (Label)itemlistview.Children[2];
            Entry entryqty = (Entry)itemlistview.Children[2];
            String item_name = label.Text;
            String item_no = labelno.Text;
            String item_qty = entryqty.Text;
            //  String item_status = labelstatus.Text;
            int iqty = Int32.Parse(item_qty);



            if (button != null)
            {
                if (button.Text == "Add to cart")
                {
                    button.Text = "Remove";
                    button.BackgroundColor = Color.Red;


                    GlobalClass.myGlobalClick += iqty;
                    await Helpers.Service.Addcart(GlobalClass.myGlobalIsession, item_no, item_name, item_qty);


                }
                else if (button.Text == "Remove")
                {
                    button.Text = "Add to cart";
                    button.BackgroundColor = Color.Gray;



                    GlobalClass.myGlobalClick -= iqty;


                    await Helpers.Service.Deletecart(GlobalClass.myGlobalIsession, item_no);


                }

            }


            NavigationBarView.FirstNameLabel.Text = GlobalClass.myGlobalClick.ToString();





        }




    }
}

