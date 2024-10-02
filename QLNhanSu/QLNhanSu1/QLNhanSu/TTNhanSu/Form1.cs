using QLNhanSu.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhanSu
{
    public partial class Form1 : Form
    {
        KetNoi kn = new KetNoi();
        DataTable tblNV;
        public Form1()
        {
            InitializeComponent();
        }
        public void LoadDataGridView()
        {
            string sql;
            sql = "select * from NhanVien";
            tblNV = kn.GetDataToTable(sql); //lấy dữ liệu
            dgvNhanVien.DataSource = tblNV;
            dgvNhanVien.Columns[0].HeaderText = "Mã nhân viên";
            dgvNhanVien.Columns[1].HeaderText = "Họ nhân viên";
            dgvNhanVien.Columns[2].HeaderText = "Tên nhân viên";
            dgvNhanVien.Columns[3].HeaderText = "Giới tính";
            dgvNhanVien.Columns[4].HeaderText = "Ngày sinh";
            dgvNhanVien.Columns[5].HeaderText = "Điện thoại";
            dgvNhanVien.Columns[6].HeaderText = "Địa chỉ";
            dgvNhanVien.Columns[7].HeaderText = "CCCD";
            dgvNhanVien.Columns[8].HeaderText = "Mã Phòng Ban";
            dgvNhanVien.Columns[9].HeaderText = "Mã Bộ Phận";
            dgvNhanVien.Columns[10].HeaderText = "Mã Chức Vụ";

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
            dgvNhanVien.Columns[10].Width = 100;

            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vitri = dgvNhanVien.CurrentCell.RowIndex;
            txtMaNV.Text = dgvNhanVien.Rows[vitri].Cells[0].Value.ToString();
            txtHoNV.Text = dgvNhanVien.Rows[vitri].Cells[1].Value.ToString();
            txtTenNV.Text = dgvNhanVien.Rows[vitri].Cells[2].Value.ToString();
            if (dgvNhanVien.CurrentRow.Cells[3].Value.ToString() == "Nam") cbGioiTinh.Checked = true;
            else cbGioiTinh.Checked = false;
            dtpNgaySinh.Text = dgvNhanVien.Rows[vitri].Cells[4].Value.ToString();
            txtSDT.Text = dgvNhanVien.Rows[vitri].Cells[5].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.Rows[vitri].Cells[6].Value.ToString();
            txtCCCD.Text = dgvNhanVien.Rows[vitri].Cells[7].Value.ToString();
            cbPhongBan.Text = dgvNhanVien.Rows[vitri].Cells[8].Value.ToString();
            cbBoPhan.Text = dgvNhanVien.Rows[vitri].Cells[9].Value.ToString();
            cbChucVu.Text = dgvNhanVien.Rows[vitri].Cells[10].Value.ToString();

        }
        private void ResetValues()
        {

            txtMaNV.Text = "";
            txtHoNV.Text = "";
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

            sql = "INSERT INTO NhanVien(MaNV,HoNV,TenNV,GioiTinh,NgaySinh,SDT,CCCD,DiaChi,MaPB,MaBP,MaCV) VALUES (N'" + txtMaNV.Text + "',N'" + txtHoNV.Text + "',N'" + txtTenNV.Text + "',N'" + gt + "',N'" + dt + "',N'" + txtSDT.Text + "',N'" + txtDiaChi.Text + "',N'" + txtCCCD.Text + "',N'" + cbPhongBan.SelectedValue.ToString() + "',N'" + cbBoPhan.SelectedValue.ToString() + "',N'" + cbChucVu.SelectedValue.ToString() + "')";
            loadCombo();

            kn.EXECUTENONQUERY(sql);
            LoadDataGridView();
            ResetValues();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            loadCombo();

        }

        private void cbPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (cbGioiTinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            DateTime dt = dtpNgaySinh.Value;
            sql = @"UPDATE NhanVien SET  HoNV=N'" + txtHoNV.Text +
                    "',TenNV=N'" + txtTenNV.Text +
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "Delete NhanVien Where MaNV='" + txtMaNV.Text + "'";
            kn.EXECUTENONQUERY(sql);
            LoadDataGridView();
            ResetValues();
        }


    }
}
