using QLNhanSu.dangnhap;
using QLNhanSu.Main;
using QLNhanSu.TimKiem;
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

namespace QLNhanSu.TTNhanSu
{
    public partial class NhanVien : MetroFramework.Forms.MetroForm
    {
        public NhanVien()
        {
            InitializeComponent();
        }
        frmDangNhap frmDangNhap = new frmDangNhap();
        KetNoi kn = new KetNoi();
    
        private BindingSource bdsource = new BindingSource();
        SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-BBNPL2V;Initial Catalog=QLNS;Integrated Security=True");
        public void LoadDataGridView()
        {
            string sql;
            sql = "select * from NhanVien";
            bdsource.DataSource = kn.GetDataToTable(sql);
            dgvNhanVien.DataSource = bdsource;
            txtHienHanh.Text = (bdsource.Position + 1).ToString();
            txtTongSo.Text = bdsource.Count.ToString();
            dgvNhanVien.Columns[0].HeaderText = "Mã nhân viên";
            dgvNhanVien.Columns[1].HeaderText = "Tên nhân viên";
            dgvNhanVien.Columns[2].HeaderText = "Giới tính";
            dgvNhanVien.Columns[3].HeaderText = "Ngày sinh";
            dgvNhanVien.Columns[4].HeaderText = "Điện thoại";
            dgvNhanVien.Columns[5].HeaderText = "Địa chỉ";
            dgvNhanVien.Columns[6].HeaderText = "CCCD";
            dgvNhanVien.Columns[7].HeaderText = "Mã Phòng Ban";
            dgvNhanVien.Columns[8].HeaderText = "Mã Bộ Phận";
            dgvNhanVien.Columns[9].HeaderText = "Mã Chức Vụ";

            dgvNhanVien.Columns[0].Width = 100;
            dgvNhanVien.Columns[1].Width = 150;
            dgvNhanVien.Columns[2].Width = 100;
            dgvNhanVien.Columns[3].Width = 150;
            dgvNhanVien.Columns[4].Width = 100;
            dgvNhanVien.Columns[5].Width = 100;
            dgvNhanVien.Columns[6].Width = 100;
            dgvNhanVien.Columns[7].Width = 100;
            dgvNhanVien.Columns[8].Width = 100;
            dgvNhanVien.Columns[9].Width = 100;

            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vitri = dgvNhanVien.CurrentCell.RowIndex;
            txtMaNV.Text = dgvNhanVien.Rows[vitri].Cells[0].Value.ToString();
            txtTenNV.Text = dgvNhanVien.Rows[vitri].Cells[1].Value.ToString();
            if (dgvNhanVien.CurrentRow.Cells[2].Value.ToString() == "Nam") cbGioiTinh.Checked = true;
            else cbGioiTinh.Checked = false;
            dtpNgaySinh.Text = dgvNhanVien.Rows[vitri].Cells[3].Value.ToString();
            txtSDT.Text = dgvNhanVien.Rows[vitri].Cells[4].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.Rows[vitri].Cells[5].Value.ToString();
            txtCCCD.Text = dgvNhanVien.Rows[vitri].Cells[6].Value.ToString();
            cbPhongBan.Text = dgvNhanVien.Rows[vitri].Cells[7].Value.ToString();
            cbBoPhan.Text = dgvNhanVien.Rows[vitri].Cells[8].Value.ToString();
            cbChucVu.Text = dgvNhanVien.Rows[vitri].Cells[9].Value.ToString();
        }
        private void ResetValues()
        {

            txtMaNV.Text = "";
            txtTenNV.Text = "";
            cbGioiTinh.Checked = false;
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtCCCD.Text = "";
        }
        public void loadCombo()
        {
            KetNoi.FillCombo("select * from BoPhan", cbBoPhan, "MaBP", "TenBP");
            KetNoi.FillCombo("select * from ChucVu", cbChucVu, "MaCV", "TenCV");
            KetNoi.FillCombo("select * from PhongBan", cbPhongBan, "MaPB", "TenPB");

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (cbGioiTinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            DateTime dt = dtpNgaySinh.Value;
            sql = "INSERT INTO NhanVien(MaNV,TenNV,GioiTinh,NgaySinh,SDT,CCCD,DiaChi,MaPB,MaBP,MaCV) VALUES (N'" + txtMaNV.Text + "',N'" + txtTenNV.Text + "',N'" + gt + "',N'" + dt + "',N'" + txtSDT.Text + "',N'" + txtDiaChi.Text + "',N'" + txtCCCD.Text + "',N'" + cbPhongBan.SelectedValue.ToString() + "',N'" + cbBoPhan.SelectedValue.ToString() + "',N'" + cbChucVu.SelectedValue.ToString() + "')";

            DialogResult thongbao;
            thongbao = (MessageBox.Show("Bạn có muốn thêm" + txtMaNV.Text + " ?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Information));
            if (thongbao == DialogResult.Yes)
            {

                loadCombo();

                kn.EXECUTENONQUERY(sql);
                LoadDataGridView();
            }
            else
            {
                NhanVien f = new NhanVien();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }

            ResetValues();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (cbGioiTinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            DateTime dt = dtpNgaySinh.Value;
            DialogResult thongbao;
            thongbao = (MessageBox.Show("Bạn có muốn sửa" + txtMaNV.Text + " ?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Information));
            if (thongbao == DialogResult.Yes)
            {
                sql = @"UPDATE NhanVien SET  TenNV=N'" + txtTenNV.Text +
                    "',GioiTinh=N'" + gt +
                     "',NgaySinh=N'" + dt +
                      "',SDT=N'" + txtSDT.Text +
                    "',CCCD='" + txtCCCD.Text +
                    "',DiaChi='" + txtDiaChi.Text +
                      "',MaPB='" + cbPhongBan.SelectedValue +
                        "',MaCV='" + cbChucVu.SelectedValue +
                          "',MaBP='" + cbBoPhan.SelectedValue +
                    "' WHERE MaNV=N'" + txtMaNV.Text + "'";
                loadCombo();
                kn.EXECUTENONQUERY(sql);
                LoadDataGridView();
                ResetValues();
            }
            
            else
            {
                NhanVien f = new NhanVien();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            DialogResult thongbao;
            thongbao = (MessageBox.Show("Bạn có muốn xoá" + txtMaNV.Text + " ?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Information));
            if (thongbao == DialogResult.Yes)
            {
                sql = "Delete NhanVien Where MaNV='" + txtMaNV.Text + "'";
                kn.EXECUTENONQUERY(sql);
                LoadDataGridView();
                ResetValues();
            }
            else
            {
                NhanVien f = new NhanVien();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
           
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = (MessageBox.Show("Bạn có muốn thoát ?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Information));
            if (thongbao == DialogResult.Yes)
            {
                frmMain main = new frmMain();
                this.Close();
                this.Hide();
                main.ShowDialog();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bdsource.Position = 0;
            txtHienHanh.Text = (bdsource.Position + 1).ToString();
            txtTongSo.Text = bdsource.Count.ToString();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = true;
            dgvNhanVien_SelectionChanged(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bdsource.Position -= 1;
            txtHienHanh.Text = (bdsource.Position + 1).ToString();
            txtTongSo.Text = bdsource.Count.ToString();
            if (bdsource.Position == 0)
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
            button3.Enabled = true;
            button4.Enabled = true;
            dgvNhanVien_SelectionChanged(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bdsource.Position += 1;
            txtHienHanh.Text = (bdsource.Position + 1).ToString();
            txtTongSo.Text = bdsource.Count.ToString();
            if (bdsource.Position == bdsource.Count - 1)
            {
                button4.Enabled = false;
                button3.Enabled = false;
            }
            button1.Enabled = true;
            button2.Enabled = true;
            dgvNhanVien_SelectionChanged(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bdsource.Position = bdsource.Count - 1;
            txtHienHanh.Text = (bdsource.Position + 1).ToString();
            txtTongSo.Text = bdsource.Count.ToString();
            button3.Enabled = false;
            button4.Enabled = false;
            button2.Enabled = true;
            button1.Enabled = true;
            dgvNhanVien_SelectionChanged(sender, e);
        }

        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            int vitri = dgvNhanVien.CurrentCell.RowIndex;
            txtMaNV.Text = dgvNhanVien.Rows[vitri].Cells[0].Value.ToString();
            txtTenNV.Text = dgvNhanVien.Rows[vitri].Cells[1].Value.ToString();
            if (dgvNhanVien.CurrentRow.Cells[2].Value.ToString() == "Nam") cbGioiTinh.Checked = true;
            else cbGioiTinh.Checked = false;
            dtpNgaySinh.Text = dgvNhanVien.Rows[vitri].Cells[3].Value.ToString();
            txtSDT.Text = dgvNhanVien.Rows[vitri].Cells[4].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.Rows[vitri].Cells[5].Value.ToString();
            txtCCCD.Text = dgvNhanVien.Rows[vitri].Cells[6].Value.ToString();
            cbPhongBan.Text = dgvNhanVien.Rows[vitri].Cells[7].Value.ToString();
            cbBoPhan.Text = dgvNhanVien.Rows[vitri].Cells[8].Value.ToString();
            cbChucVu.Text = dgvNhanVien.Rows[vitri].Cells[9].Value.ToString();
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            loadCombo();
           
        }

        private void btnPhongBan_Click(object sender, EventArgs e)
        {
            XuatDSNVTheoPhongBan f = new XuatDSNVTheoPhongBan();
            this.Close();
            this.Hide();
            f.ShowDialog();
        }

        private void btnBoPhan_Click(object sender, EventArgs e)
        {
            XuatDSNVTheoBP f = new XuatDSNVTheoBP();
            this.Close();
            this.Hide();
            f.ShowDialog();
        }

        private void btnChucVu_Click(object sender, EventArgs e)
        {
            XuatDSNVTheoChucVu f = new XuatDSNVTheoChucVu();
            this.Close();
            this.Hide();
            f.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    }


