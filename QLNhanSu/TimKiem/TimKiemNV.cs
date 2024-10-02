using QLNhanSu.Main;
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
    public partial class TimKiemNV : MetroFramework.Forms.MetroForm
    {
        private BindingSource bdsource = new BindingSource();

        KetNoi data = new KetNoi();
        SqlConnection sqlConn = new SqlConnection(@"Data Source=DESKTOP-BBNPL2V;Initial Catalog=QLNS;Integrated Security=True");
        public TimKiemNV()
        {
            InitializeComponent();
        }
        public void LoadDataGridView()
        {
            string sql;
            sql = "select * from NhanVien";
            bdsource.DataSource = data.GetDataToTable(sql);
            dgvNhanVien.DataSource = bdsource;
            dgvNhanVien.Columns[0].HeaderText = "Mã nhân viên";
            dgvNhanVien.Columns[1].HeaderText = "Tên nhân viên";
            dgvNhanVien.Columns[2].HeaderText = "Giới tính";
            dgvNhanVien.Columns[3].HeaderText = "Ngày sinh";
            dgvNhanVien.Columns[4].HeaderText = "Điện thoại";
            dgvNhanVien.Columns[5].HeaderText = "Địa chỉ";
            dgvNhanVien.Columns[6].HeaderText = "CCCD";
            dgvNhanVien.Columns[7].HeaderText = "Mã Phòng Ban";
            dgvNhanVien.Columns[8].HeaderText = "Mã Bộ Phận";
            dgvNhanVien.Columns[9].HeaderText = "Mã Chức Vụ";

            dgvNhanVien.Columns[0].Width = 100;
            dgvNhanVien.Columns[1].Width = 150;
            dgvNhanVien.Columns[2].Width = 100;
            dgvNhanVien.Columns[3].Width = 150;
            dgvNhanVien.Columns[4].Width = 100;
            dgvNhanVien.Columns[5].Width = 100;
            dgvNhanVien.Columns[6].Width = 100;
            dgvNhanVien.Columns[7].Width = 100;
            dgvNhanVien.Columns[8].Width = 100;
            dgvNhanVien.Columns[9].Width = 100;

            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbMaNV.Checked)
                {
                    string str = @"select * from NhanVien
                    where MaNV =  '" + txtTimKiem.Text + "'";
                    DataTable data = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(str, sqlConn);
                    adapter.Fill(data);
                    dgvNhanVien.DataSource = data;
                    if (data.Rows.Count > 0)
                    {
                        dgvNhanVien.DataSource = data;
                        MessageBox.Show("Tìm kiếm thành công!");
                    }
                    else
                    {
                        dgvNhanVien.DataSource = null; // Xóa dữ liệu hiển thị
                        MessageBox.Show("Không tìm thấy kết quả!");
                    }
                }
                if (cbTenNV.Checked)
                {
                    string str = @"select * from NhanVien
                    where TenNV = N'" + txtTimKiem.Text + "'";
                    DataTable data = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(str, sqlConn);
                    adapter.Fill(data);
                    dgvNhanVien.DataSource = data;
                    if (data.Rows.Count > 0)
                    {
                        dgvNhanVien.DataSource = data;
                        MessageBox.Show("Tìm kiếm thành công!");
                    }
                    else
                    {
                        dgvNhanVien.DataSource = null; // Xóa dữ liệu hiển thị
                        MessageBox.Show("Không tìm thấy kết quả!");
                    }
                }
            }
            finally
            {
                if (sqlConn != null)
                {
                    sqlConn.Close();
                }
            }
        }

        private void cbMaNV_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMaNV.Checked)
            {
                txtTimKiem.Enabled = cbMaNV.Checked;
                txtTimKiem.Text = "";
            }

        }

        private void cbTenNV_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTenNV.Checked)
            {
                txtTimKiem.Enabled = cbTenNV.Checked;
                txtTimKiem.Text = "";
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vitri=dgvNhanVien.CurrentCell.RowIndex;
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
    }
}
