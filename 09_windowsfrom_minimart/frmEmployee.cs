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
    public partial class frmEmployee : Form
    {
        public frmEmployee()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        int employeeID = 0;
        string title = null, fristname = null,
            lastname = null, position = null, username = null, password;

        private void dgvEmployee_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            frmEmployeeInsert f = new frmEmployeeInsert();
            f.status = "update";
            f.EmployeeID = this.employeeID;
            f.title = this.title;
            f.firstname = this.fristname;
            f.lastname = this.lastname;
            f.position = this.position;
            f.username = this.username;
            f.password = this.password;
            f.ShowDialog();
            ShowData("%");
        }

        private void dgvEmployee_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            var x = dgvEmployee.CurrentRow.Cells;

            employeeID = Convert.ToInt32(dgvEmployee.CurrentRow.Cells["EmployeeID"].Value);
            title = x["title"].Value.ToString();
            fristname = x["firstname"].Value.ToString();
            lastname = x["lastname"].Value.ToString();
            position = x["position"].Value.ToString();
            username = x["username"].Value.ToString();
            password = x["password"].Value.ToString();
        }

        private void dgvEmployee_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6 && e.Value != null)
            {
                dgvEmployee.Rows[e.RowIndex].Tag = e.Value;
                e.Value = new string('\u25CF', e.Value.ToString().Length);
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string str = txtsearch.Text.Trim();
            ShowData(str);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (employeeID != 0)
            {
                string msg = employeeID.ToString() + Environment.NewLine
                     + title + fristname + " " + lastname + Environment.NewLine
                     + position;
                if (MessageBox.Show(msg, "โปรดยืนยันการลบข้อมูลนี้", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DeleteEmployee();
                    ShowData("%");
                }
            }
            else
            {
                MessageBox.Show("โปรดเลือกข้อมูลที่ต้องการจะลบก่อน", "เกิดข้อผิดพลาด");
            }
        }

        private void DeleteEmployee()
        {
            string sql = "delete from employees where employeeID = @id";
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.Parameters.AddWithValue("@id", employeeID);
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string msg = "เกิดข้อผิดพลาด" + Environment.NewLine + ex.Message;
                MessageBox.Show(msg, "การทำงานผิดพลาด");

            }
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        private void ShowData(string str)
        {
            string sql = "select * from Employees" +
               " where firstname like '%' + @str + '%'" +
               " or LastName like  '%' + @str + '%'" +
               " or Position like  '%' + @str + '%'" +
                " or username like  '%' + @str + '%'";
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.Parameters.AddWithValue("@str", str);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataSet dt = new DataSet();
            da.Fill(dt);
            dgvEmployee.DataSource = dt.Tables[0];
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            frmEmployeeInsert f = new frmEmployeeInsert();
            f.status = "insert";
            f.ShowDialog();
            ShowData("%");
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            conn = new ConnectDB().SqlCon();
            ShowData("%");
        }
    }
}
