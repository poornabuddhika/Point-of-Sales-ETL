using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMS.Entity.InventoryProducts;
using IMS.Repository;


namespace IMS.App.AppCass.Category
{ 
    class MainCategoryFormClass
    {
        public MainCategories FillEntityMainCategory(TextBox textCategoryCode,TextBox textCategoryName,TextBox textCategoryDescrip,TextBox textCategoryStockCover,CheckBox checkBoxActive_Category_main,Label labelCategoryCodeError,Label labelCategoryNameError)
        {

            var mc = new MainCategories();
            if (textCategoryCode.Text == "" || textCategoryName.Text == "")
            {

                if (textCategoryCode.Text == "")
                {

                    labelCategoryCodeError.Show();

                }
                if (textCategoryName.Text == "")
                {

                    labelCategoryNameError.Show();

                }
                MessageBox.Show("Please Fill Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mc = null;
            }
            else if (textCategoryCode.Text != "" & textCategoryName.Text != "")
            {
                labelCategoryCodeError.Hide();
                labelCategoryNameError.Hide();
                mc.MainCategoryCode = textCategoryCode.Text;
                mc.MainCategoryName = textCategoryName.Text;
                mc.MainCategoryDescription = textCategoryDescrip.Text;
                mc.MainCategoryStockCover = textCategoryStockCover.Text;
                mc.MainCategoryIsActivate = checkBoxActive_Category_main.Checked;
            }


            return mc;
        }


        public void PopulateGridViewMainCategory(DataGridView gridMainCategory, MainCategoriesRepo mainCateRepo, string searchKey = null)
        {

            gridMainCategory.AutoGenerateColumns = true;
            gridMainCategory.DataSource = mainCateRepo.GetAll(searchKey).ToList();
            MainCategoryGridViewLoading(gridMainCategory);
            gridMainCategory.ClearSelection();
            gridMainCategory.Refresh();
            //this.RefreshContent();
        }



        private void MainCategoryGridViewLoading(DataGridView gridMainCategory)
        {
            //dataGridView1.DataSource = mj.drawDespatchData(selectedDrow, (int)MahajanaDespatchClass.Lottery.Mahajana);

            gridMainCategory.RowsDefaultCellStyle.BackColor = Color.Bisque;
            gridMainCategory.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            gridMainCategory.CellBorderStyle = DataGridViewCellBorderStyle.None;

            gridMainCategory.DefaultCellStyle.SelectionBackColor = Color.Red;
            gridMainCategory.DefaultCellStyle.SelectionForeColor = Color.Yellow;

            gridMainCategory.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvMainCate.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            gridMainCategory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridMainCategory.AllowUserToResizeColumns = false;
            gridMainCategory.Columns[0].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);
            gridMainCategory.Columns[1].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);
            gridMainCategory.Columns[2].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);
            gridMainCategory.Columns[3].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);
            gridMainCategory.Columns[4].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);
            gridMainCategory.Columns[5].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);

            gridMainCategory.Columns[0].Width = 120;
            gridMainCategory.Columns[1].Width = 140;
            gridMainCategory.Columns[2].Width = 160;
            gridMainCategory.Columns[3].Width = 160;
            gridMainCategory.Columns[4].Width = 160;
            gridMainCategory.Columns[5].Width = 5;

            gridMainCategory.RowsDefaultCellStyle.Font = new Font("Tahoma", 11, FontStyle.Regular);

            gridMainCategory.Columns[0].HeaderCell.Value = "Code";
            gridMainCategory.Columns[1].HeaderCell.Value = "Name";
            gridMainCategory.Columns[2].HeaderCell.Value = "Description";

            gridMainCategory.Columns[4].HeaderCell.Value = "IsActivate";
            gridMainCategory.Columns[5].HeaderCell.Value = "";
            gridMainCategory.Columns[3].HeaderCell.Value = "";


        }



    }
}
