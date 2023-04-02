
using IMS.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IMS.App.UserInterface
{
    public partial class frmLogin : Form
    {
       // private UsersRepo usersRepo { get; set; }
        private UsersRepo usersRepo = new UsersRepo();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string role = usersRepo.GetRole(txtUserId.Text, txtPassword.Text);

            if (role == null)
            {
                MessageBox.Show("UserID & Password Incorrect", "Login Filed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.Equals(role.Trim(), "Admin"))
                
            {
                frmMain formStart = new frmMain(role, this);
                formStart.Visible = true;
                this.Visible = false;
            }
            else if (string.Equals(role.Trim(), "Cashier"))
            {
                new frmMain(role, this).Show();
                frmMain formStart = new frmMain(role, this);
                formStart.Visible = true;
                this.Visible = false;
            }
            else if (string.Equals(role.Trim(), "Salesman"))
            {
                new frmMain(role, this).Show();
                frmMain formStart = new frmMain(role, this);
                formStart.Visible = true;
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Role Returned : " + role);
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
