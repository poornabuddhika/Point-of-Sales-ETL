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
    class GRNRepo
    {

        private InventoryDBDataAccess iDB { get; set; }

        public GRNRepo()
        {
            this.iDB = new InventoryDBDataAccess();
        }


        public bool Save(GRN pro)
        {
            try
            {

                iDB.conOpen();

                var sql = @"INSERT INTO [dbo].[ST_GRN_Master] 
                            ([Ref_GRN_Doc_No], [Ref_Comp_ID], [Ref_Supplier], 
                            [Ref_WareHouse], [Ref_User_ID], [Gross_Value],[Net_Value],
                                [Disc_Rate], [Disc_Value], [Tax_Rate],
                                    [Tax_Value], [Remarks], [Log_ID1] , 
                            [GRN_Date], [Due_Date], [Log_Date],
                            [Payables], [Your_Ref_Num],[Status])
                           VALUES ('" + (pro.GRNNumber + 1) + "', '" + "ABC" + "', '" + pro.Supplier + "', " +
                                    "'" + pro.Location + "', '1', '" + pro.GrossValue + "', '" + pro.NetValue + "'," +
                                    "'" + (pro.DiscountRate / 100) + "', '" + pro.DiscountAmount + "', '" + pro.TaxesRate + "'," +
                                    " '" + pro.TaxesValue + "', '" + pro.Remarks + "', '" + "BOSS" + "'," +
                                    " '" + pro.GRNDate + "', '" + pro.DueDate + "', CURRENT_TIMESTAMP, " +
                                    "'" + pro.Payables + "', '" + pro.YourRefNumber + "','"+pro.Status.ToString()+"'); ";

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
        public bool DataExists( string yourRefNum)
        {
            try
            {

                DataSet ds = iDB.ExecuteQuery("SELECT * from ST_GRN_Master WHERE [Your_Ref_Num] = '" + yourRefNum + "' ");

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



        public Int32 DataCount()
        {
            try
            {
                iDB.conOpen();
                Int32 ds = iDB.SqlCount("SELECT COUNT(*) AS GRN_count from ST_GRN_Master");

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



        public bool UpdateDesableGIN(GRN pro)
        {
            try
            {

                string sql = @"update  [dbo].[ST_GRN_Master] SET pro.Status='false'  where  [Ref_GRN_Doc_No] ='" + pro.GRNNumber + "' ;";

                int count = this.iDB.ExecuteDMLQuery(sql);

                if (count == 1)
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
                Debug.WriteLine(e.ToString());
                throw;
            }
        }



    }
}
