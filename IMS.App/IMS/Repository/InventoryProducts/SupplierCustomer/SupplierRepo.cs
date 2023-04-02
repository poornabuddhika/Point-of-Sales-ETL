using IMS.DataAccess;
using IMS.Entity.InventoryProducts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace IMS.Repository
{
    public class SupplierRepo
    {
        private InventoryDBDataAccess iDB = new InventoryDBDataAccess();

        public SupplierRepo()
        {
            this.iDB = new InventoryDBDataAccess();
        }




        internal bool Save(Supplier pro)
        {
            try
            {

                iDB.conOpen();

                var sql = @"INSERT INTO [dbo].[supplier_Detl] ([sup_id] ,[sup_Name] ,[sup_Address] ,[sup_credit_period] ,[sup_credit_Amount] ,
                            [sup_mobile] ,[sup_office_Phone] ,[sup_Email] ,[sup_fax_number] ,[sup_Contact_Person] ,
                            [sup_City] ,[sup_remark] ,[sup_is_Active]) 
                            VALUES 
                            ('" + pro.ID + "', '" + pro.Name + "','" + pro.Address + "', '" + pro.Credit_Period + "', '" + pro.Credit_Amount + "','" +
                            pro.Mobile_Number + "','" + pro.Office_Phone_number + "', '" + pro.Email + "', '" + pro.Fax + "', '" + pro.Contact_Person +
                            "','" + pro.City + "', '" + pro.Comment + "', '" + pro.IsActive + "');";

                var rowCount = this.iDB.ExecuteDMLQuery(sql);

                if (rowCount == 1)
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
                return false;
            }
        }



        internal List<Supplier> GetAll(string key)
        {
            List<Supplier> productsList = new List<Supplier>();

            string sql;
            try
            {
                if (key == null)
                    sql = @"SELECT
                                    Products.ProductName AS ProductName, Brands.BrandName AS BrandName,
                                    Vendors.VendorName AS VendorName, ThirdCategories.ThirdCategoryName AS ThirdCategoryName,
                                    SecondCategories.SecondCategoryName AS SecondCategoryName,
                                    MainCategories.MainCategoryName AS MainCategoryName
                                    FROM Products
					                left join Brands 
					                Brands ON Products.BrandId = Brands.BrandId 
					                left join Vendors
                                    Vendors ON Brands.VendorId = Vendors.VendorId
						            left join ThirdCategories
                                    ThirdCategories ON Vendors.ThirdCategoryId = ThirdCategories.ThirdCategoryId
						            left join SecondCategories
                                    SecondCategories ON ThirdCategories.SecondCategoryId = SecondCategories.SecondCategoryId
						            left join MainCategories
                                    MainCategories ON SecondCategories.MainCategoryId = MainCategories.MainCategoryId";

                else
                    sql = @"SELECT
                                    Products.ProductName AS ProductName, Brands.BrandName AS BrandName,
                                    Vendors.VendorName AS VendorName, ThirdCategories.ThirdCategoryName AS ThirdCategoryName,
                                    SecondCategories.SecondCategoryName AS SecondCategoryName,
                                    MainCategories.MainCategoryName AS MainCategoryName
                                    FROM Products
					                left join Brands 
					                Brands ON Products.BrandId = Brands.BrandId 
					                left join Vendors
                                    Vendors ON Brands.VendorId = Vendors.VendorId
						            left join ThirdCategories
                                    ThirdCategories ON Vendors.ThirdCategoryId = ThirdCategories.ThirdCategoryId
						            left join SecondCategories
                                    SecondCategories ON ThirdCategories.SecondCategoryId = SecondCategories.SecondCategoryId
						            left join MainCategories
                                    MainCategories ON SecondCategories.MainCategoryId = MainCategories.MainCategoryId

				                    where Products.ProductName like '%" + key + "%' or Brands.BrandName like '%" + key + "%' or   Vendors.VendorName like '%" + key + "%' " +
                                    " or ThirdCategories.ThirdCategoryName like '%" + key + "%' or SecondCategories.SecondCategoryName like '%" + key + "%' " +
                                    " or  ThirdCategories.ThirdCategoryName like '%" + key + "%' or  MainCategories.MainCategoryName like '%" + key + "%';";

                var dt = this.iDB.ExecuteQueryTable(sql);

                int x = 0;
                while (x < dt.Rows.Count)
                {
                    Supplier px = ConvertToEntity(dt.Rows[x++]);
                    productsList.Add(px);
                    x++;
                }
                return productsList;
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }


        private Supplier ConvertToEntity(DataRow row)
        {
            if (row == null)
            {
                return null;
            }

            var supplier = new Supplier();
            /*
            products.ProductName = row["ProductName"].ToString();
            products.BrandName = row["BrandName"].ToString();
            products.VendorName = row["VendorName"].ToString();
            products.ThirdCategoryName = row["ThirdCategoryName"].ToString();
            products.SecondCategoryName = row["SecondCategoryName"].ToString();
            products.MainCategoryName = row["MainCategoryName"].ToString();
            */
            return supplier;
        }



        public bool DataExists( string name,string id)
        {
            try
            {

                DataSet ds = iDB.ExecuteQuery("SELECT * from supplier_Detl WHERE sup_Name = '" + name + "' or sup_id = '" + id + "'");

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





    }
       
}
