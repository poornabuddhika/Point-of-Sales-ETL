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
                        @"SELECT item_sub_category.sub_name AS SubCategoryName,
                            item_sub_category.sub_Description AS Description,
                            item_category.cat_name AS CategoryName  , item_category.cat_is_active AS Active
                            FROM item_sub_category
                           LEFT JOIN item_category ON item_sub_category.Maincategory_Name = item_category.cat_name";
                else
                    sql = @"SELECT item_sub_category.sub_name AS SubCategoryName,
                            item_sub_category.sub_Description AS Description,
                            item_category.cat_name AS CategoryName  , item_category.cat_is_active AS Active
                            FROM item_sub_category
                           LEFT JOIN item_category ON item_sub_category.Maincategory_Name = item_category.cat_name
                                 where item_sub_category.sub_name like '%" + key+"%' or item_category.cat_name like '%"+key+"%'  ; ";

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
            
           
            secCate.SubCategoryName = row["SubCategoryName"].ToString();
            secCate.SubCategoryDescription = row["Description"].ToString();
            secCate.MainCategoryName = row["CategoryName"].ToString();
            secCate.SubCategoryIsActivate = Convert.ToBoolean(row["Active"].ToString());


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
                if (sc.SubCategoryName == mainCateName)
                {
                    return sc.SubCategoryId;
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
            s.SubCategoryName = row["SecondCategoryName"].ToString();
            s.SubCategoryId = Convert.ToInt32(row["SecondCategoryId"].ToString());
            return s;
        }

        //DataCount - DataExists
        public bool DataExists(string name)
        {
            try
            {
                DataSet ds = iDB.ExecuteQuery("select sub_name from item_sub_category where sub_name='" + name+"'");

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
                var sql = @"insert into item_sub_category (sub_name, Maincategory_Name,sub_Description,sub_is_deleted)
                                values ('"+sc.SubCategoryName+"','"+sc.MainCategoryName+"','"+sc.SubCategoryDescription+"','"+sc.SubCategoryIsActivate.ToString()+"');";
                iDB.conOpen();
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
                string sql = @"update SecondCategories set SecondCategoryName='" + thc.SubCategoryName + "' , MainCategoryId='" + thc.MainCategoryId + "' where SecondCategoryId='" + thc.SubCategoryId + "';";

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
