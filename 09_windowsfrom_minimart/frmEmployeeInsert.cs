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
    public partial class frmEmployeeInsert : Form
    {
        public frmEmployeeInsert()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        public int EmployeeID { get; set; }
        public string title { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string position { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string status { get; set; } //สำหรับระบุสถานนะการทำงาน ว่าเป็น update หรือ insert
        private void frmEmployeeInsert_Load(object sender, EventArgs e)
        {
            setcbo(); //กำหนดค่าให้ combobox;
            txtEmployeeID.Text = EmployeeID.ToString();
            cboTitle.SelectedItem = title;
            txtFristName.Text = firstname;
            txtLastName.Text = lastname;
            cboPosition.SelectedItem = position;
            txtUsername.Text = username;
            txtPassword.Text = password;
            txtConfirm.Text = password;
            this.Text = (status == "insert") ? "เพิ่มข้อมูลพนักงาน" : "ปรับปรุงข้อมูลพนักงาน";
            conn = new ConnectDB().SqlCon();
        }

        private void setcbo()
        {
            string[] alltitle = { "นาย", "นาง", "นางสาว", "Mr", "Miss" };
            string[] allPosition = { "Sale Manager", "Sale Representative" };
            cboTitle.Items.AddRange(alltitle);
            cboPosition.Items.AddRange(allPosition);
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (datavalidate() == false)
            {
                return;
            }
            if (status == "insert")
            {
                insertData();

            }
            else if (status == "update")
            {
                updateData();
            }
            this.Close();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            
        }

        private void updateData() //โค้ดเเก้ใขข้อมูลพนักงาน
        {
            string sql = "update  Employees set title = @title , FirstName= @firstname, Lastname = @lastname, position = @position , UserName = @username,Password = @password where EmployeeID = @EmployeeID";
            SqlCommand comm = new SqlCommand(sql, conn);

            comm.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text.Trim());
            comm.Parameters.AddWithValue("@title", cboTitle.SelectedItem.ToString());
            comm.Parameters.AddWithValue("@firstname", txtFristName.Text.Trim());
            comm.Parameters.AddWithValue("@lastname", txtLastName.Text.Trim());
            comm.Parameters.AddWithValue("@position", cboPosition.SelectedItem.ToString());
            comm.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
            comm.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }
        private void insertData()//เพิ่มข้อมูล
        {
            string sql = "insert into Employees(title,firstname,lastname,position,username,password) values(@title,@firstname,@lastname,@position,@username,@password)";
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.Parameters.AddWithValue("@title", cboTitle.SelectedItem.ToString());
            comm.Parameters.AddWithValue("@firstname", txtFristName.Text.Trim());
            comm.Parameters.AddWithValue("@lastname", txtLastName.Text.Trim());
            comm.Parameters.AddWithValue("@position", cboPosition.SelectedItem.ToString());
            comm.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
            comm.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }
        private bool datavalidate() //สร้างมาตรวจสอบข้อมูลในฟอร์ม
        {
            if (txtFristName.Text.Trim().Length < 2)
            {
                MessageBox.Show("กรอกชื่อผิดพาด", "โปรดตรวจสอบ");
                return false;
            }
            if (txtPassword.Text != txtConfirm.Text)
            {
                MessageBox.Show("รหัสผ่านไม่ตรงกัน", "โปรดตรวจสอบ");
                return false;
            }
            if (checkDuplicateUser() == false)
            {
                return false;
            }
            return true;
        }
        private bool checkDuplicateUser()//ถ้าเป็น true ไม่ซ้ำ ถ้าเป็น false ซ้ำ
        {
            string sql = "select count(*) from Employees where username = @username and employeeID!=@employeeId";
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
            comm.Parameters.AddWithValue("@employeeId", txtEmployeeID.Text.Trim());
            conn.Open();
            int i = Convert.ToInt32(comm.ExecuteScalar());
            conn.Close();
            if (i > 0)
            {
                MessageBox.Show("มีชื่อผุ้ใช้ซ้ำกันในระบบ", "เกิดข้อผิดพลาด");
                return false;
            }
            return true;
        }
    }

}
