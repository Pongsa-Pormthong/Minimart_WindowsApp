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
    public partial class frmCategoryInsert : Form
    {
        public frmCategoryInsert()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        public int CategoryID { get; set; }
        public String CategoryName { get; set; }
        public String Description { get; set; }
        public String Insert_update_Mode { get; set; }

        private void frmCategoryInsert_Load(object sender, EventArgs e)
        {
            conn = new ConnectDB().SqlCon();
            if (Insert_update_Mode == "insert")
            {
                this.Text = "เพิ่มข้อมุลหมวดมหู่สินค้า" + Insert_update_Mode;
                txtCatagoryID.Text = "";
                txtCatagoryID.Enabled = false;
                txtCatagoryName.Text = "";
                txtDescription.Text = "";
                txtCatagoryName.Focus();
                txtCatagoryName.SelectAll();
                btnOK.Text = "Insert";
            }
            else if (Insert_update_Mode == "update")
            {
                this.Text = "เเก้ใขข้อมุลหมวดหมุ่สินค้า" + Insert_update_Mode;
                txtCatagoryID.Text = CategoryID.ToString();
                txtCatagoryID.Enabled = false;
                txtCatagoryName.Text = CategoryName;
                txtDescription.Text = Description;
                txtCatagoryName.Focus();
                txtCatagoryName.SelectAll();
                btnOK.Text = "Update";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Insert_update_Mode=="insert")
            {
                insertData();
                MessageBox.Show("เพิ่มข้อมูลเรียบร้อย");
                this.Close();
            }
            else if (Insert_update_Mode=="update")
            {
                updateData();
                MessageBox.Show("อัปเดตข้อมูลเรียบร้อย");
                this.Close();
            }
        }

        private void updateData()//ปรับปรุงข้อมูล
        {
            string sql = "update categories set categoryName= @categoryName ," +
                "description = @description where categoryID = @categoryID";
            SqlCommand comm = new SqlCommand(sql, conn);

            comm.Parameters.AddWithValue("@categoryName", txtCatagoryName.Text.Trim());
            comm.Parameters.AddWithValue("@description", txtDescription.Text.Trim());
            comm.Parameters.AddWithValue("@categoryID", txtCatagoryID.Text);
            conn.Open();
            comm.ExecuteNonQuery(); //สั่งให้คำสั่ง sql ทำงาน
            conn.Close();
        }

        private void insertData() //เพิ่มข้อมูล
        {
            string sql = "insert into categories values(@categoryName,@description)";
            SqlCommand comm = new SqlCommand(sql, conn);

            comm.Parameters.AddWithValue("@categoryName", txtCatagoryName.Text.Trim());
            comm.Parameters.AddWithValue("@description", txtDescription.Text.Trim());
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

        }
    }
}
