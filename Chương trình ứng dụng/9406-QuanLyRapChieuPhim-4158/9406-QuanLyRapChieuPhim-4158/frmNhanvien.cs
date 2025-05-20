using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9406_QuanLyRapChieuPhim_4158
{
    public partial class frmNhanvien : Form
    {
        Ketnoi data = new Ketnoi();
        public frmNhanvien()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvNhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btnrapThem_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

      
        private void loadData()
        {
            string str = "select * from NHANVIEN";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvNhanvien.DataSource = dt;
        }
        private void frmNhanvien_Load(object sender, EventArgs e)
        {

            cbogioitinh.Items.Add("Nam");
            cbogioitinh.Items.Add("Nữ");

            loadData();
            dgvNhanvien.Columns[0].Width = 100;
            dgvNhanvien.Columns[1].Width = 150;
            dgvNhanvien.Columns[2].Width = 50;
            dgvNhanvien.Columns[3].Width = 100;
            dgvNhanvien.Columns[4].Width = 100;
            dgvNhanvien.Columns[5].Width = 100;
            dgvNhanvien.Columns[6].Width = 100;
            dgvNhanvien.Columns[7].Width = 200;
            dgvNhanvien.Columns[8].Width = 150;

            dgvNhanvien.Columns[0].HeaderText = "Mã NV";
            dgvNhanvien.Columns[1].HeaderText = "Họ và tên";
            dgvNhanvien.Columns[2].HeaderText = "Giới tính";
            dgvNhanvien.Columns[3].HeaderText = "Ngày sinh";
            dgvNhanvien.Columns[4].HeaderText = "CCCD";
            dgvNhanvien.Columns[5].HeaderText = "Số điện thoại";
            dgvNhanvien.Columns[6].HeaderText = "Email";
            dgvNhanvien.Columns[7].HeaderText = "Địa chỉ";
            dgvNhanvien.Columns[8].HeaderText = "Quản lý";

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
  
        private void dgvNhanvien_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void btnrapThem_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
           
        }
        private void khoitao()
        {
            txtmanv.Text = "";
            txttennv.Text = "";
            cbogioitinh.Text = "";
            dtpngaysinhnv.Value = DateTime.Now;
            txtcccd.Text = "";
            txtsdt.Text = "";
            txtemail.Text = "";
            txtdiachi.Text = "";
            txtmaql.Text = "";
        }

        private void btnback_Click(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvNhanvien_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void panel5_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            DataView dv = new DataView(data.ExcuteQuery("Select * from NHANVIEN "));
            dv.RowFilter = string.Format("TENNV like '%{0}%'", txtTim.Text);
            dgvNhanvien.DataSource = dv;
        }

        private void btnrapThem_Click_2(object sender, EventArgs e)
        {
            try
            {

                string manv = txtmanv.Text;
                string tennv = txttennv.Text;
                string gioitinh = cbogioitinh.Text;
                string ngaysinh = dtpngaysinhnv.Text;
                string cccd = txtcccd.Text;
                string sdt = txtsdt.Text;
                string email = txtemail.Text;
                string diachi = txtdiachi.Text;
                string quanly = txtmaql.Text;

                data.ExcuteNonQuery("insert into NHANVIEN values ('" + manv + "', N'" + tennv + "',N'" + gioitinh + "', '" + ngaysinh + "', '" + cccd + "', '" + sdt + "', '" + email + "', N'" + diachi + "', '" + quanly + "')");
                MessageBox.Show("Thêm nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
                khoitao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm nhân viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            try
            {
                string manv = txtmanv.Text;
                string tennv = txttennv.Text;
                string gioitinh = cbogioitinh.Text;
                string ngaysinh = dtpngaysinhnv.Text;
                string cccd = txtcccd.Text;
                string sdt = txtsdt.Text;
                string email = txtemail.Text;
                string diachi = txtdiachi.Text;
                string quanly = txtmaql.Text;
                data.ExcuteNonQuery("update NHANVIEN set tennv = N'" + tennv + "', gioitinhnv =N'" + gioitinh + "', ngaysinh ='" + ngaysinh + "', cccd= '" + cccd + "', sodienthoainv = '" + sdt + "', emailnv = '" + email + "', diachinv = N'" + diachi + "', maql = '" + quanly + "' where manv = '" + manv + "'");
                MessageBox.Show("Sửa nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
                khoitao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa nhân viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvNhanvien.CurrentCell.RowIndex;
                string manv = dgvNhanvien.Rows[vitri].Cells[0].Value.ToString();
                data.ExcuteNonQuery("delete from NHANVIEN where manv = '" + manv + "' ");
                MessageBox.Show("Xóa nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
                khoitao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa nhân viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnback_Click_1(object sender, EventArgs e)
        {
            loadData();
            txtTim.Text = "";
        }

        private void dgvNhanvien_CellContentClick_3(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvNhanvien.CurrentRow.Index;


            txtmanv.Text = dgvNhanvien.Rows[i].Cells[0].Value.ToString();
            txttennv.Text = dgvNhanvien.Rows[i].Cells[1].Value.ToString();
            cbogioitinh.Text = dgvNhanvien.Rows[i].Cells[2].Value.ToString();
            dtpngaysinhnv.Text = dgvNhanvien.Rows[i].Cells[3].Value.ToString();
            txtcccd.Text = dgvNhanvien.Rows[i].Cells[4].Value.ToString();
            txtsdt.Text = dgvNhanvien.Rows[i].Cells[5].Value.ToString();
            txtemail.Text = dgvNhanvien.Rows[i].Cells[6].Value.ToString();
            txtdiachi.Text = dgvNhanvien.Rows[i].Cells[7].Value.ToString();
            txtmaql.Text = dgvNhanvien.Rows[i].Cells[8].Value.ToString();
        }
    }
}
