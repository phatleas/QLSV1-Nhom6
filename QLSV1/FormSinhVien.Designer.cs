using System.Drawing;
using System.Windows.Forms;

namespace QLSV1
{
    partial class FormSinhVien
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView dgvSinhVien;
        private TextBox txtMaSV, txtHoDem, txtTen,
                        txtGhiChu, txtTimKiem;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private ComboBox cboDiaChi, cboKhoa, cboDanToc, cboLop, cboGioiTinh;

        private Button Luubtn, btnXoa, btnHienThi,
                       btnTimKiem1, btnTimKiem2, btn_Excel, btnThem;

        private Label lblMaSV, lblHoDem, lblTen, lblNgaySinh, lblGioiTinh,
                      lblLop, lblDiaChi, lblGhiChu, lblTimKiem, lblKhoa, lblDanToc;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvSinhVien = new System.Windows.Forms.DataGridView();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.txtHoDem = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.cboDiaChi = new System.Windows.Forms.ComboBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.cboDanToc = new System.Windows.Forms.ComboBox();
            this.Luubtn = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnHienThi = new System.Windows.Forms.Button();
            this.btnTimKiem1 = new System.Windows.Forms.Button();
            this.btnTimKiem2 = new System.Windows.Forms.Button();
            this.lblMaSV = new System.Windows.Forms.Label();
            this.lblHoDem = new System.Windows.Forms.Label();
            this.lblTen = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.lblLop = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.lblDanToc = new System.Windows.Forms.Label();
            this.btn_Excel = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSinhVien
            // 
            this.dgvSinhVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSinhVien.ColumnHeadersHeight = 40;
            this.dgvSinhVien.Location = new System.Drawing.Point(26, 335);
            this.dgvSinhVien.Name = "dgvSinhVien";
            this.dgvSinhVien.ReadOnly = true;
            this.dgvSinhVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSinhVien.Size = new System.Drawing.Size(1773, 436);
            this.dgvSinhVien.TabIndex = 0;
            // 
            // txtMaSV
            // 
            this.txtMaSV.BackColor = System.Drawing.SystemColors.Control;
            this.txtMaSV.Location = new System.Drawing.Point(160, 15);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.ReadOnly = true;
            this.txtMaSV.Size = new System.Drawing.Size(200, 29);
            this.txtMaSV.TabIndex = 12;
            // 
            // txtHoDem
            // 
            this.txtHoDem.Location = new System.Drawing.Point(160, 60);
            this.txtHoDem.Name = "txtHoDem";
            this.txtHoDem.Size = new System.Drawing.Size(200, 29);
            this.txtHoDem.TabIndex = 13;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(160, 105);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(200, 29);
            this.txtTen.TabIndex = 14;
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Location = new System.Drawing.Point(520, 118);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(289, 29);
            this.dtpNgaySinh.TabIndex = 15;
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGioiTinh.Location = new System.Drawing.Point(160, 171);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(200, 30);
            this.cboGioiTinh.TabIndex = 16;
            // 
            // cboLop
            // 
            this.cboLop.Location = new System.Drawing.Point(160, 223);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(200, 30);
            this.cboLop.TabIndex = 17;
            // 
            // cboDiaChi
            // 
            this.cboDiaChi.Location = new System.Drawing.Point(520, 60);
            this.cboDiaChi.Name = "cboDiaChi";
            this.cboDiaChi.Size = new System.Drawing.Size(200, 30);
            this.cboDiaChi.TabIndex = 18;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(160, 279);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(200, 29);
            this.txtGhiChu.TabIndex = 19;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(520, 177);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(200, 29);
            this.txtTimKiem.TabIndex = 20;
            // 
            // cboKhoa
            // 
            this.cboKhoa.Location = new System.Drawing.Point(520, 240);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Size = new System.Drawing.Size(200, 30);
            this.cboKhoa.TabIndex = 21;
            // 
            // cboDanToc
            // 
            this.cboDanToc.Location = new System.Drawing.Point(520, 15);
            this.cboDanToc.Name = "cboDanToc";
            this.cboDanToc.Size = new System.Drawing.Size(200, 30);
            this.cboDanToc.TabIndex = 22;
            // 
            // Luubtn
            // 
            this.Luubtn.Location = new System.Drawing.Point(234, 817);
            this.Luubtn.Name = "Luubtn";
            this.Luubtn.Size = new System.Drawing.Size(100, 50);
            this.Luubtn.TabIndex = 23;
            this.Luubtn.Text = "Lưu";
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(369, 817);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 50);
            this.btnXoa.TabIndex = 24;
            this.btnXoa.Text = "Xóa";
            // 
            // btnHienThi
            // 
            this.btnHienThi.Location = new System.Drawing.Point(520, 817);
            this.btnHienThi.Name = "btnHienThi";
            this.btnHienThi.Size = new System.Drawing.Size(100, 50);
            this.btnHienThi.TabIndex = 25;
            this.btnHienThi.Text = "Hiển thị";
            // 
            // btnTimKiem1
            // 
            this.btnTimKiem1.Location = new System.Drawing.Point(757, 174);
            this.btnTimKiem1.Name = "btnTimKiem1";
            this.btnTimKiem1.Size = new System.Drawing.Size(199, 35);
            this.btnTimKiem1.TabIndex = 26;
            this.btnTimKiem1.Text = "Tìm theo Tên/Mã";
            // 
            // btnTimKiem2
            // 
            this.btnTimKiem2.Location = new System.Drawing.Point(740, 240);
            this.btnTimKiem2.Name = "btnTimKiem2";
            this.btnTimKiem2.Size = new System.Drawing.Size(160, 35);
            this.btnTimKiem2.TabIndex = 27;
            this.btnTimKiem2.Text = "Tìm theo Khoa";
            // 
            // lblMaSV
            // 
            this.lblMaSV.Location = new System.Drawing.Point(60, 15);
            this.lblMaSV.Name = "lblMaSV";
            this.lblMaSV.Size = new System.Drawing.Size(100, 23);
            this.lblMaSV.TabIndex = 1;
            this.lblMaSV.Text = "Mã SV:";
            // 
            // lblHoDem
            // 
            this.lblHoDem.Location = new System.Drawing.Point(60, 60);
            this.lblHoDem.Name = "lblHoDem";
            this.lblHoDem.Size = new System.Drawing.Size(100, 23);
            this.lblHoDem.TabIndex = 2;
            this.lblHoDem.Text = "Họ đệm:";
            // 
            // lblTen
            // 
            this.lblTen.Location = new System.Drawing.Point(60, 105);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(100, 23);
            this.lblTen.TabIndex = 3;
            this.lblTen.Text = "Tên:";
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.Location = new System.Drawing.Point(396, 108);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(100, 23);
            this.lblNgaySinh.TabIndex = 4;
            this.lblNgaySinh.Text = "Ngày sinh:";
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.Location = new System.Drawing.Point(40, 171);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(100, 23);
            this.lblGioiTinh.TabIndex = 5;
            this.lblGioiTinh.Text = "Giới tính:";
            // 
            // lblLop
            // 
            this.lblLop.Location = new System.Drawing.Point(60, 223);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(100, 23);
            this.lblLop.TabIndex = 6;
            this.lblLop.Text = "Lớp:";
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.Location = new System.Drawing.Point(420, 60);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(100, 23);
            this.lblDiaChi.TabIndex = 7;
            this.lblDiaChi.Text = "Địa chỉ:";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Location = new System.Drawing.Point(54, 279);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(100, 23);
            this.lblGhiChu.TabIndex = 8;
            this.lblGhiChu.Text = "Ghi chú:";
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.Location = new System.Drawing.Point(396, 177);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(100, 23);
            this.lblTimKiem.TabIndex = 9;
            this.lblTimKiem.Text = "Tìm kiếm:";
            // 
            // lblKhoa
            // 
            this.lblKhoa.Location = new System.Drawing.Point(420, 240);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.Size(100, 23);
            this.lblKhoa.TabIndex = 10;
            this.lblKhoa.Text = "Khoa:";
            // 
            // lblDanToc
            // 
            this.lblDanToc.Location = new System.Drawing.Point(420, 15);
            this.lblDanToc.Name = "lblDanToc";
            this.lblDanToc.Size = new System.Drawing.Size(100, 23);
            this.lblDanToc.TabIndex = 11;
            this.lblDanToc.Text = "Dân tộc:";
            // 
            // btn_Excel
            // 
            this.btn_Excel.Location = new System.Drawing.Point(663, 817);
            this.btn_Excel.Name = "btn_Excel";
            this.btn_Excel.Size = new System.Drawing.Size(107, 50);
            this.btn_Excel.TabIndex = 32;
            this.btn_Excel.Text = "Xuất Excel";
            this.btn_Excel.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnThem.Location = new System.Drawing.Point(58, 817);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(120, 50);
            this.btnThem.TabIndex = 33;
            this.btnThem.Text = "Thêm Mới";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // FormSinhVien
            // 
            this.ClientSize = new System.Drawing.Size(1599, 939);
            this.Controls.Add(this.btn_Excel);
            this.Controls.Add(this.dgvSinhVien);
            this.Controls.Add(this.lblMaSV);
            this.Controls.Add(this.lblHoDem);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.lblNgaySinh);
            this.Controls.Add(this.lblGioiTinh);
            this.Controls.Add(this.lblLop);
            this.Controls.Add(this.lblDiaChi);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.lblTimKiem);
            this.Controls.Add(this.lblKhoa);
            this.Controls.Add(this.lblDanToc);
            this.Controls.Add(this.txtMaSV);
            this.Controls.Add(this.txtHoDem);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.dtpNgaySinh);
            this.Controls.Add(this.cboGioiTinh);
            this.Controls.Add(this.cboLop);
            this.Controls.Add(this.cboDiaChi);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.cboKhoa);
            this.Controls.Add(this.cboDanToc);
            this.Controls.Add(this.Luubtn);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnHienThi);
            this.Controls.Add(this.btnTimKiem1);
            this.Controls.Add(this.btnTimKiem2);
            this.Controls.Add(this.btnThem);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.Name = "FormSinhVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Sinh viên";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}