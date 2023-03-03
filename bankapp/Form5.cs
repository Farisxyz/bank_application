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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bankapp
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox3.Text;
            string name = textBox1.Text;
            string phone= textBox2.Text;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=logindata;Integrated Security=True");
            SqlCommand sd = new SqlCommand("SELECT * FROM LOGPAGE WHERE USERNAME = @username AND NAME= @name AND PHNO=@phone", conn);
            sd.Parameters.AddWithValue("@username", username);
            sd.Parameters.AddWithValue("@name",name);
            sd.Parameters.AddWithValue("@phone",phone);
            conn.Open();
            SqlDataReader reader = sd.ExecuteReader();
            if (reader.HasRows)
            {
               
                SqlCommand cd = new SqlCommand("SELECT * FROM LOGPAGE WHERE USERNAME = @username ", conn);
                cd.Parameters.AddWithValue("@username", username);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string result = reader.GetString(reader.GetOrdinal("PASSWORD"));
                        MessageBox.Show(result+" is your password");
                    }
                }
                
                
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }

            conn.Close();
            reader.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2= new Form2();
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4(textBox3.Text);
            f4.Show();

        }
    }
}
