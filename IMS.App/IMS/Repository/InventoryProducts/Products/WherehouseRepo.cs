using IMS.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IMS.Repository
{
    class WherehouseRepo
    {
        private InventoryDBDataAccess iDB { get; set; }

        public WherehouseRepo()
        {
            this.iDB = new InventoryDBDataAccess();
        }



        public DataTable LoadComboWherehouseName()
        {
            string sql;
            try
            {
                sql = @"SELECT wherehouse_ID, wherehouse_Name FROM wherehouse";
                return this.iDB.ExecuteQueryTable(sql);
            }
            catch (Exception e)
            {
                throw;
            }
        }


    }
}
