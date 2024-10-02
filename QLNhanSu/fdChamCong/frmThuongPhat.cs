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
    public partial class frmThuongPhat : MetroFramework.Forms.MetroForm
    {
        public frmThuongPhat()
        {
            InitializeComponent();
        }
        KetNoi kn = new KetNoi();
        DataTable tblTP;
        private BindingSource bdsource = new BindingSource();
        public void LoadDataGridView()
        {
            string sql;
            sql = "select * from ThuongPhat";
            tblTP = kn.GetDataToTable(sql); //lấy dữ liệu
            dgvThuongPhat.DataSource = tblTP;
            dgvThuongPhat.Columns[0].HeaderText = "Mã Thưởng/ Phạt";
            dgvThuongPhat.Columns[1].HeaderText = "Mã Nhân Viên";
            dgvThuongPhat.Columns[2].HeaderText = "Loại";
            dgvThuongPhat.Columns[3].HeaderText = "Tiền Thưởng/ Phạt";
            dgvThuongPhat.Columns[4].HeaderText = "Lý Do";
            dgvThuongPhat.Columns[5].HeaderText = "Ngày";


            dgvThuongPhat.Columns[0].Width = 100;
            dgvThuongPhat.Columns[1].Width = 150;
            dgvThuongPhat.Columns[2].Width = 100;
            dgvThuongPhat.Columns[3].Width = 150;
            dgvThuongPhat.Columns[4].Width = 100;
            dgvThuongPhat.Columns[5].Width = 100;


            dgvThuongPhat.AllowUserToAddRows = false;
            dgvThuongPhat.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void dgvThuongPhat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vitri = dgvThuongPhat.CurrentCell.RowIndex;
            txtMaTP.Text = dgvThuongPhat.Rows[vitri].Cells[0].Value.ToString();
            cboMaNV.Text = dgvThuongPhat.Rows[vitri].Cells[1].Value.ToString();
            if (dgvThuongPhat.CurrentRow.Cells[2].Value.ToString() == "Thưởng")
            {
                cbThuong.Checked = true;
                cbPhat.Checked = false;
            }
            else
            {
                cbPhat.Checked = true;
                cbThuong.Checked = false;
            }
            txtSoTien.Text = dgvThuongPhat.Rows[vitri].Cells[3].Value.ToString();
            txtLyDo.Text = dgvThuongPhat.Rows[vitri].Cells[4].Value.ToString();
            dtpNgayTP.Text = dgvThuongPhat.Rows[vitri].Cells[5].Value.ToString();
        }
        private void ResetValues()
        {

            txtMaTP.Text = "";
            cbThuong.Checked = false;
            cbPhat.Checked=false;
            txtSoTien.Text = "";
            txtLyDo.Text = "";
        }
        public void loadCombo()
        {
            KetNoi.FillCombo("select * from NhanVien", cboMaNV, "MaNV", "TenNV");

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql, loa;
            if (cbThuong.Checked == true && cbPhat.Checked == false)
                loa = "Thưởng";
            else if (cbThuong.Checked == false && cbPhat.Checked == true)
                loa = "Phạt";
            else
                loa = "Rỗng";
            DateTime dt = dtpNgayTP.Value;
            sql = "INSERT INTO ThuongPhat(MaTP,MaNV,Loai,TienTP,LyDo,Ngay) VALUES (N'" + txtMaTP.Text + "',N'" + cboMaNV.SelectedValue.ToString() + "',N'" + loa + "',N'" + txtSoTien.Text + "',N'" + txtLyDo.Text + "',N'" + dt + "')";
            loadCombo();
            kn.EXECUTENONQUERY(sql);
            LoadDataGridView();
            ResetValues();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql, loa;
            if (cbThuong.Checked == true && cbPhat.Checked == false)
                loa = "Thưởng";
            else if (cbThuong.Checked == false && cbPhat.Checked == true)
                loa = "Phạt";
            else
                loa = "Rỗng";
            DateTime dt = dtpNgayTP.Value;
            sql = "UPDATE ThuongPhat SET  MaNV=N'" + cboMaNV.SelectedValue.ToString() +
                  "',Loai=N'" + loa +
                   "',TienTP=N'" + txtSoTien.Text +
                    "',LyDo=N'" + txtLyDo.Text +
                  "',NgayTP='" + dtpNgayTP.Text +
                  "' WHERE MaTP=N'" + txtMaTP.Text + "'";
            loadCombo();
            kn.EXECUTENONQUERY(sql);
            LoadDataGridView();
            ResetValues();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "Delete ThuongPhat Where MaTP='" + txtMaTP.Text + "'";
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

        private void frmThuongPhat_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            loadCombo();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
