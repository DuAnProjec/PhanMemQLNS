using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhanSu.TTNhanSu
{
    public partial class frmHopDongLaoDong : Form
    {
        KetNoi kn=new KetNoi();
        DataTable tblHD;
        public frmHopDongLaoDong()
        {
            InitializeComponent();
        }
        public void LoadDataGridView()
        {
            string sql;
            sql = "select * from HopDong";
            tblHD = kn.GetDataToTable(sql); //lấy dữ liệu
            dgvHDLD.DataSource = tblHD;
            dgvHDLD.Columns[0].HeaderText = "Mã hợp đồng";
            dgvHDLD.Columns[1].HeaderText = "Ngày Bắt Đầu";
            dgvHDLD.Columns[2].HeaderText = "Ngày Kết Thúc";
            dgvHDLD.Columns[3].HeaderText = "Ngày Ký";
            dgvHDLD.Columns[4].HeaderText = "Nội Dung";
            dgvHDLD.Columns[5].HeaderText = "Lần Ký";
            dgvHDLD.Columns[6].HeaderText = "Thời Hạn";
            dgvHDLD.Columns[7].HeaderText = "Hệ Số Lương";
            dgvHDLD.Columns[8].HeaderText = "Mã Nhân viên";
            dgvHDLD.Columns[0].Width = 100;
            dgvHDLD.Columns[1].Width = 150;
            dgvHDLD.Columns[2].Width = 100;
            dgvHDLD.Columns[3].Width = 150;
            dgvHDLD.Columns[4].Width = 100;
            dgvHDLD.Columns[5].Width = 100;
            dgvHDLD.Columns[6].Width = 100;
            dgvHDLD.Columns[7].Width = 100;
            dgvHDLD.Columns[8].Width = 100;
            
            dgvHDLD.AllowUserToAddRows = false;
            dgvHDLD.EditMode = DataGridViewEditMode.EditProgrammatically;

        }
        private void ResetValues()
        {

            txtMaHD.Text = "";
            txtNoiDung.Text = "";
            txtLanKy.Text = "";
            txtHeSoLuong.Text = "";
            txtMaHD.Focus();
        }
        private void dgvHDLD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vitri = dgvHDLD.CurrentCell.RowIndex;
            txtMaHD.Text=dgvHDLD.Rows[vitri].Cells[0].Value.ToString();
            dtpNgayBatDau.Text = dgvHDLD.Rows[vitri].Cells[1].Value.ToString();
            dtpNgayKetThuc.Text = dgvHDLD.Rows[vitri].Cells[2].Value.ToString();
            dtpNgayKy.Text = dgvHDLD.Rows[vitri].Cells[3].Value.ToString();
            txtNoiDung.Text = dgvHDLD.Rows[vitri].Cells[4].Value.ToString();
            txtLanKy.Text = dgvHDLD.Rows[vitri].Cells[5].Value.ToString();
            txtThoiHan.Text = dgvHDLD.Rows[vitri].Cells[6].Value.ToString();
            txtHeSoLuong.Text = dgvHDLD.Rows[vitri].Cells[7].Value.ToString();
            cboMaNV.Text = dgvHDLD.Rows[vitri].Cells[8].Value.ToString();
           
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql;
           DateTime ngaybatdau = dtpNgayBatDau.Value;
            DateTime ngayketthuc = dtpNgayKetThuc.Value;
            DateTime ngayky = dtpNgayKy.Value;

            sql = "INSERT INTO HopDong(MaHD,NgayBatDau,NgayKetThuc,NgayKy,NoiDung,LanKy,ThoiHan,HeSoLuong,MaNV) VALUES (N'" + txtMaHD.Text + "',N'" + ngaybatdau + "',N'" + ngayketthuc + "',N'" + ngayky + "',N'" + txtNoiDung.Text + "',N'" + txtLanKy.Text + "',N'" + txtThoiHan.Text + "',N'" + txtHeSoLuong.Text + "',N'" + cboMaNV.SelectedValue  + "')";
             kn.EXECUTENONQUERY(sql);
            LoadDataGridView();
            KetNoi.FillCombo("select * from NhanVien", cboMaNV, "MaNV", "MaNV");
            ResetValues();
        }

        private void frmHopDongLaoDong_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            KetNoi.FillCombo("select * from NhanVien", cboMaNV, "MaNV", "MaNV");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            DateTime ngaybatdau=dtpNgayBatDau.Value;
            DateTime ngayketthuc = dtpNgayKetThuc.Value;
            DateTime ngayky = dtpNgayKy.Value;
            sql = "UPDATE HopDong SET  NgayBatDau=N'" + ngaybatdau +
                   "',NgayKetThuc=N'" + ngayketthuc +
                   "',NgayKy=N'" + ngayky +
                    "',NoiDung=N'" + txtNoiDung.Text +
                     "',LanKy=N'" + txtLanKy.Text +
                   "',ThoiHan='" + txtThoiHan.Text +
                   "',HeSoLuong='" + txtHeSoLuong.Text +
                     "',MaNV='" + cboMaNV.SelectedValue +
                   "' WHERE MaHD=N'" + txtMaHD.Text + "'";
            
            kn.EXECUTENONQUERY(sql);
            LoadDataGridView();
            ResetValues();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "Delete HopDong Where MaHD='" + txtMaHD.Text + "'";
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
                this.Close();
                this.Hide();
                //main.ShowDialog();
            }
        }
    }
}
