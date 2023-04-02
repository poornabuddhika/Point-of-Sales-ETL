using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMS.Entity.InventoryProducts;
using IMS.Repository;
using System.Drawing;
using IMS.App.UserInterface.Category;



namespace IMS.App.AppCass.Category
{
    class UnitFormClass
    {
        internal Unit FillEntityUnitCategory(TextBox textUnitName, TextBox textUnitCode, CheckBox checkBoxUnit, Label ErrorlabelUnitName, Label ErrorlabelUnitCode)
        {
            var mc = new Unit();
            if (textUnitName.Text == "" || textUnitCode.Text == "")
            {

                if (textUnitName.Text == "")
                {

                    ErrorlabelUnitName.Show();

                }
                if (textUnitCode.Text == "")
                {

                    ErrorlabelUnitCode.Show();

                }
                MessageBox.Show("Please Fill Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mc = null;
            }
            else if (textUnitName.Text != "" & textUnitCode.Text != "")
            {
                ErrorlabelUnitName.Hide();
                ErrorlabelUnitCode.Hide();
                mc.UnitName = textUnitName.Text;
                mc.UnitCode = textUnitCode.Text;
                mc.IsActive = Convert.ToBoolean(checkBoxUnit.Checked.ToString());




            }


            return mc;
        }


        public void PopulateGridViewUnit(DataGridView dataGridViewUnit, UnitRepo unitRepo, string searchKey = null)
        {
            dataGridViewUnit.AutoGenerateColumns = true;
            dataGridViewUnit.DataSource = unitRepo.GetAll(searchKey).ToList();
            UnitGridViewLoading(dataGridViewUnit);
            dataGridViewUnit.ClearSelection();
            dataGridViewUnit.Refresh();
            //this.RefreshContent();
        }


        private void UnitGridViewLoading(DataGridView GridViewUnit)
        {
            //dataGridView1.DataSource = mj.drawDespatchData(selectedDrow, (int)MahajanaDespatchClass.Lottery.Mahajana);

            GridViewUnit.RowsDefaultCellStyle.BackColor = Color.Bisque;
            GridViewUnit.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            GridViewUnit.CellBorderStyle = DataGridViewCellBorderStyle.None;

            GridViewUnit.DefaultCellStyle.SelectionBackColor = Color.Red;
            GridViewUnit.DefaultCellStyle.SelectionForeColor = Color.Yellow;

            GridViewUnit.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvMainCate.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            GridViewUnit.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridViewUnit.AllowUserToResizeColumns = false;
            GridViewUnit.Columns[0].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);
            GridViewUnit.Columns[1].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);
            GridViewUnit.Columns[2].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);
            GridViewUnit.Columns[3].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);


            GridViewUnit.Columns[0].Width = 120;
            GridViewUnit.Columns[1].Width = 140;
            GridViewUnit.Columns[2].Width = 160;
            GridViewUnit.Columns[3].Width = 160;
           


            GridViewUnit.RowsDefaultCellStyle.Font = new Font("Tahoma", 11, FontStyle.Regular);

            GridViewUnit.Columns[0].HeaderCell.Value = "Unit ID";
            GridViewUnit.Columns[1].HeaderCell.Value = "Unit Name";
            GridViewUnit.Columns[2].HeaderCell.Value = "Unit Code";

            GridViewUnit.Columns[3].HeaderCell.Value = "Is Activate";
            



           
            GridViewUnit.Columns[0].Visible = false;
           

        }

        public void RefreshUnitContent(TextBox textUnitName, TextBox textUnitCode, TextBox textUnitSearch, CheckBox checkBoxUnit, Label ErrorlabelUnitName, Label ErrorlabelUnitCode)
        {
            textUnitName.Clear();
            textUnitCode.Clear();
            textUnitSearch.Clear();
            checkBoxUnit.Checked = true;
            ErrorlabelUnitName.Hide();
            ErrorlabelUnitCode.Hide();
        }

    }


}

