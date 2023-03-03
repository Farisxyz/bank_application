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
using System.Data.Common;

namespace bankapp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
           
            Form1 f1= new Form1();
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            string username = textBox1.Text;
            string password = textBox2.Text;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=logindata;Integrated Security=True");
            SqlCommand sd = new SqlCommand("SELECT * FROM LOGPAGE WHERE USERNAME = @username AND PASSWORD = @password",conn);
            sd.Parameters.AddWithValue("@username",username);
            sd.Parameters.AddWithValue("@password", password);
            conn.Open ();
            SqlDataReader reader=sd.ExecuteReader();
            if(reader.HasRows)
            {
                Form4 f4 = new Form4 (username);
               
                f4.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }

            conn.Close ();
            reader.Close ();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form5 f5=new Form5();
            f5.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 f3=new Form3 ();
            f3.Show();
        }
    }
}
