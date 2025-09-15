using System;
using System.Data;
using System.Windows.Forms;

namespace QLSV1
{
    public partial class FormDangKy : Form
    {
        public FormDangKy()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string username = txtTaiKhoan.Text.Trim();
            string password = txtMatKhau.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            // Kiểm tra tài khoản đã tồn tại
            string checkQuery = "SELECT * FROM TaiKhoan WHERE TenDangNhap = @user";
            DataTable dt = DataProvider.Instance.ExecuteQuery(checkQuery, new object[] { username });
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Tài khoản đã tồn tại. Vui lòng đăng nhập.");
                return;
            }

            // Thêm tài khoản mới
            string insertQuery = "INSERT INTO TaiKhoan (TenDangNhap, MatKhau, Email, QuyenQuanLy) VALUES (@user, @pass, @mail, 'User')";
            int result = DataProvider.Instance.ExecuteNonQuery(insertQuery, new object[] { username, password, email });

            if (result > 0)
            {
                MessageBox.Show("Đăng ký thành công! Vui lòng đăng nhập.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại.");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkDangNhap_LinkClicked(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}