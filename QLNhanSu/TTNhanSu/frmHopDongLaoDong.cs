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
    public partial class frmHopDongLaoDong : MetroFramework.Forms.MetroForm
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
            dgvHDLD.Columns[0].HeaderText = "Mã Hợp đồng";
            dgvHDLD.Columns[1].HeaderText = "Ngày Vào làm";
            dgvHDLD.Columns[2].HeaderText = "Hệ số lương";
            dgvHDLD.Columns[3].HeaderText = "Mã Nhân viên";
            dgvHDLD.Columns[0].Width = 100;
            dgvHDLD.Columns[1].Width = 150;
            dgvHDLD.Columns[2].Width = 100;
            dgvHDLD.Columns[3].Width = 150;
           


            dgvHDLD.AllowUserToAddRows = false;
            dgvHDLD.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vitri = dgvHDLD.CurrentCell.RowIndex;
            txtMaHD.Text = dgvHDLD.Rows[vitri].Cells[0].Value.ToString();
            dtpNgayVaoLam.Text = dgvHDLD.Rows[vitri].Cells[1].Value.ToString();
            cboHeSoLuong.Text = dgvHDLD.Rows[vitri].Cells[2].Value.ToString();
            cboMaNV.Text = dgvHDLD.Rows[vitri].Cells[3].Value.ToString();
            

        }

        private void ResetValues()
        {

            txtMaHD.Text = "";

        }
        public void loadCombo()
        {
            KetNoi.FillCombo("select * from NhanVien", cboMaNV, "MaNV", "TenNV");
            KetNoi.FillCombo("select * from Luong", cboHeSoLuong, "HeSoLuong", "HeSoLuong");


        }
       
        
      


        

        private void frmHopDongLaoDong_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            loadCombo();
        }

        private void btThem_Click_1(object sender, EventArgs e)
        {
            string sql;

            DateTime tu = dtpNgayVaoLam.Value;

            sql = "INSERT INTO HopDong(MaHD,NgayVaoLam,HeSoLuong,MaNV) VALUES (N'" + txtMaHD.Text + "',N'" + tu + "',N'" + cboHeSoLuong.SelectedValue.ToString() + "',N'" + cboMaNV.SelectedValue.ToString() + "')";
            loadCombo();
            kn.EXECUTENONQUERY(sql);
            LoadDataGridView();
            ResetValues();
        }

        private void btSua_Click_1(object sender, EventArgs e)
        {
            string sql;

            DateTime tu = dtpNgayVaoLam.Value;
            sql = @"UPDATE HopDong SET  NgayVaoLam=N'" + tu +
                    "',HeSoLuong=N'" + cboHeSoLuong.SelectedValue.ToString() +
                     "',MaNV=N'" + cboMaNV.SelectedValue.ToString() +
                    "' WHERE MaHD=N'" + txtMaHD.Text + "'";
            loadCombo();
            kn.EXECUTENONQUERY(sql);
            LoadDataGridView();
            ResetValues();
        }

        private void btXoa_Click_1(object sender, EventArgs e)
        {
            string sql;
            sql = "Delete HopDong Where MaHD='" + txtMaHD.Text + "'";
            kn.EXECUTENONQUERY(sql);
            LoadDataGridView();
            ResetValues();
        }

        private void btThoat_Click_1(object sender, EventArgs e)
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
