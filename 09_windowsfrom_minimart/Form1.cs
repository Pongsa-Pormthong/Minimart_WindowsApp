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
    public partial class FormCategory : Form
    {
        public FormCategory()
        {
            InitializeComponent();
        }

        private void dgvShowdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        SqlConnection conn;
        int CategoryID = 0;
        string CategoryName;
        string description;

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new ConnectDB().SqlCon();
            ShowData();
        }

        private void ShowData()
        {
            string sql = "select * from Categories";
            SqlDataAdapter da = new SqlDataAdapter(sql,conn);
            DataSet dt = new DataSet();
            da.Fill(dt);
            dgvShowdata.DataSource = dt.Tables[0];
        }

        private void dgvShowdata_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            CategoryID = Convert.ToInt32(dgvShowdata.CurrentRow.Cells["CategoryID"].Value);
            CategoryName = dgvShowdata.CurrentRow.Cells["CategoryName"].Value.ToString();
            description = dgvShowdata.CurrentRow.Cells["description"].Value.ToString();

            //string test = CategoryID.ToString() + Environment.NewLine + catagorieName.ToString()
            //    + Environment.NewLine + description;
            //MessageBox.Show(test);
        }

        private void dgvShowdata_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //string test = CategoryID.ToString() + Environment.NewLine + catagorieName.ToString()
            //   + Environment.NewLine + description;
            //MessageBox.Show(test);
            frmCategoryInsert f = new frmCategoryInsert();
            f.Insert_update_Mode = "update";
            f.CategoryID = this.CategoryID;
            f.CategoryName = this.CategoryName;
            f.Description = this.description;
            f.ShowDialog();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            frmCategoryInsert f = new frmCategoryInsert();
            f.Insert_update_Mode = "insert"; //เรียกใช้ frmCategories เป็นแบบเพิ่มข้อมูล
            f.ShowDialog(); //เเสดงอีกฟอร์มหนึ่งขึ้นมา
            ShowData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CategoryID == 0)
            {
                MessageBox.Show("โปรดเลือกข้อมูลที่ต้องการก่อนลบ", "เกิดข้อผิดพลาด");
                return;
            }
            string msg = "รหัสหมวดหมู่ :" +CategoryID.ToString() + Environment.NewLine
                +" หมวดหมู่ : "+CategoryName+Environment.NewLine
                +"รายละเอียด : "+description;
            if (MessageBox.Show(msg, "ยืยยันการลบ", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                deleteData();
                MessageBox.Show("ลบข้อมูลเรียบร้อย", "ผลการทำงาน");
                ShowData();
            }
            //เครียร์ตัวแปร
            CategoryID = 0;
            CategoryName = "";
            description = "";
        }

        private void deleteData()
        {
            string sql = "delete categories where categoryID = @categoryID";
            SqlCommand comm = new SqlCommand(sql, conn);

            comm.Parameters.AddWithValue("@categoryID",CategoryID);
            
            conn.Open();
            try
            {
                    comm.ExecuteNonQuery(); //สั่งให้คำสั่ง sql ทำงาน
            }
            catch (Exception ex)
            {
                string msg = "ไม่สามารถลบข้อมูลได้" +Environment.NewLine + ex.Message;
                MessageBox.Show(msg,"เกิดข้อผิดพลาด");
            }
            
            conn.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowData(txtSearch.Text.Trim());
        }

        private void ShowData(string condition)
        {
            string sql = "select * from Categories " +
                "where categoryname like '%' +@con + '%'" +
                "or Description like '%' + @con+'%' ";
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.Parameters.AddWithValue("@con", condition);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            
            DataSet dt = new DataSet();
            da.Fill(dt);
            dgvShowdata.DataSource = dt.Tables[0];
        }
    }
}
