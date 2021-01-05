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
    public partial class frmThu : Form
    {
        public frmThu()
        {
            InitializeComponent();
        }
        bool blnThem = false;
        DataSet dsDataBase = new DataSet();
        void DieuKhienBinhThuong()
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
            btnLuu.Enabled = false;
            btnKhongLuu.Enabled = false;
            btnDong.Enabled = true;
            txtSTT.ReadOnly = true;
            cboNVThu.Enabled = false;
            cboNVNop.Enabled = false;
            txtSoTien.ReadOnly = true;
            dtpNgayThu.Enabled = false;
            cboLyDo.Enabled = false;
            txtGhiChu.ReadOnly = true;
            dgvThu.Enabled = true;
        }
        void DieuKhienThem()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            btnDong.Enabled = false;
            cboNVThu.Enabled = true;
            cboNVNop.Enabled = true;
            txtSoTien.ReadOnly = false;
            dtpNgayThu.Enabled = true;
            cboLyDo.Enabled = true;
            txtGhiChu.ReadOnly = false;
            dgvThu.Enabled = false;
            // txtSTT.Text = "C" + laySTT();
            cboNVThu.SelectedIndex = -1;
            cboNVNop.SelectedIndex = -1;
            txtSoTien.Clear();
            dtpNgayThu.Value = DateTime.Now;
            cboLyDo.SelectedIndex = -1;
            txtGhiChu.Clear();
        }
        void DieuKhienSua()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            btnDong.Enabled = false;
            cboNVThu.Enabled = true;
            cboNVNop.Enabled = true;
            txtSoTien.ReadOnly = false;
            dtpNgayThu.Enabled = true;
            cboLyDo.Enabled = true;
            txtGhiChu.ReadOnly = false;
            dgvThu.Enabled = false;
        }
        void GanDuLieu()
        {
            if (dgvThu.Rows.Count > 0)
            {
                int r = dgvThu.CurrentRow.Index;
                txtSTT.Text = dgvThu[0, r].Value.ToString();
                cboNVThu.SelectedIndex = cboNVThu.FindStringExact(dgvThu[1, r].Value.ToString());
                cboNVNop.SelectedIndex = cboNVThu.FindStringExact(dgvThu[2, r].Value.ToString());
                txtSoTien.Text = dgvThu[3, r].Value.ToString();
                dtpNgayThu.Value = DateTime.Parse(dgvThu[4, r].Value.ToString());
                cboLyDo.SelectedIndex = cboLyDo.FindStringExact(dgvThu[5, r].Value.ToString());
                txtGhiChu.Text = dgvThu[6, r].Value.ToString();
            }
            else
            {
                txtSTT.Clear();
                cboNVThu.SelectedIndex = -1;
                cboNVNop.SelectedIndex = -1;
                txtSoTien.Clear();
                dtpNgayThu.Value = DateTime.Now;
                cboLyDo.SelectedIndex = -1;
                txtGhiChu.Clear();
            }
        }
        void ThemMoi()
        {
            string strSql = "INSERT INTO THU(STTPHIEU, MANV_THU, MANV_NOP, SOTIEN, NGAYTHU, LYDOTHU, GHICHU) VALUES(@STTPHIEU, @MANV_THU, @MANV_NOP, @SOTIEN, @NGAYTHU, @LYDOTHU, @GHICHU)";
            if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                MyPublics.conMyConnection.Open();
            SqlCommand cmdCommad = new SqlCommand(strSql, MyPublics.conMyConnection);
            cmdCommad.Parameters.AddWithValue("@STTPHIEU", txtSTT.Text);
            cmdCommad.Parameters.AddWithValue("@MANV_THU", cboNVThu.SelectedValue.ToString());
            cmdCommad.Parameters.AddWithValue("@MANV_NOP", cboNVNop.SelectedValue.ToString());
            cmdCommad.Parameters.AddWithValue("@SOTIEN", txtSoTien.Text);
            cmdCommad.Parameters.AddWithValue("@NGAYTHU", dtpNgayThu.Value);
            cmdCommad.Parameters.AddWithValue("@LYDOTHU", cboLyDo.SelectedValue.ToString());
            if (txtGhiChu.Text.Trim() == "")
                cmdCommad.Parameters.AddWithValue("@GHICHU", DBNull.Value);
            else
                cmdCommad.Parameters.AddWithValue("@GHICHU", txtGhiChu.Text);
            cmdCommad.ExecuteNonQuery();
            MyPublics.conMyConnection.Close();
            dsDataBase.Tables["THU"].Rows.Add(txtSTT.Text, cboNVThu.Text, cboNVNop.Text, txtSoTien.Text, dtpNgayThu.Value.ToString(), cboLyDo.Text, txtGhiChu.Text);
        }
        private void frmThu_Load(object sender, EventArgs e)
        {
            string strSql = "select STTPHIEU, NHANVIENTHU.MANV + ' - ' + NHANVIENTHU.HOTEN AS NHANVIENTHU, NHANVIENNOP.MANV + ' - ' + NHANVIENNOP.HOTEN AS NHANVIENNOP, SOTIEN, NGAYTHU, MALYDO + ' - ' + DIENGIAI AS LYDO, GHICHU FROM THU LEFT JOIN LYDOTHUCHI ON THU.LYDOTHU = LYDOTHUCHI.MALYDO LEFT JOIN NHANVIEN AS NHANVIENTHU ON THU.MANV_THU = NHANVIENTHU.MANV LEFT JOIN NHANVIEN AS NHANVIENNOP ON THU.MANV_NOP = NHANVIENNOP.MANV";
            MyPublics.OpenData(strSql, dsDataBase, "THU");
            strSql = "SELECT MANV, MANV + ' - ' + HOTEN AS HOTEN FROM NHANVIEN";
            MyPublics.OpenData(strSql, dsDataBase, "NhanVienThu");
            MyPublics.OpenData(strSql, dsDataBase, "NhanVienNop");
            strSql = "SELECT MALYDO, MALYDO + ' - ' + DIENGIAI AS LYDO FROM LYDOTHUCHI";
            MyPublics.OpenData(strSql, dsDataBase, "LyDo");
            cboNVThu.DataSource = dsDataBase.Tables["NhanVienThu"];
            cboNVThu.DisplayMember = "HOTEN";
            cboNVThu.ValueMember = "MANV";
            cboNVNop.DataSource = dsDataBase.Tables["NhanVienNop"];
            cboNVNop.DisplayMember = "HOTEN";
            cboNVNop.ValueMember = "MANV";
            cboLyDo.DataSource = dsDataBase.Tables["LyDo"];
            cboLyDo.DisplayMember = "LYDO";
            cboLyDo.ValueMember = "MALYDO";
            dgvThu.DataSource = dsDataBase;
            dgvThu.DataMember = "Thu";
            txtSTT.MaxLength = 4;
            txtGhiChu.MaxLength = 50;
            dgvThu.Width = 1250;
            dgvThu.Columns[0].Width = 70;
            dgvThu.Columns[0].HeaderText = "STT";
            dgvThu.Columns[1].Width = 200;
            dgvThu.Columns[1].HeaderText = "Nhân viên thu";
            dgvThu.Columns[2].Width = 200;
            dgvThu.Columns[2].HeaderText = "Nhân viên nộp";
            dgvThu.Columns[3].Width = 100;
            dgvThu.Columns[3].HeaderText = "Số tiền";
            dgvThu.Columns[4].Width = 100;
            dgvThu.Columns[4].HeaderText = "Ngày thu";
            dgvThu.Columns[5].Width = 300;
            dgvThu.Columns[5].HeaderText = "Lý do";
            dgvThu.Columns[6].Width = 200;
            dgvThu.Columns[6].HeaderText = "Ghi chú";
            dgvThu.AllowUserToAddRows = false;
            dgvThu.AllowUserToDeleteRows = false;
            GanDuLieu();
            DieuKhienBinhThuong();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            blnThem = true;
            DieuKhienThem();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DieuKhienSua();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult blnDongY;
            blnDongY = MessageBox.Show("Bạn có chắc muốn xóa phiếu thu mã " + txtSTT.Text + " ?", "Thông báo", MessageBoxButtons.YesNo);
            if (blnDongY == DialogResult.Yes)
            {
                string strSql = "DELETE THU WHERE STTPHIEU=@STTPHIEU";
                if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                    MyPublics.conMyConnection.Open();
                SqlCommand cmdCommand = new SqlCommand(strSql, MyPublics.conMyConnection);
                cmdCommand.Parameters.AddWithValue("@STTPHIEU", txtSTT.Text);
                cmdCommand.ExecuteNonQuery();
                MyPublics.conMyConnection.Close();
                MessageBox.Show("Đã xóa !!!", "Thông báo");
                dsDataBase.Tables["THU"].Rows.RemoveAt(dgvThu.CurrentRow.Index);
                GanDuLieu();
            }
        }
        void Sua()
        {
            string strSql = "UPDATE THU SET STTPHIEU=@STTPHIEU, MANV_THU=@MANV_THU, MANV_NOP=@MANV_NOP, SOTIEN=@SOTIEN, NGAYTHU=@NGAYTHU, LYDOTHU=@LYDOTHU, GHICHU=@GHICHU WHERE STTPHIEU=@STTPHIEU";
            if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                MyPublics.conMyConnection.Open();
            SqlCommand cmdCommad = new SqlCommand(strSql, MyPublics.conMyConnection);
            cmdCommad.Parameters.AddWithValue("@STTPHIEU", txtSTT.Text);
            cmdCommad.Parameters.AddWithValue("@MANV_THU", cboNVThu.SelectedValue.ToString());
            cmdCommad.Parameters.AddWithValue("@MANV_NOP", cboNVNop.SelectedValue.ToString());
            cmdCommad.Parameters.AddWithValue("@SOTIEN", txtSoTien.Text);
            cmdCommad.Parameters.AddWithValue("@NGAYTHU", dtpNgayThu.Value);
            cmdCommad.Parameters.AddWithValue("@LYDOTHU", cboLyDo.SelectedValue.ToString());
            if (txtGhiChu.Text.Trim() == "")
                cmdCommad.Parameters.AddWithValue("@GHICHU", DBNull.Value);
            else
                cmdCommad.Parameters.AddWithValue("@GHICHU", txtGhiChu.Text);
            cmdCommad.ExecuteNonQuery();
            MyPublics.conMyConnection.Close();
            int r = dgvThu.CurrentRow.Index;
            dsDataBase.Tables["Thu"].Rows[r][1] = cboNVThu.Text;
            dsDataBase.Tables["Thu"].Rows[r][2] = cboNVNop.Text;
            dsDataBase.Tables["Thu"].Rows[r][3] = txtSoTien.Text;
            dsDataBase.Tables["Thu"].Rows[r][4] = dtpNgayThu.Value.ToString();
            dsDataBase.Tables["Thu"].Rows[r][5] = cboLyDo.Text;
            dsDataBase.Tables["Thu"].Rows[r][6] = txtGhiChu.Text;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            float f;
            if ((txtSTT.Text.Trim() != "") || (cboNVThu.SelectedIndex != -1) || (cboNVNop.SelectedIndex != -1) || (txtSoTien.Text.Trim() != "") || (float.TryParse(txtSoTien.Text, out f)) || (cboLyDo.SelectedIndex != -1))
            {
                if (blnThem == true)
                {
                    if (MyPublics.TonTaiKhoaChinh(txtSTT.Text, "STTPHIEU", "THU"))
                    {
                        MessageBox.Show("Mã " + txtSTT.Text + " đã tồn tại", "Thông báo");
                    }
                    else
                    {
                        ThemMoi();
                        blnThem = false;
                    }
                }
                else
                {
                    Sua();
                }
            }
            else
            {
                MessageBox.Show("Bạn đã nhập sai hoặc bỏ trống một trong các dữ liệu cần thiết!", "Thông báo");
            }
            DieuKhienBinhThuong();
            GanDuLieu();
        }

        private void btnKhongLuu_Click(object sender, EventArgs e)
        {
            DieuKhienBinhThuong();
            GanDuLieu();
            blnThem = false;
        }

        private void dgvThu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GanDuLieu();
        }
    }
}
