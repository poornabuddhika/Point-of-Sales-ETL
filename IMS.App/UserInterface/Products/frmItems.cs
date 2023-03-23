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
        public frmItems()
        {
            InitializeComponent();
        }


       

        private void frmItems_Load(object sender, EventArgs e)
        {
            itemFormClass.MainCategoryIdToName(ComboMainCategory,  mainCateRepo);
        }

        private void ComboMainCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }
    }
}
