using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity.InventoryProducts
{
    public class Item
    {
        public string    ItemtId    { get; set; }
       
        public string    ItemName           { get; set; }

        public string Barcode { get; set; }

        public string DescriptionOne { get; set; }

        public string DescriptionTwo { get; set; }

        public string PurchaseUnit { get; set; }

        public string SellingUnit { get; set; }

        public string SellingPrice { get; set; }

        
        public double Cost { get; set; }

        public string MRP { get; set; }

        public string Supplier { get; set; }

        public double PacketSize { get; set; }

        public string RackNumber { get; set; }

        public string CategoryName { get; set; }

        public string subCategory { get; set; }

        public string brands { get; set; }

        public double ProductQty { get; set; }

        public double DisCount { get; set; }

        public double DiscountAmount { get; set; }

        public double WeightItem { get; set; }

        public double ServeItem { get; set; }


        public string OptionOne { get; set; }


        public string OptionTwo { get; set; }


        public bool IsActive { get; set; }


        public List<string> ErrorList { get; set; }


    }
}
