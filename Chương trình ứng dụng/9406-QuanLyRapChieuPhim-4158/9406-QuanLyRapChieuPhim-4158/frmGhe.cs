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
    public partial class frmGhe : Form
    {
        Ketnoi data = new Ketnoi();
        public frmGhe()
        {
            InitializeComponent();
        }
        private void loadData()
        {
            string str = "select * from GHE";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvGhe.DataSource = dt;
        }
        private void dgvGhe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void frmGhe_Load(object sender, EventArgs e)
        {
            loadData();

            cboghe.Items.Add("Đơn");
            cboghe.Items.Add("Đôi");

            cbotrangthai.Items.Add("Đã bán");
            cbotrangthai.Items.Add("Chưa bán");

            dgvGhe.Columns[0].Width = 150;
            dgvGhe.Columns[1].Width = 200;
            dgvGhe.Columns[2].Width = 150;
            dgvGhe.Columns[3].Width = 150;
            dgvGhe.Columns[4].Width = 200;

            dgvGhe.Columns[0].HeaderText = "Mã ghế";
            dgvGhe.Columns[1].HeaderText = "Tên ghế";
            dgvGhe.Columns[2].HeaderText = "Loại ghế";
            dgvGhe.Columns[3].HeaderText = "Trạng thái";
            dgvGhe.Columns[4].HeaderText = "Mã phòng chiếu";
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
            txtmag.Text = "";
            txtteng.Text = "";
            cboghe.Text = "";
            cbotrangthai.Text = "";
            txtmapc.Text = "";

        }

        private void btnback_Click(object sender, EventArgs e)
        {
           
        }

        private void dgvGhe_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvGhe.CurrentRow.Index;
            txtmag.Text = dgvGhe.Rows[i].Cells[0].Value.ToString();
            txtteng.Text = dgvGhe.Rows[i].Cells[1].Value.ToString();
            cboghe.Text = dgvGhe.Rows[i].Cells[2].Value.ToString();
            cbotrangthai.Text = dgvGhe.Rows[i].Cells[3].Value.ToString();
            txtmapc.Text = dgvGhe.Rows[i].Cells[4].Value.ToString();
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {

            try
            {
                string mag = txtmag.Text;
                string teng = txtteng.Text;
                string loaighe = cboghe.Text;
                string trangthai = cbotrangthai.Text;
                string mapc = txtmapc.Text;

                data.ExcuteNonQuery("update GHE set tenGHE = N'" + teng + "', LOAIGHE =N'" + loaighe + "', trangthai = '" + trangthai + "', mapc = '" + mapc + "' where maghe = '" + mag + "'");
                MessageBox.Show("Sửa thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
                khoitao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa thông tin thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvGhe.CurrentCell.RowIndex;
                string maghe = dgvGhe.Rows[vitri].Cells[0].Value.ToString();
                data.ExcuteNonQuery("delete from GHE where maghe = '" + maghe + "' ");
                MessageBox.Show("Xóa ghế thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
                khoitao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa ghế thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnback_Click_1(object sender, EventArgs e)
        {
            loadData();
            txtTim.Text = "";
        }

        private void btnTim_Click_1(object sender, EventArgs e)
        {
            DataView dv = new DataView(data.ExcuteQuery("Select * from GHE "));
            dv.RowFilter = string.Format("TENGHE like '%{0}%'", txtTim.Text);
            dgvGhe.DataSource = dv;
        }
    }
}
