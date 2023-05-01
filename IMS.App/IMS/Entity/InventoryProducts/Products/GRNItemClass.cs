using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMS.Entity
{
    class GRNItemClass
    {
       public string GRN_Detail_ID { get; set; }
        public string Ref_GRN_Master_ID { get; set; }
        public string Type { get; set; }
        public string Sub_Type { get; set; }
        public string Item_ID { get; set; }
        public float DisCount_Rate { get; set; }
        public float Ref_Master_DisCount_Rate { get; set; }
        public float Tax_Rate { get; set; }
        public float Ref_Qty1 { get; set; }
        public DateTime Eff_date { get; set; }
        public string Ref_Desc { get; set; }
        public decimal AvgCost { get; set; }

        public bool Status { get; set; }

        public decimal MRP { get; set; }


    }
}
