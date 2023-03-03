using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bankapp
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=logindata;Integrated Security=True");
            string query = "INSERT INTO LOGPAGE(USERNAME,PASSWORD,NAME,PHNO,BALANCE)VALUES (@username,@password,@name,@phone,@balance)";
            SqlCommand cmd= new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username",textBox6.Text);
            cmd.Parameters.AddWithValue("@password", textBox7.Text);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@phone", textBox2.Text);
            cmd.Parameters.AddWithValue("@balance", textBox8.Text);

            conn.Open ();
            int resukt= cmd.ExecuteNonQuery ();
            if (resukt >0)
            {
                Form2 f2 = new Form2();
                f2.Show();
                this.Hide ();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            
            }
            conn.Close ();
        }
        
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1=new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
