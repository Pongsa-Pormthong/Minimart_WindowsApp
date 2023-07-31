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

namespace _09_windowsfrom_minimart
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        //----------------------------  สร้าง property สำหรับเก็บข้อมูลที่อ่านจาก db หากใส่ชื่อผู้ใช่ เเละ password ถูกต้อง
        public int EmployeeID { get; set; }
        public string EmployeesName { get; set; }
        public string Username { get; set; }
        public string Position { get; set; }

        SqlConnection conn;

        private void btnOk_Click(object sender, EventArgs e)
        {
            string sql = "select EmployeeID,title+firstname+space(2)+lastname as EmployeeName," +
                " Position, UserName" +
                " from employees" +
                " where username = @username and Password = @password";

            SqlCommand comm = new SqlCommand(sql, conn);
            comm.Parameters.AddWithValue("@username", txtUsername.Text);
            comm.Parameters.AddWithValue("@password",txtPassword.Text);

            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();

            da.Fill(ds);

            if (ds.Tables[0].Rows.Count ==1)
            {
                EmployeeID = Convert.ToInt32(ds.Tables[0].Rows[0]["EmployeeID"].ToString());
                EmployeesName = ds.Tables[0].Rows[0]["EmployeeName"].ToString();
                Position = ds.Tables[0].Rows[0]["Position"].ToString();
                Username = ds.Tables[0].Rows[0]["Username"].ToString();
            }
            else
            {
                EmployeeID = 0;
                EmployeesName = "";
                Username = "";
                Position = "";
                MessageBox.Show("ข้อมูลการเข้าระบบไม่ถูกต้อง", "ไม่สามารถเข้าระบบได้");
                
            }
            this.Close();

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            conn = new ConnectDB().SqlCon();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
