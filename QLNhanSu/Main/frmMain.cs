using QLNhanSu.dangnhap;
using QLNhanSu.fdChamCong;
using QLNhanSu.fdLuong;
using QLNhanSu.TimKiem;
using QLNhanSu.TTNhanSu;
using QLNhanSu.xuatbaocao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhanSu.Main
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        frmDangNhap frm =new frmDangNhap();
       

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangNhap f = new frmDangNhap();
            this.Hide();
            f.ShowDialog();
           
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
          
                NhanVien f = new NhanVien();
                f.ShowDialog();
                this.Hide();
                this.Show();
            
           
        }

        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhongBan f = new PhongBan();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void chứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChucVu f = new ChucVu();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void bộPhậnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoPhan f = new BoPhan();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void hợpĐồngLaoĐộngToolStripMenuItem_Click(object sender, EventArgs e)
        {

           
           
                frmHopDongLaoDong f = new frmHopDongLaoDong();
                this.Hide();
                f.ShowDialog();
            this.Show();
        }

        private void lươngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void chấmCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bảoHiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
             
                frmBaoHiem f = new frmBaoHiem();
                this.Hide();
                f.ShowDialog();
            this.Show();

        }

        private void chấmCôngToolStripMenuItem1_Click(object sender, EventArgs e)
        {

          

            
            
                frmChamCong f = new frmChamCong();
                this.Hide();
                f.ShowDialog();
                this.Show();
            
        }

        private void phụCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {

          
                frmPhuCap f = new frmPhuCap();
                this.Hide();
                f.ShowDialog();
                this.Show();
            
        }

        private void thuongToolStripMenuItem_Click(object sender, EventArgs e)
        {

           
                frmThuongPhat f = new frmThuongPhat();
                this.Hide();
                f.ShowDialog();
                this.Show();
            
        }

        private void bảngLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBangLuong f = new frmBangLuong();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void báoCáoNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

           
          
                BaoCaoNhanVien f = new BaoCaoNhanVien();
                this.Hide();
            this.Show();
                f.ShowDialog();
            
        }

        private void nhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
                TimKiemNV f = new TimKiemNV();
                this.Hide();
                f.ShowDialog();
                this.Show();
            
            

            
        }

        private void cậpNhậtThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau f = new DoiMatKhau();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
