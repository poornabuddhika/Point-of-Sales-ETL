using IMS.App.AppCass.Products;
using IMS.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IMS.App.UserInterface.Products
{
    public partial class frmItemList : Form
    {
        ItemFormClass itemFormClass = new ItemFormClass();
        private ItemRepo itemRepo = new ItemRepo();
        public frmItemList()
        {
            InitializeComponent();
        }

        private void frmItemList_Load(object sender, EventArgs e)
        {
            itemFormClass.PopulateGridViewUnit(GridViewItem, itemRepo);
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            itemFormClass.PopulateGridViewUnit(GridViewItem, itemRepo, txtsearch.Text);
        }
    }
}
