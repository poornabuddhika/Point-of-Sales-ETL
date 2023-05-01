using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMS.Entity
{
    class GRN
    {

        public int Location { get; set; }

        public string Supplier { get; set; }

        public string Address { get; set; }

        public string Remarks { get; set; }

        public Int32 GRNNumber { get; set; }

        public DateTime GRNDate { get; set; }

        public string OurRefNumber { get; set; }


        public string GRNRefarance { get; set; }

        public string YourRefNumber { get; set; }


        public decimal Payables { get; set; }


        public DateTime DueDate { get; set; }


        public decimal GrossValue { get; set; }

        public decimal NetValue { get; set; }

        public decimal TaxesRate { get; set; }

        public decimal TaxesValue { get; set; }

        public decimal DiscountRate { get; set; }

        public decimal DiscountAmount { get; set; }

       

        public List<string> ErrorList { get; set; }


    }
}
