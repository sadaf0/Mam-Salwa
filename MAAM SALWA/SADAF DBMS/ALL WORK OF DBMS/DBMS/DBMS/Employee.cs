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
    public partial class Employee : Form
    {
        connection x = new connection();
        public Employee()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            //label8.Visible = false;
            //label9.Visible = false;
            //label10.Visible = false;

            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            //textBox7.Visible = false;
            //textBox8.Visible = false;
            //textBox9.Visible = false;

            //dateTimePicker1.Visible = false;
            //dateTimePicker2.Visible = false;
            button5.Visible = false;
            //comboBox1.Visible = false;
            button6.Visible = false;
            button1.Visible = false;
            comboBox1.Visible = false;



            x.sqlConnection1.Open();
            int c = 1;

            SqlCommand cmd = new SqlCommand("select count(Employee_ID) from employee", x.sqlConnection1);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);

                c++;
                textBox1.Text = "Emp-0" + c.ToString();
            }
            x.sqlConnection1.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;

            button5.Visible = true;

            button4.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {




                x.sqlConnection1.Open();
                SqlCommand cx = new SqlCommand("insert into employee (Emp_Name,Sex,Emp_Salary,Emp_Qualification,Emp_contactNo) values(@Emp_Name,@Sex,@Emp_Salary,@Emp_Qualification,@Emp_ContactNo)", x.sqlConnection1);
                cx.Parameters.AddWithValue("@Emp_ID", textBox1.Text);
                cx.Parameters.AddWithValue("@Emp_Name", textBox2.Text);
                cx.Parameters.AddWithValue("@Sex", textBox3.Text);
                cx.Parameters.AddWithValue("@Emp_Salary", textBox4.Text);
                cx.Parameters.AddWithValue("@Emp_Qualification", textBox5.Text);
                cx.Parameters.AddWithValue("@Emp_ContactNO", textBox6.Text);
               
                cx.ExecuteNonQuery();
                MessageBox.Show("Data Of Employee Successfully Inserted");
                button5.Enabled = false;
                x.sqlConnection1.Close();
            }
            else
            {

                MessageBox.Show("Fill The Columns First");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button1.Visible = false;
            button5.Visible = false;
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();



            comboBox1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
           

            textBox1.Visible = false;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
           

        

            textBox1.ReadOnly = true;
            button3.Enabled = false;
            button5.Visible = false;
            button6.Visible = true;

            try
            {
                x.sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("select Employee_ID from Employee", x.sqlConnection1);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.comboBox1.Items.Add(dr["Employee_ID"].ToString());
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
                SqlCommand cmd = new SqlCommand("select * from Employee where Employee_ID= '" + this.comboBox1.Text + "'", x.sqlConnection1);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.textBox2.Text = dr["Emp_Name"].ToString();
                    this.textBox3.Text = dr["Sex"].ToString();
                    this.textBox4.Text = dr["Emp_Salary"].ToString();
                    this.textBox5.Text = dr["Emp_Qualification"].ToString();
                    this.textBox6.Text = dr["Emp_ContactNo"].ToString();
                   


                }
            }
            catch (Exception eee)
            {
                MessageBox.Show("Error" + eee);

            }
            x.sqlConnection1.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {

                x.sqlConnection1.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Delete from Employee where Employee_Id=@Employee_ID", x.sqlConnection1);
                    cmd.Parameters.AddWithValue("@Employee_ID", comboBox1.Text);
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

        private void button2_Click(object sender, EventArgs e)
        {
            button7.Visible = true;
            button1.Visible = true;

            comboBox1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
           

            textBox1.Visible = false;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            
            button6.Visible = false;
            button5.Visible = false;
            button2.Enabled = false;


            try
            {
                x.sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("select Employee_ID from Employee", x.sqlConnection1);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.comboBox1.Items.Add(dr["Employee_ID"].ToString());
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("ERROR" + ee);

            }

            x.sqlConnection1.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {


                x.sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("Update Employee set Emp_name=@Emp_name,Sex=@sex,Emp_Salary=@Emp_Salary,Emp_Qualification=@Emp_Qualification,Emp_ContactNo=@Emp_contactNo where Employee_id=@Employee_id", x.sqlConnection1);

                cmd.Parameters.AddWithValue("@Employee_id", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Emp_name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Sex", textBox3.Text);
                cmd.Parameters.AddWithValue("@Emp_Salary", textBox4.Text);
                cmd.Parameters.AddWithValue("@Emp_Qualification", textBox5.Text);
                cmd.Parameters.AddWithValue("@Emp_ContactNo", textBox6.Text);
               
                cmd.ExecuteNonQuery();
                MessageBox.Show("Selected Data has been Updated ");
              
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
