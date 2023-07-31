using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _09_windowsfrom_minimart
{
    public partial class frmMinimart : Form
    {
        public frmMinimart()
        {
            InitializeComponent();
        }
        //ประกาศตัวแปร
        int employeeID = 0;                     //เก็บรหัสพนักงานที่ login เข้ามา 
        string employeeName = "";        //เก็บชื่อพนักงาน
        string Username = "";                   //เก๋บชื่อผู้ใช้
        string Position = "";                       //เก็บตำเเหน่งของผู้ใช้

        private void frmMinimart_Load(object sender, EventArgs e)
        {
            ShowHideMenu(true, false);
        }

        private void ShowHideMenu(bool mnnuStartVisible, bool mnuSaleRep)
        {
            mnuStart.Visible = mnnuStartVisible;
            mnuSalerep.Visible = mnuSaleRep;
        }

        private void mnuExitprogram_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMinimart_FormClosed(object sender, FormClosedEventArgs e)
        {
           
          
        }

        private void frmMinimart_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("ต้องการออกจากโปรเเกรมหรือไม่", "โปรยืนยัน", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuLogin_Click(object sender, EventArgs e)
        {
            frmLogin f = new frmLogin();
            f.ShowDialog();
            if (f.EmployeeID != 0)
            {
                this.employeeID = f.EmployeeID;
                this.employeeName = f.EmployeesName;
                this.Position = f.Position;
                this.Username = f.Username;
                ShowHideMenu(false, true);
                this.Text = "โปรเเกรมร้านสะดวกซื้อ ชือผู้ใช้  :  " + employeeName + "  ตำเเหน่ง : " + Position;
            }
        }

        private void mnuLogOut_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
            this.employeeID = 0;
            this.employeeName = "";
            this.Position = "";
            this.Username = "";
            ShowHideMenu(true, false);
            this.Text = "โปรเเกรมร้านสะดวกซื้อ";
        }
        
        private void mnuEmployees_Click(object sender, EventArgs e)
        {
            bool isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if(f.Name == "frmEmployee")
                {
                    f.Close();
                    break;
                }
            }
            if(isopen == false)
            {
                frmEmployee f = new frmEmployee();
                f.MdiParent = this;
                f.Show();
            }
           
            
        }

        private void mnuPorducts_Click(object sender, EventArgs e)
        {
            bool isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "FrmProduct")
                {
                    f.Close();
                    break;
                }
            }
            if (isopen == false)
            {
               FrmProduct f = new FrmProduct();
                f.MdiParent = this;
                f.Show();
                f.Focus();
            }

            
        }

        private void mnuCategories_Click(object sender, EventArgs e)
        {
            bool isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "FormCategory") //  FormCategory
                {
                    f.Close();
                    break;
                }
            }
            if (isopen == false)
            {
                FormCategory f = new FormCategory();
                 f.MdiParent = this;
                f.Show();
            }
           
        }

        private void mnuPOS_Click(object sender, EventArgs e)
        { //ปิด form ที่อยู่หน้าสุด
            //หน้า form ขายของ
            bool isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "Receipt") //  FormReceip
                {
                    f.Close();
                    break;
                }
            }
            if (isopen == false)
            {
                Receipt f = new Receipt();
                f.employeeid = this.employeeID;
                f.empName = this.employeeName;
                f.MdiParent = this;
                f.Show();
            }
        }

        private void mnuCloseActiveChild_Click(object sender, EventArgs e)
        {   //ปิด form ลูกทั้งหมด
            Form f = this.ActiveMdiChild;
            f.Close();
        }

        private void mnuCloseALlChild_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
        }

        private void mnuCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade); //เรียงเเบบเป็นชั้น
        }

        private void mnuTileVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical); //เรียงแบบเเนวตั้ง
        }

        private void mnuTileHorizental_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);//เรียงเเบบเเนวนอน
        }
    }
}
