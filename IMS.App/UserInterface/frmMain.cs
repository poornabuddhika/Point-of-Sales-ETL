using IMS.App.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMS.App.UserInterface.Products;
using IMS.App.UserInterface.Category;

namespace IMS.App.UserInterface
{
    public partial class frmMain : Form
    {
        private string role;
        private Form loginForm;


        public frmMain()
        {
            InitializeComponent();
        }

        public frmMain(string role, Form form)
        {
            InitializeComponent();

            this.loginForm = form;
            this.role = role;

            if (role == "Admin")
            {
                //SetupForAdmin();
            }
            else if (role == "Cashier")
            {
                //SetupForCashier();
            }
            else if (role == "Salesman")
            {
                //SetupForSalesman();
            }

            // this.lblShowUserInfo.Text = this.role;
        }

        public void closeForm()
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }

        }
        public void enabled_menu()
        {
           

        }
        public void disabled_menu()
        {
            
        }
        public void showFrm(Form frm)
        {
            this.IsMdiContainer = true;
            frm.MdiParent = this;
            frm.Show();
        }

        private void ts_stocks_Click(object sender, EventArgs e)
        {
            closeForm();
            //showFrm(new frmItems());
        }

        private void ts_StockOut_Click(object sender, EventArgs e)
        {
            closeForm();
            // showFrm(new frmStockOut(""));
        }

        private void ts_Return_Click(object sender, EventArgs e)
        {
            closeForm();
            //   showFrm(new frmReturn());
        }

        private void ts_ManageUsers_Click(object sender, EventArgs e)
        {
            closeForm();
            // showFrm(new frmUsers());
        }

        private void ts_Report_Click(object sender, EventArgs e)
        {
            closeForm();
            // showFrm(new frmReport());

        }

        private void ts_Login_Click(object sender, EventArgs e)
        {
           
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            disabled_menu();

        }

        private void ts_settings_Click(object sender, EventArgs e)
        {
            closeForm();
            //showFrm(new frmSettings());
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void addItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new frmItems());
        }

        private void itemMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new MainCategory());
        }

        private void frmMain_Load_1(object sender, EventArgs e)
        {

        }

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new frmsupplier_detail());
        }

        private void listItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new frmItemList());
        }

        private void gRNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new frmgrn());
        }
    }
}
    
