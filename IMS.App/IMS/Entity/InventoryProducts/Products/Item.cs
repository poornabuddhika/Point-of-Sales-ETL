using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity.InventoryProducts
{
    public class Item
    {
        public int              ItemtId             { get; set; }
        public string           ItemIdTag          { get; set; }
        public string           ItemName           { get; set; }
        public int  BrandId               { get; set; }
        public string           ItemDescription    { get; set; }
        public double ItemQuantityPerUnit{ get; set; }
        public double ItemPerUnitPrice   { get; set; }
        public double ItemMSRP           { get; set; }
        public string           ProductStatus         { get; set; }
        public double ItemDiscountRate   { get; set; }
        public double ItemSize           { get; set; }
        public string           ItemColor          { get; set; }
       // public byte[]           ProductPictures       { get; set; }
        public double ItemWeight         { get; set; }
        public int           ItemUnitStock      { get; set; }

        //outside
        public string BrandName         { get; set; }
        public string VendorName        { get; set; }

        public string SubCategoryName{ get; set; }
        public string MainCategoryName  { get; set; }

        public virtual Brands Brand{ get; set; }
    }
}
