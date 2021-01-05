using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_ThuChi
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmDangNhap1 fDN = new frmDangNhap1(this);
            fDN.ShowDialog();
        }

        private void mnuDSChi_Click(object sender, EventArgs e)
        {
            frmChi fC = new frmChi();
            fC.Show();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnuDangNhap_Click(object sender, EventArgs e)
        {
            frmDangNhap1 frmdn1 = new frmDangNhap1();
            frmdn1.ShowDialog();
        }

        private void mnuDSThu_Click(object sender, EventArgs e)
        {
            frmThu frmt = new frmThu();
            frmt.ShowDialog();
        }

        private void lYDOTHUCHIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLyDoThuChi fLD = new frmLyDoThuChi();
            fLD.Show();
        }
    }
}
