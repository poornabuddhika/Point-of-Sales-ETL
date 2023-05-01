using IMS.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IMS.App
{
    public partial class GRNPopUP : Form
    {
        private ItemRepo itemRepo = new ItemRepo();
        private frmgrn fmgrn;
        public DataGridView GridObj()
        {
            return dataGridViewGrn;
        }

        public TextBox GinTexBox()
        {
            return textBoxGINSearch;
        }




        public GRNPopUP(frmgrn fmg)
        {
            fmgrn = fmg;
            InitializeComponent();
        }

        private void GRNPopUP_Load(object sender, EventArgs e)
        {
            PopulateGridViewUnit();
        }

        public void PopulateGridViewUnit(string searchKey = null)
        {
            dataGridViewGrn.AutoGenerateColumns = true;
            dataGridViewGrn.DataSource = itemRepo.GetAllGINItems(searchKey);
            subCategoryGridViewLoading(dataGridViewGrn);
            dataGridViewGrn.ClearSelection();
            dataGridViewGrn.Refresh();
        }


        private void subCategoryGridViewLoading(DataGridView GridViewItem)
        {
            //dataGridView1.DataSource = mj.drawDespatchData(selectedDrow, (int)MahajanaDespatchClass.Lottery.Mahajana);

            GridViewItem.RowsDefaultCellStyle.BackColor = Color.Bisque;
            GridViewItem.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            GridViewItem.CellBorderStyle = DataGridViewCellBorderStyle.None;

            GridViewItem.DefaultCellStyle.SelectionBackColor = Color.Red;
            GridViewItem.DefaultCellStyle.SelectionForeColor = Color.Yellow;

            GridViewItem.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvMainCate.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            GridViewItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridViewItem.AllowUserToResizeColumns = false;
            GridViewItem.Columns[0].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);
            GridViewItem.Columns[1].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);
            GridViewItem.Columns[2].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);
            GridViewItem.Columns[3].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);
            GridViewItem.Columns[4].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);
            GridViewItem.Columns[5].HeaderCell.Style.Font = new Font("Tahoma", 11, FontStyle.Bold);


            GridViewItem.Columns[0].Width = 120;
            GridViewItem.Columns[1].Width = 140;
            GridViewItem.Columns[2].Width = 160;
            GridViewItem.Columns[3].Width = 100;
            GridViewItem.Columns[4].Width = 100;
            GridViewItem.Columns[5].Width = 100;


            GridViewItem.RowsDefaultCellStyle.Font = new Font("Tahoma", 11, FontStyle.Regular);

            GridViewItem.Columns[0].HeaderCell.Value = "Item ID";
            GridViewItem.Columns[1].HeaderCell.Value = "Item Name";
            GridViewItem.Columns[2].HeaderCell.Value = "Discount";
            GridViewItem.Columns[3].HeaderCell.Value = "Status";
            GridViewItem.Columns[4].HeaderCell.Value = "Cost_Price";
            GridViewItem.Columns[5].HeaderCell.Value = "MRP";



        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (keyData == (Keys.Escape))
                {
                    this.Close();
                    Close();
                }
                else if ((keyData == (Keys.Down)) | (keyData == (Keys.Up)))
                {


                    dataGridViewGrn.Focus();
                    dataGridViewGrn.Focus();


                }
                else if (keyData == (Keys.Enter))
                {
                    string[] row = new string[6];


                    int index = this.dataGridViewGrn.CurrentRow.Index;
                    DataGridViewRow selectedRow = dataGridViewGrn.Rows[index];
                    //MessageBox.Show(selectedRow.Cells[0].Value.ToString());

                    row[0]=selectedRow.Cells["Item_ID"].Value.ToString();
                    row[1] = selectedRow.Cells["ItemName"].Value.ToString();
                    row[2] = "";
                    row[3] = selectedRow.Cells["MRP"].Value.ToString();
                    row[4] = selectedRow.Cells["ItemCost"].Value.ToString();
                   
                   

                    //textBoxPhysicalEnd.Text = selectedRow.Cells[2].Value.ToString();
                    fmgrn.AddtoGrid(row);
                    this.Close();

                }
                else
                {
                    if (textBoxGINSearch.Focused == true)
                    {

                    }
                    else
                    {
                        textBoxGINSearch.Focus();
                    }





                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }




            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void textBoxGINSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridViewGrn.DataSource = itemRepo.GetAllGINItems(textBoxGINSearch.Text);
        }



    }
}
