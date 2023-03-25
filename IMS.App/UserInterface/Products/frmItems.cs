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




namespace IMS.App.UserInterface.Products
{
    public partial class frmItems : Form
    {
        private MainCategoriesRepo mainCateRepo = new MainCategoriesRepo();


        ItemFormClass itemFormClass = new ItemFormClass();

        SubCategoriesReop subCateRepo = new SubCategoriesReop();

        BrandsRepo brandRepo = new BrandsRepo();

        private UnitRepo unitRepo = new UnitRepo();

        public frmItems()
        {
            InitializeComponent();
        }


       

        private void frmItems_Load(object sender, EventArgs e)
        {
            itemFormClass.MainCategoryIdToName(ComboMainCategory,  mainCateRepo);
            itemFormClass.ComboPurchaseUnitlist(comboPurchaseUnit, unitRepo);
            itemFormClass.ComboSellingUnitlist(comboSellingUnit, unitRepo);
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
    }
}
