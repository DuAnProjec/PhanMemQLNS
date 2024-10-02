using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace QLNhanSu
{
    internal class KetNoi
    {
        public string strCon = "Data Source=DESKTOP-BBNPL2V;Initial Catalog=QLNS;Integrated Security=True";
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-BBNPL2V;Initial Catalog=QLNS;Integrated Security=True");
        public SqlConnection GetConnect()
        {
            SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-BBNPL2V;Initial Catalog=QLNS;Integrated Security=True");
            sqlCon.Open();
            return sqlCon;
        }
        public int EXECUTENONQUERY(string query)
        {
            int data = 0;
            using (SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-BBNPL2V;Initial Catalog=QLNS;Integrated Security=True"))
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                try
                {
                    cmd.ExecuteNonQuery(); //Thực hiện câu lệnh SQL
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                
                sqlCon.Close();
            }
            return data;
        }
        //Lấy dữ liệu vào bảng
        public DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, GetConnect()); //Định nghĩa đối tượng thuộc lớp SqlDataAdapter
            //Khai báo đối tượng table thuộc lớp DataTable
            DataTable table = new DataTable();
            dap.Fill(table); //Đổ kết quả từ câu lệnh sql vào table
            return table;
        }
        public static void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, "Data Source=DESKTOP-BBNPL2V;Initial Catalog=QLNS;Integrated Security=True");
            DataTable table = new DataTable();
            dap.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma; //Trường giá trị
            cbo.DisplayMember = ten; //Trường hiển thị
        }
        public DataTable Executequery(string query)
        {
            DataTable data = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(strCon))
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                SqlDataAdapter laydulieu = new SqlDataAdapter(cmd);
                laydulieu.Fill(data);
                sqlCon.Close();
            }
            return data;
        }
        public SqlDataReader DemSoNgayLam(string manv, DateTime ngaydau, DateTime ngaycuoi)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("DemSoNgayLam", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            cm.Parameters.AddWithValue("@ngaydau", ngaydau);
            cm.Parameters.AddWithValue("@ngaycuoi", ngaycuoi);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader DemSoNgaynghiCoPhep(string manv, DateTime ngaydau, DateTime ngaycuoi)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("DemSoNgaynghiCoPhep", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            cm.Parameters.AddWithValue("@ngaydau", ngaydau);
            cm.Parameters.AddWithValue("@ngaycuoi", ngaycuoi);
            dr = cm.ExecuteReader();
            return dr;
        }
        public SqlDataReader DemSoNgayNghiKhongPhep(string manv, DateTime ngaydau, DateTime ngaycuoi)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlDataReader dr = null;
            SqlCommand cm = new SqlCommand("DemSoNgayNghiKhongPhep", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@manv", manv);
            cm.Parameters.AddWithValue("@ngaydau", ngaydau);
            cm.Parameters.AddWithValue("@ngaycuoi", ngaycuoi);
            dr = cm.ExecuteReader();
            return dr;
        }


    }
}
