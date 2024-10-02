using QLNhanSu.Main;
using QLNhanSu.TTNhanSu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhanSu.fdChamCong
{
    public partial class frmPhuCap : MetroFramework.Forms.MetroForm
    {
        KetNoi kn = new KetNoi();
        DataTable tblNV;
        public frmPhuCap()
        {
            InitializeComponent();
        }
        public void LoadDataGridView()
        {
            string sql;
            sql = "select * from PhuCap";
            tblNV = kn.GetDataToTable(sql); //lấy dữ liệu
            dgvPhuCap.DataSource = tblNV;
            dgvPhuCap.Columns[0].HeaderText = "Mã Phụ Cấp";
            dgvPhuCap.Columns[1].HeaderText = "Tên nhân viên";
            dgvPhuCap.Columns[2].HeaderText = "Giới tính";
            dgvPhuCap.Columns[3].HeaderText = "Ngày sinh";
            dgvPhuCap.Columns[4].HeaderText = "Điện thoại";
            dgvPhuCap.Columns[5].HeaderText = "Địa chỉ";
           

            dgvPhuCap.Columns[0].Width = 100;
            dgvPhuCap.Columns[1].Width = 150;
            dgvPhuCap.Columns[2].Width = 100;
            dgvPhuCap.Columns[3].Width = 150;
            dgvPhuCap.Columns[4].Width = 100;
            dgvPhuCap.Columns[5].Width = 100;
            

            dgvPhuCap.AllowUserToAddRows = false;
            dgvPhuCap.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vitri = dgvPhuCap.CurrentCell.RowIndex;
            txtMaPC.Text = dgvPhuCap.Rows[vitri].Cells[0].Value.ToString();
            cbMaNV.Text = dgvPhuCap.Rows[vitri].Cells[1].Value.ToString();
            txtLoaiPC.Text = dgvPhuCap.Rows[vitri].Cells[3].Value.ToString();
            txtSoTien.Text = dgvPhuCap.Rows[vitri].Cells[4].Value.ToString();
            dtpTuNgay.Text = dgvPhuCap.Rows[vitri].Cells[5].Value.ToString();
            dtpDenNgay.Text = dgvPhuCap.Rows[vitri].Cells[6].Value.ToString();
          
        }

        private void ResetValues()
        {

            txtMaPC.Text = "";
            txtLoaiPC.Text = "";
            txtSoTien.Text = "";
          
        }
        public void loadCombo()
        {
            KetNoi.FillCombo("select * from NhanVien", cbMaNV, "MaNV", "TenNV");
          

        }
        
       
        private void cbPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
      

      

        

        private void frmPhuCap_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            loadCombo();
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            string sql;

            DateTime tu = dtpTuNgay.Value;
            DateTime den = dtpDenNgay.Value;

            sql = "INSERT INTO PhuCap(MaPC,MaNV,LoaiPC,TienPC,TuNgay,DenNgay) VALUES (N'" + txtMaPC.Text + "',N'" + cbMaNV.SelectedValue.ToString() + "',N'" + txtLoaiPC.Text + "',N'" + txtSoTien.Text + "',N'" + tu + "',N'" + den+ "')";
            loadCombo();
            kn.EXECUTENONQUERY(sql);
            LoadDataGridView();
            ResetValues();
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            string sql;

            DateTime tu = dtpTuNgay.Value;
            DateTime den = dtpDenNgay.Value;
            sql = @"UPDATE NhanVien SET  MaNV=N'" + cbMaNV.SelectedValue.ToString() +
                    "',LoaiPC=N'" + txtLoaiPC.Text +
                     "',TienPC=N'" + txtSoTien.Text +
                      "',TuNgay=N'" + dtpTuNgay.Text +
                    "',DenNgay='" + dtpDenNgay.Text +
                    "' WHERE MaPC=N'" + txtMaPC.Text + "'";
            loadCombo();
            kn.EXECUTENONQUERY(sql);
            LoadDataGridView();
            ResetValues();
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            string sql;
            sql = "Delete PhuCap Where MaPC='" + txtMaPC.Text + "'";
            kn.EXECUTENONQUERY(sql);
            LoadDataGridView();
            ResetValues();
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
    }
}
