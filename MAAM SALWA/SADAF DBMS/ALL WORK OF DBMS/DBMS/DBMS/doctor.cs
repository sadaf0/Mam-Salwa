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
    public partial class doctor : Form
    {
        connection x = new connection();
        public doctor()
        {
            InitializeComponent();
        }

        private void doctor_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
          

            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;


            button1.Visible = false;
            button5.Visible = false;
            comboBox1.Visible = false;
            button6.Visible = false;
            //button7.Visible = false;
            comboBox1.Visible = false;


            x.sqlConnection1.Open();
            int c = 1;

            SqlCommand cmd = new SqlCommand("select count(Doctor_ID) from doctor", x.sqlConnection1);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);

                c++;
                textBox1.Text = "0" + c.ToString();
            }
            x.sqlConnection1.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {
          
            comboBox1.Visible = false;

            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
       
            textBox1.ReadOnly = true;
            button1.Visible = false;
            button5.Visible = true;
            button6.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {




                x.sqlConnection1.Open();
                SqlCommand cx = new SqlCommand("insert into doctor (Doctor_Name,Contact_No,Doctor_Address,Doctor_designation) values(@Doctor_Name,@Contact_No,@Doctor_Address,@Doctor_Designation)", x.sqlConnection1);
                //cx.Parameters.AddWithValue("@Patient_ID", textBox1.Text);
                cx.Parameters.AddWithValue("@Doctor_Name", textBox2.Text);
                cx.Parameters.AddWithValue("@Contact_No", textBox3.Text);
                cx.Parameters.AddWithValue("@Doctor_Address", textBox4.Text);
                cx.Parameters.AddWithValue("@Doctor_Designation", textBox5.Text);
               
                cx.ExecuteNonQuery();
                MessageBox.Show("Data Of Doctor Successfully Inserted");
                button5.Enabled = false;
                x.sqlConnection1.Close();
            }
            else
            {

                MessageBox.Show("Fill The Columns First");

            }










        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Visible = true;


            comboBox1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
           

            textBox1.Visible = false;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
          
            button6.Visible = false;
            button5.Visible = false;
            button2.Enabled = false;


            try
            {
                x.sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("select Doctor_ID from Doctor", x.sqlConnection1);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.comboBox1.Items.Add(dr["Doctor_ID"].ToString());
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("ERROR" + ee);

            }

            x.sqlConnection1.Close();



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                x.sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("select * from Doctor where doctor_ID= '" + this.comboBox1.Text + "'", x.sqlConnection1);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.textBox2.Text = dr["Doctor_Name"].ToString();
                    this.textBox3.Text = dr["Contact_No"].ToString();
                    this.textBox4.Text = dr["Doctor_Address"].ToString();
                    this.textBox5.Text = dr["Doctor_Designation"].ToString();
                   


                }
            }
            catch (Exception eee)
            {
                MessageBox.Show("Error" + eee);

            }
            x.sqlConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //update...//
            if (comboBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {


                x.sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("Update Doctor set Doctor_name=@doctor_name,contact_no=@contact_No,Doctor_Address=@Doctor_Address,Doctor_Designation=@Doctor_Designation where doctor_id=@doctor_id", x.sqlConnection1);

                cmd.Parameters.AddWithValue("@doctor_id", comboBox1.Text);
                cmd.Parameters.AddWithValue("@doctor_Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Contact_No", textBox3.Text);
                cmd.Parameters.AddWithValue("@Doctor_address", textBox4.Text);
                cmd.Parameters.AddWithValue("@Doctor_Designation", textBox5.Text);
              
          
                cmd.ExecuteNonQuery();
                MessageBox.Show("Selected Data has been Updated ");
                button7.Enabled = false;
                x.sqlConnection1.Close();
            }
            else
            {

                MessageBox.Show("Fill The Record First");

            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {

                x.sqlConnection1.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Delete from doctor where doctor_Id=@doctor_ID", x.sqlConnection1);
                    cmd.Parameters.AddWithValue("@Doctor_ID", comboBox1.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data has been Deleted");

                    x.sqlConnection1.Close();
                    button6.Enabled = false;

                }
                catch (Exception aa)
                {

                    {

                        MessageBox.Show("Error" + aa);

                    }
                }

            }
            else
            {

                MessageBox.Show("Fill The Record First");
            }














        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
           

            comboBox1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
           

            textBox1.Visible = false;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
           

           

            textBox1.ReadOnly = true;
            button3.Enabled = false;
            button5.Visible = false;
            button6.Visible = true;
            button1.Visible = false;
            try
            {
                x.sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("select Doctor_ID from Doctor", x.sqlConnection1);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.comboBox1.Items.Add(dr["Doctor_ID"].ToString());
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("ERROR" + ee);

            }

            x.sqlConnection1.Close();


        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
    }
}
