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

       

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            // initialize a new instance of the SqlConnection class, containing the connection string
            SqlConnection myConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Stephen\Documents\VSProjects\csharp-db-app\PatsClothesShop\PatClothesShop.mdf;Integrated Security=True");

            try
            {
                // open connection                
                myConnection.Open();
                Console.WriteLine("Connection"); ;
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }

            // Initialize a new instance of the SqlCommand, query and SqlConnection instance
            SqlCommand myCommand = new SqlCommand("INSERT INTO Customer (FirstName, LastName) " +
                                     "Values ('Stanis', 'Baratheon'), ('Ned', 'Stark'), ('Renly', 'Baratheon'), ('Ramsay', 'Bolton'), ('Cersei', 'Lannister'), ('SteJ', 'OConnor')", myConnection);

            // executes a Transact-SQL statement against the connection and returns the number of rows affected
            myCommand.ExecuteNonQuery();

            try
            {                 
                SqlCommand myCommandSel = new SqlCommand("SELECT * FROM Customer",
                                                         myConnection);
                // Initialize a new instance of SqlReader, sends the CommandText to the Connection and builds a SqlDataReader
                SqlDataReader myReader = myCommandSel.ExecuteReader();
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
            SqlConnection myConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Stephen\Documents\VSProjects\csharp-db-app\PatsClothesShop\PatClothesShop.mdf;Integrated Security=True");

            try
            {
                myConnection.Open();
                Console.WriteLine("Connection"); ;
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }

            SqlCommand myCommandDel = new SqlCommand("DELETE FROM Customer WHERE CustomerID in(SELECT TOP 3 CustomerID FROM Customer ORDER BY CustomerID DESC)", myConnection);

            myCommandDel.ExecuteNonQuery();
            
            try
            {
                
                SqlCommand myCommandSel = new SqlCommand("SELECT * FROM Customer",
                                                         myConnection);
                SqlDataReader myReader = myCommandSel.ExecuteReader();
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
    }
}
