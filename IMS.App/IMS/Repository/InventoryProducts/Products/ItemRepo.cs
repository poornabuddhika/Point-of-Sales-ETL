﻿using System;
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

        private Item ConvertToEntity(DataRow row)
        {
            if (row == null)
            {
                return null;
            }
            
           var product = new Item();



            

            return product;
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
    }
}