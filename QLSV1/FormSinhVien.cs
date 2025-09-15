using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Globalization;
using ClosedXML.Excel;

namespace QLSV1
{
    public partial class FormSinhVien : Form
    {
        private readonly string connectionString = @"Server=.\SQLEXPRESS;Database=QuanLySinhVien;Integrated Security=True;TrustServerCertificate=True;";

        public FormSinhVien()
        {
            InitializeComponent();
            dgvSinhVien.CellClick += dgvSinhVien_CellClick;
            this.Load += new EventHandler(FormSinhVien_Load);

            Luubtn.Click += new EventHandler(btnLuu_Click);
            btnXoa.Click += new EventHandler(btnXoa_Click);
            btnHienThi.Click += new EventHandler(btnHienThi_Click);
            btnTimKiem1.Click += new EventHandler(btnTimKiem1_Click);
            btnTimKiem2.Click += new EventHandler(btnTimKiem2_Click);
            btn_Excel.Click += new EventHandler(btn_Excel_Click);
            btnThem.Click += new EventHandler(btnThem_Click);
        }


        private void FormSinhVien_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadKhoa();
            LoadDanToc();
            LoadDiaChi();
            LoadLop();
            LoadGioiTinh();
        }
        private void LoadGioiTinh()
        {
            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");
            cboGioiTinh.SelectedIndex = 0;
        }
        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT sv.MaSV, sv.HoDem, sv.Ten, sv.NgaySinh, sv.GioiTinh,
                            sv.MaLop, l.TenLop, dt.TenDanToc, dc.Tinh, dc.Xa, sv.GhiChu, k.TenKhoa
                        FROM SinhVien sv
                        LEFT JOIN Lop l ON sv.MaLop = l.MaLop
                        LEFT JOIN DanToc dt ON sv.MaDanToc = dt.MaDanToc
                        LEFT JOIN DiaChi dc ON sv.MaDiaChi = dc.MaDiaChi
                        LEFT JOIN Nganh n ON l.MaNganh = n.MaNganh
                        LEFT JOIN Khoa k ON n.MaKhoa = k.MaKhoa";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvSinhVien.DataSource = dt;

             
                    dgvSinhVien.Columns["MaSV"].HeaderText = "Mã SV";
                    dgvSinhVien.Columns["HoDem"].HeaderText = "Họ đệm";
                    dgvSinhVien.Columns["Ten"].HeaderText = "Tên";
                    dgvSinhVien.Columns["NgaySinh"].HeaderText = "Ngày sinh";
                    dgvSinhVien.Columns["GioiTinh"].HeaderText = "Giới tính";
                    dgvSinhVien.Columns["TenLop"].HeaderText = "Lớp";
                    dgvSinhVien.Columns["TenDanToc"].HeaderText = "Dân tộc";
                    dgvSinhVien.Columns["Tinh"].HeaderText = "Tỉnh/Thành phố";
                    dgvSinhVien.Columns["Xa"].HeaderText = "Xã";
                    dgvSinhVien.Columns["GhiChu"].HeaderText = "Ghi chú";
                    dgvSinhVien.Columns["TenKhoa"].HeaderText = "Khoa";

