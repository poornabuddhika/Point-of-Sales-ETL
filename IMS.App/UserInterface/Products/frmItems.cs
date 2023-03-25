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
using IMS.App.AppCass.Products;
using IMS.Entity.InventoryProducts;




namespace IMS.App.UserInterface.Products
{
    public partial class frmItems : Form
    {
        private MainCategoriesRepo mainCateRepo = new MainCategoriesRepo();


        ItemFormClass itemFormClass = new ItemFormClass();

        SubCategoriesReop subCateRepo = new SubCategoriesReop();

        BrandsRepo brandRepo = new BrandsRepo();

        private UnitRepo unitRepo = new UnitRepo();

        private RackRepo rackRepo = new RackRepo();

        public frmItems()
        {
            InitializeComponent();
        }


       

        private void frmItems_Load(object sender, EventArgs e)
        {
            itemFormClass.MainCategoryIdToName(ComboMainCategory,  mainCateRepo);
            itemFormClass.ComboPurchaseUnitlist(comboPurchaseUnit, unitRepo);
            itemFormClass.ComboSellingUnitlist(comboSellingUnit, unitRepo);
            itemFormClass.ComboRackNumberlist(comboRackNumber, rackRepo);
        }

        private void ComboMainCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ComboMainCategory.SelectedIndex==0)
            {
                comboBoxSubCategory.Items.Clear();
                comboBoxSubCategory.Text = "";
                comboBoxSubCategory.Enabled = false;
            }
            else
            {
                comboBoxSubCategory.Enabled = true;
                itemFormClass.SubCategoryIdToName(comboBoxSubCategory, subCateRepo, ComboMainCategory.SelectedItem.ToString());
                itemFormClass.BrndName(comboBoxBrand, brandRepo);
            }
            
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                Item itObj = itemFormClass.FillEntityItem(fillItem());
                if (itObj == null)
                {
                    itObj = new MainCategories();

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
                mainCatFormCla.PopulateGridViewMainCategory(gridMainCategory, mainCateRepo);

            }

            catch (Exception exception)
            {
                MessageBox.Show("Please Fill Correct Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public Item fillItem()
        {

            Item itemNew = new Item();
            itemNew.ItemtId = txtitemid.Text;
            itemNew.ItemName = txtname.Text;
            itemNew.Barcode = textBarcode.Text;
            itemNew.DescriptionOne = txtdescription.Text;
            itemNew.DescriptionTwo = textDescriptionTwo.Text;
            itemNew.PurchaseUnit = comboPurchaseUnit.SelectedItem.ToString();
            itemNew.SellingUnit = comboSellingUnit.SelectedItem.ToString();
            itemNew.SellingPrice = textBoxSellingPrice.Text;
            itemNew.Cost = Convert.ToDouble(textBoxCost.Text);
            itemNew.MRP = textBoxMrp.Text;
            itemNew.Supplier = comboBoxSupplier.SelectedItem.ToString();
            itemNew.PacketSize = Convert.ToDouble(textBoxPacketSize.Text);
            itemNew.RackNumber = comboRackNumber.SelectedItem.ToString();
            itemNew.CategoryName = ComboMainCategory.SelectedItem.ToString();
            itemNew.subCategory = comboBoxSubCategory.SelectedItem.ToString();
            itemNew.brands = comboBoxBrand.SelectedItem.ToString();
            itemNew.ProductQty = Convert.ToDouble(TextBoxProductQty.Text.ToString());
            itemNew.DisCount = Convert.ToDouble(TextBoxDiscount.Text);
            itemNew.DiscountAmount = Convert.ToDouble(TextBoxDiscountAmount.Text);
            itemNew.WeightItem = Convert.ToDouble(TextBoxWeight.Text);
            itemNew.ServeItem = Convert.ToDouble(TextBoxServeItem.Text);
            itemNew.OptionOne = TextBoxOptionOne.Text;
            itemNew.OptionTwo = TextBoxOptionTwo.Text;
            itemNew.IsActive = checkBoxISActive.Checked;





            return itemNew;

        }





    }
}
