using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity.InventoryProducts
{
    public class SubCategories
    {
        
        public string SubCategoryName { get; set; }
        public string MainCategoryName { get; set; }
        
        public string     SubCategoryDescription{ get; set; }

        public bool SubCategoryIsActivate { get; set; }

        public int SubCategoryId { get; set; }

        public byte[]     SecondCategoryImage      { get; set; }

        //OutSide
        
        public int MainCategoryId { get; set; }

        public virtual MainCategories               MainCategory   { get; set; }
        

    }
}
