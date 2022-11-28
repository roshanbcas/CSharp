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
    public partial class EmployeesDashBoard : Form
    {
        SqlConnection con;
        string connectionString = "Data Source=TOPUP-LEC-PC\\SQLEXPRESS;Initial Catalog=mydb;Integrated Security=true;";
        public EmployeesDashBoard()
        {
            InitializeComponent();
            loadTableData();
        }

        private void loadTableData()
        {
            using (con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM employee", con);
                con.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "employee");
                dgvTable.DataSource = ds.Tables["employee"].DefaultView;
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Employees emp = new Employees();
            //emp.ShowDialog();
            DialogResult dr = emp.ShowDialog();
            if (dr == DialogResult.OK)
            {
                loadTableData();
            }
        }
    }
}
