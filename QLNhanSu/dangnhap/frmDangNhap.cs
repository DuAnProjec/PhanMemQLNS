using QLNhanSu.Main;
using QLNhanSu.TTNhanSu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public string pq="";
        
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string taikhoan = txtTenDangNhap.Text;
            string matkhau = txtMatKhau.Text;
            string phanquyen = cbChucVu.SelectedItem.ToString();
            string select = @"select * from Account where TenDN='" + taikhoan + "' and Pass='" + matkhau  + "' and TenPQ=N'" + phanquyen +"'";
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
                    pq = phanquyen;
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = (MessageBox.Show("Bạn có muốn thoát ?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning));
            if (thongbao == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                if (thongbao == DialogResult.No)
                {
                    frmDangNhap lg = new frmDangNhap();
                    lg.Visible = true;
                }
            }


        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            cbChucVu.Items.Add("Nhân Viên");
            cbChucVu.Items.Add("Quản Lý");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
