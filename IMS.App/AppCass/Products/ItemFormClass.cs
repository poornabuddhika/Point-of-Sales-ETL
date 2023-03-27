using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMS.Entity.InventoryProducts;
using IMS.Repository;


namespace IMS.App.AppCass.Products
{
    class ItemFormClass
    {

        public void MainCategoryIdToName(ComboBox ComboMainCategory,MainCategoriesRepo mainCateRepo)
        {
            ComboMainCategory.Items.Clear();
            ComboMainCategory.Items.Add("--Not Selected--");
            ComboMainCategory.SelectedIndex = ComboMainCategory.FindStringExact("--Not Selected--");
            foreach (DataRow row in mainCateRepo.LoadComboMainCategoryName().Rows)
            {


                ComboMainCategory.Items.Add(row["cat_name"].ToString());


            }

        }
      

        public void SubCategoryIdToName(ComboBox comboBoxSubCategory, SubCategoriesReop subCateRepo, string SubCategoryName)
        {
            comboBoxSubCategory.Items.Clear();
            comboBoxSubCategory.Items.Add("--Not Selected--");
            comboBoxSubCategory.SelectedIndex = comboBoxSubCategory.FindStringExact("--Not Selected--");
            foreach (SubCategories row in subCateRepo.LoadComboSubCategory(SubCategoryName))
            {


                comboBoxSubCategory.Items.Add(row.SubCategoryName.ToString());


            }

        }

        internal void ComboRackNumberlist(ComboBox comboRackNumber, RackRepo rackRepo)
        {
            comboRackNumber.Items.Add("--Not Selected--");
            comboRackNumber.SelectedIndex = comboRackNumber.FindStringExact("--Not Selected--");
            foreach (Rack rack in rackRepo.GetAll(null))
            {


                comboRackNumber.Items.Add(rack.RackNumber.ToString());


            }
        }

        internal void ComboSellingUnitlist(ComboBox comboSellingUnit, UnitRepo unitRepo)
        {
            comboSellingUnit.Items.Add("--Not Selected--");
            comboSellingUnit.SelectedIndex = comboSellingUnit.FindStringExact("--Not Selected--");
            foreach (Unit unit in unitRepo.GetAll(null))
            {


                comboSellingUnit.Items.Add(unit.UnitCode.ToString());


            }
        }

        public void BrndName(ComboBox comboBoxBrand, BrandsRepo brandRepo)
        {
            comboBoxBrand.Items.Add("--Not Selected--");
            comboBoxBrand.SelectedIndex = comboBoxBrand.FindStringExact("--Not Selected--");
            foreach (DataRow row in brandRepo.LoadComboBrandName().Rows)
            {


                comboBoxBrand.Items.Add(row["bra_name"].ToString());


            }
        }


        public void ComboPurchaseUnitlist(ComboBox comboPurchaseUnit,UnitRepo unitRepo)
        {

            comboPurchaseUnit.Items.Add("--Not Selected--");
            comboPurchaseUnit.SelectedIndex = comboPurchaseUnit.FindStringExact("--Not Selected--");
            foreach (Unit unit in unitRepo.GetAll(null))
            {


                comboPurchaseUnit.Items.Add(unit.UnitCode.ToString());


            }

        }


        public Item FillEntityItem(Item item)
        {
            var mc = new Item();
            
            if (item.ErrorList.Count !=0)
            {

               
               
                MessageBox.Show("Please Fill Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mc = null;
            }
            else 
            {
                mc = item;
            }

        
            return mc;

        }



    }
}
