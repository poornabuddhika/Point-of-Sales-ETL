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
        public DataTable GetAll(string key)
        {
            List<Item> productList = new List<Item>();

            string sql;
            try
            {
                if (key == null)
                    sql = @"SELECT [Item_ID], [ItemName],[Discount], [Status]  FROM     [dbo].[Item_ItemMaster] ";
                else
                    sql = @"SELECT [Item_ID], [ItemName],[Discount], [Status]  FROM     [dbo].[Item_ItemMaster]
                    where [Item_ID]  like '%" + key + "%' or [ItemName] like '%" + key + "%' or   [Status] like '%" + key + "%'; ";
                var dt = this.iDB.ExecuteQueryTable(sql);

                
               
                return dt;
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }



        public DataTable GetAllGINItems(string key)
        {
            List<Item> productList = new List<Item>();

            string sql;
            try
            {
                if (key == null)
                {
                    sql = @"SELECT [Item_ID], [ItemName],[Discount], [Status],[ItemCost],[MRP]  FROM     [dbo].[Item_ItemMaster] 
                    where   [Status] = 'True';";
                }
                else
                {
                    sql = @"SELECT [Item_ID], [ItemName],[Discount], [Status],[ItemCost],[MRP]  FROM     [dbo].[Item_ItemMaster]
                    where ([Item_ID]  like '%" + key + "%' or [ItemName] like '%" + key + "%' ) AND   [Status] = 'True'; ";
                }
                var dt = this.iDB.ExecuteQueryTable(sql);



                return dt;
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }


        public DataTable GetAllGINItemsSearchNameID(string ID,String Name)
        {
            List<Item> productList = new List<Item>();

            string sql;
            try
            {
                
                
                
                    sql = @"SELECT [Item_ID], [ItemName],[Discount], [Status]  FROM     [dbo].[Item_ItemMaster]
                    where ([Item_ID]  ='"+ ID.Trim() + "' And [ItemName] ='" + Name.Trim() + "' ); ";
                
                var dt = this.iDB.ExecuteQueryTable(sql);



                return dt;
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

            Item itemNew = new Item();




            itemNew.ItemtId = row["Item_ID"].ToString();

            itemNew.ItemName = row["ItemName"].ToString();

          /*  itemNew.Barcode = row["Barcode"].ToString();


            itemNew.DescriptionOne = row["Description1"].ToString();

            itemNew.DescriptionTwo = row["Description2"].ToString();

            itemNew.PurchaseUnit = row["Purchase_Unit"].ToString();


            itemNew.SellingUnit = row["Selling_Unit"].ToString();

            try { itemNew.SellingPrice = Convert.ToDecimal(row["Selling_Price"].ToString()); } catch (Exception ex) { itemNew.SellingPrice = Convert.ToDecimal("0.0"); };


            try { itemNew.Cost = Convert.ToDecimal(row["ItemCost"].ToString()); } catch (Exception ex) { itemNew.Cost = Convert.ToDecimal("0.0"); };

            try { itemNew.MRP = Convert.ToDecimal(row["MRP"].ToString()); } catch (Exception ex) { itemNew.MRP = Convert.ToDecimal("0.0"); };

            itemNew.Supplier = row["Supplier"].ToString();
            try { itemNew.PacketSize = Convert.ToInt32(row["Packet_Size"].ToString()); } catch (Exception ex) { itemNew.PacketSize = 0; }


            itemNew.RackNumber = row["Rack_No"].ToString();


            itemNew.CategoryName = row["Category"].ToString();


            itemNew.subCategory = row["Sub_Category"].ToString();


            itemNew.brands = row["Brand_Name"].ToString();

            try { itemNew.ProductQty = Convert.ToDouble(row["Product_Qty"].ToString()); } catch (Exception e) { itemNew.ProductQty = 0.0; }

    */
            try { itemNew.DisCount = Convert.ToDouble(row["Discount"].ToString()); } catch (Exception e) { itemNew.DisCount = 0.0; }
            /*
            try { itemNew.DiscountAmount = Convert.ToDouble(row["DiscountAmount"].ToString()); } catch (Exception e) { itemNew.DiscountAmount = 0.0; }
            try { itemNew.WeightItem = Convert.ToBoolean(row["Weight"].ToString()); } catch (Exception e) { itemNew.WeightItem = false; }
            try { itemNew.ServeItem = Convert.ToBoolean(row["Save_Item"].ToString()); } catch (Exception e) { itemNew.ServeItem = false; }
            itemNew.OptionOne = row["OptionOne"].ToString();
            itemNew.OptionTwo = row["optionTwo"].ToString();
            try { itemNew.IsActive = Convert.ToBoolean(row["Status"].ToString()); } catch (Exception e) { itemNew.IsActive = false; }
            */




            return itemNew;
        }



        //DataCount - DataExists
        public bool DataExists(string id,string name)
        {
            try
            {
                
                DataSet ds = iDB.ExecuteQuery("SELECT Item_ItemMaster.ItemName,Item_ItemMaster.Item_ID from Item_ItemMaster WHERE Item_ItemMaster.ItemName = '"+name+"' or Item_ItemMaster.Item_ID = '"+id+"'");

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

                iDB.conOpen();

                var sql = @"INSERT INTO [dbo].[Item_ItemMaster] ([Item_ID], [ItemName], [Barcode], [Description1], [Description2],
                            [Purchase_Unit], [Selling_Unit], [Selling_Price], [ItemCost], [MRP], [Supplier], [Packet_Size], [Rack_No],
                            [Category], [Sub_Category], [Brand_Name], [Product_Qty], [Discount], [DiscountAmount], [Weight], [Save_Item], [OptionOne], [optionTwo], [Status]) 
                            VALUES 
                            ('"+pro.ItemtId+"', '"+pro.ItemName+"','"+pro.Barcode+"', '"+pro.DescriptionOne+"', '"+pro.DescriptionTwo+"','"+
                            pro.PurchaseUnit+"','"+pro.SellingUnit+"', '"+pro.SellingPrice+"', '"+pro.Cost+"', '"+pro.MRP+"','"+pro.Supplier+"', '"+pro.PacketSize+"', '"+pro.RackNumber+
                            "','"+pro.CategoryName+"', '"+pro.subCategory+"', '"+pro.brands+"', '"+pro.ProductQty+"', '"+pro.DisCount+"', '"+pro.DiscountAmount+"','"+pro.WeightItem+"', '"+pro.ServeItem+"', '"+pro.OptionOne+"', '"+pro.OptionTwo+"','"+pro.IsActive+"');";
                
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
        public bool UpdateProduct(Item pro)
        {
            try
            {

                string sql = @"update  [dbo].[Item_ItemMaster] set [Item_ID] ='" + pro.ItemtId + "', [ItemName]='"+ pro.ItemName + "', [Barcode]='"+ pro.Barcode + "', [Description1]='"+ pro.DescriptionOne + "', [Description2]='"+ pro.DescriptionTwo + "',"+

                    "[Purchase_Unit]='"+ pro.PurchaseUnit + "', [Selling_Unit]='"+ pro.SellingUnit + "', [Selling_Price]='"+ pro.SellingPrice + "', [ItemCost]='"+ pro.Cost + "', [MRP]='"+ pro.MRP + "', [Supplier]='"+ pro.Supplier + "', [Packet_Size]='"+ pro.PacketSize + "', [Rack_No]='"+ pro.RackNumber + "',"+

                   " [Category]='" + pro.CategoryName + "', [Sub_Category]='" + pro.subCategory + "', [Brand_Name]='" + pro.brands + "', [Product_Qty]='" + pro.ProductQty + "', [Discount]='" + pro.DisCount + "', [DiscountAmount]='" + pro.DiscountAmount + "', [Weight]='" + pro.WeightItem + "', [Save_Item]='" 
                   
                   + pro.ServeItem + "', [OptionOne]='" + pro.OptionOne + "', [optionTwo]='" + pro.OptionTwo + "', [Status]='" + pro.IsActive + "'  where  [Item_ID] ='" + pro.ItemtId + "' ;";

                    
                              
                                 

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

        public List<Item> GetItemList(string key)
        {
            DataTable dt = GetAll(key);

            List<Item> list = new List<Item>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(ConvertToEntity(row));
            }
            return list;
        }




       


    }
}
