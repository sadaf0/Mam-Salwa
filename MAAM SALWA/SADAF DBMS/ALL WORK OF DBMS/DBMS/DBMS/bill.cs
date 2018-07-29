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

namespace DBMS
{
    public partial class bill : Form
    {
        connection x = new connection();
        public bill()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bill_Load(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
            textBox1.Enabled = false;

            x.sqlConnection1.Open();
            int c = 1;

            SqlCommand cmd = new SqlCommand("select count(ID) from Bill", x.sqlConnection1);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);

                c++;
                textBox2.Text = "0" + c.ToString();
            }
            x.sqlConnection1.Close();










        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && dateTimePicker1.Text!="")
            {




                x.sqlConnection1.Open();
                SqlCommand cx = new SqlCommand("insert into Bill (Patient_Name,TotalCost,Date) values(@Patient_Name,@TotalCost,@Date)", x.sqlConnection1);
               // cx.Parameters.AddWithValue("@ID", textBox1.Text);
                cx.Parameters.AddWithValue("@Patient_Name", textBox3.Text);
                cx.Parameters.AddWithValue("@TotalCost", textBox4.Text);
                cx.Parameters.AddWithValue("@Date", dateTimePicker1.Text);
                cx.ExecuteNonQuery();
                textBox1.Text += "Bill ID: " + textBox2.Text +Environment.NewLine +"Patient Name: " + textBox3.Text +Environment.NewLine +"Total Amount: " + textBox4.Text;
                MessageBox.Show("Bill Created");
                button1.Enabled = false;
                x.sqlConnection1.Close();
            }
            else
            {

                MessageBox.Show("Fill The Columns First");

            }


        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();



        }
    }
}
