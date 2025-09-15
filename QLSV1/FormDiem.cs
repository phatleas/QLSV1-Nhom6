using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace QLSV1
{
    public partial class FormDiem : Form
    {
        DataProvider provider = new DataProvider();

        public FormDiem()
        {
            InitializeComponent();
            LoadData();
            LoadComboBoxData();
            dgvDiem.CellClick += dgvDiem_CellClick;
            cboTimKiem.SelectedIndex = 0; // Chọn mặc định
        }

        private void LoadData()
        {
            try
            {
                string query = @"SELECT d.MaDiem, d.MaSV, sv.HoDem, sv.Ten, d.MaMH, mh.TenMH, 
               d.DiemSo, d.GhiChu 
               FROM Diem d 
               LEFT JOIN SinhVien sv ON d.MaSV = sv.MaSV 
               LEFT JOIN MonHoc mh ON d.MaMH = mh.MaMH";
                dgvDiem.DataSource = provider.ExecuteQuery(query);

                // Đặt tên cột hiển thị
                if (dgvDiem.Columns.Count > 0)
                {
                    if (dgvDiem.Columns.Count > 0)
                    {
                        dgvDiem.Columns["MaDiem"].HeaderText = "Mã điểm";
                        dgvDiem.Columns["MaSV"].HeaderText = "Mã SV";
                        dgvDiem.Columns["HoDem"].HeaderText = "Họ đệm";
                        dgvDiem.Columns["Ten"].HeaderText = "Tên";
                        dgvDiem.Columns["MaMH"].HeaderText = "Mã MH";
                        dgvDiem.Columns["TenMH"].HeaderText = "Tên môn học";
                        dgvDiem.Columns["DiemSo"].HeaderText = "Điểm số";
                        dgvDiem.Columns["GhiChu"].HeaderText = "Ghi chú";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboBoxData()
        {
            try
            {
                // Load danh sách sinh viên
                string querySV = "SELECT MaSV, CONCAT(HoDem, ' ', Ten) as HoTen FROM SinhVien ORDER BY HoDem, Ten";
                DataTable dtSV = provider.ExecuteQuery(querySV);

                // Load danh sách môn học
                string queryMH = "SELECT MaMH, TenMH FROM MonHoc";
                DataTable dtMH = provider.ExecuteQuery(queryMH);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu ComboBox: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDiem.Rows[e.RowIndex];
                txtMaSV.Text = row.Cells["MaSV"].Value?.ToString() ?? "";
                txtMaMH.Text = row.Cells["MaMH"].Value?.ToString() ?? "";
                txtDiemSo.Text = row.Cells["DiemSo"].Value?.ToString() ?? "";
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString() ?? "";
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMaMH.Text))
            {
                MessageBox.Show("Vui lòng nhập mã môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaMH.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDiemSo.Text))
            {
                MessageBox.Show("Vui lòng nhập điểm số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiemSo.Focus();
                return false;
            }

            if (!float.TryParse(txtDiemSo.Text, out float diem) || diem < 0 || diem > 10)
            {
                MessageBox.Show("Điểm số phải là số từ 0 đến 10!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiemSo.Focus();
                return false;
            }

            return true;
        }

        private void ClearInput()
        {
            txtMaSV.Clear();
            txtMaMH.Clear();
            txtDiemSo.Clear();
            txtGhiChu.Clear();
            txtMaSV.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                // Kiểm tra trùng lặp
                string checkQuery = "SELECT COUNT(*) FROM Diem WHERE MaSV = @MaSV AND MaMH = @MaMH";
                DataTable dt = provider.ExecuteQuery(checkQuery,
                    new object[] { txtMaSV.Text, txtMaMH.Text });

                if (dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0)
                {
                    MessageBox.Show("Sinh viên này đã có điểm môn học này rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = "INSERT INTO Diem(MaSV,MaMH,DiemSo,GhiChu) VALUES(@MaSV,@MaMH,@DiemSo,@GhiChu)";
                provider.ExecuteNonQuery(query,
                    new object[] { txtMaSV.Text, txtMaMH.Text, float.Parse(txtDiemSo.Text), txtGhiChu.Text });

                MessageBox.Show("Thêm điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm điểm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            if (dgvDiem.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int maDiem = Convert.ToInt32(dgvDiem.CurrentRow.Cells["MaDiem"].Value);
                string query = "UPDATE Diem SET MaSV=@MaSV,MaMH=@MaMH,DiemSo=@DiemSo,GhiChu=@GhiChu WHERE MaDiem=@MaDiem";
                provider.ExecuteNonQuery(query,
                    new object[] { txtMaSV.Text, txtMaMH.Text, float.Parse(txtDiemSo.Text), txtGhiChu.Text, maDiem });

                MessageBox.Show("Cập nhật điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa điểm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDiem.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa điểm này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int maDiem = Convert.ToInt32(dgvDiem.CurrentRow.Cells["MaDiem"].Value);
                    string query = "DELETE FROM Diem WHERE MaDiem=@MaDiem";
                    provider.ExecuteNonQuery(query, new object[] { maDiem });

                    MessageBox.Show("Xóa điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearInput();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa điểm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        // Chức năng tìm kiếm
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTimKiem.Focus();
                return;
            }

            try
            {
                string query = @"SELECT d.MaDiem, d.MaSV, CONCAT(sv.HoDem, ' ', sv.Ten) as TenSV, d.MaMH, mh.TenMH, 
                               d.DiemSo, d.GhiChu 
                               FROM Diem d 
                               LEFT JOIN SinhVien sv ON d.MaSV = sv.MaSV 
                               LEFT JOIN MonHoc mh ON d.MaMH = mh.MaMH 
                               WHERE ";

                string searchValue = txtTimKiem.Text.Trim();
                string whereClause = "";

                switch (cboTimKiem.SelectedIndex)
                {
                    case 0: // Mã sinh viên
                        whereClause = "d.MaSV LIKE @searchValue";
                        searchValue = "%" + searchValue + "%";
                        break;
                    case 1: // Tên sinh viên
                        whereClause = "CONCAT(sv.HoDem, ' ', sv.Ten) LIKE @searchValue";
                        searchValue = "%" + searchValue + "%";
                        break;
                    case 2: // Mã môn học
                        whereClause = "d.MaMH LIKE @searchValue";
                        searchValue = "%" + searchValue + "%";
                        break;
                    case 3: // Tên môn học
                        whereClause = "mh.TenMH LIKE @searchValue";
                        searchValue = "%" + searchValue + "%";
                        break;
                    case 4: // Điểm số
                        if (float.TryParse(searchValue, out float diem))
                        {
                            whereClause = "d.DiemSo = @searchValue";
                            // Không thêm % cho tìm kiếm điểm số chính xác
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập điểm số hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        break;
                    default:
                        whereClause = "d.MaSV LIKE @searchValue";
                        searchValue = "%" + searchValue + "%";
                        break;
                }

                query += whereClause;

                DataTable result = provider.ExecuteQuery(query, new object[] { searchValue });
                dgvDiem.DataSource = result;

                if (dgvDiem.Columns.Count > 0)
                {
                    dgvDiem.Columns["MaDiem"].HeaderText = "Mã điểm";
                    dgvDiem.Columns["MaSV"].HeaderText = "Mã SV";
                    dgvDiem.Columns["HoDem"].HeaderText = "Họ đệm";
                    dgvDiem.Columns["Ten"].HeaderText = "Tên";
                    dgvDiem.Columns["MaMH"].HeaderText = "Mã MH";
                    dgvDiem.Columns["TenMH"].HeaderText = "Tên môn học";
                    dgvDiem.Columns["DiemSo"].HeaderText = "Điểm số";
                    dgvDiem.Columns["GhiChu"].HeaderText = "Ghi chú";
                }

                if (result.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Tìm thấy {result.Rows.Count} kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Làm mới kết quả tìm kiếm
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboTimKiem.SelectedIndex = 0;
            LoadData();
        }

        private void FormDiem_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}