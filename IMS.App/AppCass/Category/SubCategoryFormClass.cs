using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMS.Entity.InventoryProducts;
using IMS.Repository;
using IMS.Repository.InventoryProducts;

namespace IMS.App.AppCass.Category
{
    class SubCategoryFormClass
    {
        public SubCategories FillEntitySubCategory(ComboBox comboSubCategory,TextBox texSUBCategoryCode,TextBox texSUBCategoryDes, Label ErrorLabelSubCategoryCombo,Label ErrorLabelSubCategoryName,CheckBox checkBoxSubCategoryActive,int hiddenSubCategory_id)
        {

            var mc = new SubCategories();
            if (comboSubCategory.SelectedIndex == 0 || texSUBCategoryCode.Text == "")
            {

                if (comboSubCategory.SelectedIndex == 0)
                {

                    ErrorLabelSubCategoryCombo.Show();

                }
                if (texSUBCategoryCode.Text == "")
                {

                    ErrorLabelSubCategoryName.Show();

                }
                MessageBox.Show("Please Fill Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mc = null;
            }
            else if (comboSubCategory.SelectedIndex != 0 & texSUBCategoryCode.Text != "")
            {
                ErrorLabelSubCategoryCombo.Hide();
                ErrorLabelSubCategoryName.Hide();
                mc.SubCategoryName = texSUBCategoryCode.Text;
                mc.MainCategoryName = comboSubCategory.Text;
                mc.SubCategoryDescription = texSUBCategoryDes.Text;
                mc.SubCategoryIsActivate = checkBoxSubCategoryActive.Checked;
                mc.SubCategoryId = hiddenSubCategory_id;

            }


            return mc;
        }




        public void PopulateGridViewSubCategory(DataGridView dataGridViewSubCategory,SubCategoriesReop subCateRepo, string searchKey = null)
        {

            dataGridViewSubCategory.AutoGenerateColumns = true;
            dataGridViewSubCategory.DataSource = subCateRepo.GetAll(searchKey).ToList();
            subCategoryGridViewLoading(dataGridViewSubCategory);
            dataGridViewSubCategory.ClearSelection();
            dataGridViewSubCategory.Refresh();
            //this.RefreshContent();
        }


        private void subCategoryGridViewLoading(DataGridView dataGridViewSubCategory)
        {
            //dataGridView1.DataSource = mj.drawDespatchData(selectedDrow, (int)MahajanaDespatchClass.Lottery.Mahajana);

            dataGridViewSubCategory.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dataGridViewSubCategory.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dataGridViewSubCategory.CellBorderStyle = DataGridViewCellBorderStyle.None;

            dataGridViewSubCategory.DefaultCellStyle.SelectionBackColor = Color.Red;
            dataGridViewSubCategory.DefaultCellStyle.SelectionForeColor = Color.Yellow;

            dataGridViewSubCategory.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvMainCate.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridViewSubCategory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSubCategory.AllowUserToResizeColumns = false;
            dataGridViewSubCategory.Columns[0].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);
            dataGridViewSubCategory.Columns[1].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);
            dataGridViewSubCategory.Columns[2].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);
            dataGridViewSubCategory.Columns[3].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);
            dataGridViewSubCategory.Columns[4].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);
            dataGridViewSubCategory.Columns[5].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);

            dataGridViewSubCategory.Columns[0].Width = 120;
            dataGridViewSubCategory.Columns[1].Width = 140;
            dataGridViewSubCategory.Columns[2].Width = 160;
            dataGridViewSubCategory.Columns[3].Width = 160;
            dataGridViewSubCategory.Columns[4].Width = 0;
            dataGridViewSubCategory.Columns[5].Width = 0;
            dataGridViewSubCategory.Columns[6].Width = 0;
            dataGridViewSubCategory.Columns[7].Width = 0;
            dataGridViewSubCategory.Columns[7].Width = 0;

            dataGridViewSubCategory.RowsDefaultCellStyle.Font = new Font("Tahoma", 11, FontStyle.Regular);

            dataGridViewSubCategory.Columns[0].HeaderCell.Value = "Sub CategoryName";
            dataGridViewSubCategory.Columns[1].HeaderCell.Value = "Main CategoryName";
            dataGridViewSubCategory.Columns[2].HeaderCell.Value = "Description";

            dataGridViewSubCategory.Columns[3].HeaderCell.Value = "Is Activate";
            dataGridViewSubCategory.Columns[4].HeaderCell.Value = "";
            dataGridViewSubCategory.Columns[5].HeaderCell.Value = "";


        }



    }
}
