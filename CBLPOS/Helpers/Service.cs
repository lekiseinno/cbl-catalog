using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CBLPOS.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CBLPOS.Helpers
{
    public static class Service
    {

        private static Uri BaseAddress = new Uri("http://10.10.2.31");


   //     private static Uri BaseAddress = new Uri("http://lekise.dyndns.biz");




        public static async Task<ImageList> GetImageList(string ifolder)
        {

            var requestUri = "http://10.10.2.31:8081/CBL-POS/images/readdir.php?folder=" + ifolder;

          //  var requestUri = "http://lekise.dyndns.biz:8081/CBL-POS/images/readdir.php?folder=" + ifolder;


            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync(requestUri);
                return JsonConvert.DeserializeObject<ImageList>(result);
            }
        }





        public static async Task<List<ItemList>> GetScreenList(string iscreen, string icatalog, string imsg)
        {

            var param = new Dictionary<string, string>();
            param.Add("Item_screen", iscreen);
            param.Add("Item_Category_Code", icatalog);
            param.Add("text", imsg);

            var content = new FormUrlEncodedContent(param);

            var client = new HttpClient();
            client.BaseAddress = BaseAddress;
            var response = await client.PostAsync("api/caballo/products/get_screen", content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                if (json != "null")
                {
                    var items = JArray.Parse(json).ToObject<List<ItemList>>();
                    return items;
                }
                else return null;
            }
            else return null;
        }


        public static async Task<List<SizeList>> GetGroupSize(string iscreen, string icatalog)
        {

            var param = new Dictionary<string, string>();
            param.Add("Item_screen", iscreen);
            param.Add("Item_Category_Code", icatalog);


            var content = new FormUrlEncodedContent(param);

            var client = new HttpClient();
            client.BaseAddress = BaseAddress;


            var response = await client.PostAsync("api/caballo/products/group_size", content);


            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                if (json != "null")
                {
                    var items = JArray.Parse(json).ToObject<List<SizeList>>();
                    return items;
                }
                else return null;
            }
            else return null;
        }



        public static async Task<List<TypeList>> GetGroupType(string iscreen, string icatalog)
        {

            var param = new Dictionary<string, string>();
            param.Add("Item_screen", iscreen);
            param.Add("Item_Category_Code", icatalog);


            var content = new FormUrlEncodedContent(param);

            var client = new HttpClient();
            client.BaseAddress = BaseAddress;
            var response = await client.PostAsync("api/caballo/products/group_type", content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                if (json != "null")
                {
                    var items = JArray.Parse(json).ToObject<List<TypeList>>();
                    return items;
                }
                else return null;
            }
            else return null;
        }

        public static async Task<List<ColorList>> GetGroupColor(string iscreen, string icatalog)
        {

            var param = new Dictionary<string, string>();
            param.Add("Item_screen", iscreen);
            param.Add("Item_Category_Code", icatalog);


            var content = new FormUrlEncodedContent(param);

            var client = new HttpClient();
            client.BaseAddress = BaseAddress;
            var response = await client.PostAsync("api/caballo/products/group_color", content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();

                if (json != "null")
                {
                    var items = JArray.Parse(json).ToObject<List<ColorList>>();
                    return items;
                }
                else return null;



            }
            else return null;
        }

        //add item to cart CartPage

        public static async Task<bool> Addcart(string isession, string iitemno, string iitemname, string iitemqty)
        {

            var param = new Dictionary<string, string>();


            param.Add("item_No", iitemno);
            param.Add("item_Desc", iitemname);
            param.Add("session", isession);
            param.Add("item_Qty", iitemqty);

            var content = new FormUrlEncodedContent(param);

            var client = new HttpClient();
            client.BaseAddress = BaseAddress;
            var response = await client.PostAsync("api/caballo/addtocart", content);

            return response.StatusCode == HttpStatusCode.OK;
        }


        public static async Task<bool> Updatecart(string isession, string iitemno, string iitemqty)
        {

            var param = new Dictionary<string, string>();


            param.Add("item_No", iitemno);
            param.Add("session", isession);
            param.Add("item_Qty", iitemqty);

            var content = new FormUrlEncodedContent(param);

            var client = new HttpClient();
            client.BaseAddress = BaseAddress;
            var response = await client.PostAsync("api/caballo/updatetocart", content);

            return response.StatusCode == HttpStatusCode.OK;
        }

        public static async Task<bool> Deletecart(string isession, string iitemno)
        {

            var param = new Dictionary<string, string>();


            param.Add("session", isession);
            param.Add("item_No", iitemno);


            var content = new FormUrlEncodedContent(param);

            var client = new HttpClient();
            client.BaseAddress = BaseAddress;
            var response = await client.PostAsync("api/caballo/deletetocart", content);

            return response.StatusCode == HttpStatusCode.OK;
        }



        public static async Task<bool> DeleteAllcart(string isession)
        {

            var param = new Dictionary<string, string>();


            param.Add("session", isession);


            var content = new FormUrlEncodedContent(param);

            var client = new HttpClient();
            client.BaseAddress = BaseAddress;
            var response = await client.PostAsync("api/caballo/deletesession", content);

            return response.StatusCode == HttpStatusCode.OK;
        }


        // get item จาก server โดยใช้ session  Cartdetailpage

        public static async Task<List<CartList>> Getitemcart(string isession)
        {

            var param = new Dictionary<string, string>();


            param.Add("session", isession);


            var content = new FormUrlEncodedContent(param);

            var client = new HttpClient();
            client.BaseAddress = BaseAddress;
            var response = await client.PostAsync("api/caballo/getitemcart", content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                if (json != "null")
                {
                    var items = JArray.Parse(json).ToObject<List<CartList>>();
                    return items;
                }
                else return null;
            }

            else return null;

        }



        public static async Task<List<OrderList>> GetOrderAll()
        {


            var client = new HttpClient();
            client.BaseAddress = BaseAddress;
            var response = await client.GetAsync("api/caballo/orders_sum");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                if (json != "null")
                {
                    var items = JArray.Parse(json).ToObject<List<OrderList>>();
                    return items;
                }
                else return null;
            }


            else return null;

        }




        //Get Customer CartDetailPage

        public static async Task<List<Customer>> GetCustomer()
        {

            var client = new HttpClient();
            client.BaseAddress = BaseAddress;
            var response = await client.GetAsync("api/caballo/customers");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                if (json != "null")
                {
                    var customers = JArray.Parse(json).ToObject<List<Customer>>();
                    return customers;
                }
                else return null;

            }

            else return null;
        }


        //Get Employee CartDetailPage


        public static async Task<Employee> AuthenUser(string username, string password)
        {
            var param = new Dictionary<string, string>();
            param.Add("emp_username", username);
            param.Add("emp_password", password);

            var content = new FormUrlEncodedContent(param);

            var client = new HttpClient();
            client.BaseAddress = BaseAddress;

            var response = await client.PostAsync("api/caballo/auth", content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();

                if (json != "null")
                {
                    return JObject.Parse(json).ToObject<Employee>();
                }
                else return null;

            }
            else return null;
        }




        public static async Task<List<Employee>> GetEmployee()
        {

            var client = new HttpClient();
            client.BaseAddress = BaseAddress;
            var response = await client.GetAsync("api/caballo/employees");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                var employees = JArray.Parse(json).ToObject<List<Employee>>();
                return employees;
            }
            else return null;
        }



        // confirm Order head & Datail CartPageDatail


        public static async Task<bool> ConfirmOrders(string icustomer_code, string isession, string iemployee_code)
        {

            var param = new Dictionary<string, string>();

            param.Add("customer_code", icustomer_code);
            param.Add("employee_code", iemployee_code);
            param.Add("session", isession);

            var content = new FormUrlEncodedContent(param);

            var client = new HttpClient();
            client.BaseAddress = BaseAddress;
            var response = await client.PostAsync("api/caballo/confirm_orders", content);

            return response.StatusCode == HttpStatusCode.OK;
        }



        //public static async Task<bool> ConfirmOrderDetail(ItemDetails cartList)
        //{


        //    //ArrayList paramList = new ArrayList();
        //    //CartList cartLists = cartList;

        //    //paramList.Add(cartList);
        //    var param = new Dictionary<string, string>();

        //    param.Add("item_No", cartList.Item_No);
        //    param.Add("item_Qty", cartList.Orders_detail_Qty.ToString());


        //    var content = new FormUrlEncodedContent(param);
        //    // var content = JsonConvert.SerializeObject(param);

        //    var client = new HttpClient();
        //    client.BaseAddress = BaseAddress;
        //    var response = await client.PostAsync("api/caballo/confirm_orders/detail", content);

        //    return response.StatusCode == HttpStatusCode.OK;
        //}


    }
}
