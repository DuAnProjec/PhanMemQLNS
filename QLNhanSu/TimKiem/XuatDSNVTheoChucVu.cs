using QLNhanSu.TTNhanSu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhanSu.TimKiem
{
    public partial class XuatDSNVTheoChucVu : MetroFramework.Forms.MetroForm
    {
        public XuatDSNVTheoChucVu()
        {
            InitializeComponent();
        }
        private BindingSource bdsource = new BindingSource();

        KetNoi data = new KetNoi();
        SqlConnection sqlConn = new SqlConnection("Data Source=DESKTOP-BBNPL2V;Initial Catalog=QLNS;Integrated Security=True");
        private void XuatDSNVTheoChucVu_Load(object sender, EventArgs e)
        {
            KetNoi.FillCombo("select * from ChucVu", cboChucVu, "MaCV", "TenCV");

        }
        public void LoadDataGridView()
        {
            string sql;
            sql = "select * from NhanVien NV join ChucVu CV on NV.MaCV=CV.MaCV";
            bdsource.DataSource = data.GetDataToTable(sql);
            dgvXemNVCV.DataSource = bdsource;
            dgvXemNVCV.Columns[0].HeaderText = "Mã nhân viên";
            dgvXemNVCV.Columns[1].HeaderText = "Tên nhân viên";
            dgvXemNVCV.Columns[2].HeaderText = "Giới tính";
            dgvXemNVCV.Columns[3].HeaderText = "Ngày sinh";
            dgvXemNVCV.Columns[4].HeaderText = "Điện thoại";
            dgvXemNVCV.Columns[5].HeaderText = "Địa chỉ";
            dgvXemNVCV.Columns[6].HeaderText = "CCCD";
            dgvXemNVCV.Columns[7].HeaderText = "Tên Bộ Phận";
            dgvXemNVCV.Columns[0].Width = 100;
            dgvXemNVCV.Columns[1].Width = 150;
            dgvXemNVCV.Columns[2].Width = 100;
            dgvXemNVCV.Columns[3].Width = 150;
            dgvXemNVCV.Columns[4].Width = 100;
            dgvXemNVCV.Columns[5].Width = 100;
            dgvXemNVCV.Columns[6].Width = 100;
            dgvXemNVCV.Columns[7].Width = 100;


            dgvXemNVCV.AllowUserToAddRows = false;
            dgvXemNVCV.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void btnXemDS_Click(object sender, EventArgs e)
        {
            try
            {
                string str = @"select MaNV, TenNV, GioiTinh,NgaySinh,SDT,DiaChi,CCCD,
                CV.TenCV from NhanVien NV join ChucVu CV on NV.MaCV=CV.MaCV
                 where CV.MaCV='" + cboChucVu.SelectedValue.ToString() + "'";
                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(str, sqlConn);
                adapter.Fill(data);
                LoadDataGridView();
                int sl = data.Rows.Count;
                MessageBox.Show("Có " + sl + "nhân viên thuộc bộ phận" + cboChucVu.SelectedValue.ToString());
            }
            finally
            {
                if (sqlConn != null)
                {
                    sqlConn.Close();
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = (MessageBox.Show("Bạn có muốn thoát ?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Information));
            if (thongbao == DialogResult.Yes)
            {
                NhanVien main = new NhanVien();
                this.Close();
                this.Hide();
                main.ShowDialog();
            }
        }
    }
}
