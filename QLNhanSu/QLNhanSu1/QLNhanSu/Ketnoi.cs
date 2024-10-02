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
        public string strCon = @"Data Source=NGUYENNGOCNHAN\\SQLEXPRESS;Initial Catalog=QLNS;Integrated Security=True";
        public SqlConnection GetConnect()
        {
            SqlConnection sqlCon = new SqlConnection("Data Source = NGUYENNGOCNHAN\\SQLEXPRESS; Initial Catalog = QLNS; Integrated Security = True");
            sqlCon.Open();
            return sqlCon;
        }
        public int EXECUTENONQUERY(string query)
        {
            int data = 0;
            using (SqlConnection sqlCon = new SqlConnection("Data Source = NGUYENNGOCNHAN\\SQLEXPRESS; Initial Catalog = QLNS; Integrated Security = True"))
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
            SqlDataAdapter dap = new SqlDataAdapter(sql, "Data Source = NGUYENNGOCNHAN\\SQLEXPRESS; Initial Catalog = QLNS; Integrated Security = True");
            DataTable table = new DataTable();
            dap.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma; //Trường giá trị
            cbo.DisplayMember = ten; //Trường hiển thị
        }
    }
}
