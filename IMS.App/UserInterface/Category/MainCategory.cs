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
using IMS.Repository.InventoryProducts;

namespace IMS.App.UserInterface.Category
{

    public partial class MainCategory : Form  
    {
        //Main Category class
        private MainCategoriesRepo mainCateRepo = new MainCategoriesRepo();

        //Subcategory Class
        private SubCategoriesReop subCateRepo = new SubCategoriesReop();

        private BrandsRepo brandsRepo = new BrandsRepo();
        private VendorsRepo vendorsRepo = new VendorsRepo();
        private UnitRepo unitRepo = new UnitRepo();
        private RackRepo rackRepo = new RackRepo();

        BrandFormClass br = new BrandFormClass();
        UnitFormClass unitForm = new UnitFormClass();
        RackNumberFormClass racknumberform = new RackNumberFormClass();

        //Main Category Region Start
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

        private void PopulateGridViewMainCategory(string searchKey = null)
        {

            this.gridMainCategory.AutoGenerateColumns = true;
            this.gridMainCategory.DataSource = this.mainCateRepo.GetAll(searchKey).ToList();
            MainCategoryGridViewLoading();
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

        private void MainCategoryGridViewLoading()
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

        private void textCategorySearch_TextChanged(object sender, EventArgs e)
        {
            this.PopulateGridViewMainCategory(this.textCategorySearch.Text);
        }


        #endregion 
        //Main Category Region End
        private void Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTab();
        }



        private void selectedTab()
        {
            if (TabCategory.SelectedTab.Text == "Main Category")
            {
                labelCategoryCodeError.Hide();
                labelCategoryNameError.Hide();
                PopulateGridViewMainCategory();
            }
            else if (TabCategory.SelectedTab.Text == "Sub Category")
            {
                ErrorLabelSubCategoryCombo.Hide();
                ErrorLabelSubCategoryName.Hide();
                MainCategoryIdToName();
                this.PopulateGridViewSubCategory();
            }
            else if(TabCategory.SelectedTab.Text == "Brand")
            {
                ErrorlabelBrandName.Hide();
                ErrorlabelBrandTag.Hide();
                br.PopulateGridViewBrand(GridViewBrand,brandsRepo);
            }
            else if(TabCategory.SelectedTab.Text == "UNIT Master")
            {
                ErrorlabelUnitName.Hide();
                ErrorlabelUnitCode.Hide();
                unitForm.PopulateGridViewUnit(dataGridViewUnit,unitRepo);
            }
        }


        //sub Catagogy region Start

        #region Sub Caregory

        private int hiddenSubCategory_id = 0;
        private int hiddenBrandCategory_id = 0;
        private SubCategoriesReop subCateReop = new SubCategoriesReop();

        public void MainCategoryIdToName()
        {
            this.comboSubCategory.Items.Clear();
            this.comboSubCategory.Items.Add("--Not Selected--");
            this.comboSubCategory.SelectedIndex = comboSubCategory.FindStringExact("--Not Selected--");
            foreach (DataRow row in this.mainCateRepo.LoadComboMainCategoryName().Rows)
            {


                this.comboSubCategory.Items.Add(row["cat_name"].ToString());

                
            }



        }



        private void comboSubCategory_KeyPress(object sender, KeyPressEventArgs e)
        {

            comboSubCategory.DroppedDown = false;

        }

