using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMS.Entity.InventoryProducts
{
    class Supplier
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Credit_Period { get; set; }

        public decimal Credit_Amount { get; set; }

        public string Office_Phone_number { get; set; }

        public string Mobile_Number { get; set; }

        public string Email { get; set; }


        public string Fax { get; set; }


        public string Contact_Person { get; set; }

        public string City { get; set; }

        public string Comment { get; set; }

        public bool IsActive { get; set; }


        public List<string> ErrorList { get; set; }

    }
}
