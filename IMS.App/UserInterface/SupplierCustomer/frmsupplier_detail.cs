using IMS.Entity.InventoryProducts;
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
    public partial class frmsupplier_detail : Form
    {

        SupplierRepo supplierRepo = new SupplierRepo();
        CitiesRepo citiesRepo = new CitiesRepo();

        public frmsupplier_detail()
        {
            InitializeComponent();
        }

        private void frmsupplier_detail_Load(object sender, EventArgs e)
        {
            CityCombo();
        }



        public void CityCombo()
        {
            
            Dictionary<int, string> comboSource = new Dictionary<int, string>();

            foreach (DataRow row in this.citiesRepo.Loadcities().Rows)
            {


                //this.comboSubCategory.Items.Add(row["cat_name"].ToString());
                comboSource.Add(Convert.ToInt32(row["id"].ToString()), row["name_en"].ToString().Trim());

               

            }

            ComboBoxCity.DataSource = new BindingSource(comboSource, null);
            ComboBoxCity.DisplayMember = "Value";
            ComboBoxCity.ValueMember = "Key";
            


        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                Supplier mcObj = FillEntitySu(FillSupplierObj());
                if (mcObj == null)
                {
                   

                    return;
                }

                var decision = this.supplierRepo.DataExists(mcObj.Name, mcObj.ID);

                if (decision)
                {
                    MessageBox.Show("Please Press Update Button");
                }
                else
                {
                    //Save
                    if (this.supplierRepo.Save(mcObj))
                    {
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
                MessageBox.Show("Please Fill Correct Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

 


        private Supplier FillSupplierObj()
        {

            Supplier supplier = new Supplier();
            List<string> errorList = new List<string>();


            if (textBoxSupplierID.Text == "") { ERRID.Show(); errorList.Add("Please Fill the Item ID"); } else { supplier.ID = textBoxSupplierID.Text; }

            if (textBoxSupplierName.Text == "") { ERRName.Show(); errorList.Add("Please Fill the Item Name"); } else { supplier.Name = textBoxSupplierName.Text; }

            if (textBoxAddress.Text == "") { ERRAddress.Show(); errorList.Add("Please Fill the Barcode"); } else { supplier.Address = textBoxAddress.Text; }

            if (comboBoxCriditLimit.SelectedIndex == -1) { ERRCriditPeriod.Show(); errorList.Add("Please Fill the Barcode"); } else { supplier.Credit_Period = comboBoxCriditLimit.SelectedItem.ToString(); }


            if (TextBoxCriditAmount.Text=="") { ErrCriditAmount.Show(); errorList.Add("Please Select Purchase Unit"); } else { supplier.Credit_Amount = TextBoxCriditAmount.DollarValue; }


            if (textBoxTPNumber.Text == "") { ErrCriditAmount.Show(); errorList.Add("Please Select Purchase Unit"); } else { supplier.Office_Phone_number = textBoxTPNumber.Text; }

            supplier.Mobile_Number=textBoxMobileNumber.Text ;

            supplier.Email = textBoxEmail.Text;

            supplier.Fax = textBoxFaxNumber.Text;

            supplier.Contact_Person = textBoxContactPerson.Text;

            if (ComboBoxCity.SelectedIndex == 0) { ERRCity.Show(); errorList.Add("Please Select City"); } else { supplier.City = ((KeyValuePair<int, string>)ComboBoxCity.SelectedItem).Value; }
           

            supplier.Comment = textBoxComments.Text;
            supplier.IsActive = checkBoxIsActive.Checked;
            supplier.ErrorList = errorList;




            return supplier;

        }



        private Supplier FillEntitySu(Supplier su)
        {

            var mc = su;

            if (su.ErrorList.Count != 0)
            {



                MessageBox.Show("Please Fill Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mc = null;
            }
            else
            {
                mc = su;
            }


           


            return mc;
        }

        private void ComboBoxCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBoxCity.DroppedDown = false;
        }

        private void ComboBoxCity_Click(object sender, EventArgs e)
        {
            
        }

        private void textBoxSupplierID_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSupplierID.Text == "")
            {
                ERRID.Show();
            }
            else
            {
                ERRID.Hide();
            }
        }
    }
}
