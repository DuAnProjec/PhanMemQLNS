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
    public partial class ChucVu : Form
    {
        KetNoi kn = new KetNoi();
        DataTable tblCV;
        public ChucVu()
        {
            InitializeComponent();
        }
        public void LoadDataGridView()
        {
            string sql;
            sql = "select MaCV,TenCV from ChucVu";
            tblCV = kn.GetDataToTable(sql); //lấy dữ liệu
            dgvChucVu.DataSource = tblCV;
            dgvChucVu.Columns[0].HeaderText = "Mã chức vụ";
            dgvChucVu.Columns[1].HeaderText = "Tên chức vụ";
            dgvChucVu.Columns[0].Width = 100;
            dgvChucVu.Columns[1].Width = 150;
            dgvChucVu.AllowUserToAddRows = false;
            dgvChucVu.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void dgvChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vitri = dgvChucVu.CurrentCell.RowIndex;
            txtMaCV.Text = dgvChucVu.Rows[vitri].Cells[0].Value.ToString();
            txtTenCV.Text = dgvChucVu.Rows[vitri].Cells[1].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "INSERT INTO ChucVu(MaCV,TenCV) VALUES (N'" + txtMaCV.Text + "',N'" + txtTenCV.Text + "')";
            kn.EXECUTENONQUERY(sql);
            LoadDataGridView();
        }

        private void ChucVu_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            sql = @"UPDATE ChucVu SET  TenCV=N'" + txtTenCV.Text +
                    "' WHERE MaCV=N'" + txtMaCV.Text + "'";
            kn.EXECUTENONQUERY(sql);
            LoadDataGridView();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "Delete BoPhan Where MaBP='" + txtMaCV.Text + "'";
            kn.EXECUTENONQUERY(sql);
            LoadDataGridView();
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
