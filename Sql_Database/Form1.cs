using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Sql_Database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string CompanyName = textBox2.Text;
            string ContactName = textBox3.Text;
            string Phone = textBox4.Text;

            string connectionString = @"Data Source=DESKTOP-TMDV7FV\SQLEXPRESS;Initial Catalog=softtech;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string query = "INSERT INTO Customer1(CompanyNAME,ContactNAME,Phone) VALUES('" + CompanyName + "','" + ContactName + "','" + Phone + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show("Data Inserted");
            }
            else if (i == 0)
            {
                MessageBox.Show("Sorry! No Insertion");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-TMDV7FV\\SQLEXPRESS;Initial Catalog=softtech;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("select * from Customer1", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String Connectionstring = @"Data Source=DESKTOP-TMDV7FV\SQLEXPRESS;Initial Catalog=softtech;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionstring);
            int deleteData = int.Parse(textBox5.Text);
            string query = "DELETE Customer1 where CustomerID =" + deleteData;
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int del = cmd.ExecuteNonQuery();
            if (del == 0)
            {
                MessageBox.Show("Data Deletion Error");
            }
            else if (del > 0)
            {
                MessageBox.Show("Data Deleted Succesfully");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string CompanyName = textBox2.Text;
            string ContactName = textBox3.Text;
            string Phone = textBox4.Text;
            int updateData = int.Parse(textBox1.Text);
            String Connectionstring = @"Data Source=DESKTOP-TMDV7FV\SQLEXPRESS;Initial Catalog=softtech;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionstring);
            string query = "UPDATE Customer1 SET CompanyNAME='" + CompanyName + "', ContactNAME = '" +
            ContactName + "' , Phone = '" + Phone + "' WHERE CustomerID = " + updateData;
            SqlCommand sqlCommand = new SqlCommand(query, con);
            con.Open();
            int comm = sqlCommand.ExecuteNonQuery();
            if (comm > 0)
            {
                MessageBox.Show("Data Updated Successfully");
            }
            else if (comm == 0)
            {
                MessageBox.Show("Failure! Data not Updated");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
