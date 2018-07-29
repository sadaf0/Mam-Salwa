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
    public partial class Patient : Form
    {
        connection x = new connection();
        public Patient()
        {
            InitializeComponent();
        }

        private void Patient_Load(object sender, EventArgs e)
        {
            //label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;

            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;

            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            button5.Visible = false;
            comboBox1.Visible = false;
            button6.Visible = false;
            button7.Visible = false;



            x.sqlConnection1.Open();
            int c = 1;
           
            SqlCommand cmd = new SqlCommand("select count(Patient_ID) from patient", x.sqlConnection1);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
               
                c++;
                textBox1.Text = "Patient-0" + c.ToString();
            }
            x.sqlConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button7.Visible = false;
            comboBox1.Visible = false;

            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = false;

            textBox9.Visible = false;


            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;

            textBox1.ReadOnly = true;
            button1.Enabled = false;
            button5.Visible = true;
            button6.Visible = false;



        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {




                x.sqlConnection1.Open();
                SqlCommand cx = new SqlCommand("insert into patient (P_Name,P_Address,Sex,Age,Blood_Group,cn,AdmitDate,DischargeDate) values(@P_Name,@P_Address,@Sex,@Age,@Blood_Group,@cn,@AdmitDate,@DischargeDate)", x.sqlConnection1);
                //cx.Parameters.AddWithValue("@Patient_ID", textBox1.Text);
                cx.Parameters.AddWithValue("@P_Name", textBox2.Text);
                cx.Parameters.AddWithValue("@P_Address", textBox3.Text);
                cx.Parameters.AddWithValue("@Sex", textBox4.Text);
                cx.Parameters.AddWithValue("@Age", textBox5.Text);
                cx.Parameters.AddWithValue("@Blood_Group", textBox6.Text);
                cx.Parameters.AddWithValue("@cn", textBox7.Text);
                cx.Parameters.AddWithValue("@AdmitDate", dateTimePicker1.Text);
                cx.Parameters.AddWithValue("@DischargeDate", dateTimePicker2.Text);
                cx.ExecuteNonQuery();
                MessageBox.Show("Data Of Patient Successfully Inserted");
                button5.Enabled = false;
                x.sqlConnection1.Close();
            }
            else
            {

                MessageBox.Show("Fill The Columns First");
            
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "")
            {

                x.sqlConnection1.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Delete from patient where patient_Id=@patient_ID", x.sqlConnection1);
                    cmd.Parameters.AddWithValue("@patient_ID", comboBox1.Text);
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
            button7.Visible = false;
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();













            comboBox1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;

            textBox1.Visible = false;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;

            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;

            textBox1.ReadOnly = true;
            button3.Enabled = false;
            button5.Visible = false;
            button6.Visible = true;

            try
            {
                x.sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("select Patient_ID from patient", x.sqlConnection1);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.comboBox1.Items.Add(dr["Patient_ID"].ToString());
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show("ERROR"+ee);
            
            }

            x.sqlConnection1.Close();














        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                x.sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("select * from patient where patient_ID= '" + this.comboBox1.Text + "'", x.sqlConnection1);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.textBox2.Text = dr["P_Name"].ToString();
                    this.textBox3.Text = dr["P_Address"].ToString();
                    this.textBox4.Text = dr["Sex"].ToString();
                    this.textBox5.Text = dr["Age"].ToString();
                    this.textBox6.Text = dr["Blood_Group"].ToString();
                    this.textBox7.Text = dr["Cn"].ToString();

                    this.textBox8.Text = dr["AdmitDate"].ToString();

                    this.textBox9.Text = dr["DischargeDate"].ToString();


                }
            }
            catch(Exception eee)
            {
                MessageBox.Show("Error"+eee);
            
            }
            x.sqlConnection1.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            button7.Visible = true;


            comboBox1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;

            textBox1.Visible = false;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;
            button6.Visible = false;
            button5.Visible = false;
            button2.Enabled = false;


            try
            {
                x.sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("select Patient_ID from patient", x.sqlConnection1);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.comboBox1.Items.Add(dr["Patient_ID"].ToString());
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
            if (comboBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "")
            {


                x.sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("Update patient set P_name=@p_name,p_address=@p_address,sex=@sex,age=@age,blood_group=@blood_group,cn=@cn,admitdate=@admitdate,dischargedate=@dischargedate where patient_id=@patient_id", x.sqlConnection1);

                cmd.Parameters.AddWithValue("@patient_id", comboBox1.Text);
                cmd.Parameters.AddWithValue("@P_name", textBox2.Text);
                cmd.Parameters.AddWithValue("@p_address", textBox3.Text);
                cmd.Parameters.AddWithValue("@sex", textBox4.Text);
                cmd.Parameters.AddWithValue("@age", textBox5.Text);
                cmd.Parameters.AddWithValue("@blood_group", textBox6.Text);
                cmd.Parameters.AddWithValue("@cn", textBox7.Text);
                cmd.Parameters.AddWithValue("@admitdate", textBox8.Text);
                cmd.Parameters.AddWithValue("@dischargedate", textBox9.Text);
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

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
    }
}
