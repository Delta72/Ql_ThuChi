namespace QL_ThuChi
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuDuLieu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDSThu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDSChi = new System.Windows.Forms.ToolStripMenuItem();
            this.lYDOTHUCHIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTienIch = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDoiMatKhau = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGioiThieu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDuLieu,
            this.mnuTienIch,
            this.mnuThoat});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(689, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuDuLieu
            // 
            this.mnuDuLieu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNhanVien,
            this.mnuDSThu,
            this.mnuDSChi,
            this.lYDOTHUCHIToolStripMenuItem});
            this.mnuDuLieu.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuDuLieu.Name = "mnuDuLieu";
            this.mnuDuLieu.Size = new System.Drawing.Size(68, 20);
            this.mnuDuLieu.Text = "DỮ LIỆU";
            // 
            // mnuNhanVien
            // 
            this.mnuNhanVien.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuNhanVien.Name = "mnuNhanVien";
            this.mnuNhanVien.Size = new System.Drawing.Size(180, 22);
            this.mnuNhanVien.Text = "NHÂN VIÊN";
            // 
            // mnuDSThu
            // 
            this.mnuDSThu.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuDSThu.Name = "mnuDSThu";
            this.mnuDSThu.Size = new System.Drawing.Size(180, 22);
            this.mnuDSThu.Text = "DANH SÁCH THU";
            this.mnuDSThu.Click += new System.EventHandler(this.mnuDSThu_Click);
            // 
            // mnuDSChi
            // 
            this.mnuDSChi.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuDSChi.Name = "mnuDSChi";
            this.mnuDSChi.Size = new System.Drawing.Size(180, 22);
            this.mnuDSChi.Text = "DANH SÁCH CHI";
            this.mnuDSChi.Click += new System.EventHandler(this.mnuDSChi_Click);
            // 
            // lYDOTHUCHIToolStripMenuItem
            // 
            this.lYDOTHUCHIToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lYDOTHUCHIToolStripMenuItem.Name = "lYDOTHUCHIToolStripMenuItem";
            this.lYDOTHUCHIToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lYDOTHUCHIToolStripMenuItem.Text = "LY DO THU CHI";
            this.lYDOTHUCHIToolStripMenuItem.Click += new System.EventHandler(this.lYDOTHUCHIToolStripMenuItem_Click);
            // 
            // mnuTienIch
            // 
            this.mnuTienIch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDangNhap,
            this.mnuDangXuat,
            this.mnuDoiMatKhau,
            this.mnuGioiThieu});
            this.mnuTienIch.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuTienIch.Name = "mnuTienIch";
            this.mnuTienIch.Size = new System.Drawing.Size(72, 20);
            this.mnuTienIch.Text = "TIỆN ÍCH";
            // 
            // mnuDangNhap
            // 
            this.mnuDangNhap.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuDangNhap.Name = "mnuDangNhap";
            this.mnuDangNhap.Size = new System.Drawing.Size(180, 22);
            this.mnuDangNhap.Text = "ĐĂNG NHẬP";
            this.mnuDangNhap.Click += new System.EventHandler(this.mnuDangNhap_Click);
            // 
            // mnuDangXuat
            // 
            this.mnuDangXuat.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuDangXuat.Name = "mnuDangXuat";
            this.mnuDangXuat.Size = new System.Drawing.Size(180, 22);
            this.mnuDangXuat.Text = "ĐĂNG XUẤT";
            // 
            // mnuDoiMatKhau
            // 
            this.mnuDoiMatKhau.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuDoiMatKhau.Name = "mnuDoiMatKhau";
            this.mnuDoiMatKhau.Size = new System.Drawing.Size(180, 22);
            this.mnuDoiMatKhau.Text = "ĐỔI MẬT KHẨU";
            // 
            // mnuGioiThieu
            // 
            this.mnuGioiThieu.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuGioiThieu.Name = "mnuGioiThieu";
            this.mnuGioiThieu.Size = new System.Drawing.Size(180, 22);
            this.mnuGioiThieu.Text = "GIỚI THIỆU";
            // 
            // mnuThoat
            // 
            this.mnuThoat.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Size = new System.Drawing.Size(63, 20);
            this.mnuThoat.Text = "THOÁT";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 357);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHƯƠNG TRÌNH QUẢN LÝ THU CHI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuNhanVien;
        private System.Windows.Forms.ToolStripMenuItem mnuDSThu;
        private System.Windows.Forms.ToolStripMenuItem mnuDSChi;
        private System.Windows.Forms.ToolStripMenuItem mnuTienIch;
        private System.Windows.Forms.ToolStripMenuItem mnuDangNhap;
        private System.Windows.Forms.ToolStripMenuItem mnuGioiThieu;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        public System.Windows.Forms.ToolStripMenuItem mnuDuLieu;
        public System.Windows.Forms.ToolStripMenuItem mnuDangXuat;
        public System.Windows.Forms.ToolStripMenuItem mnuDoiMatKhau;
        private System.Windows.Forms.ToolStripMenuItem lYDOTHUCHIToolStripMenuItem;
    }
}