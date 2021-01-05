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
    public partial class frmLyDoThuChi : Form
    {
        DataSet dsLyDo = new DataSet();
        bool blnThem = false;

        public frmLyDoThuChi()
        {
            InitializeComponent();
        }

        private void frmLyDoThuChi_Load(object sender, EventArgs e)
        {
            string strSql = "SELECT * FROM LYDOTHUCHI";
            MyPublics.OpenData(strSql, dsLyDo, "LyDo");
            dgvLyDoThuChi.DataSource = dsLyDo;
            dgvLyDoThuChi.DataMember = "LyDo";
        }
    }
}
