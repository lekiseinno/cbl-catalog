using System;
namespace CBLPOS.Models
{
    public class OrderList
    {
        public string Orders_No { get; set; }

        public DateTime Orders_Date
        {
            get;
            set;
        }
        public string emp_code { get; set; }
        public string emp_name { get; set; }
        public string Customer_code { get; set; }
        public string Customer_name { get; set; }
        public double Orders_Price { get; set; }
        public int Orders_Qty { get; set; }
        public string Orders_Status { get; set; }


    }
}
