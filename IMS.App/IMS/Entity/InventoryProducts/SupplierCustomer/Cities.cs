using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMS.App.IMS.Entity.InventoryProducts.SupplierCustomer
{
    class Cities
    {
        public int id { get; set; }
        public int district_id { get; set; }
        public string name_en { get; set; }
        public string name_si { get; set; }
        public string name_ta { get; set; }
        public string sub_name_en { get; set; }
        public string sub_name_si { get; set; }
        public string sub_name_ta { get; set; }
        public string postcode { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }


    }
}
