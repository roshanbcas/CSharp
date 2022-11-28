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
    public partial class DepartmentForm : Form
    {
        string connectionString = "Data Source=TOPUP-LEC-PC\\SQLEXPRESS;Initial Catalog=mydb;Integrated Security=true;";
        public DepartmentForm()
        {
            InitializeComponent();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            string depid = txtDepId.Text;
            string depname = txtDepName.Text;

            string sql = "INSERT INTO department VALUES(" + depid + ", '" + depname +  "')";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, con);
                    //opn connection
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Save success!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Save failed!", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
