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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace bankapp
{
    public partial class Form4 : Form
    {
        public string uname;
        public Form4(string val)
        {
            InitializeComponent();
            uname = val;
            
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=logindata;Integrated Security=True");

            conn.Open();
            SqlCommand sd = new SqlCommand("SELECT * FROM LOGPAGE WHERE USERNAME = @username ", conn);
            sd.Parameters.AddWithValue("@username", uname);
            SqlDataReader reader = sd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string result = reader.GetString(reader.GetOrdinal("NAME"));
                    int pho = reader.GetInt32(reader.GetOrdinal("PHNO"));
                    int bal = reader.GetInt32(reader.GetOrdinal("BALANCE"));
                    textBox1.Text = result;
                    textBox2.Text = pho.ToString();
                    textBox3.Text = bal.ToString();
                }
            }
            reader.Close();
            conn.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
           
        }

        private void Form4_Load_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a= Convert.ToInt32(textBox3.Text);
            int b = Convert.ToInt32(textBox4.Text);
            int c;
            c = a + b;
            textBox3.Text = c.ToString();
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=logindata;Integrated Security=True");
            string query = "UPDATE LOGPAGE SET BALANCE= (@balance) WHERE USERNAME =@USERNAME";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@balance", c);
            cmd.Parameters.AddWithValue("@username", uname);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x= Convert.ToInt32(textBox3.Text);
            int y = Convert.ToInt32(textBox4.Text);
            int z;
            z = x - y;
            textBox3.Text = z.ToString();
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=logindata;Integrated Security=True");
            string query = "UPDATE LOGPAGE(Balance) SET BALANCE= (@balance) WHERE USERNAME =@USERNAME";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@balance", z);
            cmd.Parameters.AddWithValue("@username", uname);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2= new Form2();
            form2.Show();
            this.Hide();
        }
    }
}
    