using System;
using System.Data;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Office2010.Drawing;
using Microsoft.Data.SqlClient;

namespace QLSV1
{
    public partial class FormMonHoc : Form
    {
        string connectionString = @"Server=.\SQLEXPRESS;Database=QuanLySinhVien;Integrated Security=True;TrustServerCertificate=True;";

        public FormMonHoc()
        {
            InitializeComponent();
            this.Load += new EventHandler(FormMonHoc_Load);
            dgvMonHoc.CellClick += dgvMonHoc_CellClick;
        }

        private void FormMonHoc_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // Load danh sách môn học
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM MonHoc";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvMonHoc.DataSource = dt;
            }
        }

        // Thêm môn học
        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Loại bỏ cột MaMH và GhiChu khỏi câu lệnh INSERT
                string sql = "INSERT INTO MonHoc (TenMH, SoTinChi) VALUES (@TenMH, @SoTinChi)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TenMH", txtTenMH.Text.Trim());

                // Kiểm tra và xử lý trường SoTinChi
                if (int.TryParse(txtSoTinChi.Text.Trim(), out int soTinChi))
                {
                    cmd.Parameters.AddWithValue("@SoTinChi", soTinChi);
                }
                else
                {
                    MessageBox.Show("Số tín chỉ không hợp lệ! Vui lòng nhập một số nguyên.");
                    return;
                }

                conn.Open();
                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm môn học thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Thêm môn học thất bại!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                conn.Close();
                LoadData();
            }
        }

        // Sửa môn học
        private void btnSua_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "UPDATE MonHoc SET TenMH=@TenMH, SoTinChi=@SoTinChi, GhiChu=@GhiChu WHERE MaMH=@MaMH";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaMH", txtMaMH.Text.Trim());
                cmd.Parameters.AddWithValue("@TenMH", txtTenMH.Text.Trim());
                cmd.Parameters.AddWithValue("@SoTinChi", int.TryParse(txtSoTinChi.Text.Trim(), out int stc) ? stc : 0);
                cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text.Trim());

                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật môn học thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                conn.Close();
                LoadData();
            }
        }

        // Xóa môn học
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa môn học này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM MonHoc WHERE MaMH=@MaMH";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaMH", txtMaMH.Text.Trim());

                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa môn học thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                conn.Close();
                LoadData();
            }
        }

        // Lưu (thông báo)
        private void btnLuu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dữ liệu đã được lưu!", "Thông báo");
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvMonHoc.Rows[e.RowIndex].Cells["MaMH"].Value != null)
            {
                DataGridViewRow row = dgvMonHoc.Rows[e.RowIndex];
                txtMaMH.Text = row.Cells["MaMH"].Value?.ToString();
                txtTenMH.Text = row.Cells["TenMH"].Value?.ToString();
                txtSoTinChi.Text = row.Cells["SoTinChi"].Value?.ToString();
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();
            }
        }
    }
}
