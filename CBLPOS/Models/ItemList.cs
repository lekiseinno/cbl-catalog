using System;
using System.Collections.Generic;

namespace CBLPOS.Models
{
    public class ItemList
    {
        //  public int Count { get; internal set; }
        public string No_ { get; set; }
        public string Description { get; set; }
        public string Item_type { get; set; }
        public string Item_screen { get; set; }
        public string Item_size { get; set; }
        // public bool Status { get; set; }
        public string ButtonText { get; set; }
        public int Qty { get; set; }
        public string ColorText { get; set; }

    }

    public class CartList
    {
        public string Orders_tmp_session { get; set; }
        public string Orders_tmp_Item_no { get; set; }
        public string Orders_tmp_Descriptions { get; set; }
        public int Orders_tmp_Qty { get; set; }
        public string Orders_tmp_Status { get; set; }
    }




    //public class Order
    //{
    //    // [Key]
    //    public int OrderId { get; set; }
    //    public string CustomerName { get; set; }
    //    public ICollection<ItemDetails> Details { get; set; }
    //}

    //public class ItemDetails
    //{
    //    //  [Key]
    //    public string Item_No { get; set; }

    //    public int Orders_detail_Qty { get; set; }

    //    // public Order Order { get; set; }
    //}

}

