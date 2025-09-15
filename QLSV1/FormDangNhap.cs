using System;
using System.Data;
using System.Windows.Forms;

namespace QLSV1 { 
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTaiKhoan.Text.Trim();
            string password = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu.");
                return;
            }

            string query = "SELECT * FROM TaiKhoan WHERE TenDangNhap = @user AND MatKhau = @pass";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, new object[] { username, password });

            if (dt.Rows.Count > 0)
            {
                FormHome home = new FormHome();
                this.Hide();
                home.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng.");
            }
        }

        private void linkDangKy_LinkClicked(object sender, EventArgs e)
        {
            FormDangKy dk = new FormDangKy();
            this.Hide();
            dk.ShowDialog();
            this.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}