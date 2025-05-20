using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9406_QuanLyRapChieuPhim_4158
{
    internal class Ketnoi
    {
        private string connectString = @"Data Source = THANHDUYEN; Initial Catalog = QUANLYRAPCHIEUPHIM; Integrated Security = True";

        public SqlConnection getConnect()
        {
            SqlConnection conn = new SqlConnection(connectString);
            conn.Open();
            return conn;
        }
        public DataTable ThongtinNV()
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from NHANVIEN", getConnect());
            adapter.Fill(data);
            return data;
        }
        public int ExcuteNonQuery(string query)
        {
            int data = 0;
            using (SqlConnection ketnoi = new SqlConnection(connectString))
            {
                ketnoi.Open();
                SqlCommand thucthi = new SqlCommand(query, ketnoi);
                data = thucthi.ExecuteNonQuery();
            }
            return data;
        }
        public DataTable ExcuteQuery(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection ketnoi = new SqlConnection(connectString))
            {
                ketnoi.Open();
                SqlCommand thucthi = new SqlCommand(query, ketnoi);
                SqlDataAdapter laydulieu = new SqlDataAdapter(thucthi);
                laydulieu.Fill(dt);
                ketnoi.Close();

            }
            return dt;
        }
        public string ExcuteScalar(string query)
        {
            string result = "";
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                object obj = cmd.ExecuteScalar();
                if (obj != null)
                    result = obj.ToString();
                conn.Close();
            }
            return result;
        }
    }
}