        private void btnSUBCategorySave_Click(object sender, EventArgs e)
        {
           
            try
            {
                
                SubCategories scObj = FillEntitySubCategory();
                if (scObj == null)
                {
                    scObj = new SubCategories();

                    return;
                }

                var decision = this.subCateReop.DataExists(scObj.SubCategoryName);

                if (decision)
                {
                    MessageBox.Show("Please Press Update Button");
                }
                else
                {
                    //Save
                    if (this.subCateRepo.Save(scObj))
                    {
                        MessageBox.Show("Save Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Save Failed");
                    }
                }
                Refresh();
                this.PopulateGridViewSubCategory();

            
            }

            catch (Exception exception)
            {
                MessageBox.Show("Please Fill Correct Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        private SubCategories FillEntitySubCategory()
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



        private void PopulateGridViewSubCategory(string searchKey = null)
        {

            this.dataGridViewSubCategory.AutoGenerateColumns = true;
            this.dataGridViewSubCategory.DataSource = this.subCateRepo.GetAll(searchKey).ToList();
            subCategoryGridViewLoading();
            this.dataGridViewSubCategory.ClearSelection();
            this.Refresh();
            //this.RefreshContent();
        }


        private void subCategoryGridViewLoading()
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



        private void texSUBCategoryCodeSearch_TextChanged(object sender, EventArgs e)
        {
            this.PopulateGridViewSubCategory(this.texSUBCategoryCodeSearch.Text);
        }

        private void dataGridViewSubCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;// get the Row Index
            DataGridViewRow selectedRow = dataGridViewSubCategory.Rows[index];
            texSUBCategoryCode.Text = selectedRow.Cells[0].Value.ToString();
            comboSubCategory.Text = selectedRow.Cells[1].Value.ToString();
            texSUBCategoryDes.Text = selectedRow.Cells[2].Value.ToString();
            checkBoxSubCategoryActive.Checked = Convert.ToBoolean(selectedRow.Cells[3].Value.ToString());
            hiddenSubCategory_id = Convert.ToInt32(selectedRow.Cells[4].Value.ToString());

        }

        private void btnSUBCategoryUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SubCategories mcObj = this.FillEntitySubCategory();
                if (mcObj == null)
                {
                    mcObj = new SubCategories();

                    return;
                }

                var decision = this.subCateRepo.DataExists(mcObj.SubCategoryName);

                if (decision)
                {
                    //Update
                    if (this.subCateRepo.UpdateProduct(mcObj))
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
                this.PopulateGridViewSubCategory();

            }

            catch (Exception exception)
            {
                MessageBox.Show("Please Fill Correct Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        #endregion

        //sub Catagogy region End


        private void btnBrandSave_Click(object sender, EventArgs e)
        {
          
            
            try
            {
                Brands brObj = br.FillEntityBrandCategory(textBrandName, textBrandTAG, checkBoxBrandISActive, ErrorlabelBrandName,ErrorlabelBrandTag,hiddenBrandCategory_id);
                if (brObj == null)
                {
                    brObj = new Brands();

                    return;
                }

                var decision = this.brandsRepo.DataExists(brObj.BrandName);

                if (decision)
                {
                    MessageBox.Show("Please Press Update Button");
                }
                else
                {
                    //Save
                    if (this.brandsRepo.Save(brObj))
                    {
                        MessageBox.Show("Save Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Save Failed");
                    }
                }
                Refresh();
                br.PopulateGridViewBrand(GridViewBrand, brandsRepo);


            }

            catch (Exception exception)
            {
                MessageBox.Show("Please Fill Correct Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void buttonBrandUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Brands brObj = br.FillEntityBrandCategory(textBrandName, textBrandTAG, checkBoxBrandISActive, ErrorlabelBrandName, ErrorlabelBrandTag, hiddenBrandCategory_id);
                if (brObj == null)
                {
                    brObj = new Brands();

                    return;
                }

                var decision = this.brandsRepo.DataExists(brObj.BrandName);

                if (decision)
                {
                    //Update
                    if (this.brandsRepo.UpdateProduct(brObj))
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
                br.PopulateGridViewBrand(GridViewBrand, brandsRepo);

            }

            catch (Exception exception)
            {
                MessageBox.Show("Please Fill Correct Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void GridViewBrand_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;// get the Row Index
            DataGridViewRow selectedRow = GridViewBrand.Rows[index];
           
            hiddenBrandCategory_id = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
            textBrandName.Text = selectedRow.Cells[1].Value.ToString();
            textBrandTAG.Text = selectedRow.Cells[2].Value.ToString();
            checkBoxBrandISActive.Checked=Convert.ToBoolean( selectedRow.Cells[3].Value.ToString());

        }

        private void textBrandSearch_TextChanged(object sender, EventArgs e)
        {
            br.PopulateGridViewBrand(GridViewBrand,brandsRepo, textBrandSearch.Text);
        }

        private void buttonUnitSave_Click(object sender, EventArgs e)
        {

            try
            {
                Unit brObj = unitForm.FillEntityUnitCategory(textUnitName, textUnitCode, checkBoxUnit, ErrorlabelUnitName, ErrorlabelUnitCode);
                if (brObj == null)
                {
                    brObj = new Unit();

                    return;
                }

                var decision = this.unitRepo.DataExists(brObj.UnitName);

                if (decision)
                {
                    MessageBox.Show("Please Press Update Button");
                }
                else
                {
                    //Save
                    if (this.unitRepo.Save(brObj))
                    {
                        MessageBox.Show("Save Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Save Failed");
                    }
                }
                Refresh();
                unitForm.PopulateGridViewUnit(dataGridViewUnit, unitRepo);


            }

            catch (Exception exception)
            {
                MessageBox.Show("Please Fill Correct Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonUnitUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Unit brObj = unitForm.FillEntityUnitCategory(textUnitName, textUnitCode, checkBoxUnit, ErrorlabelUnitName, ErrorlabelUnitCode);
                if (brObj == null)
                {
                    brObj = new Unit();

                    return;
                }

                var decision = this.unitRepo.DataExists(brObj.UnitName);

                if (decision)
                {
                    //Update
                    if (this.unitRepo.UpdateProduct(brObj))
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
                unitForm.PopulateGridViewUnit(dataGridViewUnit, unitRepo);

            }

            catch (Exception exception)
            {
                MessageBox.Show("Please Fill Correct Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textUnitSearch_TextChanged(object sender, EventArgs e)
        {
            unitForm.PopulateGridViewUnit(dataGridViewUnit, unitRepo,textUnitSearch.Text);
        }

        private void dataGridViewUnit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;// get the Row Index
            DataGridViewRow selectedRow = dataGridViewUnit.Rows[index];

           
            textUnitName.Text = selectedRow.Cells[1].Value.ToString();
            textUnitCode.Text = selectedRow.Cells[2].Value.ToString();
            checkBoxUnit.Checked = Convert.ToBoolean(selectedRow.Cells[3].Value.ToString());
        }

        private void buttonRackSave_Click(object sender, EventArgs e)
        {

            try
            {
                Rack brObj = racknumberform.FillEntityRack(textBoxRackNumber, ErrorlabelRacNum, checkBoxRack);
                if (brObj == null)
                {
                    brObj = new Rack();

                    return;
                }
                
                var decision = this.rackRepo.DataExists(brObj.RackNumber);

                if (decision)
                {
                    MessageBox.Show("Record already exists!!!!!! Please Press Update Button");
                }
                else
                {
                    //Save
                    if (this.rackRepo.Save(brObj))
                    {
                        MessageBox.Show("Save Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Save Failed");
                    }
                }
                Refresh();
                racknumberform.PopulateGridViewRack(dataGridViewRackNumber, rackRepo);


            }

            catch (Exception exception)
            {
                MessageBox.Show("Please Fill Correct Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRackUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Rack brObj = racknumberform.FillEntityRack(textBoxRackNumber, ErrorlabelRacNum, checkBoxRack);
                if (brObj == null)
                {
                    brObj = new Rack();

                    return;
                }

                var decision = this.rackRepo.DataExists(brObj.RackNumber);

                if (decision)
                {
                    //Update
                    if (this.rackRepo.UpdateProduct(brObj))
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
                racknumberform.PopulateGridViewRack(dataGridViewRackNumber, rackRepo);

            }

            catch (Exception exception)
            {
                MessageBox.Show("Please Fill Correct Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }







}
