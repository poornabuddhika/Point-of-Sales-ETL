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
using IMS.App.AppCass.Category;

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
        MainCategoryFormClass mainCatFormCla = new MainCategoryFormClass();
        SubCategoryFormClass subCateFmC = new SubCategoryFormClass();

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
                MainCategories mcObj = mainCatFormCla.FillEntityMainCategory(textCategoryCode,textCategoryName, textCategoryDescrip,textCategoryStockCover, checkBoxActive_Category_main,labelCategoryCodeError,labelCategoryNameError);
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
                mainCatFormCla.PopulateGridViewMainCategory(gridMainCategory,  mainCateRepo);

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
                MainCategories mcObj = mainCatFormCla.FillEntityMainCategory(textCategoryCode, textCategoryName, textCategoryDescrip, textCategoryStockCover, checkBoxActive_Category_main, labelCategoryCodeError, labelCategoryNameError);
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
                mainCatFormCla.PopulateGridViewMainCategory(gridMainCategory, mainCateRepo);

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

       
      

        public void RefreshContent()
        {
            textCategoryCode.Clear();
            textCategoryName.Clear();
            textCategoryDescrip.Clear();
            textCategoryStockCover.Clear();
            checkBoxActive_Category_main.Checked = true;
            textCategorySearch.Clear();
        }

        
        private void textCategorySearch_TextChanged(object sender, EventArgs e)
        {
            
            mainCatFormCla.PopulateGridViewMainCategory(gridMainCategory, mainCateRepo, textCategorySearch.Text);
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
                mainCatFormCla.PopulateGridViewMainCategory(gridMainCategory, mainCateRepo);
            }
            else if (TabCategory.SelectedTab.Text == "Sub Category")
            {
                ErrorLabelSubCategoryCombo.Hide();
                ErrorLabelSubCategoryName.Hide();
                MainCategoryIdToName();
                subCateFmC.PopulateGridViewSubCategory(dataGridViewSubCategory,subCateRepo);
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

                SubCategories scObj = subCateFmC.FillEntitySubCategory(comboSubCategory, texSUBCategoryCode, texSUBCategoryDes, ErrorLabelSubCategoryCombo, ErrorLabelSubCategoryName, checkBoxSubCategoryActive, hiddenSubCategory_id);
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
                subCateFmC.PopulateGridViewSubCategory(dataGridViewSubCategory, subCateRepo);


            }

            catch (Exception exception)
            {
                MessageBox.Show("Please Fill Correct Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void texSUBCategoryCodeSearch_TextChanged(object sender, EventArgs e)
        {
            
            subCateFmC.PopulateGridViewSubCategory(dataGridViewSubCategory, subCateRepo, this.texSUBCategoryCodeSearch.Text);
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
                SubCategories mcObj = subCateFmC.FillEntitySubCategory(comboSubCategory, texSUBCategoryCode, texSUBCategoryDes, ErrorLabelSubCategoryCombo, ErrorLabelSubCategoryName, checkBoxSubCategoryActive, hiddenSubCategory_id);
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
                subCateFmC.PopulateGridViewSubCategory(dataGridViewSubCategory, subCateRepo);

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

        private void btnSUBCategoryClear_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonRackClear_Click(object sender, EventArgs e)
        {
            racknumberform.RefreshRackContent(textBoxRackNumber, textRackSearch, ErrorlabelRacNum, checkBoxRack);
        }

        private void buttonUnitClear_Click(object sender, EventArgs e)
        {
            unitForm.RefreshUnitContent( textUnitName,textUnitCode,textUnitSearch,checkBoxUnit,ErrorlabelUnitName,ErrorlabelUnitCode);
        }
    }







}
