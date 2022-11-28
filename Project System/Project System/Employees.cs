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

namespace Project_System
{
    public partial class Employees : Form
    {
        SqlConnection con;
        string connectionString = "Data Source=TOPUP-LEC-PC\\SQLEXPRESS;Initial Catalog=mydb;Integrated Security=true;";
        
        public Employees()
        {
            InitializeComponent();
            loadDepartments();
        }

        private void loadDepartments()
        {
            using (con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM department", con);
                con.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "department");
                Department.DisplayMember = "depname";
                Department.ValueMember = "depid";
                Department.DataSource = ds.Tables["department"];
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            string fname = firstName.Text;
            string initial = initials.Text;
            string lname = lastName.Text;
            string empaddress = txtAddress.Text;
            string sex = Gender.Text;
            string dob = dateOfBirth.Value.ToShortDateString();
            string salary = Salary.Text;
            string depid = Department.SelectedValue.ToString();
            string phone = Phone.Text;
            string email = Email.Text;
            string sql = "INSERT INTO employee (first_name, mid_initials, last_name, empaddress, dob, gender, salary, department, email, phone) VALUES('" + 
                fname + "', '" + initial + "', '" + lname + "', '" + empaddress + "', '" +
                dob + "', '" + sex + "', " + salary + ", " + depid + ", '" + email + "', '" + phone + "')";

            updateDB(sql, "Save");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String sql = "SELECT * FROM employee WHERE empid = " + EmpNo.Text;

            using (con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            firstName.Text = reader["first_name"].ToString();
                            lastName.Text = reader["last_name"].ToString();
                            initials.Text = reader["mid_initials"].ToString();
                            txtAddress.Text = reader["empaddress"].ToString();
                            Gender.SelectedItem = reader["gender"].ToString();
                            String dob = reader["dob"].ToString();
                            dateOfBirth.Value = dob != "" ? DateTime.Parse(dob) : DateTime.Now;
                            Salary.Text = reader["salary"].ToString();
                            Department.SelectedValue = reader["department"].ToString();
                            Phone.Text = reader["phone"].ToString();
                            Email.Text = reader["email"].ToString();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string fname = firstName.Text;
            string initial = initials.Text;
            string lname = lastName.Text;
            string empaddress = txtAddress.Text;
            string sex = Gender.Text;
            string dob = dateOfBirth.Value.ToShortDateString();
            string salary = Salary.Text;
            string depid = Department.SelectedValue.ToString();
            string phone = Phone.Text;
            string email = Email.Text;
            string sql = "UPDATE employee SET first_name = '" + fname + 
                "', mid_initials = '" + initial + "', last_name = '" + lname + 
                "', empaddress = '" + empaddress + "', dob = '" + dob + 
                "', gender = '" + sex +  "', salary = '" + salary + "', department = '" + depid + 
                "', email = '" + email + "', phone = '" + phone +"' WHERE empid = " + EmpNo.Text;

            updateDB(sql, "Update");
        }

        private void updateDB(string query, string msg)
        {
            using (con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    //opn connection
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show(msg + " success!", msg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(msg + " failed!", msg +" Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM employee WHERE empid = " + EmpNo.Text;

            updateDB(sql, "DELETE");
        }
    }
}
