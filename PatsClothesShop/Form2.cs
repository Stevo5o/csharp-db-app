using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace PatsClothesShop
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        int i, j;
        private void Form2_Load(object sender, EventArgs e)
        {
            customerTableAdapter1.Fill(patClothesShopDataSet1.Customer);
        }  

        private void button1_Click(object sender, EventArgs e)
        {
            // save changes to the dataset 
            bindingSource1.EndEdit();

            int result = 0;

            // return number of items updated
            result = customerTableAdapter1.Update(patClothesShopDataSet1.Customer);

            // display the row has been updated
            MessageBox.Show(result.ToString());
        }

             

        private void btn_Insert_Click(object sender, EventArgs e)
        {           
            bindingSource1.EndEdit();
            patClothesShopDataSet1.Customer.AddCustomerRow(textBox1.Text, textBox2.Text);         
            
            MessageBox.Show("Name Added");
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            bindingSource1.RemoveCurrent();
            Update();

            MessageBox.Show("Name Deleted");
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = null;
            textBox1.Clear();
            textBox2.Clear();
            patClothesShopDataSet1.RejectChanges();
            bindingSource1.ResetBindings(false);
        }
    }
}
