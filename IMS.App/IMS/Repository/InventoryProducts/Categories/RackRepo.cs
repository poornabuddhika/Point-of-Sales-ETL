using IMS.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Entity;
using IMS.Entity.InventoryProducts;
using System.Diagnostics;

namespace IMS.Repository.InventoryProducts
{
    class RackRepo
    {
        private InventoryDBDataAccess iDB { get; set; }

        public RackRepo()
        {
            this.iDB = new InventoryDBDataAccess();
        }

        //view & search
        public List<Rack> GetAll(string key)
        {
            List<Rack> rackList = new List<Rack>();

            string sql;
            try
            {
                if (key == null)
                    sql = @"SELECT item_rack.Rack_Number,item_rack.rack_id,item_rack.Rack_IsActive FROM item_rack;";
                else
                    sql = @"SELECT item_rack.Rack_Number,item_rack.rack_id,item_rack.Rack_IsActive FROM item_rack
                           where item_rack.Rack_Number like '%" + key + "%' ; ";

                var dt = this.iDB.ExecuteQueryTable(sql);

                int x = 0;
                while (x < dt.Rows.Count)
                {
                    Rack br = this.ConvertToEntity(dt.Rows[x]);
                    rackList.Add(br);
                    x++;
                }
                return rackList;
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }

        private Rack ConvertToEntity(DataRow row)
        {
            if (row == null)
            {
                return null;
            }

            var rack = new Rack();

            rack.RackNumber = row["Rack_Number"].ToString();
            rack.RackIsActive = Convert.ToBoolean(row["Rack_IsActive"].ToString());



            return rack;
        }

        //LoadComboBox
        public DataTable LoadComboRack()
        {
            string sql;
            try
            {
                sql = @"SELECT item_rack.Rack_Number,item_rack.rack_id,item_rack.Rack_IsActive FROM item_rack";
                return this.iDB.ExecuteQueryTable(sql);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Rack> GetRackList()
        {
            DataTable dt = LoadComboRack();

            List<Rack> list = new List<Rack>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(ConvertToBrandList(row));
            }

            return list;
        }

        public string GetRackNumber(string brandName)
        {
            List<Rack> list = GetRackList();

            foreach (Rack rack in list)
            {
                if (rack.RackNumber == brandName)
                {
                    return rack.RackNumber;
                }
            }
            return null;
        }

        private Rack ConvertToBrandList(DataRow row)
        {
            if (row == null)
            {
                return null;
            }

            var b = new Rack();
            b.RackNumber = row["Rack_Number"].ToString();
            b.RackIsActive = Convert.ToBoolean(row["Rack_IsActive"].ToString());
            return b;
        }

        //DataCount - DataExists
        public bool DataExists(string name)
        {
            try
            {
                DataSet ds = iDB.ExecuteQuery("SELECT item_rack.Rack_Number,item_rack.rack_id,item_rack.Rack_IsActive FROM item_rack WHERE item_rack.Rack_Number='" + name + "'");

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

        //save - Brands
        public bool Save(Rack br)
        {
            iDB.conOpen();
            try
            {
                var sql = @"insert into item_rack (Rack_Number, Rack_IsActive)
                                values ('" + br.RackNumber + "' , '" + br.RackIsActive + "');";

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

        //update - Brands
        public bool UpdateProduct(Rack br)
        {
            try
            {
                iDB.conOpen();
                string sql = @"update item_rack set item_rack.Rack_Number='" + br.RackNumber + "' , item_rack.Rack_IsActive='" + br.RackIsActive + "' WHERE item_rack.Rack_Number='"+ br.RackNumber + "' ";

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

        //delete - Brands
        public bool Delete(string id)
        {
            string sql;

            try
            {
                sql = @"delete from item_rack where item_rack.Rack_Number ='" + id + "';";
                var dataTable = this.iDB.ExecuteDMLQuery(sql);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
                throw;
            }
        }
    }


}

