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
    public partial class frmtrangChu : Form
    {
        public frmtrangChu()
        {
            InitializeComponent();

            
        }

        private void frmtrangChu_Load(object sender, EventArgs e)
        {

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
            pnlchucNang.Controls.Add(frmCon);
            pnlchucNang.Tag = frmCon;
            frmCon.BringToFront();
            frmCon.Show();

        }

        private void btnrapPhim_Click(object sender, EventArgs e)
        {
            moFormCon(new frmrapPhim());
        }

        private void btnlichChieu_Click(object sender, EventArgs e)
        {
            moFormCon(new frmlichChieu());
        }

        private void btnkhungThoiGian_Click(object sender, EventArgs e)
        {
            
        }

        private void btntrangChu_Click(object sender, EventArgs e)
        {
            
        }

        private void pnlchucNang_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void btnnhanVien_Click(object sender, EventArgs e)
        {
            moFormCon(new frmNhanvien());
        }

        private void btnkhachHang_Click(object sender, EventArgs e)
        {
          
        }

        private void btnvePhim_Click(object sender, EventArgs e)
        {
            moFormCon(new frmVephim());
        }

        private void btnphimChieu_Click(object sender, EventArgs e)
        {
            moFormCon(new frmPhimchieu());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn thoát chương trình?",
     "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.OK)
            {
                
                frmdangNhap dangnhap = new frmdangNhap();
                dangnhap.ShowDialog();
                this.Close();
            }
        }

        private void pnlchucNang_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            moFormCon(new frmGhe());

        }
    }
}
