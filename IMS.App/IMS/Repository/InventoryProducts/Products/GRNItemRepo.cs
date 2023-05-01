using IMS.DataAccess;
using IMS.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace IMS.Repository
{
    class GRNItemRepo
    {

        private InventoryDBDataAccess iDB { get; set; }

        public GRNItemRepo()
        {
            this.iDB = new InventoryDBDataAccess();
        }


        public bool Save(GRNItemClass pro)
        {
            try
            {

                iDB.conOpen();

                var sql = @"INSERT INTO [dbo].[ST_GRN_Item_Detail] (
                                [GRN_Detail_ID]  ,
                                [Ref_GRN_Master_ID]  ,
                                [Type] ,
                                [Sub_Type],
                                [Item_ID],
                                [Ref_Master_DisCount_Rate] ,
                                [Item_DisCount_Rate],
                                [Tax_Rate],
                                [Ref_Qty1] ,
                                [Eff_date],
                                [Ref_Desc],
                                [AvgCost], 
                                [Status],
                                [MRP]
                                )
                           VALUES ('" + pro.GRN_Detail_ID + "', '"+pro.Ref_GRN_Master_ID+"','"+pro.Type+"' ,'"+pro.Sub_Type+"', '"+pro.Item_ID+"','"+pro.Ref_Master_DisCount_Rate+"' ,"+
                                "'"+ pro.DisCount_Rate + "','"+pro.Tax_Rate+"','"+pro.Ref_Qty1 +"','"+pro.Eff_date+"','"+ pro.Ref_Desc+"','"+pro.AvgCost+"', '"+pro.Status+"','"+pro.MRP+"'); ";

                var rowCount = this.iDB.ExecuteDMLQuery(sql);

                if (rowCount == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
        }


        //DataCount - DataExists
        public bool GINItemDataExists(string yourRefNum)
        {
            try
            {

                DataSet ds = iDB.ExecuteQuery("SELECT * from ST_GRN_Item_Detail WHERE [GRN_Master_ID] = '" + yourRefNum + "' ");

                //System.Windows.MessageBox.Show(ds.Tables[0].Rows.Count);
                Debug.WriteLine(ds.Tables[0].Rows.Count);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                throw;

                return false;
            }
        }



        public Int32 GRNItemDataCount()
        {
            try
            {
                iDB.conOpen();
                Int32 ds = iDB.SqlCount("SELECT COUNT(*) AS GRN_Item_count from ST_GRN_Item_Detail");

                //System.Windows.MessageBox.Show(ds.Tables[0].Rows.Count);
                Debug.WriteLine(ds);

                if (ds > 0)
                {
                    return ds;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                throw;

                return 0;
            }
        }





    }
}