                    dgvSinhVien.Columns["MaSV"].DisplayIndex = 0;
                    dgvSinhVien.Columns["TenKhoa"].DisplayIndex = 1;
                    dgvSinhVien.Columns["HoDem"].DisplayIndex = 2;
                    dgvSinhVien.Columns["Ten"].DisplayIndex = 3;
                    dgvSinhVien.Columns["TenLop"].DisplayIndex = 4;
                    dgvSinhVien.Columns["NgaySinh"].DisplayIndex = 5;
                    dgvSinhVien.Columns["GioiTinh"].DisplayIndex = 6;
                    dgvSinhVien.Columns["TenDanToc"].DisplayIndex = 7;
                    dgvSinhVien.Columns["Tinh"].DisplayIndex = 8;
                    dgvSinhVien.Columns["Xa"].DisplayIndex = 9;
                    dgvSinhVien.Columns["GhiChu"].DisplayIndex = 10;
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Lỗi SQL: Vui lòng kiểm tra chuỗi kết nối và truy vấn.\n" + sqlEx.Message, "Lỗi kết nối");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi");
            }
        }
       
        private void ClearForm()
        {
            txtMaSV.Text = string.Empty;
            txtHoDem.Text = string.Empty;
            txtTen.Text = string.Empty;
            dtpNgaySinh.Value = DateTime.Now;
            cboGioiTinh.Text = string.Empty;
            cboLop.SelectedIndex = -1; 
            cboDanToc.SelectedIndex = -1;
            cboDiaChi.SelectedIndex = -1;
            txtGhiChu.Text = string.Empty;
            txtTimKiem.Text = string.Empty;

           
            txtMaSV.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearForm();
            MessageBox.Show("Sẵn sàng để nhập dữ liệu mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadKhoa()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT MaKhoa, TenKhoa FROM Khoa";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cboKhoa.DataSource = dt;
                    cboKhoa.DisplayMember = "TenKhoa";
                    cboKhoa.ValueMember = "MaKhoa";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu Khoa: " + ex.Message);
            }
        }

        private void LoadDanToc()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT MaDanToc, TenDanToc FROM DanToc";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cboDanToc.DataSource = dt;
                    cboDanToc.DisplayMember = "TenDanToc";
                    cboDanToc.ValueMember = "MaDanToc";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu Dân tộc: " + ex.Message);
            }
        }

        private void LoadDiaChi()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT MaDiaChi, Tinh, Xa FROM DiaChi";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cboDiaChi.DataSource = dt;
                    cboDiaChi.DisplayMember = "Tinh";
                    cboDiaChi.ValueMember = "MaDiaChi";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu Địa chỉ: " + ex.Message);
            }
        }

        private void LoadLop()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT MaLop, TenLop FROM Lop";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboLop.DataSource = dt;
                    cboLop.DisplayMember = "TenLop"; 
                    cboLop.ValueMember = "MaLop";   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu lớp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string hoDem = txtHoDem.Text.Trim();
                    string ten = txtTen.Text.Trim();
                    DateTime ngaySinh = dtpNgaySinh.Value;
                    string gioiTinh = cboGioiTinh.SelectedItem?.ToString();
                    string maLop = cboLop.SelectedValue?.ToString();
                    string maDanToc = cboDanToc.SelectedValue?.ToString();
                    string maDiaChi = cboDiaChi.SelectedValue?.ToString();
                    string ghiChu = txtGhiChu.Text.Trim();

                  
                    if (string.IsNullOrEmpty(hoDem) || string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(gioiTinh) || string.IsNullOrEmpty(maLop))
                    {
                        MessageBox.Show("Vui lòng điền đầy đủ thông tin bắt buộc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    
                    string sqlInsert = "INSERT INTO SinhVien (HoDem, Ten, NgaySinh, GioiTinh, MaLop, MaDanToc, MaDiaChi, GhiChu) " +
                                       "OUTPUT INSERTED.MaSV " + 
                                       "VALUES (@HoDem, @Ten, @NgaySinh, @GioiTinh, @MaLop, @MaDanToc, @MaDiaChi, @GhiChu)";

                    SqlCommand cmd = new SqlCommand(sqlInsert, conn);
                    cmd.Parameters.AddWithValue("@HoDem", hoDem);
                    cmd.Parameters.AddWithValue("@Ten", ten);
                    cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                    cmd.Parameters.AddWithValue("@MaLop", maLop);
                    cmd.Parameters.AddWithValue("@MaDanToc", maDanToc);
                    cmd.Parameters.AddWithValue("@MaDiaChi", maDiaChi);
                    cmd.Parameters.AddWithValue("@GhiChu", ghiChu);

                    
                    var newMaSV = cmd.ExecuteScalar();

                    
                    txtMaSV.Text = newMaSV.ToString();

                    MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã SV cần xóa!", "Thông báo");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa SV này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM SinhVien WHERE MaSV = @MaSV";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaSV", txtMaSV.Text.Trim());
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sinh viên để xóa.", "Thông báo");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi");
            }
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvSinhVien.Rows.Count)
            {
                DataGridViewRow row = dgvSinhVien.Rows[e.RowIndex];
                txtMaSV.Text = row.Cells["MaSV"].Value?.ToString();
                txtHoDem.Text = row.Cells["HoDem"].Value?.ToString();
                txtTen.Text = row.Cells["Ten"].Value?.ToString();

                if(row.Cells["NgaySinh"].Value != DBNull.Value && row.Cells["NgaySinh"].Value is DateTime ngaySinh)
                {
                    dtpNgaySinh.Value = ngaySinh;
                }
                else
                {
                    dtpNgaySinh.Value = DateTime.Now; 
                }

                cboGioiTinh.SelectedItem = row.Cells["GioiTinh"].Value?.ToString();
                cboLop.Text = row.Cells["TenLop"].Value?.ToString();
                cboLop.SelectedValue = row.Cells["MaLop"].Value;
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();

                if (row.Cells["TenDanToc"].Value != null)
                {
                    string tenDanToc = row.Cells["TenDanToc"].Value.ToString();
                    foreach (DataRowView item in cboDanToc.Items)
                    {
                        if (item["TenDanToc"].ToString() == tenDanToc)
                        {
                            cboDanToc.SelectedValue = item["MaDanToc"];
                            break;
                        }
                    }
                }

                if (row.Cells["Tinh"].Value != null)
                {
                    string tinh = row.Cells["Tinh"].Value.ToString();
                    string xa = row.Cells["Xa"].Value?.ToString();
                    foreach (DataRowView item in cboDiaChi.Items)
                    {
                        if (item["Tinh"].ToString() == tinh && item["Xa"].ToString() == xa)
                        {
                            cboDiaChi.SelectedValue = item["MaDiaChi"];
                            break;
                        }
                    }
                }

                if (row.Cells["TenKhoa"].Value != null)
                {
                    string tenKhoa = row.Cells["TenKhoa"].Value.ToString();
                    foreach (DataRowView item in cboKhoa.Items)
                    {
                        if (item["TenKhoa"].ToString() == tenKhoa)
                        {
                            cboKhoa.SelectedValue = item["MaKhoa"];
                            break;
                        }
                    }
                }
            }

        }

        private void btnTimKiem1_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"
                        SELECT sv.MaSV, sv.HoDem, sv.Ten, sv.NgaySinh, sv.GioiTinh,
                               l.TenLop, dt.TenDanToc, dc.Tinh, dc.Xa, sv.GhiChu, k.TenKhoa
                        FROM SinhVien sv
                        LEFT JOIN Lop l ON sv.MaLop = l.MaLop
                        LEFT JOIN DanToc dt ON sv.MaDanToc = dt.MaDanToc
                        LEFT JOIN DiaChi dc ON sv.MaDiaChi = dc.MaDiaChi
                        LEFT JOIN Nganh n ON l.MaNganh = n.MaNganh
                        LEFT JOIN Khoa k ON n.MaKhoa = k.MaKhoa
                        WHERE sv.MaSV = @MaSV OR sv.HoDem LIKE @HoDem OR sv.Ten LIKE @Ten";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaSV", keyword);
                    cmd.Parameters.AddWithValue("@HoDem", "%" + keyword + "%");
                    cmd.Parameters.AddWithValue("@Ten", "%" + keyword + "%");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvSinhVien.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnTimKiem2_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"
                        SELECT sv.MaSV, sv.HoDem, sv.Ten, sv.NgaySinh, sv.GioiTinh,
                               l.TenLop, dt.TenDanToc, dc.Tinh, dc.Xa, sv.GhiChu, k.TenKhoa
                        FROM SinhVien sv
                        LEFT JOIN Lop l ON sv.MaLop = l.MaLop
                        LEFT JOIN DanToc dt ON sv.MaDanToc = dt.MaDanToc
                        LEFT JOIN DiaChi dc ON sv.MaDiaChi = dc.MaDiaChi
                        LEFT JOIN Nganh n ON l.MaNganh = n.MaNganh
                        LEFT JOIN Khoa k ON n.MaKhoa = k.MaKhoa
                        WHERE k.TenKhoa LIKE @TenKhoa";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@TenKhoa", "%" + keyword + "%");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvSinhVien.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }
        private void btn_Excel_Click(object sender, EventArgs e)
        {
            if (dgvSinhVien.Rows.Count > 0)
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                var ws = wb.Worksheets.Add("DanhSachSinhVien");

                        
                                for (int i = 0; i < dgvSinhVien.Columns.Count; i++)
                                {
                                    ws.Cell(1, i + 1).Value = dgvSinhVien.Columns[i].HeaderText;
                                }

                               
                                for (int i = 0; i < dgvSinhVien.Rows.Count; i++)
                                {
                                    for (int j = 0; j < dgvSinhVien.Columns.Count; j++)
                                    {
                                        object value = dgvSinhVien.Rows[i].Cells[j].Value;

                                        
                                        if (dgvSinhVien.Columns[j].Name == "NgaySinh" && value != null && value != DBNull.Value)
                                        {
                                           
                                            if (DateTime.TryParse(value.ToString(), out DateTime d))
                                            {
                                                var cell = ws.Cell(i + 2, j + 1);
                                                cell.Value = d;
                                               
                                                cell.Style.DateFormat.Format = "dd/MM/yyyy";
                                            }
                                            else
                                            {
                                                
                                                ws.Cell(i + 2, j + 1).Value = value?.ToString();
                                            }
                                        }
                                        else
                                        {
                                            ws.Cell(i + 2, j + 1).Value = value?.ToString();
                                        }
                                    }
                                }

                                var range = ws.Range(1, 1, dgvSinhVien.Rows.Count + 1, dgvSinhVien.Columns.Count);
                                range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                                range.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                                ws.Columns().AdjustToContents();

                                wb.SaveAs(sfd.FileName);
                            }

                            MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}