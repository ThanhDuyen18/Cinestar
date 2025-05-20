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
    public partial class frmdangNhap : Form
    {
        string connectString = @"Data Source = THANHDUYEN; Initial Catalog = QUANLYRAPCHIEUPHIM; Integrated Security = True";
        public frmdangNhap()
        {
            InitializeComponent();
        }

        private void frmdangNhap_Load(object sender, EventArgs e)
        {
            cbochucVu.Items.Add("Quản lý");
            cbochucVu.Items.Add("Nhân viên");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDangky dangky = new frmDangky();
            dangky.Show();
            this.Hide();
        }

        private void btnnutDangnhap_Click(object sender, EventArgs e)
        {
            if (txttenDangNhap.Text == "" || txtmatKhau.Text == "" || cbochucVu.Text == "")
            {
                MessageBox.Show("Thông tin đăng nhập còn thiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string selectData = "SELECT * from USERS where username = @tendk and password = @pass";

                    using (SqlCommand cmd = new SqlCommand(selectData, conn))
                    {
                        cmd.Parameters.AddWithValue("@tendk", txttenDangNhap.Text.Trim());
                        cmd.Parameters.AddWithValue("@pass", txtmatKhau.Text.Trim());
                        cmd.Parameters.AddWithValue("@role", cbochucVu.Text.Trim());

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();

                        adapter.Fill(dt);
                        
                        if(dt.Rows.Count > 0 && cbochucVu.Text == "Quản lý")
                        {
                           
                            frmtrangChu trangchu = new frmtrangChu();
                            trangchu.Show();
                            this.Hide();
                        }
                        else if (dt.Rows.Count > 0 && cbochucVu.Text == "Nhân viên")
                        {
                            frmtrangchuNV trangchu1 = new frmtrangchuNV();
                            trangchu1.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error );
                        }
                    }
                }
            }
        }

        private void btnnutThoat_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn thoát chương trình?",
     "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
