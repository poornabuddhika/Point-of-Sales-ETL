using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMS.Entity;
using IMS.Repository;
using IMS.Entity.InventoryProducts;

namespace IMS.App
{
    public partial class frmgrn : Form
    {
        private WherehouseRepo whereHouseRepo = new WherehouseRepo();

        private SupplierRepo supplierRepo = new SupplierRepo();

        private ItemRepo itemRepo = new ItemRepo();

        private GRN gRN = new GRN();

        private GRNItemClass grnItmclass = new GRNItemClass();

        private GRNRepo gRNRepo = new GRNRepo();

        private GRNItemRepo gRNItemRepo = new GRNItemRepo();

        GRNFormClass gRNFormClass = new GRNFormClass();

        GRNPopUP gRNPopUP;
        private GRNPopUP GrnPopupOb()
        {

             gRNPopUP = new GRNPopUP(this);
            return gRNPopUP;
        }
        
        public frmgrn()
        {
            GrnPopupOb();
            InitializeComponent();
        }

       

        //Form Load 

        private void frmgrn_Load(object sender, EventArgs e)
        {
            WherehouseCombo();
            SupplierCombo();
            dataGridViewGRN.Columns[0].ReadOnly = true;
            dataGridViewGRN.Columns[1].ReadOnly = true;
            dataGridViewGRN.Columns[5].ReadOnly = true;


        }



        public void WherehouseCombo()
        {
            this.comboBoxWherehouseCombo.Items.Clear();
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(0, "--select--");
            foreach (DataRow row in this.whereHouseRepo.LoadComboWherehouseName().Rows)
            {

                comboSource.Add(Convert.ToInt32(row["wherehouse_ID"].ToString().Trim()), row["wherehouse_Name"].ToString().Trim());

            }

            comboBoxWherehouseCombo.DataSource = new BindingSource(comboSource, null);
            comboBoxWherehouseCombo.DisplayMember = "Value";
            comboBoxWherehouseCombo.ValueMember = "Key";



        }



        public void SupplierCombo()
        {

            Dictionary<string, string> comboSource = new Dictionary<string, string>();

            comboSource.Add("0", "--select--");

            foreach (DataRow row in this.supplierRepo.LoadSupplier().Rows)
            {


               
                comboSource.Add(row["sup_id"].ToString(), row["sup_Name"].ToString().Trim());



            }

            comboBoxSupplier.DataSource = new BindingSource(comboSource, null);
            comboBoxSupplier.DisplayMember = "Value";
            comboBoxSupplier.ValueMember = "Key";



        }


