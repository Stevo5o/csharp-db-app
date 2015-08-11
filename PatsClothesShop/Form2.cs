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

        private void Form2_Load(object sender, EventArgs e)
        {
            customerTableAdapter1.Fill(patClothesShopDataSet1.Customer);
        }

        SqlConnection myConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Stephen\Documents\VSProjects\csharp-db-app\PatsClothesShop\PatClothesShop.mdf;Integrated Security=True");

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection.Open();
                Console.WriteLine("Connection"); ;
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }

            SqlCommand myCommand = new SqlCommand("INSERT INTO Customer (FirstName, LastName) " +
                                     "Values ('SteJ', 'OConnor')", myConnection);

            myCommand.ExecuteNonQuery();

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommandSel = new SqlCommand("SELECT * FROM Customer",
                                                         myConnection);
                myReader = myCommandSel.ExecuteReader();
                while (myReader.Read())
                {
                    Console.WriteLine(myReader["FirstName"].ToString());
                    Console.WriteLine(myReader["LastName"].ToString());
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Broke");
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            
        }
    }
}
