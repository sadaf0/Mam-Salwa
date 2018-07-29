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
    public partial class Appointment : Form
    {
        connection x = new connection();
        public Appointment()
        {
            InitializeComponent();
        }

        private void Appointment_Load(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
            x.sqlConnection1.Open();
            int c = 1;

            SqlCommand cx = new SqlCommand("select count(Appointment_ID) from Appointment", x.sqlConnection1);

            SqlDataReader dx = cx.ExecuteReader();
            if (dx.Read())
            {
                c = Convert.ToInt32(dx[0]);

                c++;
                textBox2.Text = "00" + c.ToString();
            }
            x.sqlConnection1.Close();







           try
            {
                x.sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("select P_Name from patient", x.sqlConnection1);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.comboBox1.Items.Add(dr["P_Name"].ToString());
                }

             

            }
            catch (Exception ee)
            {
                MessageBox.Show("ERROR" + ee);

            }

            x.sqlConnection1.Close();



            try
            {
                x.sqlConnection1.Open();
                SqlCommand cm = new SqlCommand("select Doctor_Name from doctor", x.sqlConnection1);
                SqlDataReader ddr = cm.ExecuteReader();
                while (ddr.Read())
                {
                    this.comboBox2.Items.Add(ddr["Doctor_Name"].ToString());
                }



            }
            catch (Exception ee)
            {
                MessageBox.Show("ERROR" + ee);

            }

            x.sqlConnection1.Close();






        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox5.Text != "" && comboBox1.Text!="" && comboBox2.Text!="")
            {




                x.sqlConnection1.Open();
                SqlCommand cx = new SqlCommand("insert into Appointment (Patient_Name,Doctor_Name,Date_of_Appointment,Timing) values(@Patient_Name,@Doctor_Name,@Date_Of_Appointment,@timing)", x.sqlConnection1);
                //cx.Parameters.AddWithValue("@Patient_ID", textBox1.Text);
                cx.Parameters.AddWithValue("@Patient_Name", comboBox1.Text);
                cx.Parameters.AddWithValue("@Doctor_Name", comboBox2.Text);
                cx.Parameters.AddWithValue("@Date_Of_Appointment", dateTimePicker1.Text);
                cx.Parameters.AddWithValue("@Timing", textBox5.Text);
                cx.ExecuteNonQuery();
                MessageBox.Show("Appointment SuccessFully Created");
                button6.Enabled = false;
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
