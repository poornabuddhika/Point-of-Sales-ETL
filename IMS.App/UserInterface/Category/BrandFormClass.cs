using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMS.Entity.InventoryProducts;
using IMS.Repository;
using System.Drawing;
namespace IMS.App.UserInterface.Category
{
    class BrandFormClass
    {
   

        internal Brands FillEntityBrandCategory(TextBox textBrandName, TextBox textBrandTAG, CheckBox checkBoxBrandISActive,Label ErrorlabelBrandName,Label ErrorlabelBrandTag,int FillEntityBrandCategory)
        {
            var mc = new Brands();
            if (textBrandName.Text == "" || textBrandTAG.Text == "")
            {

                if (textBrandName.Text == "")
                {

                    ErrorlabelBrandName.Show();

                }
                if (textBrandTAG.Text == "")
                {

                    ErrorlabelBrandTag.Show();

                }
                MessageBox.Show("Please Fill Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mc = null;
            }
            else if (textBrandName.Text != "" & textBrandTAG.Text != "")
            {
                ErrorlabelBrandName.Hide();
                ErrorlabelBrandTag.Hide();
                mc.BrandName = textBrandName.Text;
                mc.BrandTag = textBrandTAG.Text;
                mc.BrandIsActive = Convert.ToBoolean( checkBoxBrandISActive.Checked.ToString());
                mc.BrandId = FillEntityBrandCategory;



            }


            return mc;
        }


        public void PopulateGridViewBrand(DataGridView GridViewBrand,BrandsRepo brandsRepo, string searchKey=null)
        {
            GridViewBrand.AutoGenerateColumns = true;
            GridViewBrand.DataSource = brandsRepo.GetAll(searchKey).ToList();
            brandGridViewLoading(GridViewBrand);
            GridViewBrand.ClearSelection();
            GridViewBrand.Refresh();
            //this.RefreshContent();
        }


        private void brandGridViewLoading(DataGridView GridViewBrand)
        {
            //dataGridView1.DataSource = mj.drawDespatchData(selectedDrow, (int)MahajanaDespatchClass.Lottery.Mahajana);

            GridViewBrand.RowsDefaultCellStyle.BackColor = Color.Bisque;
            GridViewBrand.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            GridViewBrand.CellBorderStyle = DataGridViewCellBorderStyle.None;

            GridViewBrand.DefaultCellStyle.SelectionBackColor = Color.Red;
            GridViewBrand.DefaultCellStyle.SelectionForeColor = Color.Yellow;

            GridViewBrand.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvMainCate.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            GridViewBrand.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridViewBrand.AllowUserToResizeColumns = false;
            GridViewBrand.Columns[0].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);
            GridViewBrand.Columns[1].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);
            GridViewBrand.Columns[2].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);
            GridViewBrand.Columns[3].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);
            GridViewBrand.Columns[4].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);
            GridViewBrand.Columns[5].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);

            GridViewBrand.Columns[0].Width = 120;
            GridViewBrand.Columns[1].Width = 140;
            GridViewBrand.Columns[2].Width = 160;
            GridViewBrand.Columns[3].Width = 160;
            GridViewBrand.Columns[4].Width = 0;
            GridViewBrand.Columns[5].Width = 0;
            GridViewBrand.Columns[6].Width = 0;
            GridViewBrand.Columns[7].Width = 0;
            GridViewBrand.Columns[7].Width = 0;
            

            GridViewBrand.RowsDefaultCellStyle.Font = new Font("Tahoma", 11, FontStyle.Regular);

            GridViewBrand.Columns[0].HeaderCell.Value = "Brand ID";
            GridViewBrand.Columns[1].HeaderCell.Value = "Brand Name";
            GridViewBrand.Columns[2].HeaderCell.Value = "Brand TAG";

            GridViewBrand.Columns[3].HeaderCell.Value = "Is Activate";
            GridViewBrand.Columns[4].HeaderCell.Value = "";
            GridViewBrand.Columns[5].HeaderCell.Value = "";



            GridViewBrand.Columns[4].Visible = false;
            GridViewBrand.Columns[0].Visible = false;
            GridViewBrand.Columns[5].Visible = false;
            GridViewBrand.Columns[6].Visible = false;
            GridViewBrand.Columns[7].Visible = false;
            GridViewBrand.Columns[8].Visible = false;
            GridViewBrand.Columns[9].Visible = false;

        }



    }
}
