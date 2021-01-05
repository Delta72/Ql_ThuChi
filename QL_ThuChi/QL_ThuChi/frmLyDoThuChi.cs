using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        void dkkbt()
        {
            if (MyPublics.strQuyenSD == "AllAdmin" || MyPublics.strQuyenSD == "Admin")
            {
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            else
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
            btnDong.Enabled = true;
            btnLuu.Enabled = false;
            btnKhongLuu.Enabled = false;
            txtMa.ReadOnly = true;
            txtMa.BackColor = Color.White;
            txtDienGiai.ReadOnly = false;
            txtDienGiai.BackColor = Color.White;
            dgvLyDoThuChi.Enabled = true;
        }

        void dkktm()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            txtMa.ReadOnly = false;
            txtMa.Clear();
            txtDienGiai.ReadOnly = false;
            txtDienGiai.Clear();
            dgvLyDoThuChi.Enabled = false;
        }

        void dkkcs()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            txtDienGiai.ReadOnly = false;
            dgvLyDoThuChi.Enabled = false;
        }

        void GanDuLieu()
        {
            if(dgvLyDoThuChi.Rows.Count > 0)
            {
                txtMa.Text = dgvLyDoThuChi[0, dgvLyDoThuChi.CurrentRow.Index].Value.ToString();
                txtDienGiai.Text = dgvLyDoThuChi[1, dgvLyDoThuChi.CurrentRow.Index].Value.ToString();
            }
            else
            {
                txtMa.Clear();
                txtDienGiai.Clear();
            }
        }

        private void frmLyDoThuChi_Load(object sender, EventArgs e)
        {
            string strSql = "SELECT * FROM LYDOTHUCHI";
            MyPublics.OpenData(strSql, dsLyDo, "LyDo");
            dgvLyDoThuChi.DataSource = dsLyDo;
            dgvLyDoThuChi.DataMember = "LyDo";
            txtMa.MaxLength = 6;
            txtDienGiai.MaxLength = 100;
            dgvLyDoThuChi.Width = 1046;
            dgvLyDoThuChi.Columns[0].Width = 300;
            dgvLyDoThuChi.Columns[0].HeaderText = "Mã";
            dgvLyDoThuChi.Columns[1].Width = 691;
            dgvLyDoThuChi.Columns[1].HeaderText = "Diễn giải";
            dgvLyDoThuChi.AllowUserToAddRows = false;
            dgvLyDoThuChi.AllowUserToDeleteRows = false;
            GanDuLieu();
            dkkbt();
        }

        private void dgvLyDoThuChi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GanDuLieu();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            blnThem = true;
            dkktm();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            dkkcs();
        }

        private void btnKhongLuu_Click(object sender, EventArgs e)
        {
            blnThem = false;
            GanDuLieu();
            dkkbt();
        }

        bool KiemTra()
        {
            if(txtMa.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập mã lý do", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMa.Focus();
                return false;
            }
            if(txtDienGiai.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập diễn giải", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDienGiai.Focus();
                return false;
            }
            return true;
        }

        void ThemMoi()
        {
            string strSql = "INSERT INTO LYDOTHUCHI(MALYDO, DIENGIAI) VALUES(@MALYDO, @DIENGIAI)";
            if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                MyPublics.conMyConnection.Open();
            SqlCommand cmdCommand = new SqlCommand(strSql, MyPublics.conMyConnection);
            cmdCommand.Parameters.AddWithValue("@MALYDO", txtMa.Text);
            cmdCommand.Parameters.AddWithValue("@DIENGIAI", txtDienGiai.Text);
            cmdCommand.ExecuteNonQuery();
            MyPublics.conMyConnection.Close();
            dsLyDo.Tables["LyDo"].Rows.Add(txtMa.Text, txtDienGiai.Text);
            GanDuLieu();
            dkkbt();
        }

        void ChinhSua()
        {
            string strSql = "UPDATE LYDOTHUCHI SET DIENGIAI=@DIENGIAI WHERE MALYDO=@MALYDO";
            if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                MyPublics.conMyConnection.Open();
            SqlCommand cmdCommand = new SqlCommand(strSql, MyPublics.conMyConnection);
            cmdCommand.Parameters.AddWithValue("@MALYDO", txtMa.Text);
            cmdCommand.Parameters.AddWithValue("@DIENGIAI", txtDienGiai.Text);
            cmdCommand.ExecuteNonQuery();
            MyPublics.conMyConnection.Close();
            dsLyDo.Tables["LyDo"].Rows[dgvLyDoThuChi.CurrentRow.Index][1] = txtDienGiai.Text;
            GanDuLieu();
            dkkbt();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                if (blnThem)
                {
                    if (MyPublics.TonTaiKhoaChinh(txtMa.Text, "MALYDO", "LYDOTHUCHI"))
                    {
                        MessageBox.Show("Mã lý do đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMa.Focus();
                    }
                    else
                    {
                        ThemMoi();
                    }
                }
                else
                    ChinhSua();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(MyPublics.TonTaiKhoaChinh(txtMa.Text, "LYDOTHU", "THU"))
            {
                MessageBox.Show("Tồn tại dữ liệu với lý do " + txtMa.Text + " ở danh sách thu. Bạn phải xóa dữ liệu đó trước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (MyPublics.TonTaiKhoaChinh(txtMa.Text, "LYDOCHI", "CHI"))
            {
                MessageBox.Show("Tồn tại dữ liệu với lý do " + txtMa.Text + " ở danh sách chi. Bạn phải xóa dữ liệu đó trước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult blnDongY;
                blnDongY = MessageBox.Show("Bạn có chắc chắn xóa lý do " + txtDienGiai.Text + " (" + txtMa.Text + ")", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(blnDongY == DialogResult.Yes)
                {
                    string strSql = "DELETE LYDOTHUCHI WHERE MALYDO=@MALYDO";
                    if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                        MyPublics.conMyConnection.Open();
                    SqlCommand cmdCommand = new SqlCommand(strSql, MyPublics.conMyConnection);
                    cmdCommand.Parameters.AddWithValue("@MALYDO", txtMa.Text);
                    cmdCommand.ExecuteNonQuery();
                    MyPublics.conMyConnection.Close();
                    dsLyDo.Tables["LyDo"].Rows.RemoveAt(dgvLyDoThuChi.CurrentRow.Index);
                    GanDuLieu();
                    dkkbt();
                }
            }
        }
    }
}
