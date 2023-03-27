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


        private ItemRepo itemRepo = new ItemRepo();

        public frmItems()
        {
            InitializeComponent();
        }




        private void frmItems_Load(object sender, EventArgs e)
        {
            itemFormClass.MainCategoryIdToName(ComboMainCategory, mainCateRepo);
            itemFormClass.ComboPurchaseUnitlist(comboPurchaseUnit, unitRepo);
            itemFormClass.ComboSellingUnitlist(comboSellingUnit, unitRepo);
            itemFormClass.ComboRackNumberlist(comboRackNumber, rackRepo);
        }

        private void ComboMainCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboMainCategory.SelectedIndex == 0)
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
                    itObj = new Item();

                    return;
                }

                var decision = this.itemRepo.DataExists(itObj.ItemtId, itObj.ItemName);

                if (decision)
                {
                    MessageBox.Show("Please Press Update Button");
                }
                else
                {
                    //Save
                    if (this.itemRepo.Save(itObj))
                    {
                        MessageBox.Show("Save Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Save Failed");
                    }
                }
                Refresh();
                //// mainCatFormCla.PopulateGridViewMainCategory(gridMainCategory, mainCateRepo);

            }

            catch (Exception exception)
            {
                MessageBox.Show("Please Fill Correct Data" + exception.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public Item fillItem()
        {

            Item itemNew = new Item();
            List<string> errorList = new List<string>();


            if (txtitemid.Text == "") { ERRID.Show(); errorList.Add("Please Fill the Item ID"); } else { itemNew.ItemtId = txtitemid.Text; }

            if (txtname.Text == "") { ERRName.Show(); errorList.Add("Please Fill the Item Name"); } else { itemNew.ItemName = txtname.Text; }

            if (textBarcode.Text == "") { ERRBarcode.Show(); errorList.Add("Please Fill the Barcode"); } else { itemNew.Barcode = textBarcode.Text; }


            itemNew.DescriptionOne = txtdescription.Text;

            itemNew.DescriptionTwo = textDescriptionTwo.Text;

            if (comboPurchaseUnit.SelectedIndex == 0) { ERRPurchaseUnit.Show(); errorList.Add("Please Select Purchase Unit"); } else { itemNew.PurchaseUnit = comboPurchaseUnit.SelectedItem.ToString(); }

            if (comboSellingUnit.SelectedIndex == 0) { ERRSellingUnit.Show(); errorList.Add("Please Select Selling Unit"); } else { itemNew.SellingUnit = comboSellingUnit.SelectedItem.ToString(); }



            if (textBoxSellingPrice.Text == ""){ERRSellingPrice.Show();errorList.Add("Please Fill Selling Price");} else{itemNew.SellingPrice = textBoxSellingPrice.Text; }

            itemNew.Cost = Convert.ToDouble(textBoxCost.Text);
            itemNew.MRP = textBoxMrp.Text;
            itemNew.Supplier = comboBoxSupplier.SelectedItem.ToString();
            itemNew.PacketSize = Convert.ToDouble(textBoxPacketSize.Text);


            if (comboRackNumber.SelectedIndex == 0) { ERRReck.Show(); errorList.Add("Please Select the Rack Number"); } else { itemNew.RackNumber = comboRackNumber.SelectedItem.ToString(); }


            if (ComboMainCategory.SelectedIndex == 0) { ERRCategory.Show(); errorList.Add("Please Select Main Category"); } else { itemNew.CategoryName = ComboMainCategory.SelectedItem.ToString(); }


            if (comboBoxSubCategory.SelectedIndex == 0) { ERRSubCategory.Show(); errorList.Add("Please Select Sub Category"); } else { itemNew.subCategory = comboBoxSubCategory.SelectedItem.ToString(); }


            if (comboBoxBrand.SelectedIndex == 0) { ERRBrandName.Show(); errorList.Add("Please Select Brand"); } else { itemNew.brands = comboBoxBrand.SelectedItem.ToString(); }

            itemNew.ProductQty = Convert.ToDouble(TextBoxProductQty.Text.ToString());


            if (TextBoxDiscount.Text == "") { ErrDiscount.Show(); errorList.Add("Please Fill Discount Amount"); } else { itemNew.DisCount = Convert.ToDouble(TextBoxDiscount.Text); }

            itemNew.DiscountAmount = Convert.ToDouble(TextBoxDiscountAmount.Text);
            itemNew.WeightItem = Convert.ToDouble(TextBoxWeight.Text);
            itemNew.ServeItem = Convert.ToDouble(TextBoxServeItem.Text);
            itemNew.OptionOne = TextBoxOptionOne.Text;
            itemNew.OptionTwo = TextBoxOptionTwo.Text;
            itemNew.IsActive = checkBoxISActive.Checked;
            itemNew.ErrorList = errorList;




            return itemNew;

        }

        private void txtitemid_TextChanged(object sender, EventArgs e)
        {
            if (txtitemid.Text == "")
            {
                ERRID.Show();
            }
            else
            {
                ERRID.Hide();
            }
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {
            if (txtname.Text == "")
            {
                ERRName.Show();
            }
            else
            {
                ERRName.Hide();
            }
        }

        private void textBarcode_TextChanged(object sender, EventArgs e)
        {
            if (textBarcode.Text == "")
            {
                ERRBarcode.Show();
            }
            else
            {
                ERRBarcode.Hide();
            }
        }

        private void comboPurchaseUnit_TextChanged(object sender, EventArgs e)
        {
            if (comboPurchaseUnit.SelectedIndex == 0)
            {
                ERRPurchaseUnit.Show();
            }
            else
            {
                ERRPurchaseUnit.Hide();
            }
        }

        private void comboSellingUnit_TextChanged(object sender, EventArgs e)
        {
            if (comboSellingUnit.SelectedIndex == 0)
            {
                ERRSellingUnit.Show();
            }
            else
            {
                ERRSellingUnit.Hide();
            }

        }

        private void textBoxSellingPrice_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSellingPrice.Text == "")
            {
                ERRSellingPrice.Show();
            }
            else
            {
                ERRSellingPrice.Hide();
            }
        }

        private void comboRackNumber_TextChanged(object sender, EventArgs e)
        {
            if (comboRackNumber.SelectedIndex == 0)
            {
                ERRReck.Show();
            }
            else
            {
                ERRReck.Hide();
            }
        }

        private void ComboMainCategory_TextChanged(object sender, EventArgs e)
        {
            if (ComboMainCategory.SelectedIndex == 0)
            {
                ERRCategory.Show();
            }
            else
            {
                ERRCategory.Hide();
            }
        }

        private void comboBoxSubCategory_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxSubCategory.SelectedIndex == 0)
            {
                ERRSubCategory.Show();
            }
            else
            {
                ERRSubCategory.Hide();
            }

        }

        private void comboBoxBrand_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxBrand.SelectedIndex == 0)
            {
                ERRBrandName.Show();
            }
            else
            {
                ERRBrandName.Hide();
            }
        }

        private void TextBoxDiscount_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxDiscount.Text == "")
            {
                ErrDiscount.Show();
            }
            else
            {
                ErrDiscount.Hide();
            }
        }


    }
}
