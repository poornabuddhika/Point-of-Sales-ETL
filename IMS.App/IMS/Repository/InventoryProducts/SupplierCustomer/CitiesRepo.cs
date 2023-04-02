using IMS.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IMS.Repository
{
    class CitiesRepo
    {

        private InventoryDBDataAccess iDB { get; set; }

        public CitiesRepo()
        {
            this.iDB = new InventoryDBDataAccess();
        }







        //LoadComboBox
        public DataTable Loadcities()
        {
            string sql;
            try
            {
                sql = @"SELECT id, name_en FROM cities ORDER BY id ASC";
                return this.iDB.ExecuteQueryTable(sql);
            }
            catch (Exception e)
            {
                throw;
            }
        }



    }
}
