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
    public partial class frmDangNhap1 : Form
    {
        frmMain fM;
        int count = 0;

        public frmDangNhap1(frmMain fMain) : this()
        {
            fM = fMain;
        }
        public frmDangNhap1()
        {
            InitializeComponent();
        }

        private void frmDangNhap1_Load(object sender, EventArgs e)
        {
            btnDangNhap.Focus();
            txtMatKhau.PasswordChar = '*';
            txtTaiKhoan.Text = "001358";
            txtMatKhau.Text = "001358";
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string strSql;
            SqlDataReader drReader;
            SqlCommand cmdCommand;
            try
            {
                MyPublics.ConnectDatabase();
                if (MyPublics.conMyConnection.State == ConnectionState.Open)
                {
                    strSql = "SELECT MANV, QUYENSD, HOTEN FROM NHANVIEN WHERE MANV=@MANV AND MATKHAU=@MATKHAU";
                    cmdCommand = new SqlCommand(strSql, MyPublics.conMyConnection);
                    cmdCommand.Parameters.AddWithValue("@MANV", txtTaiKhoan.Text);
                    cmdCommand.Parameters.AddWithValue("@MATKHAU", txtMatKhau.Text);
                    drReader = cmdCommand.ExecuteReader();
                    if (drReader.HasRows)
                    {
                        drReader.Read();
                        MyPublics.strMaNV = drReader.GetString(0);
                        MyPublics.strQuyenSD = drReader.GetString(1);
                        MyPublics.strTen = drReader.GetString(2);
                        drReader.Close();
                        fM.mnuDuLieu.Enabled = true;
                        fM.mnuDangXuat.Enabled = true;
                        fM.mnuDoiMatKhau.Enabled = true;
                        MyPublics.conMyConnection.Close();
                        this.Close();
                    }
                    else
                    {
                        count++;
                        MessageBox.Show("Mã nhân viên hoặc mật khẩu sai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTaiKhoan.Focus();
                        if (count >= 3)
                        {
                            MessageBox.Show("Bạn đã nhập sai 3 lần", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            fM.mnuDuLieu.Enabled = false;
                            fM.mnuDangXuat.Enabled = false;
                            fM.mnuDoiMatKhau.Enabled = false;
                            MyPublics.strMaNV = "";
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Kết nỗi không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception) { }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            fM.mnuDuLieu.Enabled = false;
            fM.mnuDangXuat.Enabled = false;
            fM.mnuDoiMatKhau.Enabled = false;
            MyPublics.strMaNV = "";
            this.Close();
        }
    }
}
