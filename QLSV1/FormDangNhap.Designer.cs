using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Drawing;
using System.Windows.Forms;

namespace QLSV1
{
    partial class FormDangNhap
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTaiKhoan;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.LinkLabel linkDangKy;

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
            lblTaiKhoan = new Label();
            lblMatKhau = new Label();
            txtTaiKhoan = new TextBox();
            txtMatKhau = new TextBox();
            btnDangNhap = new Button();
            btnThoat = new Button();
            linkDangKy = new LinkLabel();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblTaiKhoan
            // 
            lblTaiKhoan.AutoSize = true;
            lblTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTaiKhoan.Location = new Point(400, 247);
            lblTaiKhoan.Name = "lblTaiKhoan";
            lblTaiKhoan.Size = new Size(120, 32);
            lblTaiKhoan.TabIndex = 0;
            lblTaiKhoan.Text = "Tài khoản:";
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Font = new System.Drawing.Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMatKhau.Location = new Point(401, 346);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(106, 30);
            lblMatKhau.TabIndex = 1;
            lblMatKhau.Text = "Mật khẩu:";
            // 
            // txtTaiKhoan
            // 
            txtTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTaiKhoan.Location = new Point(539, 239);
            txtTaiKhoan.Name = "txtTaiKhoan";
            txtTaiKhoan.Size = new Size(220, 39);
            txtTaiKhoan.TabIndex = 2;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = new System.Drawing.Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMatKhau.Location = new Point(539, 338);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.Size = new Size(220, 39);
            txtMatKhau.TabIndex = 3;
            // 
            // btnDangNhap
            // 
            btnDangNhap.Location = new Point(350, 444);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(212, 65);
            btnDangNhap.TabIndex = 4;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(658, 444);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(153, 65);
            btnThoat.TabIndex = 5;
            btnThoat.Text = "Thoát";
            btnThoat.Click += btnThoat_Click;
            // 
            // linkDangKy
            // 
            linkDangKy.AutoSize = true;
            linkDangKy.Location = new Point(429, 569);
            linkDangKy.Name = "linkDangKy";
            linkDangKy.Size = new Size(89, 25);
            linkDangKy.TabIndex = 6;
            linkDangKy.TabStop = true;
            linkDangKy.Text = "Đăng ký?";
            linkDangKy.Click += linkDangKy_LinkClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(411, 80);
            label1.Name = "label1";
            label1.Size = new Size(336, 50);
            label1.TabIndex = 7;
            label1.Text = "Quản Lý Sinh Viên";
            label1.Click += label1_Click;
            // 
            // FormDangNhap
            // 
            ClientSize = new Size(1205, 759);
            Controls.Add(label1);
            Controls.Add(lblTaiKhoan);
            Controls.Add(lblMatKhau);
            Controls.Add(txtTaiKhoan);
            Controls.Add(txtMatKhau);
            Controls.Add(btnDangNhap);
            Controls.Add(btnThoat);
            Controls.Add(linkDangKy);
            Font = new System.Drawing.Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "FormDangNhap";
            Text = "Đăng nhập";
            ResumeLayout(false);
            PerformLayout();
        }
        private Label label1;
    }
}