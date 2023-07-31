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
    public partial class FrmProduct : Form
    {
        public FrmProduct()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        
        string Product_Name,ProductID;
        double Price = 0.0;
        int Unit = 0;
        int CategoryID = 0;
        bool discontinued = false;

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            conn = new ConnectDB().SqlCon();
            showData("%");
        }

        private void showData(string str)
        {
            string sql = "select productID,ProductName,UnitPrice,UnitsInStock," +
                " p.CategoryID,c.CategoryName,Discontinued" +
                " from products p join Categories c on p.CategoryID = c.CategoryID" +
                " where productID like '%'+@str+'%' " +
                " or ProductName like  '%'+@str+'%' " +
                " or CategoryName like '%'+@str+'%' ";
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.Parameters.AddWithValue("@str", str);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataSet dt = new DataSet();
            da.Fill(dt);
            dgvResult.DataSource = dt.Tables[0];
        }

        private void dgvResult_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            frmProductInsert f = new frmProductInsert();
            f.Insert_update_Mode = "update";
            f.ProductID = this.ProductID;
            f.Product_Name = this.Product_Name;
            f.Price = this.Price;
            f.Unit = this.Unit;
            f.CategoryID = this.CategoryID;
            f.Discontiued = this.discontinued;
            f.ShowDialog();
            showData("%");
        }

        private void dgvResult_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            ProductID = dgvResult.CurrentRow.Cells["ProductID"].Value.ToString();
            Product_Name = dgvResult.CurrentRow.Cells["ProductName"].Value.ToString();
            Price = Convert.ToDouble(dgvResult.CurrentRow.Cells["UnitPrice"].Value);
            Unit = Convert.ToInt32(dgvResult.CurrentRow.Cells["UnitsInStock"].Value);
            CategoryID = Convert.ToInt32(dgvResult.CurrentRow.Cells["CategoryID"].Value);
            discontinued= Convert.ToBoolean(dgvResult.CurrentRow.Cells["Discontinued"].Value);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            frmProductInsert f = new frmProductInsert();
            f.Insert_update_Mode = "insert"; //เรียกใช้ frmCategories เป็นแบบเพิ่มข้อมูล
            f.ShowDialog(); //เเสดงอีกฟอร์มหนึ่งขึ้นมา
            showData("%");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (ProductID != "" )
            {
                if (MessageBox.Show("ต้องการลบข้อมูลหรือไม่","โปรดยืนยัน",MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    deleteData();
                    showData("%");
                }
            }
            else
            {
                MessageBox.Show("โปรดเลือกข้อมูลก่อนลบ");
            }
           
        }

        private void deleteData()
        {
            string sql = "delete Products where ProductID = @ProductID";
            SqlCommand comm = new SqlCommand(sql, conn);

            comm.Parameters.AddWithValue("@ProductID", ProductID);

            conn.Open();
            try
            {
                comm.ExecuteNonQuery(); //สั่งให้คำสั่ง sql ทำงาน
            }
            catch (Exception ex)
            {
                string msg = "ไม่สามารถลบข้อมูลได้" + Environment.NewLine + ex.Message;
                MessageBox.Show(msg, "เกิดข้อผิดพลาด");
            }

            conn.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            showData(txtSearch.Text.Trim());
        }

       
    }
}
