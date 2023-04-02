using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.DataAccess;
using IMS.Entity;
using IMS.Entity.InventoryProducts;

namespace IMS.Repository
{
    public class UnitRepo
    {
        private InventoryDBDataAccess iDB{get; set;}

        public UnitRepo()
        {
            this.iDB = new InventoryDBDataAccess();
        }

        //view & search
        public List<Unit> GetAll(string key)
        {
            List<Unit> thirdCategoriesList = new List<Unit>();

            string sql;
            try
            {
                if (key == null)
                    sql =
                        @"SELECT item_unit.unit_name ,item_unit.unit_code,item_unit.unit_IsActive FROM item_unit";
                else
                    sql = @"SELECT item_unit.unit_name,item_unit.unit_code,item_unit.unit_IsActive FROM item_unit
                          where item_unit.unit_name like '%" + key + "%' or item_unit.unit_code like '%" + key + "%' ; ";

                var dt = this.iDB.ExecuteQueryTable(sql);

                int x = 0;
                while (x < dt.Rows.Count)
                {
                    Unit th = this.ConvertToEntity(dt.Rows[x]);
                    thirdCategoriesList.Add(th);
                    x++;
                }
                return thirdCategoriesList;
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }

        private Unit ConvertToEntity(DataRow row)
        {
            if (row == null)
            {
                return null;
            }

            var unti = new Unit();

            unti.UnitName = row["unit_name"].ToString();
            unti.UnitCode = (row["unit_code"].ToString());
            unti.IsActive= Convert.ToBoolean(row["unit_IsActive"].ToString());
            
            return unti;
        }

        //LoadComboBox
        public DataTable LoadComboThirdCategoryName()
        {
            string sql;
            try
            {
                sql = @"SELECT ThirdCategoryId , ThirdCategoryName FROM ThirdCategories";
                return this.iDB.ExecuteQueryTable(sql);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Unit> GetThirdCategoryList()
        {
            try
            {
                DataTable dt = LoadComboThirdCategoryName();

                List<Unit> list = new List<Unit>();

                foreach (DataRow row in dt.Rows)
                {
                    list.Add(ConvertToThirdCateList(row));
                }
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                throw;
            }
        }

        public int GetThirdCateId(string thirdCateName)
        {
            try
            {
                List<Unit> list = GetThirdCategoryList();

                foreach (Unit thirdCate in list)
                {
                    if (thirdCate.UnitName == thirdCateName)
                    {
                        return thirdCate.UnitId;
                    }
                }
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private Unit ConvertToThirdCateList(DataRow row)
        {
            try
            {
                if (row == null)
                {
                    return null;
                }

                var thC = new Unit();
                thC.UnitName= row["unit_name"].ToString();
                thC.UnitCode = row["unit_code"].ToString();
                thC.IsActive = Convert.ToBoolean(row["unit_IsActive"].ToString());
                return thC;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                throw;
            }
        }

        //DataCount - DataExists
        public bool DataExists(string name)
        {
            try
            {
                DataSet ds = iDB.ExecuteQuery("select * from item_unit where unit_name='" + name+"'");

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

        //save - ThirdCategory
        public bool Save(Unit thc)
        {
            try
            {
                iDB.conOpen();
                var sql = @"insert into item_unit (unit_name, unit_code,unit_IsActive)
                                values ('" + thc.UnitName + "' , '" + thc.UnitCode + "','"+thc.IsActive.ToString()+"');";

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

        //update - ThirdCategory
        public bool UpdateProduct(Unit thc)
        {
            try
            {
                iDB.conOpen();
                string sql = @"update item_unit set item_unit.unit_name='"+ thc.UnitName+ "' , item_unit.unit_code='"+thc.UnitCode+ "',item_unit.unit_IsActive='"+thc.IsActive.ToString()+"' where item_unit.unit_name='"+thc.UnitName+"'";

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

        //delete - ThirdCategory
        public bool Delete(string id)
        {
            string sql;

            try
            {
                sql = @"delete from ThirdCategories where ThirdCategoryId ='" + id + "';";
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
