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
      

        public void SubCategoryIdToName(ComboBox ComboMainCategory, SubCategoriesReop subCateRepo, string SubCategoryName)
        {
            ComboMainCategory.Items.Clear();
            ComboMainCategory.Items.Add("--Not Selected--");
            ComboMainCategory.SelectedIndex = ComboMainCategory.FindStringExact("--Not Selected--");
            foreach (SubCategories row in subCateRepo.LoadComboSubCategory(SubCategoryName))
            {


                ComboMainCategory.Items.Add(row.MainCategoryName.ToString());


            }

        }




    }
}
