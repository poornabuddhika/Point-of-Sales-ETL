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
    public class SubCategoriesReop
    {
        private InventoryDBDataAccess iDB{get; set;}

        public SubCategoriesReop()
        {
            this.iDB = new InventoryDBDataAccess();
        }

        // view & search
        public List<SubCategories> GetAll(string key)
        {
            List<SubCategories> secondCategoriesList = new List<SubCategories>();

            string sql;
            try
            {
                if (key == null)
                    sql =
                        @"SELECT SecondCategories.SecondCategoryId AS SecondCategoryId, SecondCategories.SecondCategoryName AS SecondCategoryName,
                          MainCategories.MainCategoryId AS MainCategoryId,
                          MainCategories.MainCategoryName AS MainCategoryName
                          FROM SecondCategories
				          LEFT JOIN MainCategories
                          ON SecondCategories.MainCategoryId = MainCategories.MainCategoryId";
                else
                    sql = @"SELECT SecondCategories.SecondCategoryId AS SecondCategoryId, SecondCategories.SecondCategoryName AS SecondCategoryName,
                          MainCategories.MainCategoryId AS MainCategoryId,
                          MainCategories.MainCategoryName AS MainCategoryName
                          FROM SecondCategories
				          LEFT JOIN MainCategories
                          ON SecondCategories.MainCategoryId = MainCategories.MainCategoryId
                          where SecondCategories.SecondCategoryName like '%" + key + "%' or MainCategories.MainCategoryName like '%" + key + "%' ; ";

                var dt = this.iDB.ExecuteQueryTable(sql);

                int x = 0;
                while (x < dt.Rows.Count)
                {
                    SubCategories sc = this.ConvertToEntity(dt.Rows[x]);
                    secondCategoriesList.Add(sc);
                    x++;
                }
                return secondCategoriesList;
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }

        private SubCategories ConvertToEntity(DataRow row)
        {
            if (row == null)
            {
                return null;
            }

            var secCate = new SubCategories();
            secCate.SecondCategoryId = Convert.ToInt32(row["SecondCategoryId"].ToString());
            secCate.SecondCategoryName = row["SecondCategoryName"].ToString();
            secCate.MainCategoryId = Convert.ToInt32(row["MainCategoryId"].ToString());
            secCate.MainCategoryName = row["MainCategoryName"].ToString();
            return secCate;
        }

        //LoadComboBox
        public DataTable LoadComboMainCategoryName()
        {
            string sql;
            try
            {
                sql = @"SELECT SecondCategoryId, SecondCategoryName FROM SecondCategories";
                return this.iDB.ExecuteQueryTable(sql);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<SubCategories> GetSecondCategoriesList()
        {
            DataTable dt = LoadComboMainCategoryName();

            List<SubCategories> list = new List<SubCategories>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(ConvertToSecondCateList(row));
            }
            return list;
        }

        public int GetSecondCategoryId(string mainCateName)
        {
            List<SubCategories> list = GetSecondCategoriesList();

            foreach (SubCategories sc in list)
            {
                if (sc.SecondCategoryName == mainCateName)
                {
                    return sc.SecondCategoryId;
                }
            }
            return 0;
        }

        private SubCategories ConvertToSecondCateList(DataRow row)
        {
            if (row == null)
            {
                return null;
            }

            var s = new SubCategories();
            s.SecondCategoryName = row["SecondCategoryName"].ToString();
            s.SecondCategoryId = Convert.ToInt32(row["SecondCategoryId"].ToString());
            return s;
        }

        //DataCount - DataExists
        public bool DataExists(int id)
        {
            try
            {
                DataSet ds = iDB.ExecuteQuery("select SecondCategoryId from SecondCategories where SecondCategoryId=" + id);

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

        //save - SecondCategory
        public bool Save(SubCategories sc)
        {
            try
            {
                var sql = @"insert into SecondCategories (SecondCategoryName, MainCategoryId)
                                values ('" + sc.SecondCategoryName + "' , '" + sc.MainCategoryId + "');";

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

        //update - SecondCategory
        public bool UpdateProduct(SubCategories thc)
        {
            try
            {
                string sql = @"update SecondCategories set SecondCategoryName='" + thc.SecondCategoryName + "' , MainCategoryId='" + thc.MainCategoryId + "' where SecondCategoryId='" + thc.SecondCategoryId + "';";

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

        //delete - SecondCategory
        public bool Delete(string id)
        {
            string sql;

            try
            {
                sql = @"delete from SecondCategories where SecondCategoryId ='" + id + "';";
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
