
namespace _09_windowsfrom_minimart
{
    partial class frmMinimart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnuSalerep = new System.Windows.Forms.MenuStrip();
            this.mnuData = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmployees = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCategories = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPorducts = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPOS = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReports = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportByRecipt = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPeportByProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportByCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportByEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportByDate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuForms = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCloseActiveChild = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCloseALlChild = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTileVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTileHorizental = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStart = new System.Windows.Forms.MenuStrip();
            this.mnuLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.จดการขอมลToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.จดการขอมลToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExitprogram = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalerep.SuspendLayout();
            this.mnuStart.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuSalerep
            // 
            this.mnuSalerep.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuSalerep.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuData,
            this.mnuPOS,
            this.mnuReports,
            this.mnuForms,
            this.mnuExit,
            this.mnuLogOut});
            this.mnuSalerep.Location = new System.Drawing.Point(0, 28);
            this.mnuSalerep.Name = "mnuSalerep";
            this.mnuSalerep.Size = new System.Drawing.Size(800, 28);
            this.mnuSalerep.TabIndex = 0;
            this.mnuSalerep.Text = "menuStrip1";
            // 
            // mnuData
            // 
            this.mnuData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEmployees,
            this.mnuCategories,
            this.mnuPorducts});
            this.mnuData.Name = "mnuData";
            this.mnuData.Size = new System.Drawing.Size(95, 24);
            this.mnuData.Text = "จัดการข้อมูล";
            // 
            // mnuEmployees
            // 
            this.mnuEmployees.Name = "mnuEmployees";
            this.mnuEmployees.Size = new System.Drawing.Size(239, 26);
            this.mnuEmployees.Text = "จัดการข้อมูลพนักงาน";
            this.mnuEmployees.Click += new System.EventHandler(this.mnuEmployees_Click);
            // 
            // mnuCategories
            // 
            this.mnuCategories.Name = "mnuCategories";
            this.mnuCategories.Size = new System.Drawing.Size(239, 26);
            this.mnuCategories.Text = "จัดการข้อมูลประเภทสินค้า";
            this.mnuCategories.Click += new System.EventHandler(this.mnuCategories_Click);
            // 
            // mnuPorducts
            // 
            this.mnuPorducts.Name = "mnuPorducts";
            this.mnuPorducts.Size = new System.Drawing.Size(239, 26);
            this.mnuPorducts.Text = "จัดการข้อมูลสินค้า";
            this.mnuPorducts.Click += new System.EventHandler(this.mnuPorducts_Click);
            // 
            // mnuPOS
            // 
            this.mnuPOS.Name = "mnuPOS";
            this.mnuPOS.Size = new System.Drawing.Size(80, 24);
            this.mnuPOS.Text = "ขายสินค้า";
            this.mnuPOS.Click += new System.EventHandler(this.mnuPOS_Click);
            // 
            // mnuReports
            // 
            this.mnuReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuReportByRecipt,
            this.mnuPeportByProduct,
            this.mnuReportByCategory,
            this.mnuReportByEmployee,
            this.mnuReportByDate});
            this.mnuReports.Name = "mnuReports";
            this.mnuReports.Size = new System.Drawing.Size(123, 24);
            this.mnuReports.Text = "รายการขายสินค้า";
            // 
            // mnuReportByRecipt
            // 
            this.mnuReportByRecipt.Name = "mnuReportByRecipt";
            this.mnuReportByRecipt.Size = new System.Drawing.Size(298, 26);
            this.mnuReportByRecipt.Text = "เเสดงรายการขายตามใบเสร็จ";
            // 
            // mnuPeportByProduct
            // 
            this.mnuPeportByProduct.Name = "mnuPeportByProduct";
            this.mnuPeportByProduct.Size = new System.Drawing.Size(298, 26);
            this.mnuPeportByProduct.Text = "ยอดขายสินค้าตามชนิดสินค้า";
            // 
            // mnuReportByCategory
            // 
            this.mnuReportByCategory.Name = "mnuReportByCategory";
            this.mnuReportByCategory.Size = new System.Drawing.Size(298, 26);
            this.mnuReportByCategory.Text = "ยอดขายสินค้าเเยกตามประเภทสินค้า";
            // 
            // mnuReportByEmployee
            // 
            this.mnuReportByEmployee.Name = "mnuReportByEmployee";
            this.mnuReportByEmployee.Size = new System.Drawing.Size(298, 26);
            this.mnuReportByEmployee.Text = "ยอดขายสินค้าเเยกตามพนักงาน";
            // 
            // mnuReportByDate
            // 
            this.mnuReportByDate.Name = "mnuReportByDate";
            this.mnuReportByDate.Size = new System.Drawing.Size(298, 26);
            this.mnuReportByDate.Text = "ยอดขายสินค้าตามช่วงเวลา";
            // 
            // mnuForms
            // 
            this.mnuForms.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCloseActiveChild,
            this.mnuCloseALlChild,
            this.mnuCascade,
            this.mnuTileVertical,
            this.mnuTileHorizental});
            this.mnuForms.Name = "mnuForms";
            this.mnuForms.Size = new System.Drawing.Size(55, 24);
            this.mnuForms.Text = "ฟอร์ม";
            // 
            // mnuCloseActiveChild
            // 
            this.mnuCloseActiveChild.Name = "mnuCloseActiveChild";
            this.mnuCloseActiveChild.Size = new System.Drawing.Size(272, 26);
            this.mnuCloseActiveChild.Text = "ปิดฟอร์มที่ Active";
            this.mnuCloseActiveChild.Click += new System.EventHandler(this.mnuCloseActiveChild_Click);
            // 
            // mnuCloseALlChild
            // 
            this.mnuCloseALlChild.Name = "mnuCloseALlChild";
            this.mnuCloseALlChild.Size = new System.Drawing.Size(272, 26);
            this.mnuCloseALlChild.Text = "ปิดฟอร์มทั้งหมด";
            this.mnuCloseALlChild.Click += new System.EventHandler(this.mnuCloseALlChild_Click);
            // 
            // mnuCascade
            // 
            this.mnuCascade.Name = "mnuCascade";
            this.mnuCascade.Size = new System.Drawing.Size(272, 26);
            this.mnuCascade.Text = "จัดเรียงฟอร์ม(Cascade)";
            this.mnuCascade.Click += new System.EventHandler(this.mnuCascade_Click);
            // 
            // mnuTileVertical
            // 
            this.mnuTileVertical.Name = "mnuTileVertical";
            this.mnuTileVertical.Size = new System.Drawing.Size(272, 26);
            this.mnuTileVertical.Text = "จัดเรียงฟอร์ม(The Vertical)";
            this.mnuTileVertical.Click += new System.EventHandler(this.mnuTileVertical_Click);
            // 
            // mnuTileHorizental
            // 
            this.mnuTileHorizental.Name = "mnuTileHorizental";
            this.mnuTileHorizental.Size = new System.Drawing.Size(272, 26);
            this.mnuTileHorizental.Text = "จัดเรียงฟอร์ม(The Horizental)";
            this.mnuTileHorizental.Click += new System.EventHandler(this.mnuTileHorizental_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(100, 24);
            this.mnuExit.Text = "จบการทำงาน";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuLogOut
            // 
            this.mnuLogOut.Name = "mnuLogOut";
            this.mnuLogOut.Size = new System.Drawing.Size(101, 24);
            this.mnuLogOut.Text = "ออกจากระบบ";
            this.mnuLogOut.Click += new System.EventHandler(this.mnuLogOut_Click);
            // 
            // mnuStart
            // 
            this.mnuStart.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuStart.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLogin,
            this.mnuExitprogram});
            this.mnuStart.Location = new System.Drawing.Point(0, 0);
            this.mnuStart.Name = "mnuStart";
            this.mnuStart.Size = new System.Drawing.Size(800, 28);
            this.mnuStart.TabIndex = 1;
            this.mnuStart.Text = "menuStrip2";
            // 
            // mnuLogin
            // 
            this.mnuLogin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.จดการขอมลToolStripMenuItem,
            this.จดการขอมลToolStripMenuItem1});
            this.mnuLogin.Name = "mnuLogin";
            this.mnuLogin.Size = new System.Drawing.Size(80, 24);
            this.mnuLogin.Text = "เข้าสู่ระบบ";
            this.mnuLogin.Click += new System.EventHandler(this.mnuLogin_Click);
            // 
            // จดการขอมลToolStripMenuItem
            // 
            this.จดการขอมลToolStripMenuItem.Name = "จดการขอมลToolStripMenuItem";
            this.จดการขอมลToolStripMenuItem.Size = new System.Drawing.Size(83, 26);
            // 
            // จดการขอมลToolStripMenuItem1
            // 
            this.จดการขอมลToolStripMenuItem1.Name = "จดการขอมลToolStripMenuItem1";
            this.จดการขอมลToolStripMenuItem1.Size = new System.Drawing.Size(83, 26);
            // 
            // mnuExitprogram
            // 
            this.mnuExitprogram.Name = "mnuExitprogram";
            this.mnuExitprogram.Size = new System.Drawing.Size(100, 24);
            this.mnuExitprogram.Text = "จบการทำงาน";
            this.mnuExitprogram.Click += new System.EventHandler(this.mnuExitprogram_Click);
            // 
            // frmMinimart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mnuSalerep);
            this.Controls.Add(this.mnuStart);
            this.ForeColor = System.Drawing.Color.Black;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuSalerep;
            this.Name = "frmMinimart";
            this.Text = "frmMinimart";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMinimart_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMinimart_FormClosed);
            this.Load += new System.EventHandler(this.frmMinimart_Load);
            this.mnuSalerep.ResumeLayout(false);
            this.mnuSalerep.PerformLayout();
            this.mnuStart.ResumeLayout(false);
            this.mnuStart.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuSalerep;
        private System.Windows.Forms.ToolStripMenuItem mnuData;
        private System.Windows.Forms.ToolStripMenuItem mnuEmployees;
        private System.Windows.Forms.ToolStripMenuItem mnuCategories;
        private System.Windows.Forms.ToolStripMenuItem mnuPorducts;
        private System.Windows.Forms.ToolStripMenuItem mnuPOS;
        private System.Windows.Forms.ToolStripMenuItem mnuReports;
        private System.Windows.Forms.ToolStripMenuItem mnuReportByRecipt;
        private System.Windows.Forms.ToolStripMenuItem mnuPeportByProduct;
        private System.Windows.Forms.ToolStripMenuItem mnuReportByCategory;
        private System.Windows.Forms.ToolStripMenuItem mnuReportByEmployee;
        private System.Windows.Forms.ToolStripMenuItem mnuReportByDate;
        private System.Windows.Forms.ToolStripMenuItem mnuForms;
        private System.Windows.Forms.ToolStripMenuItem mnuCloseActiveChild;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuLogOut;
        private System.Windows.Forms.MenuStrip mnuStart;
        private System.Windows.Forms.ToolStripMenuItem mnuLogin;
        private System.Windows.Forms.ToolStripMenuItem จดการขอมลToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem จดการขอมลToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuExitprogram;
        private System.Windows.Forms.ToolStripMenuItem mnuCloseALlChild;
        private System.Windows.Forms.ToolStripMenuItem mnuCascade;
        private System.Windows.Forms.ToolStripMenuItem mnuTileVertical;
        private System.Windows.Forms.ToolStripMenuItem mnuTileHorizental;
    }
}