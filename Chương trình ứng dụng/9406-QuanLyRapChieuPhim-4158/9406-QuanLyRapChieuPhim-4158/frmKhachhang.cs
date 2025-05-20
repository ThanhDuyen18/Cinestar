using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9406_QuanLyRapChieuPhim_4158
{
    
    public partial class frmKhachhang : Form
    {
        Ketnoi data = new Ketnoi();
        public frmKhachhang()
        {
            InitializeComponent();
        }
        private void loadData()
        {
            string str = "select * from KHACHHANG";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvKhachhang1.DataSource = dt;
        }
        private void frmKhachhang_Load(object sender, EventArgs e)
        {
            loadData();

      

            dgvKhachhang1.Columns[0].Width = 150;
            dgvKhachhang1.Columns[1].Width = 200;
            dgvKhachhang1.Columns[2].Width = 100;

            dgvKhachhang1.Columns[0].HeaderText = "Mã KH";
            dgvKhachhang1.Columns[1].HeaderText = "Họ và tên";
            dgvKhachhang1.Columns[2].HeaderText = "Số điện thoại";
     
        }

        private void dgvKhachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void btnrapThem_Click(object sender, EventArgs e)
        {
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
           
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
           
        }
        private void khoitao()
        {
            txtmakh.Text = "";
            txttenkh.Text = "";
            txtsdt.Text = "";

        
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvKhachhang_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTim_Click_1(object sender, EventArgs e)
        {
            DataView dv = new DataView(data.ExcuteQuery("Select TENKH AS [Họ và Tên] from KHACHHANG "));
            dv.RowFilter = string.Format("[Họ và tên] like '%{0}%'", txtTim.Text);
            dgvKhachhang1.DataSource = dv;
        }

        private void btnrapThem_Click_1(object sender, EventArgs e)
        {
            try
            {

                string makh = txtmakh.Text;
                string tenkh = txttenkh.Text;
                string sdt = txtsdt.Text;


                data.ExcuteNonQuery("insert into KHACHHANG values ('" + makh + "', N'" + tenkh + "', '" + sdt + "')");
                MessageBox.Show("Thêm khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
                khoitao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm khách hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvKhachhang1.CurrentCell.RowIndex;
                string makh = dgvKhachhang1.Rows[vitri].Cells[0].Value.ToString();
                data.ExcuteNonQuery("delete from KHACHHANG where makh = '" + makh + "' ");
                MessageBox.Show("Xóa khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
                khoitao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa khách hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            try
            {
                string makh = txtmakh.Text;
                string tenkh = txttenkh.Text;
                string sdt = txtsdt.Text;

                data.ExcuteNonQuery("update KHACHHANG set tenKH = N'" + tenkh + "', sodienthoaikh = '" + sdt + "' where makh = '" + makh + "'");
                MessageBox.Show("Sửa khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
                khoitao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa khách hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnback_Click_1(object sender, EventArgs e)
        {
            loadData();
            txtTim.Text = "";
        }

        private void dgvKhachhang1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvKhachhang1.CurrentRow.Index;
            txtmakh.Text = dgvKhachhang1.Rows[i].Cells[0].Value.ToString();
            txttenkh.Text = dgvKhachhang1.Rows[i].Cells[1].Value.ToString();
            txtsdt.Text = dgvKhachhang1.Rows[i].Cells[2].Value.ToString();

        }
    }
}
