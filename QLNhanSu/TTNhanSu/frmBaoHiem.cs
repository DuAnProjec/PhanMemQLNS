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

namespace QLNhanSu.TTNhanSu
{
    public partial class frmBaoHiem : MetroFramework.Forms.MetroForm
    {
        public frmBaoHiem()
        {
            InitializeComponent();
        }
        KetNoi kn = new KetNoi();
        DataTable tblNV;
        private BindingSource bdsource = new BindingSource();
        public void LoadDataGridView()
        {
            string sql;
            sql = "select * from BaoHiem";
            tblNV = kn.GetDataToTable(sql); //lấy dữ liệu
            dgvBaoHiem.DataSource = tblNV;
            dgvBaoHiem.Columns[0].HeaderText = "Mã Bảo Hiểm";
            dgvBaoHiem.Columns[1].HeaderText = "Loại Bảo hiểm";
            dgvBaoHiem.Columns[2].HeaderText = "Ngày Cấp";
            dgvBaoHiem.Columns[3].HeaderText = "Nơi Cấp";
            dgvBaoHiem.Columns[4].HeaderText = "Ngày Hết hạn";
            dgvBaoHiem.Columns[5].HeaderText = "Mã Nhân Viên";
            dgvBaoHiem.Columns[6].HeaderText = "Tiền DN hỗ trợ";
            dgvBaoHiem.Columns[7].HeaderText = "Tiền nhân viên phải trả";


            dgvBaoHiem.Columns[0].Width = 100;
            dgvBaoHiem.Columns[1].Width = 150;
            dgvBaoHiem.Columns[2].Width = 100;
            dgvBaoHiem.Columns[3].Width = 150;
            dgvBaoHiem.Columns[4].Width = 100;
            dgvBaoHiem.Columns[5].Width = 100;
            dgvBaoHiem.Columns[6].Width = 100;
            dgvBaoHiem.Columns[7].Width = 100;


            dgvBaoHiem.AllowUserToAddRows = false;
            dgvBaoHiem.EditMode = DataGridViewEditMode.EditProgrammatically;

        }
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vitri = dgvBaoHiem.CurrentCell.RowIndex;
            txtMaBH.Text = dgvBaoHiem.Rows[vitri].Cells[0].Value.ToString();
            txtLoaiBH.Text = dgvBaoHiem.Rows[vitri].Cells[1].Value.ToString();
            dtpNgayCap.Text = dgvBaoHiem.Rows[vitri].Cells[2].Value.ToString();
            txtNoiCap.Text = dgvBaoHiem.Rows[vitri].Cells[3].Value.ToString();
            dtpNgayHetHan.Text = dgvBaoHiem.Rows[vitri].Cells[4].Value.ToString();
            cbMaNV.Text = dgvBaoHiem.Rows[vitri].Cells[5].Value.ToString();
            txtTienDNHT.Text = dgvBaoHiem.Rows[vitri].Cells[6].Value.ToString();
            txtTienBHPhaiNop.Text = dgvBaoHiem.Rows[vitri].Cells[7].Value.ToString();

        }
        public void loadcombo()
        {
            KetNoi.FillCombo("select * from NhanVien", cbMaNV, "MaNV", "TenNV");

        }
        private void ResetValues()
        {

            txtMaBH.Text = "";
            txtLoaiBH.Text = "";
            txtNoiCap.Text = "";
           
        }
              
        

        

       

        private void frmBaoHiem_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            loadcombo();
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
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

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            string sql;

            DateTime dt = dtpNgayCap.Value;
            DateTime hh = dtpNgayHetHan.Value;

            sql = "INSERT INTO BaoHiem (MaBH,LoaiBH,NgayCap,NoiCap,NgayHetHan,MaNV,TienDNHT,TienBHPhaiNop) VALUES (N'" + txtMaBH.Text + "',N'" + txtLoaiBH.Text + "',N'" + dt + "',N'" + txtNoiCap.Text + "',N'" + hh + "',N'" + cbMaNV.SelectedValue.ToString() + "',N'" + txtTienDNHT.Text + "',N'" + txtTienBHPhaiNop.Text+"')";
            loadcombo();
            kn.EXECUTENONQUERY(sql);
            LoadDataGridView();
            ResetValues();
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            string sql;
            DateTime dt = dtpNgayCap.Value;
            DateTime hh = dtpNgayHetHan.Value;

            sql = @"UPDATE BaoHiem SET  LoaiBH=N'" + txtLoaiBH.Text +
                    "',NgayCap=N'" + dt +
                    "',NoiCap=N'" + txtNoiCap.Text +
                     "',NgayHetHan=N'" + hh +
                      "',MaNV=N'" + cbMaNV.SelectedValue +
                       "',TienDNHT=N'" + txtTienDNHT.Text +
                       "',TienBHPhaiNop=N'" + txtTienBHPhaiNop.Text +

                    "' WHERE MaBH=N'" + txtMaBH.Text + "'";
            loadcombo();
            kn.EXECUTENONQUERY(sql);
            LoadDataGridView();
            ResetValues();
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            string sql;
            sql = "Delete BaoHiem Where MaBH='" + txtMaBH.Text + "'";
            kn.EXECUTENONQUERY(sql);
            LoadDataGridView();
            ResetValues();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
