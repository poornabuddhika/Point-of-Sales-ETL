using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity.InventoryProducts
{
    public class Unit
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; }

        public string UnitCode { get; set; }

        public bool IsActive { get; set; }



    }
}
