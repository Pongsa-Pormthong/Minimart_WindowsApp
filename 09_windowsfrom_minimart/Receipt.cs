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
    public partial class Receipt : Form
    {
        public Receipt()
        {
            InitializeComponent();
        }
        //-------------- property-----------//
        public int employeeid { get; set; }
        public string empName { get; set; }

        // ------------ ประกาศตัวแปร ---------------//
        SqlConnection conn;
        SqlTransaction tr;

        private void Receipt_Load(object sender, EventArgs e)
        {
            conn = new ConnectDB().SqlCon();
            txtEmployeeID.Text = this.employeeid.ToString();
            txtEmployeeName.Text = this.empName;
            ListViewFormat();
            ClearProductData();
            //clearEmployeeDate(); //อาจจะไม่จำเป็นต้องใช้ตอนนี้
        }

        private void ClearProductData()
        {
            txtProductID.Text = "";
            txtProductName.Text = "";
            txtUnitPrice.Text = "0";
            txtQuantity.Text = "1";
            txtTotal.Text = "0";
        }
        private void CalculateTotal() //คำนวณยอดรวมเฉพาะรายการ
        {
            double price = Convert.ToDouble(txtUnitPrice.Text);
            double quntity = Convert.ToDouble(txtQuantity.Text);
            double total = price * quntity;
            txtTotal.Text = total.ToString("#,##0.00");
            txtProductID.Focus();
        }

        private void CalculateNetprice() //คำนวณยอดรวมทั้งหมด
        {
            double temNetprice = 0.0;
            for (int i = 0; i < lblProduct.Items.Count; i++)
            {
                temNetprice += Convert.ToDouble(lblProduct.Items[i].SubItems[4].Text);
            }
            lblNetprice.Text = temNetprice.ToString("#,##0.00");
        }
        private void clearEmployeeDate() 
        {
          
        } //ล้างช้อความรหัสเเละชื่อพนังาน


        private void ListViewFormat()
        {
            lblProduct.Columns.Add("รหัสสินค้า", 150, HorizontalAlignment.Left);
            lblProduct.Columns.Add("สินค้า", 200, HorizontalAlignment.Left);
            lblProduct.Columns.Add("ราคา", 100, HorizontalAlignment.Right);
            lblProduct.Columns.Add("จำนวณ", 100, HorizontalAlignment.Right);
            lblProduct.Columns.Add("รวมเป็นเงิน", 100, HorizontalAlignment.Right);
            lblProduct.View = View.Details;
            lblProduct.GridLines = true;
            lblProduct.FullRowSelect = true;
        }

        private void txtEmployeeID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string sql = "select employeeID,Title+FirstName+space(2)+LastName as empName" +
                    " from employees where employeeID = @employeeID";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@employeeID", txtEmployeeID.Text);
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();

                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    txtEmployeeID.Text = dt.Rows[0][0].ToString();
                    txtEmployeeName.Text = dt.Rows[0][1].ToString();
                    txtProductID.Focus();
                }
                else
                {
                    clearEmployeeDate();
                    txtEmployeeID.Focus();
                }
                dr.Close(); 
                conn.Close();

            }
        }

        private void txtProductID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProductID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string sql = "select ProductID,ProductName,Unitprice from Products" +
                    " where productID = @productID ";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@productID", txtProductID.Text);
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    txtProductID.Text = dt.Rows[0][0].ToString();
                    txtProductName.Text = dt.Rows[0][1].ToString();
                    txtUnitPrice.Text = dt.Rows[0][2].ToString();
                    CalculateTotal();
                    txtProductID.Focus();
                }
                else
                {
                    MessageBox.Show("ไม่พบสินค้ารหัสนี้", "เกิดข้อผิดพลาด");
                    ClearProductData();
                    txtProductID.Focus();
                }
                dr.Close();
                conn.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearProductData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtProductID.Text == "" || txtProductName.Text == "")
            {
                txtProductID.Focus();
                return;
            }
            if (Convert.ToInt32(txtQuantity.Text)==0)
            {
                txtProductID.Focus();
                return;
            }
            ListViewItem lvi;
            string tmpProductID = "";
            for (int i = 0; i < lblProduct.Items.Count; i++)
            {
                tmpProductID = lblProduct.Items[i].SubItems[0].Text;
                if (txtProductID.Text == tmpProductID)
                {
                    int qty = Convert.ToInt32(lblProduct.Items[i].SubItems[3].Text)
                        + Convert.ToInt32(txtQuantity.Text);

                    double newTotoal = Convert.ToDouble(lblProduct.Items[i].SubItems[4].Text)
                        + Convert.ToDouble(txtTotal.Text);
                    lblProduct.Items[i].SubItems[3].Text = qty.ToString();
                    lblProduct.Items[i].SubItems[4].Text = newTotoal.ToString("#,##0.00");
                    CalculateTotal();
                    CalculateNetprice();
                    return;
                }
            }
            string[] anyData = new string[] { txtProductID.Text ,txtProductName.Text,
            txtUnitPrice.Text,txtQuantity.Text,txtTotal.Text};

            lvi = new ListViewItem(anyData);
            lblProduct.Items.Add(lvi);
            CalculateNetprice();
            ClearProductData();
            btnSave.Enabled = true;
            txtProductID.Focus();


        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantity.Text == "" || Convert.ToInt32(txtQuantity.Text) ==0)
            {
                txtQuantity.Text = "1";
            }
            CalculateTotal();
        }

        private void lblProduct_DoubleClick(object sender, EventArgs e)
        {
            for (int i = 0; i < lblProduct.SelectedItems.Count; i++)
            {
                ListViewItem lvi = lblProduct.SelectedItems[i];
                lblProduct.Items.Remove(lvi);
            }
            CalculateNetprice();
            txtProductID.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lblProduct.Clear();
            clearEmployeeDate();
            ClearProductData();
            ListViewFormat();
            lblNetprice.Text = "0.00";
            txtEmployeeID.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int lastOrderID = 0; //เก็บ orderID ที่เพิ่มหลังสุดเตรียมไว่เพิ่มข้อมูลหลังสุดในตาราง Details
            if (txtEmployeeID.Text =="" || txtEmployeeName.Text =="")
            {
                MessageBox.Show("โปรดกรอกข้อมูล", "เกิดข้อผิดพลาด");
                txtEmployeeID.Focus();
                return;
            }
            if(lblProduct.Items.Count > 0)
            {
                if (MessageBox.Show("บันทึกรายการสินค้า","โปรดยืนยัน",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    conn.Open();
                    tr = conn.BeginTransaction();
                    // บันทึกข้อมูลลงตาราง recipts

                    string sql = "Insert into Receipts(ReceiptDate,EmployeeID,TotalCash)" +
                        " Values(getdate(), @employeeID, @totalcash)";
                    SqlCommand comm = new SqlCommand(sql, conn,tr);
                    comm.Parameters.AddWithValue("@employeeID", txtEmployeeID.Text);
                    comm.Parameters.AddWithValue("@totalcash", lblNetprice.Text);
                    comm.ExecuteNonQuery();


                    // ---------- อ่านค่า receiptID ที่บันทึกไว้
                    string sql1 = "Select top 1 ReceiptID from Receipts Order by ReceiptID desc";

                    SqlCommand comm1 = new SqlCommand(sql1, conn, tr);
                    SqlDataReader dr = comm1.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        lastOrderID = dr.GetInt32(dr.GetOrdinal("receiptID"));

                    }
                    dr.Close();
                    // ------------------ เพิ่มข้อมูลรายการที่ตรงกับ LastOrderID ลงในตาราง Details -----------
                    for (int i = 0; i < lblProduct.Items.Count; i++)
                    {
                        string sql2 = "insert into Details(ReceiptID,ProductID,UnitPrice,Quantity)"
                            + " values(@ReceiptID,@ProductID,@UnitPrice,@Quantity)";
                        SqlCommand comm3 = new SqlCommand(sql2, conn, tr);
                        comm3.Parameters.AddWithValue("@ReceiptID", lastOrderID);
                        comm3.Parameters.AddWithValue("@ProductID", lblProduct.Items[i].SubItems[0].Text);
                        comm3.Parameters.AddWithValue("@UnitPrice", lblProduct.Items[i].SubItems[2].Text);
                        comm3.Parameters.AddWithValue("@Quantity", lblProduct.Items[i].SubItems[3].Text);

                        comm3.ExecuteNonQuery();
                      
                    }
                    tr.Commit();
                    conn.Close();
                    MessageBox.Show("บันทึกรายการเรียบร้อบ", "ผลการทำงาน");
                }
            }
            btnCancel.PerformClick();

        }

        private void lblProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
