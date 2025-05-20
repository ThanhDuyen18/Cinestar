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
using System.IO;

namespace _9406_QuanLyRapChieuPhim_4158
{
    public partial class frmPhimchieu : Form
    {
        Ketnoi data = new Ketnoi();
        string conn = @"Data Source = THANHDUYEN; Initial Catalog = QUANLYRAPCHIEUPHIM; Integrated Security = True";
        public frmPhimchieu()
        {
            InitializeComponent();
           
        }
        private void loadData()
        {
            string str = "select * from PHIM";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvphimchieu.DataSource = dt;
        }
        private void frmPhimchieu_Load(object sender, EventArgs e)
        {
            
            loadData();
            cbotheloai.Items.Add(@"Kinh dị");
            cbotheloai.Items.Add(@"Hài hước");
            cbotheloai.Items.Add(@"Tâm lý");
            cbotheloai.Items.Add(@"Tình cảm");
            cbotheloai.Items.Add(@"Khoa học - Viễn tưởng");
            cbotheloai.Items.Add(@"Hoạt hình");

            cbothoiluong.Items.Add("01:30:00");
            cbothoiluong.Items.Add("01:45:00");
            cbothoiluong.Items.Add("02:00:00");
            cbothoiluong.Items.Add("02:15:00");
            cbothoiluong.Items.Add("02:30:00");
            cbothoiluong.Items.Add("02:45:00");
            cbothoiluong.Items.Add("03:00:00");
            cbothoiluong.Items.Add("03:15:00");


            dgvphimchieu.Columns[0].Width = 100;
            dgvphimchieu.Columns[1].Width = 100;
            dgvphimchieu.Columns[2].Width = 150;
            dgvphimchieu.Columns[3].Width = 100;
            dgvphimchieu.Columns[4].Width = 100;
            dgvphimchieu.Columns[5].Width = 100;
            dgvphimchieu.Columns[6].Width = 100;
     
           


            dgvphimchieu.Columns[0].HeaderText = "Mã phim";
            dgvphimchieu.Columns[1].HeaderText = "Tên phim";
            dgvphimchieu.Columns[2].HeaderText = "Thể loại";
            dgvphimchieu.Columns[3].HeaderText = "Xuất xứ";
            dgvphimchieu.Columns[4].HeaderText = "Thời lượng";
            dgvphimchieu.Columns[5].HeaderText = "Đạo diễn";
            dgvphimchieu.Columns[6].HeaderText = "Hình";
           
        }
        private Form hienTai = null;
        private void moFormCon(Form frmCon)
        {
            if (hienTai != null)
                hienTai.Close();
            hienTai = frmCon;
            frmCon.BringToFront();
            frmCon.Show();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void btnrapThem_Click(object sender, EventArgs e)
        {
            
        }
        private void khoitao()
        {
            txtmaphim.Text = "";
            txttenphim.Text = "";
            cbotheloai.Text = "";         
            txtxuatxu.Text = "";
            cbothoiluong.Text = "";
            txtdaodien.Text = "";
           

            ptbphim.Image = null;
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
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

        private void dgvPhimchieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTai_Click(object sender, EventArgs e)
        {
          
        }

        private void dgvPhimchieu_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvPhimchieu_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void panel5_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void dgvphimchieu_CellContentClick_3(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvphimchieu.CurrentRow.Index;


            txtmaphim.Text = dgvphimchieu.Rows[i].Cells[0].Value.ToString();
            txttenphim.Text = dgvphimchieu.Rows[i].Cells[1].Value.ToString();
            cbotheloai.Text = dgvphimchieu.Rows[i].Cells[2].Value.ToString();
            txtxuatxu.Text = dgvphimchieu.Rows[i].Cells[3].Value.ToString();
            cbothoiluong.Text = dgvphimchieu.Rows[i].Cells[4].Value.ToString();
            txtdaodien.Text = dgvphimchieu.Rows[i].Cells[5].Value.ToString();
            ptbphim.ImageLocation = dgvphimchieu.Rows[i].Cells[6].Value.ToString();
           

        }

        private void btnTai_Click_1(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                String imagePath = "";

                file.Filter = "Image Files (*.jpg; *.png)|*.jpg; *.png";

                if (file.ShowDialog() == DialogResult.OK)
                {
                    imagePath = file.FileName;
                    ptbphim.ImageLocation = imagePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvphimchieu.CurrentCell.RowIndex;
                string maphim = dgvphimchieu.Rows[vitri].Cells[0].Value.ToString();
                data.ExcuteNonQuery("delete from PHIM where maphim = '" + maphim + "' ");
                MessageBox.Show("Xóa phim thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
                khoitao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa phim thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {

                data.ExcuteNonQuery("update PHIM set tenphim = N'" + txttenphim.Text + "', theloai =N'" + cbotheloai.Text + "', xuatxu =N'" + txtxuatxu.Text + "' , thoiluong= '" + cbothoiluong.Text + "', daodien = N'" + txtdaodien.Text + "', hinh = '" + ptbphim.ImageLocation + "' where maphim = '" + txtmaphim.Text + "'");
                MessageBox.Show("Sửa phim thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
                khoitao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa phim thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnrapThem_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(conn))
                {
                    connect.Open();

                    string checkID = "select maphim from PHIM where maphim = '" + txtmaphim.Text + "'";

                    using (SqlCommand cID = new SqlCommand(checkID, connect))
                    {
                        cID.Parameters.AddWithValue("MAPHIM", txtmaphim.Text);

                        SqlDataAdapter adapter = new SqlDataAdapter(cID);
                        DataTable table = new DataTable();

                        adapter.Fill(table);

                        if (table.Rows.Count > 0)
                        {
                            MessageBox.Show("Mã này đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string path = Path.Combine(@"D:\9406-QuanLyRapChieuPhim-4158\9406-QuanLyRapChieuPhim-4158\9406-QuanLyRapChieuPhim-4158\Movie_Directory\" + txtmaphim.Text + ".jpg");
                            string insertData = "insert into PHIM (maphim, tenphim, theloai, xuatxu, thoiluong, daodien, hinh) " +
                                "Values ('" + txtmaphim.Text + "', N'" + txttenphim.Text + "', N'" + cbotheloai.Text + "', N'" + txtxuatxu.Text + "', '" + cbothoiluong.Text + "', N'" + txtdaodien.Text + "', '" + path + "')";



                            string directoryPath = Path.GetDirectoryName(path);

                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);

                            }
                            File.Copy(ptbphim.ImageLocation, path, true);

                            using (SqlCommand cmd = new SqlCommand(insertData, connect))
                            {
                                cmd.Parameters.AddWithValue("MAPHIM", txtmaphim.Text);
                                cmd.Parameters.AddWithValue("TENPHIM", txttenphim.Text);
                                cmd.Parameters.AddWithValue("THELOAI", cbotheloai.Text);
                                cmd.Parameters.AddWithValue("XUATXU", txtxuatxu.Text);
                                cmd.Parameters.AddWithValue("THOILUONG", cbothoiluong.Text);
                                cmd.Parameters.AddWithValue("DAODIEN", txtdaodien.Text);
                                cmd.Parameters.AddWithValue("HINH", path);
                              
                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Thêm phim thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                loadData();
                                khoitao();
                            }
                        }

                    }
;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DataView dv = new DataView(data.ExcuteQuery("Select * from PHIM "));
            dv.RowFilter = string.Format("TENPHIM like '%{0}%'", txtTim.Text);
            dgvphimchieu.DataSource = dv;
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }
    }
}
