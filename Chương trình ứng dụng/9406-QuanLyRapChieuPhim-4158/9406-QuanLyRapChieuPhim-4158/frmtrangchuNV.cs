using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9406_QuanLyRapChieuPhim_4158
{
    public partial class frmtrangchuNV : Form
    {
        public frmtrangchuNV()
        {
            InitializeComponent();
        }
        private Form hienTai = null;
        private void moFormCon(Form frmCon)
        {
            if (hienTai != null)
                hienTai.Close();
            hienTai = frmCon;
            frmCon.TopLevel = false;
            frmCon.FormBorderStyle = FormBorderStyle.None;
            frmCon.Dock = DockStyle.Fill;
            pnlmainNV.Controls.Add(frmCon);
            pnlmainNV.Tag = frmCon;
            frmCon.BringToFront();
            frmCon.Show();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn thoát chương trình?",
     "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.OK)
                this.Close();
        }

        private void btntrangChu_Click(object sender, EventArgs e)
        {
            moFormCon(new frmtrangChu());
        }

        private void btnvePhim_Click(object sender, EventArgs e)
        {
            moFormCon(new frmVephim());
        }

        private void btnphimChieu_Click(object sender, EventArgs e)
        {
            
        }

        private void btnkhachHang_Click(object sender, EventArgs e)
        {
            moFormCon(new frmKhachhang());
        }

        private void pnlmainNV_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
