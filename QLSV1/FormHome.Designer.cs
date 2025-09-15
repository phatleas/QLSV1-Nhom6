using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Drawing;
using System.Windows.Forms;

namespace QLSV1
{
    partial class FormHome
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuSinhVien;
        private System.Windows.Forms.ToolStripMenuItem menuBangDiem;
        private System.Windows.Forms.ToolStripMenuItem menuMonHoc;

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
            menuStrip1 = new MenuStrip();
            menuSinhVien = new ToolStripMenuItem();
            menuBangDiem = new ToolStripMenuItem();
            menuMonHoc = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuSinhVien, menuBangDiem, menuMonHoc });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1303, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuSinhVien
            // 
            menuSinhVien.Name = "menuSinhVien";
            menuSinhVien.Size = new Size(124, 20);
            menuSinhVien.Text = "Danh sách sinh viên";
            menuSinhVien.Click += menuItem_Click;
            // 
            // menuBangDiem
            // 
            menuBangDiem.Name = "menuBangDiem";
            menuBangDiem.Size = new Size(76, 20);
            menuBangDiem.Text = "Bảng điểm";
            menuBangDiem.Click += menuItem_Click;
            // 
            // menuMonHoc
            // 
            menuMonHoc.Name = "menuMonHoc";
            menuMonHoc.Size = new Size(67, 20);
            menuMonHoc.Text = "Môn học";
            menuMonHoc.Click += menuItem_Click;
            // 
            // FormHome
            // 
            ClientSize = new Size(1303, 715);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "FormHome";
            Text = "Trang chủ";
            Load += FormHome_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}