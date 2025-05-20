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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _9406_QuanLyRapChieuPhim_4158
{
    public partial class frmlichChieu : Form
    {
        Ketnoi data = new Ketnoi();
        public frmlichChieu()
        {
            InitializeComponent();
        }
        private void loadData()
        {
            string str = "select * from SUATCHIEU";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvsuatchieu.DataSource = dt;
        }
        private void loadDatagio()
        {
            string str = "select * from KHUNGGIO";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvkhunggio.DataSource = dt;
        }
        private void dgvsuatchieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int i;
            i = dgvsuatchieu.CurrentRow.Index;
            txtMaSC.Text = dgvsuatchieu.Rows[i].Cells[0].Value.ToString();
            cbomaphim.Text = dgvsuatchieu.Rows[i].Cells[1].Value.ToString();
            cbomapc.Text = dgvsuatchieu.Rows[i].Cells[2].Value.ToString();
            cbomagio.Text = dgvsuatchieu.Rows[i].Cells[3].Value.ToString();
            dtpngaychieu.Text = dgvsuatchieu.Rows[i].Cells[4].Value.ToString();
         
        }

        private void frmlichChieu_Load(object sender, EventArgs e)
        {
            loadData();
            loadDatagio();
            dgvsuatchieu.Columns[0].Width = 150;
            dgvsuatchieu.Columns[1].Width = 150;
            dgvsuatchieu.Columns[2].Width = 150;
            dgvsuatchieu.Columns[3].Width = 200;
            dgvsuatchieu.Columns[4].Width = 100;

            dgvsuatchieu.Columns[1].HeaderText = "Mã phim";
            dgvsuatchieu.Columns[2].HeaderText = "Mã phòng chiếu";
            dgvsuatchieu.Columns[3].HeaderText = "Mã giờ";
            dgvsuatchieu.Columns[4].HeaderText = "Ngày chiếu";
            dgvsuatchieu.Columns[0].HeaderText = "Mã suất chiếu";

            dgvkhunggio.Columns[0].Width = 150;
            dgvkhunggio.Columns[1].Width = 200;

            dgvkhunggio.Columns[0].HeaderText = "Mã giờ";
            dgvkhunggio.Columns[1].HeaderText = "Khung giờ";
            LoadComboBox();

        }
        private void LoadComboBox()
        {
            string connectionString = @"Data Source = THANHDUYEN; Initial Catalog = QUANLYRAPCHIEUPHIM; Integrated Security = True"; 
            string query = "SELECT MaPHIM FROM PHIM";
            string query1 = "SELECT MaPC FROM PHONGCHIEU";
            string query2 = "SELECT MaGIO FROM KHUNGGIO";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))

                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())

                        {
                            cbomaphim.Items.Add(reader["MAPHIM"].ToString());
                        }
                    }
                }
                
            }
            using (SqlConnection connection1 = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query1, connection1))

                {
                    connection1.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())

                        {
                            cbomapc.Items.Add(reader["MAPC"].ToString());
                        }
                    }
                }

            }
            using (SqlConnection connection1 = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query2, connection1))

                {
                    connection1.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())

                        {
                            cbomagio.Items.Add(reader["MAGIO"].ToString());
                        }
                    }
                }

            }
        }
            private void dgvkhunggio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvkhunggio.CurrentRow.Index;
            txtmagio.Text = dgvkhunggio.Rows[i].Cells[0].Value.ToString();
            txtkhunggio.Text = dgvkhunggio.Rows[i].Cells[1].Value.ToString();
        }

        private void btnthemgio_Click(object sender, EventArgs e)
        {
            try
            {
               data.ExcuteNonQuery("insert into KHUNGGIO values ('" + txtmagio.Text + "', N'" + txtkhunggio.Text + "')");
                MessageBox.Show("Thêm khung giờ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDatagio();
                txtmagio.Text = "";
                txtkhunggio.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm khung giờ thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnthemsuat_Click(object sender, EventArgs e)
        {
            try
            {
                data.ExcuteNonQuery("insert into SUATCHIEU values ('"+ txtMaSC.Text +"', '" + cbomaphim.Text + "','" + cbomapc.Text + "','" + cbomagio.Text + "', '"+ dtpngaychieu.Text+"')");
                MessageBox.Show("Thêm suất chiếu phim thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
                khoitao();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Thêm suất chiếu phim thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsuagio_Click(object sender, EventArgs e)
        {
            try
            {
                data.ExcuteNonQuery("update KHUNGGIO set khunggio = N'" + txtkhunggio.Text + "' where magio = '" + txtmagio.Text + "'");
                MessageBox.Show("Sửa thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDatagio();
                txtmagio.Text = "";
                txtkhunggio.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa thông tin thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnxoagio_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvkhunggio.CurrentCell.RowIndex;
                string magio = dgvkhunggio.Rows[vitri].Cells[0].Value.ToString();
                data.ExcuteNonQuery("delete from KHUNGGIO where magio = '" + magio + "' ");
                MessageBox.Show("Xóa giờ chiếu phim thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDatagio();
                txtmagio.Text = "";
                txtkhunggio.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa giờ chiếu phim thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnxoasuat_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvsuatchieu.CurrentCell.RowIndex;
                string masc = dgvsuatchieu.Rows[vitri].Cells[0].Value.ToString();
                string maphim = dgvsuatchieu.Rows[vitri].Cells[2].Value.ToString();
                string mapc = dgvsuatchieu.Rows[vitri].Cells[1].Value.ToString();
                string magio = dgvsuatchieu.Rows[vitri].Cells[3].Value.ToString();
                data.ExcuteNonQuery("delete from LICHCHIEU where masuatchieu = '"+ masc+"' and mapc = '" + mapc + "' and maphim = '"+maphim+"' and magio = '"+magio+"'");
                MessageBox.Show("Xóa suất chiếu phim thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
                khoitao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa suất chiếu phim thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsuasuat_Click(object sender, EventArgs e)
        {
            try
            {
                data.ExcuteNonQuery("update SUATCHIEU set mapc = N'" + cbomapc.Text + "', magio =N'" + cbomagio.Text + "', ngaychieu ='" + dtpngaychieu.Text + "' where maphim = '" + cbomaphim.Text + "'");
                MessageBox.Show("Sửa thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
                khoitao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa thông tin thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txttimsuat_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void khoitao()
        {
            txtMaSC.Text = "";
            cbomaphim.Text = "";
            cbomapc.Text = "";
            cbomagio.Text = "";

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btntimsuat_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(data.ExcuteQuery("Select * from SUATCHIEU "));
            dv.RowFilter = string.Format("MaPHIM like '%{0}%'", txttimsuat.Text);
            dgvsuatchieu.DataSource = dv;
        }

        private void cbomagio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbomapc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbomaphim_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
