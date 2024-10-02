using QLNhanSu.dangnhap;
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
    public partial class PhongBan : MetroFramework.Forms.MetroForm
    {
        frmDangNhap frmDangNhap = new frmDangNhap();
        KetNoi kn = new KetNoi();
        DataTable tblPB;
        public PhongBan()
        {
            InitializeComponent();
        }

        private void PhongBan_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            if(frmDangNhap.pq=="Nhân Viên")
            {
                btnThem.Enabled = false;    
                btnSua.Enabled = false; 
                btnXoa.Enabled = false;
            }
        }
        public void LoadDataGridView()
        {
            string sql;
            sql = "select * from PhongBan";
            tblPB = kn.GetDataToTable(sql); //lấy dữ liệu
            dgvPhongBan.DataSource = tblPB;
            dgvPhongBan.Columns[0].HeaderText = "Mã phòng ban";
            dgvPhongBan.Columns[1].HeaderText = "Tên phòng ban";
            dgvPhongBan.Columns[0].Width = 150;
            dgvPhongBan.Columns[1].Width = 200;
            dgvPhongBan.AllowUserToAddRows = false;
            dgvPhongBan.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void dgvPhongBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vitri = dgvPhongBan.CurrentCell.RowIndex;
            txtMaPB.Text = dgvPhongBan.Rows[vitri].Cells[0].Value.ToString();
            txtTenPB.Text = dgvPhongBan.Rows[vitri].Cells[1].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "INSERT INTO PhongBan(MaPB,TenPB) VALUES (N'" + txtMaPB.Text + "',N'" + txtTenPB.Text +  "')";
            kn.EXECUTENONQUERY(sql);
            LoadDataGridView();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            sql = @"UPDATE PhongBan SET  TenPB=N'" + txtTenPB.Text +
                    "' WHERE MaPB=N'" + txtMaPB.Text + "'";
            kn.EXECUTENONQUERY(sql);
            LoadDataGridView();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "Delete PhongBan Where MaPB='" + txtMaPB.Text + "'";
            kn.EXECUTENONQUERY(sql);
            LoadDataGridView();
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

        private void button1_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
    }
}
