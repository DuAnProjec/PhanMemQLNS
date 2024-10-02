using Microsoft.Reporting.Map.WebForms.BingMaps;
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
    public partial class TTNhanVien : Form
    {
        public TTNhanVien()
        {
            InitializeComponent();
        }
        Ketnoi kn=new Ketnoi();
        DataTable tblNV = new DataTable();
        private void TTNhanVien_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        private void ResetValues()
        {

            txtMaNV.Text = "";
            txtHoNV.Text = "";
            txtTenNV.Text = "";
            cbGioiTinh.Checked = false;
            txtDiaChi.Text = "";
            dtpNgaysinh.Text = "";
            txtCCCD.Text = "";
            txtSDT.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (cbGioiTinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            DateTime NgaySinh = dtpNgaysinh.Value;
            if (MessageBox.Show("Bạn có muốn thêm không?", "Thông báo",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = @"INSERT INTO NhanVien (MaNV,HoNV,TenNV,GioiTinh,NgaySinh,SDT,CCCD,DiaChi) VALUES ('" + txtMaNV.Text + "',N'" + txtHoNV.Text + "',N'" + txtTenNV.Text + "',N'" + gt + "',N'" + NgaySinh + "',N'" + txtSDT.Text + "',N'" + txtCCCD.Text + "',N'" + txtDiaChi.Text + "')  ";
                kn.EXECUTENONQUERY(sql);
                LoadDataGridView();
                ResetValues();
                btnXoa.Enabled = true;
                btnThem.Enabled = true;
                btnSua.Enabled = true;

                txtMaNV.Text = "";
                MessageBox.Show("Thêm thành công " + txtMaNV.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ResetValues();
                txtMaNV.Focus();
            }
        }
        public void LoadDataGridView()
        {
            tblNV = kn.GetDataToTable();
            dgvNhanVien.DataSource = tblNV;
            dgvNhanVien.Columns[0].HeaderText = "Mã nhân viên";
            dgvNhanVien.Columns[1].HeaderText = "Họ nhân viên";
            dgvNhanVien.Columns[2].HeaderText = "Tên nhân viên";
            dgvNhanVien.Columns[3].HeaderText = "Giới Tính";
            dgvNhanVien.Columns[4].HeaderText = "Ngày Sinh";
            dgvNhanVien.Columns[5].HeaderText = "SĐT";
            dgvNhanVien.Columns[6].HeaderText = "CCCD";
            dgvNhanVien.Columns[7].HeaderText = "Địa chỉ";
            dgvNhanVien.Columns[0].Width = 100;
            dgvNhanVien.Columns[1].Width = 150;
            dgvNhanVien.Columns[2].Width = 100;
            dgvNhanVien.Columns[3].Width = 150;
            dgvNhanVien.Columns[4].Width = 100;
            dgvNhanVien.Columns[5].Width = 100;
            dgvNhanVien.Columns[6].Width = 100;
            dgvNhanVien.Columns[7].Width = 100;
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
            dtpNgaysinh.Text = dgvNhanVien.Rows[vitri].Cells[4].Value.ToString();
            txtSDT.Text = dgvNhanVien.Rows[vitri].Cells[5].Value.ToString();
            txtCCCD.Text = dgvNhanVien.Rows[vitri].Cells[6].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.Rows[vitri].Cells[7].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if(cbGioiTinh.Checked==true)
            {
                gt = "Nam";
            }
            else
            {
                gt = "Nữ";
            }

            sql= "UPDATE NhanVien SET  HoNV = N'" + txtHoNV.Text +
                    "',TenNV=N'" + txtTenNV.Text +gt+
                    "',NgaySinh='" + dtpNgaysinh.Value + 
                    "',SDT='" + txtSDT.Text +
                    "',CCCD='" + txtCCCD.Text +
                    "',DiaChi='" + txtDiaChi.Text +
                    "' WHERE MaNV=N'" + txtMaNV.Text + "'";
            kn.EXECUTENONQUERY(sql);
            LoadDataGridView();
            ResetValues();
            txtMaNV.Text = "";
        }
    }
}
