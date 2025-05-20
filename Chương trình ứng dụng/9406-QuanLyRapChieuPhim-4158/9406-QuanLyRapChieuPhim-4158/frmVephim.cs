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
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace _9406_QuanLyRapChieuPhim_4158
{

    public partial class frmVephim : Form
    {
        private SqlConnection connection; 
        private SqlDataAdapter adapter;
        private DataSet ds;
        string connectionString = @"Data Source = THANHDUYEN; Initial Catalog = QUANLYRAPCHIEUPHIM; Integrated Security = True";

        Ketnoi data = new Ketnoi();
        public frmVephim()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
        }
     

        private void loadData()
        {
            string str = "select SC.MASUATCHIEU, P.TENPHIM,SC.MAPC, SC.NGAYCHIEU, KHUNGGIO.KHUNGGIO from suatchieu SC join phim P on SC.MAPHIM = P.maphim join KHUNGGIO on SC.MAGIO = khunggio.magio";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvphimchieu.DataSource = dt;
        }

        private void loadData1()
        {
            string str = "select * from GHE join PHONGCHIEU ON ghe.MAPC = PHONGCHIEU.MaPC where ghe.MAPC = '"+txtmapc.Text+"' and ghe.TRANGTHAI = N'Chưa bán'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvghe.DataSource = dt;
        }
        private void frmVephim_Load(object sender, EventArgs e)
        {
            loadData();
            loadcombobox();
            cbothanhtoan.Items.Add(@"Đã thanh toán");

        }
        
        
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dgvphimchieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
           
        }

        string maphim;
        private void button3_Click(object sender, EventArgs e)
        {
            loadData1();


        }

       
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {



           

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void dgvphimchieu_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvphimchieu.CurrentRow.Index;

            txtMasc.Text = dgvphimchieu.Rows[i].Cells[0].Value.ToString();
            txttenphim.Text = dgvphimchieu.Rows[i].Cells[1].Value.ToString();
            txtgio.Text = dgvphimchieu.Rows[i].Cells[4].Value.ToString();
            txtmapc.Text = dgvphimchieu.Rows[i].Cells[2].Value.ToString();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         

        }
        private void LoadComboBox()
        {
            
        }
       

        public string ThemHoaDon()
        {
            try
            {
                data.ExcuteNonQuery("INSERT INTO HOADON (MAKH, NGAYLAPHD, THANHTIEN, MANV, SOLUONG, MASUATCHIEU) " +
                "VALUES ('" + txtmakh.Text + "', '" + dtpngaychieu.Text + "', '" + txtthanhtien.Text + "', '" + cbonhanvien.Text + "', '" + txtsoluong.Text + "', '" + txtMasc.Text.Trim() + "')");
                MessageBox.Show("Thêm hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
                return LayMaHDVuaThem(txtmakh.Text, dtpngaychieu.Text); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm hóa đơn thất bại\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private string LayMaHDVuaThem(string maKH, string ngayLapHD)
        {
            string maHD = null;
            string queryLayMa = $"SELECT TOP 1 MAHD FROM HOADON WHERE MAKH = '{maKH}' AND NGAYLAPHD = '{ngayLapHD}' ORDER BY MAHD DESC"; 
            maHD = data.ExcuteScalar(queryLayMa)?.ToString();
            return maHD;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (cbothanhtoan.Text == "Đã thanh toán")
            {
                string maHoaDon = ThemHoaDon();

                if (!string.IsNullOrEmpty(maHoaDon))
                {
                    bool veDaThem = false;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow && row.Cells[0].Value != null && row.Cells[3].Value != null)
                        {
                            string maGhe = row.Cells[0].Value.ToString();
                            string GIA = row.Cells[3].Value.ToString();

                            string queryVe = string.Format("INSERT INTO VE (MaHD, MaGHE, GIAGHE) VALUES ('{0}', '{1}', '{2}')", maHoaDon, maGhe, GIA);
                    

                            try
                            {
                                data.ExcuteNonQuery(queryVe);
                            
                                veDaThem = true;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi thêm vé cho ghế " + maGhe + "!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else if (!row.IsNewRow)
                        {
                            MessageBox.Show("Lỗi: Mã ghế hoặc giá vé bị thiếu ở một số hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    if (veDaThem)
                    {
                        MessageBox.Show("Mua vé thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HienThiThongTinVe(maHoaDon);
                    }
                    else
                    {
                        MessageBox.Show("Không có vé nào được chọn để mua!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi khi lấy mã hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vé chưa được thanh toán!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

 
        private void HienThiThongTinVe(string maHoaDon)
        {
         
            string queryThongTinVe = string.Format("SELECT MaGHE, GIAGHE FROM VE WHERE MaHD = '{0}'", maHoaDon);
            System.Data.DataTable dtVe = data.ExcuteQuery(queryThongTinVe);

            if (dtVe.Rows.Count > 0)
            {
                string thongTin = "--- Thông tin vé ---\n";
                thongTin += "Mã hóa đơn: " + maHoaDon + "\n";
                foreach (System.Data.DataRow row in dtVe.Rows)
                {
                    thongTin += "Mã ghế: " + row["MaGHE"].ToString() + ", Giá: " + row["GIAGHE"].ToString() + "\n";
                }
                MessageBox.Show(thongTin, "Thông tin vé", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin vé cho hóa đơn " + maHoaDon, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

      
        }
        private void btnrapThem_Click(object sender, EventArgs e)
        {
            if (dgvghe.CurrentRow != null)
            {
                int rowIndex = dgvghe.CurrentRow.Index;

            
                List<string> selectedColumns = new List<string> { "MAGHE" , "TENGHE", "TENPC", "GIA", "TRANGTHAI" };

          
                if (dataGridView1.Columns.Count == 0)
                {
                    foreach (string columnName in selectedColumns)
                    {
                        if (dgvghe.Columns.Contains(columnName))
                        {
                            dataGridView1.Columns.Add((DataGridViewColumn)dgvghe.Columns[columnName].Clone());
                        }
                    }
                }

              
                int newRow = dataGridView1.Rows.Add();

             
                for (int i = 0; i < selectedColumns.Count; i++)
                {
                    string colName = selectedColumns[i];
                    dataGridView1.Rows[newRow].Cells[i].Value = dgvghe.Rows[rowIndex].Cells[colName].Value;
                }
                int count = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow && row.Cells.Cast<DataGridViewCell>().Any(c => c.Value != null && c.Value.ToString() != ""))
                    {
                        count++;
                    }
                }
                txtsoluong.Text = count.ToString();

                int tongTien = 0;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    if (!row.IsNewRow && row.Cells["gia"].Value != null)
                    {
                        int gia;
                        if (int.TryParse(row.Cells["gia"].Value.ToString(), out gia))
                        {
                            tongTien += gia;
                        }
                    }
                }

                txtthanhtien.Text = tongTien.ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng để thêm!");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn tạo vé mới?",
     "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.OK)
            {
                txtmakh.Text = "";
                txttenkh.Text = "";
                txtsdt.Text = "";
                txtsoluong.Text = "";
                txtthanhtien.Text = "";
            
                cbonhanvien.Text = "";
                cbothanhtoan.Text = "";
                dataGridView1.Rows.Clear();
                dgvghe.DataSource = null;
               
            }
        }

        private void txtsdtkh_TextChanged(object sender, EventArgs e)
        {

        }
        public string them()
        {
            try
            {
                data.ExcuteNonQuery("insert into KHACHHANG (TENKH, SODIENTHOAIKH) values ( N'" + txttenkh.Text + "', '" + txtsdt.Text + "')");
                MessageBox.Show("Thêm khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
                string queryLayMaKH = "SELECT TOP 1 MAKH FROM KHACHHANG ORDER BY MAKH DESC";
                string maKHVuaThem = data.ExcuteScalar(queryLayMaKH)?.ToString();
                return maKHVuaThem;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm khách hàng thất bại\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            string maKH = them();
            if (!string.IsNullOrEmpty(maKH))
            {
                txtmakh.Text = maKH;
            }
            else
            {
                txtmakh.Text = ""; 
            }
        }
        private string LayMaKH(string sdt, string tenkh)
        {
            string makh = null;
            string queryLayMa = $"SELECT TOP 1 MAHD FROM KHACHHANG WHERE SODIENTHOAIKH = '{sdt}' AND tenkh = '{tenkh}' ORDER BY MAKH DESC"; // Sắp xếp để lấy bản ghi mới nhất nếu có nhiều
            makh = data.ExcuteScalar(queryLayMa)?.ToString();
            return makh;
        }
        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtsoluong_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtthanhtien_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpngaychieu_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.CurrentRow != null)
            {
                decimal currentThanhTien;
                if (decimal.TryParse(txtthanhtien.Text, out currentThanhTien))
                {
                    if (dataGridView1.CurrentRow.Cells[3].Value != null) 
                    {
                        decimal giaVeRemoved;
                        if (decimal.TryParse(dataGridView1.CurrentRow.Cells[3].Value.ToString(), out giaVeRemoved))
                        {
                            currentThanhTien -= giaVeRemoved;
                            txtthanhtien.Text = currentThanhTien.ToString();
                            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                        }
                        else
                        {
                            MessageBox.Show("Lỗi: Giá vé không hợp lệ trong dòng được chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: Không tìm thấy giá vé trong dòng được chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi: Giá trị hiện tại trong ô Thành tiền không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            DataTable dt = data.ExcuteQuery("SELECT * FROM KHACHHANG WHERE SODIENTHOAIKH = '"+txtsdt.Text+"'");
            DataView dv = new DataView(dt);

            if (dv.Count > 0)
            {

                DataRowView row = dv[0];


             
                txtmakh.Text = row["MaKH"].ToString();
                txttenkh.Text = row["TENKH"].ToString();

                MessageBox.Show("Đã có tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Chưa có tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmakh.Text = "";
                txttenkh.Text = "";
            }
        }

        private void cbonhanvien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void loadcombobox()
        {
            string connectionString = @"Data Source = THANHDUYEN; Initial Catalog = QUANLYRAPCHIEUPHIM; Integrated Security = True";
            string query = "SELECT MaNV FROM NHANVIEN";
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))

                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())

                        {
                            cbonhanvien.Items.Add(reader["MANV"].ToString());
                        }
                    }
                }

            }
        }
    }
}
