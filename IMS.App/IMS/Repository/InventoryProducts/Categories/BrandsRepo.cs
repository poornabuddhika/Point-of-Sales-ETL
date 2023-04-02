using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.DataAccess;
using IMS.Entity.InventoryProducts;

namespace IMS.Repository
{
    
    public class BrandsRepo
    {
        private InventoryDBDataAccess iDB{ get; set; }

        public BrandsRepo()
        {
            this.iDB = new InventoryDBDataAccess();
        }

        //view & search
        public List<Brands> GetAll(string key)
        {
            List<Brands> brandsList = new List<Brands>();

            string sql;
            try
            {
                if (key == null)
                    sql = @"SELECT item_brand.bra_id AS BrandId, item_brand.bra_TAG   AS BrandTag, item_brand.bra_name As BrandName,
                                    item_brand.bra_is_deleted AS IsActive FROM item_brand;";
                else
                    sql = @"SELECT item_brand.bra_id AS BrandId, item_brand.bra_TAG   AS BrandTag, item_brand.bra_name As BrandName,
                                item_brand.bra_is_deleted AS IsActive FROM item_brand
                                    where item_brand.bra_name like '%" + key + "%' or item_brand.bra_TAG  like '%" + key + "%' ; ";

                var dt = this.iDB.ExecuteQueryTable(sql);

                int x = 0;
                while (x < dt.Rows.Count)
                {
                    Brands br = this.ConvertToEntity(dt.Rows[x]);
                    brandsList.Add(br);
                    x++;
                }
                return brandsList;
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }

        private Brands ConvertToEntity(DataRow row)
        {
            if (row == null)
            {
                return null;
            }

            var brand = new Brands();
            brand.BrandId = Convert.ToInt32(row["BrandId"].ToString());
            brand.BrandTag = row["BrandTag"].ToString();
            brand.BrandName = row["BrandName"].ToString();
            brand.BrandIsActive =Convert.ToBoolean( row["IsActive"].ToString());
           
           
            return brand;
        }
        
        //LoadComboBox
        public DataTable LoadComboBrandName()
        {
            string sql;
            try
            {
                sql = @"SELECT bra_name from item_brand WHERE bra_is_ISActive='TRUE'";
                return this.iDB.ExecuteQueryTable(sql);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Brands> GetBrandsList()
        {
            DataTable dt = LoadComboBrandName();

            List<Brands> list = new List<Brands>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(ConvertToBrandList(row));
            }

            return list;
        }

        public int GetBrandId(string brandName)
        {
            List<Brands> list = GetBrandsList();

            foreach (Brands brand in list)
            {
                if (brand.BrandName == brandName)
                {
                    return brand.BrandId;
                }
            }
            return 0;
        }

        private Brands ConvertToBrandList(DataRow row)
        {
            if (row == null)
            {
                return null;
            }

            var b = new Brands();
            b.BrandName = row["BrandName"].ToString();
            b.BrandId = Convert.ToInt32(row["BrandId"].ToString());
            return b;
        }

        //DataCount - DataExists
        public bool DataExists(string name)
        {
            try
            {
                DataSet ds = iDB.ExecuteQuery("select bra_name from item_brand where bra_name='" + name+"'");

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
        public bool Save(Brands br)
        {
            iDB.conOpen();
            try
            {
                var sql = @"insert into item_brand (bra_name, bra_TAG,bra_is_ISActive)
                                values ('" + br.BrandName + "' , '" + br.BrandTag + "','"+ br.BrandIsActive + "' );";

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
        public bool UpdateProduct(Brands br)
        {
            try
            {
                iDB.conOpen();
                string sql = @"update item_brand set item_brand.bra_name='"+br.BrandName+"' , item_brand.bra_TAG='"+br.BrandTag+
                    "',item_brand.bra_is_ISActive='" + br.BrandIsActive+ "' where item_brand.bra_name='" + br.BrandName+"' ";

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
                sql = @"delete from Brands where BrandId ='" + id + "';";
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
