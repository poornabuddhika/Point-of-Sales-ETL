using IMS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMS.Repository;

namespace IMS.App
{
    class GRNFormClass
    {
        public decimal itemTotal(decimal qty,decimal price,decimal presentage)
        {
            return (qty * price) - (((qty * price) * presentage) / 100);
        }

        public decimal AddGrossValue(decimal inputVal,decimal outPutValue)
        {
            return outPutValue = outPutValue + inputVal;
        }


        public string GridValueTot(DataGridView dataGridViewGRN)
        {
            decimal total = 0;

            int rowCount = dataGridViewGRN.RowCount - 1;
            for (int i = 0; i < rowCount; i++)
            {
                total = Convert.ToDecimal(dataGridViewGRN.Rows[i].Cells[5].Value) + total;
            }

            return Math.Round(total, 2).ToString();
        }



        public void SaveItemByItem(List<GRNItemClass> gRNItemList,GRNItemRepo gRNItemRepo)
        {
            foreach(GRNItemClass gRNItemClass in  gRNItemList)
            {
                 Int32 itemCount=gRNItemRepo.GRNItemDataCount();
                gRNItemClass.GRN_Detail_ID = itemCount.ToString();
                gRNItemRepo.Save(gRNItemClass);


            }
        }



    }
}
