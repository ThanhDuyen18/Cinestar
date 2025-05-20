using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _9406_QuanLyRapChieuPhim_4158
{
    public partial class frmDangky : Form
    {
        string connectString = @"Data Source = THANHDUYEN; Initial Catalog = QUANLYRAPCHIEUPHIM; Integrated Security = True";
        public frmDangky()
        {
            InitializeComponent();
        }

        private void frmDangky_Load(object sender, EventArgs e)
        {

        }

        private void btnnutDangnhap_Click(object sender, EventArgs e)
        {
            
        }

        private void btnquenMatKhau_Click(object sender, EventArgs e)
        {
            frmdangNhap dangnhap = new frmdangNhap();
            dangnhap.Show();
            this.Hide();
        }

        private void btnnutThoat_Click(object sender, EventArgs e)
        {
            frmdangNhap dangnhap = new frmdangNhap();
            dangnhap.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
