using QLNhanSu.Main;
using QLNhanSu.TTNhanSu;
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
    public partial class frmDangNhap : Form
    {
        KetNoi kn = new KetNoi();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string taikhoan = txtTenDangNhap.Text;
            string matkhau = txtMatKhau.Text;
            string select = @"select *from Account where TenDN='" + taikhoan + "' and Pass='" + matkhau + "'";
            SqlCommand cmd = new SqlCommand(select,kn.GetConnect() );
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                if (reader.Read() == true)
                {
                    MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmMain main = new frmMain();
                    this.Hide();
                    main.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Đăng nhập không thành công! \nKiểm tra lại tên tài khoản và mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
