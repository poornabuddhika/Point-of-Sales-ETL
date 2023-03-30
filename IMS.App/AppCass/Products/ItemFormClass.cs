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


       public void PopulateGridViewUnit(DataGridView GridViewItem,ItemRepo itemRepo, string searchKey = null)
        {
            GridViewItem.AutoGenerateColumns = true;
            GridViewItem.DataSource = itemRepo.GetAll(searchKey);
            subCategoryGridViewLoading(GridViewItem);
            GridViewItem.ClearSelection();
            GridViewItem.Refresh();
        }


        private void subCategoryGridViewLoading(DataGridView GridViewItem)
        {
            //dataGridView1.DataSource = mj.drawDespatchData(selectedDrow, (int)MahajanaDespatchClass.Lottery.Mahajana);

            GridViewItem.RowsDefaultCellStyle.BackColor = Color.Bisque;
            GridViewItem.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            GridViewItem.CellBorderStyle = DataGridViewCellBorderStyle.None;

            GridViewItem.DefaultCellStyle.SelectionBackColor = Color.Red;
            GridViewItem.DefaultCellStyle.SelectionForeColor = Color.Yellow;

            GridViewItem.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvMainCate.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            GridViewItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridViewItem.AllowUserToResizeColumns = false;
            GridViewItem.Columns[0].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);
            GridViewItem.Columns[1].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);
            GridViewItem.Columns[2].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);
            GridViewItem.Columns[3].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);


            GridViewItem.Columns[0].Width = 120;
            GridViewItem.Columns[1].Width = 140;
            GridViewItem.Columns[2].Width = 160;
            GridViewItem.Columns[3].Width = 160;


            GridViewItem.RowsDefaultCellStyle.Font = new Font("Tahoma", 11, FontStyle.Regular);

            GridViewItem.Columns[0].HeaderCell.Value = "Item ID";
            GridViewItem.Columns[1].HeaderCell.Value = "Item Name";
            GridViewItem.Columns[2].HeaderCell.Value = "Discount";
            GridViewItem.Columns[3].HeaderCell.Value = "Status";


           
    }



    }
}