        //Save Button
        private void button1_Click(object sender, EventArgs e)
        {

            
            try
            {
                GRN grnObj = FillEntityItem(fillGRN());
                if (grnObj == null)
                {
                    grnObj = new GRN();

                    return;
                }

                var decision = this.gRNRepo.DataExists(grnObj.YourRefNumber);

                if (decision)
                {
                    MessageBox.Show("Please Press Update Button");
                }
                else
                {
                   
                       

                        //Save
                        if (this.gRNRepo.Save(grnObj))
                        {
                        List<GRNItemClass> gRNItemClasses2 = fillItemsToList(grnObj);
                        if(gRNItemClasses2.Count !=0)
                        {
                            bool boolginItem= gRNFormClass.SaveItemByItem(gRNItemClasses2, gRNItemRepo);
                            if (boolginItem == false)
                            {
                                this.gRNRepo.UpdateDesableGIN(grnObj);
                                this.gRNItemRepo.UpdateDesableGINItems(grnObj);
                            }
                            
                        }

                        MessageBox.Show("Save Successfully");
                        }
                        else
                        {
                            MessageBox.Show("Save Failed");
                        }
                    }
                   
                
                Refresh();
               

            }

            catch (Exception exception)
            {
                MessageBox.Show("Please Fill Correct Data" + exception.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private List<GRNItemClass> fillItemsToList(GRN gRN)
        {
            List<GRNItemClass> grnItemList = new List<GRNItemClass>();
            for(int i=0;i<(dataGridViewGRN.RowCount-1);i++)
            {
                grnItmclass.Item_ID = dataGridViewGRN.Rows[i].Cells[0].Value.ToString();
                grnItmclass.Ref_Desc= dataGridViewGRN.Rows[i].Cells[1].Value.ToString();
                grnItmclass.Ref_GRN_Master_ID = (gRN.GRNNumber+1).ToString();
                
               if (dataGridViewGRN.Rows[i].Cells[2].Value == null)
                {
                    MessageBox.Show("Please fill the " + grnItmclass.Ref_Desc.ToString() + "Qty");
                    return null;
                }
               else
                {
                    grnItmclass.Ref_Qty1 = float.Parse(dataGridViewGRN.Rows[i].Cells[2].Value.ToString());
                }
                
               if(dataGridViewGRN.Rows[i].Cells[3].Value==null)
                {
                    grnItmclass.MRP = 0;
                }
               else
                {
                    grnItmclass.MRP = Convert.ToDecimal(dataGridViewGRN.Rows[i].Cells[3].Value.ToString());
                }
                
                 
                if (dataGridViewGRN.Rows[i].Cells[4].Value == null)
                {
                    grnItmclass.AvgCost = 0;
                }
                else
                {
                    grnItmclass.AvgCost = Convert.ToDecimal(dataGridViewGRN.Rows[i].Cells[4].Value.ToString());
                }
                    

                if (dataGridViewGRN.Rows[i].Cells[6].Value == null)
                {
                    grnItmclass.DisCount_Rate = 0.0f;
                }
                else
                {
                    grnItmclass.DisCount_Rate = (float.Parse(dataGridViewGRN.Rows[i].Cells[6].Value.ToString() )) / 100;
                }
                

                grnItemList.Add(grnItmclass);


            }
            return grnItemList;
        }




        private GRN fillGRN()
        {
            GRN grn = new GRN();
            List<string> errorList = new List<string>();

            if (comboBoxWherehouseCombo.SelectedIndex == 0) { errorList.Add("Fill the Location"); ErrLocation.Show(); } else { grn.Location=((KeyValuePair<int, string>)comboBoxWherehouseCombo.SelectedItem).Key; };
            if (comboBoxSupplier.SelectedIndex == 0) { errorList.Add("Fill the Supplier");ErrSupplier.Show(); } else { grn.Supplier = ((KeyValuePair<string, string>)comboBoxSupplier.SelectedItem).Key; };
           
            grn.Remarks = textBoxRemarks.Text;
            
            //set the GRN Number
            grn.GRNNumber = gRNRepo.DataCount();
            
            textBoxGrnNumber.Text = grn.GRNNumber.ToString("D8");

            grn.GRNDate = dateTimePickerGranDate.Value;
            

            grn.OurRefNumber = textBoxOurRefNo.Text;
            grn.GRNRefarance = textBoxGrnRefNo.Text;

            if (gRNRepo.DataExists(textBoxYourRefNo.Text)) { errorList.Add("Fill the YourRef Number"); ERRYourRefNo.Show();MessageBox.Show("Your Referance Number Already Exists"); } else { grn.YourRefNumber = textBoxYourRefNo.Text; ERRYourRefNo.Hide(); ; }
               

            grn.Payables = (textBoxPayables.Text=="")? Convert.ToDecimal("0") : Convert.ToDecimal(textBoxPayables.Text);
            grn.DueDate = dateTimePickerDueDate.Value;

            grn.GrossValue = (textBoxGrossValue.Text=="" )? Convert.ToDecimal("0"):   Convert.ToDecimal( textBoxGrossValue.Text);
            grn.NetValue=(textBoxNetValue.Text=="") ? Convert.ToDecimal("0"): Convert.ToDecimal(textBoxNetValue.Text);
            grn.TaxesValue = (textBoxTaxes.Text=="")? Convert.ToDecimal("0"):Convert.ToDecimal(textBoxTaxes.Text);
            grn.DiscountRate =(textBoxDis1.Text=="")? Convert.ToDecimal("0") : Convert.ToDecimal(textBoxDis1.Text);
            grn.DiscountAmount=(textBoxDis2.Text=="")? Convert.ToDecimal("0") : Convert.ToDecimal(textBoxDis2.Text);
            grn.ErrorList = errorList;

            return grn;

        }

        private GRN FillEntityItem(GRN grn)
        {

            var mc = new GRN();

            if (grn.ErrorList.Count != 0)
            {



                MessageBox.Show("Please Fill the Correct  Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mc = null;
            }
            else
            {
                mc = grn;
            }


            return mc;



        }

        private void textBoxYourRefNo_TextChanged(object sender, EventArgs e)
        {
            if (textBoxYourRefNo.Text == "")
            {
                ERRYourRefNo.Show();
            }
            else
            {
                ERRYourRefNo.Hide();
            }
        }

        private void comboBoxWherehouseCombo_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxWherehouseCombo.SelectedIndex == 0)
            {
                ErrLocation.Show();
            }
            else
            {
                ErrLocation.Hide();
            }
        }

        private void comboBoxSupplier_TextChanged(object sender, EventArgs e)
        {

            if (comboBoxSupplier.SelectedIndex == 0)
            {
                ErrSupplier.Show();
            }
            else
            {
                ErrSupplier.Hide();
            }


        }

 

        private AutoCompleteStringCollection AutoDataSource(List<Item> itemsList)
        {
            AutoCompleteStringCollection ac = new AutoCompleteStringCollection();

            foreach (Item it in itemsList)
            {

                ac.Add(it.ItemtId.ToString() + it.ItemName.ToString());
            }

            return ac;

        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((keyData == (Keys.Down)) | (keyData == (Keys.Up)) )
            {
                if (gRNPopUP.Visible == true)
                {
                    gRNPopUP.Focus();
                    gRNPopUP.GridObj().Focus();
                }
                
            }
            else if ((keyData == (Keys.Escape)) )
            {
                if (gRNPopUP.Visible == true)
                {
                    gRNPopUP.Close();
                }
            }
            else 
            {
                if (gRNPopUP.Visible == true)
                {
                    gRNPopUP.GinTexBox().Focus();
                }

            }

                return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dataGridViewGRN_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // GRNPopUP gRNPopUP = new GRNPopUP();
            if (e.ColumnIndex == 0 | e.ColumnIndex == 1)
            {
                if (gRNPopUP.IsDisposed != true)
                {
                    gRNPopUP.Show();
                }
                else
                {
                    gRNPopUP = new GRNPopUP(this);
                    gRNPopUP.Show();

                }
            }







        }

        public bool AddtoGrid(string[] row)
        {
            
            dataGridViewGRN.Rows.Add(row);

            return true;
        }

        

        private void dataGridViewGRN_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 2)
                {
                    if ((dataGridViewGRN.Rows[e.RowIndex].Cells[2].Value != null) & (dataGridViewGRN.Rows[e.RowIndex].Cells[4].Value != null))
                    {
                        decimal qty = Convert.ToDecimal(dataGridViewGRN.Rows[e.RowIndex].Cells[2].Value.ToString());
                        decimal price = Convert.ToDecimal(dataGridViewGRN.Rows[e.RowIndex].Cells[4].Value.ToString());
                        decimal presentage = 0;
                        if (dataGridViewGRN.Rows[e.RowIndex].Cells[6].Value != null)
                        {
                             presentage = Convert.ToDecimal(dataGridViewGRN.Rows[e.RowIndex].Cells[6].Value.ToString());
                        }
                        else
                        {
                             presentage = 0;
                        }
                        dataGridViewGRN.Rows[e.RowIndex].Cells[5].Value = gRNFormClass.itemTotal(qty, price, presentage);
                        textBoxGrossValue.Text = gRNFormClass.GridValueTot(dataGridViewGRN);
                    }

                }
                else if (e.ColumnIndex == 4)
                {
                    decimal qty = Convert.ToDecimal(dataGridViewGRN.Rows[e.RowIndex].Cells[2].Value.ToString());
                    decimal price = Convert.ToDecimal(dataGridViewGRN.Rows[e.RowIndex].Cells[4].Value.ToString());
                    decimal presentage = 0;
                    if (dataGridViewGRN.Rows[e.RowIndex].Cells[6].Value != null)
                    {
                        presentage = Convert.ToDecimal(dataGridViewGRN.Rows[e.RowIndex].Cells[6].Value.ToString());
                    }
                    else
                    {
                        presentage = 0;
                    }
                    dataGridViewGRN.Rows[e.RowIndex].Cells[5].Value = gRNFormClass.itemTotal(qty, price, presentage);
                    textBoxGrossValue.Text = gRNFormClass.GridValueTot(dataGridViewGRN);
                }
                else if (e.ColumnIndex == 6)
                {
                    if ((dataGridViewGRN.Rows[e.RowIndex].Cells[2].Value != null) & (dataGridViewGRN.Rows[e.RowIndex].Cells[4].Value != null))
                    {
                        decimal qty = Convert.ToDecimal(dataGridViewGRN.Rows[e.RowIndex].Cells[2].Value.ToString());
                        decimal price = Convert.ToDecimal(dataGridViewGRN.Rows[e.RowIndex].Cells[4].Value.ToString());
                        decimal presentage = 0;
                        if (dataGridViewGRN.Rows[e.RowIndex].Cells[6].Value != null)
                        {
                            presentage = Convert.ToDecimal(dataGridViewGRN.Rows[e.RowIndex].Cells[6].Value.ToString());
                        }
                        else
                        {
                            presentage = 0;
                        }
                        dataGridViewGRN.Rows[e.RowIndex].Cells[5].Value = gRNFormClass.itemTotal(qty, price, presentage);
                        textBoxGrossValue.Text= gRNFormClass.GridValueTot(dataGridViewGRN);
                    }

                }
                
            }
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void textBoxGrossValue_TextChanged(object sender, EventArgs e)
        {
            textBoxNetValue.Text= GRNNetValue(textBoxGrossValue.Text, textBoxDis1.Text);
            textBoxDis2.Text= DisCountAmount(textBoxGrossValue.Text, textBoxDis1.Text);
        }


        private string GRNNetValue(string textBoxGrossValue,string disCountText)
        {
            decimal disCount = (disCountText == "") ? 0 : Convert.ToDecimal(disCountText);
            decimal GrossValue = (textBoxGrossValue == "") ? 0 : Convert.ToDecimal(textBoxGrossValue);


            return Math.Round((GrossValue - ((GrossValue * disCount) / 100)), 2).ToString();
        }


        private string DisCountAmount(string textBoxGrossValue, string disCountText)
        {
            decimal disCount = (disCountText == "") ? 0 : Convert.ToDecimal(disCountText);
            decimal GrossValue = (textBoxGrossValue == "") ? 0 : Convert.ToDecimal(textBoxGrossValue);


            return Math.Round(((GrossValue * disCount) / 100), 2).ToString();
        }

        private void textBoxDis1_TextChanged(object sender, EventArgs e)
        {
            textBoxNetValue.Text = GRNNetValue(textBoxGrossValue.Text, textBoxDis1.Text);
            textBoxDis2.Text = DisCountAmount(textBoxGrossValue.Text, textBoxDis1.Text);
        }
    }
}
