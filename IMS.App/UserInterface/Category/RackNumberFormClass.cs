using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMS.Entity.InventoryProducts;
using IMS.Repository.InventoryProducts;


namespace IMS.App.UserInterface.Category
{
    class RackNumberFormClass
    {
        internal Rack FillEntityRack(TextBox textBoxRackNumber, Label ErrorlabelRacNum,CheckBox checkBoxRack)
        {
            var mc = new Rack();
            if (textBoxRackNumber.Text == "")
            {

                if (textBoxRackNumber.Text == "")
                {
                    ErrorlabelRacNum.Show();
                }

                MessageBox.Show("Please Fill Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mc = null;
            }
            else if (textBoxRackNumber.Text != "")
            {
                ErrorlabelRacNum.Hide();
                
                
                mc.RackNumber = textBoxRackNumber.Text;
               
                mc.RackIsActive = Convert.ToBoolean(checkBoxRack.Checked.ToString());
            

            }


            return mc;
        }


        public void PopulateGridViewRack(DataGridView dataGridViewRackNumber, RackRepo rackRepo, string searchKey = null)
        {
            dataGridViewRackNumber.AutoGenerateColumns = true;
            dataGridViewRackNumber.DataSource = rackRepo.GetAll(searchKey).ToList();
            brandGridViewLoading(dataGridViewRackNumber);
            dataGridViewRackNumber.ClearSelection();
            dataGridViewRackNumber.Refresh();
            
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


            GridViewBrand.Columns[0].Width = 120;
            GridViewBrand.Columns[1].Width = 140;
            GridViewBrand.Columns[2].Width = 160;



            GridViewBrand.RowsDefaultCellStyle.Font = new Font("Tahoma", 11, FontStyle.Regular);

            GridViewBrand.Columns[0].HeaderCell.Value = "Brand ID";
            GridViewBrand.Columns[1].HeaderCell.Value = "Brand Name";
            GridViewBrand.Columns[2].HeaderCell.Value = "Brand TAG";




           
            GridViewBrand.Columns[0].Visible = false;
           

        }

    }
}
      

