using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity.InventoryProducts
{
    public class MainCategories
    {
        public string MainCategoryCode { get; set; }
        public string MainCategoryName { get; set; }
        public string MainCategoryDescription { get; set; }
        public string MainCategoryStockCover { get; set; }

        public bool MainCategoryIsActivate { get; set; }

        public virtual ICollection<SecondCategories> SecondCategories{ get; set; }
    }
}
