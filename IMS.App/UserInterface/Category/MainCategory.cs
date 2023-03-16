using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Repository;
using IMS.Entity.InventoryProducts;
using System.Text.RegularExpressions;

namespace IMS.App.UserInterface.Category
{

    public partial class MainCategory : Form
    {

        private MainCategoriesRepo mainCateRepo = new MainCategoriesRepo();

        #region MainCategory
        //constructor
        public MainCategory()
        {
            InitializeComponent();
        }


        
        //Save Button
        private void btnsave_Category_Main_Click(object sender, EventArgs e)
        {
            try
            {
                MainCategories mcObj = this.FillEntity();
                if (mcObj == null)
                {
                    mcObj = new MainCategories();
                    
                    return;
                }

                var decision = this.mainCateRepo.DataExists(mcObj.MainCategoryCode);

                if (decision)
                {
                    MessageBox.Show("Please Press Update Button");
                }
                else
                {
                    //Save
                    if (this.mainCateRepo.Save(mcObj))
                    {
                        MessageBox.Show("Save Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Save Failed");
                    }
                }
                Refresh();
                this.PopulateGridViewMainCategory();

            }

            catch (Exception exception)
            {
                MessageBox.Show("Please Fill Correct Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        //Update Button
        private void btnupdate_Category_Main_Click(object sender, EventArgs e)
        {

            try
            {
                MainCategories mcObj = this.FillEntity();
                if (mcObj == null)
                {
                    mcObj = new MainCategories();

                    return;
                }

                var decision = this.mainCateRepo.DataExists(mcObj.MainCategoryCode);

                if (decision)
                {
                    //Update
                    if (this.mainCateRepo.UpdateProduct(mcObj))
                    {
                        MessageBox.Show("Update Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Update Failed");
                    }
                }
                else
                {
                    MessageBox.Show("This Recode not Exist in the Database");
                }
                Refresh();
                this.PopulateGridViewMainCategory();

            }

            catch (Exception exception)
            {
                MessageBox.Show("Please Fill Correct Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Clear Button
        private void btnClear_Category_Click(object sender, EventArgs e)
        {
            textCategoryCode.Text = "";
            textCategoryName.Text = "";
            textCategoryDescrip.Text = "";
            textCategoryStockCover.Text = "";
            checkBoxActive_Category_main.Checked = true;
        }

       

        private void MainCategory_Load(object sender, EventArgs e)
        {
            labelCategoryCodeError.Hide();
            labelCategoryNameError.Hide();
            selectedTab();
            

        }

        private void dgvMainCate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;// get the Row Index
            DataGridViewRow selectedRow = gridMainCategory.Rows[index];
            textCategoryCode.Text = selectedRow.Cells[0].Value.ToString();
            textCategoryName.Text = selectedRow.Cells[1].Value.ToString();
            textCategoryDescrip.Text = selectedRow.Cells[2].Value.ToString();
            textCategoryStockCover.Text = selectedRow.Cells[3].Value.ToString();
            checkBoxActive_Category_main.Checked = Convert.ToBoolean(selectedRow.Cells[4].Value.ToString());

        }

        private MainCategories FillEntity()
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
            else if(textCategoryCode.Text != "" & textCategoryName.Text != "")
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

        private void PopulateGridViewMainCategory(string searchKey = null)
        {
           
            this.gridMainCategory.AutoGenerateColumns = true;
            this.gridMainCategory.DataSource = this.mainCateRepo.GetAll(searchKey).ToList();
            gridViewLoading();
            this.gridMainCategory.ClearSelection();
            this.Refresh();
            //this.RefreshContent();
        }

        public void RefreshContent()
        {
            textCategoryCode.Clear();
            textCategoryName.Clear();
            textCategoryDescrip.Clear();
            textCategoryStockCover.Clear();
            checkBoxActive_Category_main.Checked = true;
            textCategorySearch.Clear();
        }

        private void gridViewLoading()
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
            gridMainCategory.Columns[3].Width = 1;
            gridMainCategory.Columns[4].Width = 80;
            gridMainCategory.Columns[5].Width = 5;

            gridMainCategory.RowsDefaultCellStyle.Font = new Font("Tahoma", 11, FontStyle.Regular);

            gridMainCategory.Columns[0].HeaderCell.Value = "Code";
            gridMainCategory.Columns[1].HeaderCell.Value = "Name";
            gridMainCategory.Columns[2].HeaderCell.Value = "Description";
           
            gridMainCategory.Columns[4].HeaderCell.Value = "IsActivate";
            gridMainCategory.Columns[5].HeaderCell.Value = "";
            gridMainCategory.Columns[3].HeaderCell.Value = "";


        }

        private void textCategorySearch_TextChanged(object sender, EventArgs e)
        {
            this.PopulateGridViewMainCategory(this.textCategorySearch.Text);
        }


        #endregion 

        private void Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTab();
        }



        private void selectedTab()
        {
            if (TabCategory.SelectedTab.Text == "Main Category")
            {
                PopulateGridViewMainCategory();
            }
            else if(TabCategory.SelectedTab.Text == "Sub Category")
            {
                
                MainCategoryIdToName();
            }
        }



        public void MainCategoryIdToName()
        {
            this.comboSubCategory.Items.Clear();
            this.comboSubCategory.Items.Add("--Not Selected--");
            this.comboSubCategory.SelectedIndex = comboSubCategory.FindStringExact("--Not Selected--");
            foreach (DataRow row in this.mainCateRepo.LoadComboMainCategoryName().Rows)
            {
                 this.comboSubCategory.Items.Add(  row["cat_code"].ToString()+"   "+ row["cat_name"].ToString());
                

            }



        }

 

        private void comboSubCategory_KeyPress(object sender, KeyPressEventArgs e)
        {

            comboSubCategory.DroppedDown = false;
           
        }


    }


}
