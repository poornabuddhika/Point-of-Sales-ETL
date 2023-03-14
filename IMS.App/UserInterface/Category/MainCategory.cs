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

namespace IMS.App.UserInterface.Category
{
    public partial class MainCategory : Form
    {

        private MainCategoriesRepo mainCateRepo = new MainCategoriesRepo();

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
                this.PopulateGridView();

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
                this.PopulateGridView();

            }

            catch (Exception exception)
            {
                MessageBox.Show("Please Fill Correct Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Clear Button
        private void btnClear_main_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            texName.Text = "";
            texDescrip.Text = "";
            texStockCover.Text = "";
            checkBoxActive_Category_main.Checked = true;
        }

       

        private void MainCategory_Load(object sender, EventArgs e)
        {
            labelCodeError.Hide();
            labelNameError.Hide();
            
        }



        private MainCategories FillEntity()
        {

            var mc = new MainCategories();
            if (txtCode.Text == "" || texName.Text == "")
            {

                if (txtCode.Text == "")
                {

                    labelCodeError.Show();

                }
                if (texName.Text == "")
                {

                    labelNameError.Show();

                }
                MessageBox.Show("Please Fill Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mc = null;
            }
            else if(txtCode.Text != "" & texName.Text != "")
            {
                labelCodeError.Hide();
                labelNameError.Hide();
                mc.MainCategoryCode = txtCode.Text;
                mc.MainCategoryName = texName.Text;
                mc.MainCategoryDescription = texDescrip.Text;
                mc.MainCategoryStockCover = texStockCover.Text;
                mc.MainCategoryIsActivate = checkBoxActive_Category_main.Checked;
            }

            
            return mc;
        }

        private void PopulateGridView(string searchKey = null)
        {
           
            this.dgvMainCate.AutoGenerateColumns = true;
            this.dgvMainCate.DataSource = this.mainCateRepo.GetAll(searchKey).ToList();
            gridViewLoading();
            this.dgvMainCate.ClearSelection();
            this.Refresh();
            this.RefreshContent();
        }

        public void RefreshContent()
        {
            txtCode.Clear();
            texName.Clear();
            texDescrip.Clear();
            texStockCover.Clear();
            checkBoxActive_Category_main.Checked = true;
        }

        private void gridViewLoading()
        {
            //dataGridView1.DataSource = mj.drawDespatchData(selectedDrow, (int)MahajanaDespatchClass.Lottery.Mahajana);

            dgvMainCate.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dgvMainCate.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dgvMainCate.CellBorderStyle = DataGridViewCellBorderStyle.None;

            dgvMainCate.DefaultCellStyle.SelectionBackColor = Color.Red;
            dgvMainCate.DefaultCellStyle.SelectionForeColor = Color.Yellow;

            dgvMainCate.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvMainCate.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvMainCate.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMainCate.AllowUserToResizeColumns = false;
            dgvMainCate.Columns[0].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);
            dgvMainCate.Columns[1].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);
            dgvMainCate.Columns[2].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);
            dgvMainCate.Columns[3].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);
            dgvMainCate.Columns[4].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);
            dgvMainCate.Columns[5].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);

            dgvMainCate.Columns[0].Width = 100;
            dgvMainCate.Columns[1].Width = 100;
            dgvMainCate.Columns[2].Width = 120;
            dgvMainCate.Columns[3].Width = 1;
            dgvMainCate.Columns[4].Width = 50;
            dgvMainCate.Columns[5].Width = 5;

            dgvMainCate.RowsDefaultCellStyle.Font = new Font("Tahoma", 11, FontStyle.Regular);

            dgvMainCate.Columns[0].HeaderCell.Value = "Code";
            dgvMainCate.Columns[1].HeaderCell.Value = "Name";
            dgvMainCate.Columns[2].HeaderCell.Value = "Description";
           
            dgvMainCate.Columns[4].HeaderCell.Value = "IsActivate";
            dgvMainCate.Columns[5].HeaderCell.Value = "";
            dgvMainCate.Columns[3].HeaderCell.Value = "";






        }





    }
}
