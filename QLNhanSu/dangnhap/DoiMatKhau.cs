using QLNhanSu.Main;
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

namespace QLNhanSu.dangnhap
{
    public partial class DoiMatKhau : MetroFramework.Forms.MetroForm
    {
        public DoiMatKhau()
        {
            InitializeComponent();
        }
        KetNoi kn=new KetNoi();
        SqlConnection sqlConn = new SqlConnection("Data Source=DESKTOP-BBNPL2V;Initial Catalog=QLNS;Integrated Security=True");

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string select = @"select * from Account where TenDN='" + txtTenDangNhap.Text + "' and Pass='" + txtMatKhauCu.Text + "'";
            SqlCommand cmd = new SqlCommand(select, kn.GetConnect());
            SqlDataReader reader = cmd.ExecuteReader();
           
            try
            {
                if (reader.Read() == true)
                {
                    string sql;
                    sql = @"UPDATE Account SET  Pass=N'" + txtMatKhauMoi.Text + "'";
                    kn.EXECUTENONQUERY(sql);
                    MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else
                {
                    MessageBox.Show("Đổi tài khoản không thành công! \nKiểm tra lại tên tài khoản và mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
