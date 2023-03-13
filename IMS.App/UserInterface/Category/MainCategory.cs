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
            this.dgvMainCate.AutoGenerateColumns = false;
            this.dgvMainCate.DataSource = this.mainCateRepo.GetAll(searchKey).ToList();
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

        
    }
}
