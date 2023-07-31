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
    public partial class frmProductInsert : Form
    {
        public frmProductInsert()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        public string ProductID { get; set; }
        public String Product_Name { get; set; }
        public double Price { get; set; }
        public int Unit { get; set; }
        public int CategoryID { get; set; }
        public bool Discontiued { get; set; }
        public String Insert_update_Mode { get; set; }
        public string oldProductID { get; set; }

        private void frmProductInsert_Load(object sender, EventArgs e)
        {
            conn = new ConnectDB().SqlCon();
            setcbo();
   

            if (Insert_update_Mode == "insert")
            {
                clearform();

            }
            else if (Insert_update_Mode == "update")
            {
                getData();
               
            }
        }

        private void getData()
        {
            this.Text = "เเก้ใขข้อมุลหมวดหมุ่สินค้า" + Insert_update_Mode;
            txtProductID.Text = this.ProductID;
            txtProductID.Enabled = false;
            txtProductName.Text = this.Product_Name;
            txtPrice.Text = this.Price.ToString();
            txtUnit.Text = this.Unit.ToString();
            cboCategory.SelectedValue = this.CategoryID;
            if (Discontiued == true)
            {
                rdoDiscontinued.Checked = true;
            }
            else
            {
                rdoContinued.Checked = true;
            }
            btnOk.Text = "Update";
        }

        private void clearform()
        {
            txtProductID.Text = null;
            txtProductName.Text = null;
            txtPrice.Text = null;
            txtUnit.Text = null;
            cboCategory.SelectedIndex = -1;
            rdoContinued.Checked = true;
            rdoDiscontinued.Checked = false;
        }

        private void setcbo()
        {
            string sql = "select categoryID,CategoryName from Categories";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cboCategory.DataSource = ds.Tables[0];
            cboCategory.ValueMember = "CategoryID";
            cboCategory.DisplayMember = "CategoryName";
            cboCategory.SelectedIndex = -1;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(dataValidate() == false)
            {
                return;
            }
            if (Insert_update_Mode == "insert")
            {
                insertData();
                MessageBox.Show("เพิ่มข้อมูลเรียบร้อย");
              
            }
            else if (Insert_update_Mode == "update")
            {
                oldProductID = ProductID;
                updateData();
                MessageBox.Show("อัปเดตข้อมูลเรียบร้อย");
               
            }
            this.Close();
        }

        private bool dataValidate()
        {
            if (string.IsNullOrEmpty(txtProductID.Text.Trim()))
            {
                MessageBox.Show("โปรดกรอกรหัสสินค้าก่อน", "เกิดข้อผิดพลาด");
                return false;
            }
            if (string.IsNullOrEmpty(txtProductName.Text.Trim()))
            {
                MessageBox.Show("โปรดกรอกชื่อสินค้าก่อน", "เกิดข้อผิดพลาด");
                return false;
            }
            return true;
        }

        private void updateData()
        {
            string sql = "update Products set productID= @newProductID, ProductName= @ProductName ," +
                  " UnitPrice = @Price,UnitsInStock=@Unit,CategoryID=@CategoryID, " +
                  " Discontinued=@Discontinued where ProductID = @ProductID";
            SqlCommand comm = new SqlCommand(sql, conn);

            comm.Parameters.AddWithValue("@newProductID", txtProductID.Text.Trim());
            comm.Parameters.AddWithValue("@ProductName", txtProductName.Text.Trim());
            comm.Parameters.AddWithValue("@Price", txtPrice.Text.Trim());
            comm.Parameters.AddWithValue("@Unit", txtUnit.Text.Trim());
            comm.Parameters.AddWithValue("@CategoryID", cboCategory.SelectedIndex);
            bool discon = false;
            if (rdoContinued.Checked)
            {
                discon = false;
            }
            else
            {
                discon = true;
            }
            comm.Parameters.AddWithValue("@Discontinued", discon);
            comm.Parameters.AddWithValue("@ProductID",oldProductID);
            conn.Open();
            try
            {
                    comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("ไม่สามารถเเก้ใขข้อมลได้" + e.ToString() + "ผิดพลาด");
            }
            
            conn.Close();
        }

        private void insertData()
        {
            string sql = "insert into Products values(@ProductID,@ProductName,@Price,@Unit,@CategoryID,@Discontinued)";
            SqlCommand comm = new SqlCommand(sql, conn);

            comm.Parameters.AddWithValue("@ProductID", txtProductID.Text.Trim());
            comm.Parameters.AddWithValue("@ProductName", txtProductName.Text.Trim());
            comm.Parameters.AddWithValue("@Price", txtPrice.Text.Trim());
            comm.Parameters.AddWithValue("@Unit", txtUnit.Text.Trim());
            comm.Parameters.AddWithValue("@CategoryID", cboCategory.SelectedValue);
            bool discon = false;
            if (rdoContinued.Checked)
            {
                discon = false;
            }
            else
            {
                discon = true;
            }
            comm.Parameters.AddWithValue("@Discontinued", discon);
            conn.Open();

            try
            {
                        comm.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("ไม่สามารถเพิ่มข้อมลได้" + ex.ToString() + "ผิดพลาด");
            }
            
            conn.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
