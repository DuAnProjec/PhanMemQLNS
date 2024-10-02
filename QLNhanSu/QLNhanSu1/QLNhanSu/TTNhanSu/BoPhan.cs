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
    public partial class BoPhan : Form
    {
        KetNoi kn = new KetNoi();
        DataTable tblBP;
        public BoPhan()
        {
            InitializeComponent();
        }
        public void LoadDataGridView()
        {
            string sql;
            sql = "select MaBP,TenBP from BoPhan";
            tblBP = kn.GetDataToTable(sql); //lấy dữ liệu
            dgvBoPhan.DataSource = tblBP;
            dgvBoPhan.Columns[0].HeaderText = "Mã bộ phận";
            dgvBoPhan.Columns[1].HeaderText = "Tên bộ phận";
            dgvBoPhan.Columns[0].Width = 100;
            dgvBoPhan.Columns[1].Width = 150;
            dgvBoPhan.AllowUserToAddRows = false;
            dgvBoPhan.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void dgvBoPhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vitri = dgvBoPhan.CurrentCell.RowIndex;
            txtMaBP.Text =  dgvBoPhan.Rows[vitri].Cells[0].Value.ToString();
            txtTenBP.Text = dgvBoPhan.Rows[vitri].Cells[1].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "INSERT INTO BoPhan(MaBP,TenBP) VALUES (N'" + txtMaBP.Text + "',N'" + txtTenBP.Text + "')";
            kn.EXECUTENONQUERY(sql);
            LoadDataGridView();
        }

        private void BoPhan_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            
            sql = @"UPDATE BoPhan SET  HoNV=N'" + txtTenBP.Text +
                    "' WHERE MaNV=N'" + txtMaBP.Text + "'";
          
            kn.EXECUTENONQUERY(sql);
            LoadDataGridView();
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "Delete BoPhan Where MaBP='" + txtMaBP.Text + "'";
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
