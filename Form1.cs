using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Form_1_project
{
    public partial class Form1 : Form
    {

        string path = @"Data Source=.\SQLEXPRESS; Initial Catalog=registrations; Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;

        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection(path);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            if (txtfirstname.Text == "" || txtlastname.Text == "" || txtemail.Text == "" || txtcontactnumber.Text == "" || txtage.Text == "")
            {
                MessageBox.Show("please fill in the blanks");
            }
            else
            {
                try
                {

                    string gender;
                    if (rbtnMale.Checked)
                    {
                        gender = "male";
                    }
                    else
                    {
                        gender = "female";
                    }

                    con.Open();
                    cmd = new SqlCommand("insert into Employee (First_Name,Last_Name,Email_add,Conts,show_year,Gender) values ('" + txtfirstname.Text + "','" + txtlastname.Text + "','" + txtemail.Text + "', '" + txtcontactnumber.Text + "','" + txtage.Text + "', '" + gender + "')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("your data has been save in database");
                    clear();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);


                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DateTime startdate = dateTimePicker1.Value;
            DateTime enddate = dateTimePicker2.Value;
            txtage.Text = calcage(startdate, enddate).ToString();
        }

        public long calcage(System.DateTime Startdate, System.DateTime EndDate)
        {
            long age = 0;
            System.TimeSpan ts = new TimeSpan(Startdate.Ticks - EndDate.Ticks);
            age = (long)(ts.Days / 365);
            return age;
        }

        public void clear()
        {
            txtfirstname.Text = "";
            txtlastname.Text = "";
            txtemail.Text = "";
            txtcontactnumber.Text = "";
            txtage.Text = "";
        }




    }
    }



         

       