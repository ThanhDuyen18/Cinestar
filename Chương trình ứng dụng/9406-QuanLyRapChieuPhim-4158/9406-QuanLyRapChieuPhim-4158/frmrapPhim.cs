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
    public partial class frmrapPhim : Form
    {
        Ketnoi data = new Ketnoi();
        public frmrapPhim()
        {
            InitializeComponent();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void frmrapPhim_Load(object sender, EventArgs e)
        {
            loadData();
            dgvPhongchieu.Columns[0].Width = 150;
            dgvPhongchieu.Columns[1].Width = 200;
            dgvPhongchieu.Columns[2].Width = 200;
            dgvPhongchieu.Columns[3].Width = 100;


            dgvPhongchieu.Columns[0].HeaderText = "Mã phòng chiếu";
            dgvPhongchieu.Columns[1].HeaderText = "Tên phòng";
            dgvPhongchieu.Columns[2].HeaderText = "Số lượng ghế";
            dgvPhongchieu.Columns[3].HeaderText = "Số lượng còn lại";
           
        }
        private void loadData()
        {
            string str = "select * from PHONGCHIEU";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvPhongchieu.DataSource = dt;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
         
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvPhongchieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvPhongchieu_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnrapThem_Click(object sender, EventArgs e)
        {
            
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
           
        }
        private void khoitao()
        {
            txtmapc.Text = "";
            txttenpc.Text = "";
            txtslg.Text = "";
            txtslton.Text = "";
          
        }

        private void btnback_Click(object sender, EventArgs e)
        {
          
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvPhongchieu_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvPhongchieu.CurrentRow.Index;


            txtmapc.Text = dgvPhongchieu.Rows[i].Cells[0].Value.ToString();
            txttenpc.Text = dgvPhongchieu.Rows[i].Cells[1].Value.ToString();
            txtslg.Text = dgvPhongchieu.Rows[i].Cells[2].Value.ToString();
            txtslton.Text = dgvPhongchieu.Rows[i].Cells[3].Value.ToString();
        }

        private void btnTim_Click_1(object sender, EventArgs e)
        {
            DataView dv = new DataView(data.ExcuteQuery("Select * from PHONGCHIEU "));
            dv.RowFilter = string.Format("TENPC like '%{0}%'", txttim.Text);
            dgvPhongchieu.DataSource = dv;
        }

        private void btnrapThem_Click_1(object sender, EventArgs e)
        {
            try
            {


                data.ExcuteNonQuery("insert into PHONGCHIEU values ('" + txtmapc.Text + "', N'" + txttenpc.Text + "',N'" + txtslg + "', '" + txtslton + "')");
                MessageBox.Show("Thêm phòng chiếu phim thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
                khoitao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm phòng chiếu phim thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsua_Click_1(object sender, EventArgs e)
        {
            try
            {

                data.ExcuteNonQuery("update PHONGCHIEU set tenpc = N'" + txttenpc.Text + "', SLGHE =N'" + txtslg.Text + "', SLTON ='" + txtslton.Text + "' where mapc = '" + txtmapc.Text + "'");
                MessageBox.Show("Sửa thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
                khoitao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa thông tin thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnxoa_Click_1(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvPhongchieu.CurrentCell.RowIndex;
                string mapc = dgvPhongchieu.Rows[vitri].Cells[0].Value.ToString();
                data.ExcuteNonQuery("delete from PHONGCHIEU where mapc = '" + mapc + "' ");
                MessageBox.Show("Xóa phòng chiếu phim thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
                khoitao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa phòng chiếu phim thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnback_Click_1(object sender, EventArgs e)
        {
            loadData();
            txttim.Text = "";
        }
    }
}
