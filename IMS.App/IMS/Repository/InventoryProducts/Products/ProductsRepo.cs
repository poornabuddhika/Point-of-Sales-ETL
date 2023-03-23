using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.DataAccess;
using IMS.Entity;
using IMS.Entity.InventoryProducts;

namespace IMS.Repository
{
    public class ItemRepo
    {
        private InventoryDBDataAccess iDB {get; set;}

        public ItemRepo()
        {
            this.iDB = new InventoryDBDataAccess();
        }


        public string GetTotalItems()
        {
            return iDB.GetSingleData("select count(ProductId) as id from Items ", "id");
        }
        public string GetAvailableItems()
        {
            return iDB.GetSingleData("select count(ProductId) as id from Products where ProductStatus='YES' ", "id");
        }
        public string GetNoAvailableProducts()
        {
            return iDB.GetSingleData("select count(ProductId) as id from Products where ProductStatus='NO' ", "id");
        }

        //view & search
        public List<Item> GetAll(string key)
        {
            List<Item> productList = new List<Item>();

            string sql;
            try
            {
                if (key == null)
                    sql = @"SELECT Products.ProductId AS pID, Products.ProductIdTag AS pTag, Brands.BrandName AS pBrandName,
                    Products.ProductName AS pName, Products.ProductStatus AS pStatus, Products.ProductMSRP AS pMSRP, 
                    Products.ProductPerUnitPrice AS pPerUnPrice, Products.ProductQuantityPerUnit AS pQuaPerUn,
					Products.ProductDiscountRate AS pDisRate, Products.ProductSize AS pSize, Products.ProductColor AS pColor, 
                    Products.ProductWeight AS pWeight, Products.ProductUnitStock AS pUnStock, Products.ProductDescription AS pDisc
                    FROM     Products 
					left join Brands
					on Brands.BrandId=Products.BrandId";
                else
                    sql = @"SELECT Products.ProductId AS pID, Products.ProductIdTag AS pTag, Products.ProductName AS pName,
                    Brands.BrandName AS pBrandName, Products.ProductStatus AS pStatus, Products.ProductMSRP AS pMSRP, 
                    Products.ProductPerUnitPrice AS pPerUnPrice, Products.ProductQuantityPerUnit AS pQuaPerUn,
                    Products.ProductDiscountRate AS pDisRate, Products.ProductSize AS pSize, Products.ProductColor AS pColor, 
                    Products.ProductWeight AS pWeight, Products.ProductUnitStock AS pUnStock, Products.ProductDescription AS pDisc
                    FROM     Products INNER JOIN
                    Brands ON Products.BrandId = Brands.BrandId 
                    where Products.ProductIdTag like '%" + key + "%' or Products.ProductName like '%" + key + "%' or  Brands.BrandName like '%" + key + "%'; ";
                var dt = this.iDB.ExecuteQueryTable(sql);

                int x = 0;
                while (x < dt.Rows.Count)
                {
                    Item pro = this.ConvertToEntity(dt.Rows[x]);
                    productList.Add(pro);
                    x++;
                }
                return productList;
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }

        private Item ConvertToEntity(DataRow row)
        {
            if (row == null)
            {
                return null;
            }

            var product = new Item();
            product.ItemtId = Convert.ToInt32(row["pID"].ToString());
            product.ItemIdTag = row["pTag"].ToString();
            product.ItemName = row["pName"].ToString();
            product.BrandName = row["pBrandName"].ToString();
            product.ProductStatus = row["pStatus"].ToString();
            /*
            product.ProductMSRP = Convert.ToDouble(row["pMSRP"].ToString());
            product.ProductPerUnitPrice = Convert.ToDouble(row["pPerUnPrice"].ToString());
            product.ProductQuantityPerUnit = Convert.ToDouble(row["pQuaPerUn"].ToString());
            product.ProductDiscountRate = Convert.ToDouble(row["pDisRate"].ToString());
            product.ProductSize = Convert.ToDouble(row["pSize"].ToString());
            product.ProductColor = row["pColor"].ToString();
            product.ProductWeight = Convert.ToDouble(row["pWeight"].ToString());
            product.ProductUnitStock = Convert.ToInt32(row["pUnStock"].ToString());
            product.ProductDescription = row["pDisc"].ToString();
            */
            return product;
        }

        //DataCount - DataExists
        public bool DataExists(int id)
        {
            try
            {
                DataSet ds = iDB.ExecuteQuery("select ProductId from Products where ProductId="+id);

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

        //save - Product
        public bool Save(Item pro)
        {
            try
            {
                string sql = null;
                /*
                var sql = @"insert into Products (ProductName, BrandId, ProductDescription, ProductQuantityPerUnit,
                                ProductPerUnitPrice, ProductMSRP, Itemstatus, ProductDiscountRate, Itemsize, 
                                ProductColor, ProductWeight, ProductUnitStock)
                                values ('" + pro.ProductName + "' , '" + pro.BrandId + "' , '" + pro.ProductDescription + "' ,'" + pro.ProductQuantityPerUnit + "' ,'" 
                                + pro.ProductPerUnitPrice + "' ,'" + pro.ProductMSRP + "' ,'" + pro.Itemstatus + "' ,'" + pro.ProductDiscountRate + "' ,'" + pro.Itemsize + "' ,'" + pro.ProductColor + "' ,'" + pro.ProductWeight + "' ,'" + pro.ProductUnitStock + "');";
                */
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

        //update - Product
        public bool UpdateProduct(Item product)
        {
            try
            {
                string sql = null;
                /*
                string sql = @"update Items set ProductName='" + product.ProductName + "' , BrandId='" + product.BrandId + "',ProductDescription='" + product.ProductDescription + "', ProductQuantityPerUnit='" + product.ProductQuantityPerUnit + "'," +
                             "ProductPerUnitPrice='" + product.ProductPerUnitPrice + "', ProductMSRP='" + product.ProductMSRP + "', Itemstatus='" + product.Itemstatus + "',ProductDiscountRate='" + product.ProductDiscountRate + "',Itemsize='" +
                             product.Itemsize + "',ProductColor='" + product.ProductColor + "',ProductWeight='" + product.ProductWeight + "',ProductUnitStock='" + product.ProductUnitStock + "' where ProductId='" + product.ProductId + "'";
                */
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

        //delete - Product
        public bool Delete(string id)
        {
            string sql;

            try
            {
                sql = @"delete from Items where ProductId ='" + id + "';";
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
