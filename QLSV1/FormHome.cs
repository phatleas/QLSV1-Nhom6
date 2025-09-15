using System;
using System.Windows.Forms;
using QLSV1;

namespace QLSV1
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void menuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in this.MdiChildren) childForm.Close();

            if (sender is ToolStripMenuItem menuItem)
            {
                Form frm = null;

                switch (menuItem.Name)
                {
                    case "menuSinhVien":
                        frm = new FormSinhVien();
                        break;

                    case "menuBangDiem":
                        frm = new FormDiem();
                        break;

                    case "menuMonHoc":
                        frm = new FormMonHoc();
                        break;

                    default:
                        return;
                }

                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                frm.BringToFront();
            }
        }

        private void FormHome_Load(object sender, EventArgs e)
        {

        }
    }
}