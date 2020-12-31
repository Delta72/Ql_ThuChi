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
    public partial class frmChi : Form
    {
        DataSet dsDatabase = new DataSet();
        bool blnThem = false;
        public frmChi()
        {
            InitializeComponent();
        }

        string laySTT()
        {
            string strSql = "SELECT COUNT(*) + 1 FROM CHI", res = "";
            if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                MyPublics.conMyConnection.Open();
            SqlCommand cmdCommand = new SqlCommand(strSql, MyPublics.conMyConnection);
            SqlDataReader drReader = cmdCommand.ExecuteReader();
            if (drReader.HasRows)
            {
                drReader.Read();
                res = drReader.GetInt32(0).ToString();
                drReader.Close();
            }
            else
                res = "001";
            while (res.Length < 3) res = "0" + res;
            MyPublics.conMyConnection.Close();
            return res;
        }

        void dkkbt()
        {
            if(MyPublics.strQuyenSD == "AllAdmin" || MyPublics.strQuyenSD== "Admin")
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
            cboNVChi.Enabled = false;
            cboNVNhan.Enabled = false;
            txtSoTien.ReadOnly = true;
            dtpNgayChi.Enabled = false;
            cboLyDo.Enabled = false;
            txtGhiChu.ReadOnly = true;
            dgvChi.Enabled = true;
        }

        void dkktm()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            btnDong.Enabled = false;
            cboNVChi.Enabled = true;
            cboNVNhan.Enabled = true;
            txtSoTien.ReadOnly = false;
            dtpNgayChi.Enabled = true;
            cboLyDo.Enabled = true;
            txtGhiChu.ReadOnly = false;
            dgvChi.Enabled = false;
            txtSTT.Text = "C" + laySTT();
            cboNVChi.SelectedIndex = -1;
            cboNVNhan.SelectedIndex = -1;
            txtSoTien.Clear();
            dtpNgayChi.Value = DateTime.Now;
            cboLyDo.SelectedIndex = -1;
            txtGhiChu.Clear();
        }

        void dkkcs()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            btnDong.Enabled = false;
            cboNVChi.Enabled = true;
            cboNVNhan.Enabled = true;
            txtSoTien.ReadOnly = false;
            dtpNgayChi.Enabled = true;
            cboLyDo.Enabled = true;
            txtGhiChu.ReadOnly = false;
            dgvChi.Enabled = false;
        }

        void GanDuLieu()
        {
            if(dgvChi.Rows.Count > 0)
            {
                int r = dgvChi.CurrentRow.Index;
                txtSTT.Text = dgvChi[0, r].Value.ToString();
                cboNVChi.SelectedIndex = cboNVChi.FindStringExact(dgvChi[1, r].Value.ToString());
                cboNVNhan.SelectedIndex = cboNVChi.FindStringExact(dgvChi[2, r].Value.ToString());
                txtSoTien.Text = dgvChi[3, r].Value.ToString();
                dtpNgayChi.Value = DateTime.Parse(dgvChi[4, r].Value.ToString());
                cboLyDo.SelectedIndex = cboLyDo.FindStringExact(dgvChi[5, r].Value.ToString());
                txtGhiChu.Text = dgvChi[6, r].Value.ToString();
            }
            else
            {
                txtSTT.Clear();
                cboNVChi.SelectedIndex = -1;
                cboNVNhan.SelectedIndex = -1;
                txtSoTien.Clear();
                dtpNgayChi.Value = DateTime.Now;
                cboLyDo.SelectedIndex = -1;
                txtGhiChu.Clear();
            }
        }

        private void frmChi_Load(object sender, EventArgs e)
        {
            string strSql = "SELECT STTPHIEU, NHANVIENCHI.MANV + ' - ' + NHANVIENCHI.HOTEN AS NHANVIENCHI, NHANVIENNHAN.MANV + ' - ' + NHANVIENNHAN.HOTEN AS NHANVIENNHAN, SOTIEN, NGAYCHI, MALYDO + ' - ' + DIENGIAI AS LYDO, GHICHU FROM CHI LEFT JOIN LYDOTHUCHI ON CHI.LYDOCHI = LYDOTHUCHI.MALYDO LEFT JOIN NHANVIEN AS NHANVIENCHI ON CHI.MANV_CHI = NHANVIENCHI.MANV LEFT JOIN NHANVIEN AS NHANVIENNHAN ON CHI.MANV_NHAN = NHANVIENNHAN.MANV";
            MyPublics.OpenData(strSql, dsDatabase, "Chi");
            strSql = "SELECT MANV, MANV + ' - ' + HOTEN AS HOTEN FROM NHANVIEN";
            MyPublics.OpenData(strSql, dsDatabase, "NhanVienChi");
            MyPublics.OpenData(strSql, dsDatabase, "NhanVienNhan");
            strSql = "SELECT MALYDO, MALYDO + ' - ' + DIENGIAI AS LYDO FROM LYDOTHUCHI";
            MyPublics.OpenData(strSql, dsDatabase, "LyDo");
            cboNVChi.DataSource = dsDatabase.Tables["NhanVienChi"];
            cboNVChi.DisplayMember = "HOTEN";
            cboNVChi.ValueMember = "MANV";
            cboNVNhan.DataSource = dsDatabase.Tables["NhanVienNhan"];
            cboNVNhan.DisplayMember = "HOTEN";
            cboNVNhan.ValueMember = "MANV";
            cboLyDo.DataSource = dsDatabase.Tables["LyDo"];
            cboLyDo.DisplayMember = "LYDO";
            cboLyDo.ValueMember = "MALYDO";
            dgvChi.DataSource = dsDatabase;
            dgvChi.DataMember = "Chi";
            txtSTT.MaxLength = 4;
            txtGhiChu.MaxLength = 50;
            dgvChi.Width = 1270;
            dgvChi.Columns[0].HeaderText = "STT";
            dgvChi.Columns[1].HeaderText = "Nhân viên chi";
            dgvChi.Columns[2].HeaderText = "Nhân viên nhận";
            dgvChi.Columns[3].HeaderText = "Số tiền";
            dgvChi.Columns[4].HeaderText = "Ngày chi";
            dgvChi.Columns[5].HeaderText = "Lý do";
            dgvChi.Columns[6].HeaderText = "Ghi chú";
            dgvChi.AllowUserToAddRows = false;
            dgvChi.AllowUserToDeleteRows = false;
            GanDuLieu();
            dkkbt();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvChi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GanDuLieu();
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
            dkkbt();
            GanDuLieu();
            blnThem = false;
        }

        bool KiemTra()
        {
            if (txtSTT.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập số thứ tự", "Thông báo");
                txtSTT.Focus();
                return false;
            }
            if(cboNVChi.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn nhân viên chi", "Thông báo");
                return false;
            }
            if (cboNVNhan.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn nhân viên nhận", "Thông báo");
                return false;
            }
            if (txtSoTien.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập số tiền", "Thông báo");
                txtSoTien.Focus();
                return false;
            }
            if (!float.TryParse(txtSoTien.Text, out float f))
            {
                MessageBox.Show("Bạn nhập sai định dạng số", "Thông báo");
                txtSoTien.Clear();
                txtSoTien.Focus();
                return false;
            }
            if (cboLyDo.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn lý do", "Thông báo");
                return false;
            }
            return true;
        }

        void ThemMoi()
        {
            string strSql = "INSERT INTO CHI(STTPHIEU, MANV_CHI, MANV_NHAN, SOTIEN, NGAYCHI, LYDOCHI, GHICHU) VALUES(@STTPHIEU, @MANV_CHI, @MANV_NHAN, @SOTIEN, @NGAYCHI, @LYDOCHI, @GHICHU)";
            if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                MyPublics.conMyConnection.Open();
            SqlCommand cmdCommad = new SqlCommand(strSql, MyPublics.conMyConnection);
            cmdCommad.Parameters.AddWithValue("@STTPHIEU", txtSTT.Text);
            cmdCommad.Parameters.AddWithValue("@MANV_CHI", cboNVChi.SelectedValue.ToString());
            cmdCommad.Parameters.AddWithValue("@MANV_NHAN", cboNVNhan.SelectedValue.ToString());
            cmdCommad.Parameters.AddWithValue("@SOTIEN", txtSoTien.Text);
            cmdCommad.Parameters.AddWithValue("@NGAYCHI", dtpNgayChi.Value);
            cmdCommad.Parameters.AddWithValue("@LYDOCHI", cboLyDo.SelectedValue.ToString());
            if (txtGhiChu.Text.Trim() == "")
                cmdCommad.Parameters.AddWithValue("@GHICHU", DBNull.Value);
            else
                cmdCommad.Parameters.AddWithValue("@GHICHU", txtGhiChu.Text);
            cmdCommad.ExecuteNonQuery();
            MyPublics.conMyConnection.Close();
            dsDatabase.Tables["Chi"].Rows.Add(txtSTT.Text, cboNVChi.Text, cboNVNhan.Text, txtSoTien.Text, dtpNgayChi.Value.ToString(), cboLyDo.Text, txtGhiChu.Text);
        }

        void ChinhSua()
        {
            string strSql = "UPDATE CHI SET STTPHIEU=@STTPHIEU, MANV_CHI=@MANV_CHI, MANV_NHAN=@MANV_NHAN, SOTIEN=@SOTIEN, NGAYCHI=@NGAYCHI, LYDOCHI=@LYDOCHI, GHICHU=@GHICHU WHERE STTPHIEU=@STTPHIEU";
            if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                MyPublics.conMyConnection.Open();
            SqlCommand cmdCommad = new SqlCommand(strSql, MyPublics.conMyConnection);
            cmdCommad.Parameters.AddWithValue("@STTPHIEU", txtSTT.Text);
            cmdCommad.Parameters.AddWithValue("@MANV_CHI", cboNVChi.SelectedValue.ToString());
            cmdCommad.Parameters.AddWithValue("@MANV_NHAN", cboNVNhan.SelectedValue.ToString());
            cmdCommad.Parameters.AddWithValue("@SOTIEN", txtSoTien.Text);
            cmdCommad.Parameters.AddWithValue("@NGAYCHI", dtpNgayChi.Value);
            cmdCommad.Parameters.AddWithValue("@LYDOCHI", cboLyDo.SelectedValue.ToString());
            if (txtGhiChu.Text.Trim() == "")
                cmdCommad.Parameters.AddWithValue("@GHICHU", DBNull.Value);
            else
                cmdCommad.Parameters.AddWithValue("@GHICHU", txtGhiChu.Text);
            cmdCommad.ExecuteNonQuery();
            MyPublics.conMyConnection.Close();
            int r = dgvChi.CurrentRow.Index;
            dsDatabase.Tables["Chi"].Rows[r][1] = cboNVChi.Text;
            dsDatabase.Tables["Chi"].Rows[r][2] = cboNVNhan.Text;
            dsDatabase.Tables["Chi"].Rows[r][3] = txtSoTien.Text;
            dsDatabase.Tables["Chi"].Rows[r][4] = dtpNgayChi.Value.ToString();
            dsDatabase.Tables["Chi"].Rows[r][5] = cboLyDo.Text;
            dsDatabase.Tables["Chi"].Rows[r][6] = txtGhiChu.Text;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                if (blnThem)
                {
                    if (MyPublics.TonTaiKhoaChinh(txtSTT.Text, "STTPHIEU", "CHI"))
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
                    ChinhSua();
                dkkbt();
                GanDuLieu();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult blnDongY;
            blnDongY = MessageBox.Show("Bạn có chắc muốn xóa phiếu chi mã " + txtSTT.Text, "Thông báo", MessageBoxButtons.YesNo);
            if (blnDongY == DialogResult.Yes)
            {
                string strSql = "DELETE Chi WHERE STTPHIEU=@STTPHIEU";
                if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                    MyPublics.conMyConnection.Open();
                SqlCommand cmdCommand = new SqlCommand(strSql, MyPublics.conMyConnection);
                cmdCommand.Parameters.AddWithValue("@STTPHIEU", txtSTT.Text);
                cmdCommand.ExecuteNonQuery();
                MyPublics.conMyConnection.Close();
                MessageBox.Show("Đã xóa thành công", "Thông báo");
                dsDatabase.Tables["Chi"].Rows.RemoveAt(dgvChi.CurrentRow.Index);
                GanDuLieu();
            }
        }
    }
}
