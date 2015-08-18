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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void customerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.patClothesShopDataSet);

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'patClothesShopDataSet.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.patClothesShopDataSet.Customer);

        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            SqlConnection myConnect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\bluetutor\Documents\vsProjects\csharp-db-app\PatsClothesShop\PatsClothesShop\PatClothesShop.mdf;Integrated Security=True");
            DataTable myDT = new DataTable();
            SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM Customer WHERE CustomerID = " + int.Parse(cus_ID.Text), myConnect);
            SDA.Fill(myDT); 
            customerDataGridView.DataSource = myDT;
        }

        private void btn_DisplayAll_Click(object sender, EventArgs e)
        {
            SqlConnection myConnect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\bluetutor\Documents\vsProjects\csharp-db-app\PatsClothesShop\PatsClothesShop\PatClothesShop.mdf;Integrated Security=True");
            DataTable myDT = new DataTable();
            SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM Customer", myConnect);
            SDA.Fill(myDT);
            customerDataGridView.DataSource = myDT;
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            cus_ID.Clear();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection myConnect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\bluetutor\Documents\vsProjects\csharp-db-app\PatsClothesShop\PatsClothesShop\PatClothesShop.mdf;Integrated Security=True");
            DataTable myDT = new DataTable();
            SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM Customer", myConnect);
            SDA.Fill(myDT);
            customerDataGridView.DataSource = myDT;
        }

        private void btnRun_Click(object sender, EventArgs e)
        { 
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\PatClothesShop.mdf;Integrated Security=True");        

            string SQLSTRING = "SELECT * FROM Customer WHERE " + cboField.Text + " " + cboOperator.Text + " " + textValue.Text;

            DataTable myDT = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(SQLSTRING, con);
            da.Fill(myDT);
            customerDataGridView.DataSource = myDT;            
        }
    }
}
