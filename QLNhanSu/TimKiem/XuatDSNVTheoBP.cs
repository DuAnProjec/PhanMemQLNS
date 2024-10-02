using QLNhanSu.Main;
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
    public partial class XuatDSNVTheoBP : MetroFramework.Forms.MetroForm
    {
        public XuatDSNVTheoBP()
        {
            InitializeComponent();
        }
        private BindingSource bdsource = new BindingSource();

        KetNoi data = new KetNoi();
        SqlConnection sqlConn = new SqlConnection("Data Source=DESKTOP-BBNPL2V;Initial Catalog=QLNS;Integrated Security=True");

        private void XuatDSNVTheoBP_Load(object sender, EventArgs e)
        {
            KetNoi.FillCombo("select * from BoPhan", cbBoPhan, "MaBP", "TenBP");

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vitri=dgvTimKiemBP.CurrentCell.RowIndex;

        }
        public void LoadDataGridView()
        {
            string sql;
            sql = "select * from NhanVien NV join BoPhan BP on NV.MaBP=BP.MaBP";
            bdsource.DataSource = data.GetDataToTable(sql);
            dgvTimKiemBP.DataSource = bdsource;
            dgvTimKiemBP.Columns[0].HeaderText = "Mã nhân viên";
            dgvTimKiemBP.Columns[1].HeaderText = "Tên nhân viên";
            dgvTimKiemBP.Columns[2].HeaderText = "Giới tính";
            dgvTimKiemBP.Columns[3].HeaderText = "Ngày sinh";
            dgvTimKiemBP.Columns[4].HeaderText = "Điện thoại";
            dgvTimKiemBP.Columns[5].HeaderText = "Địa chỉ";
            dgvTimKiemBP.Columns[6].HeaderText = "CCCD";
            dgvTimKiemBP.Columns[7].HeaderText = "Tên Bộ Phận";
            dgvTimKiemBP.Columns[0].Width = 100;
            dgvTimKiemBP.Columns[1].Width = 150;
            dgvTimKiemBP.Columns[2].Width = 100;
            dgvTimKiemBP.Columns[3].Width = 150;
            dgvTimKiemBP.Columns[4].Width = 100;
            dgvTimKiemBP.Columns[5].Width = 100;
            dgvTimKiemBP.Columns[6].Width = 100;
            dgvTimKiemBP.Columns[7].Width = 100;


            dgvTimKiemBP.AllowUserToAddRows = false;
            dgvTimKiemBP.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void btnXuatDS_Click(object sender, EventArgs e)
        {
            try
            {
                string str = @"select MaNV, TenNV, GioiTinh,NgaySinh,SDT,DiaChi,CCCD,
                BP.TenBP from NhanVien NV join BoPhan BP on NV.MaBP=BP.MaBP
                 where BP.MaBP='" + cbBoPhan.SelectedValue.ToString() + "'";
                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(str, sqlConn);
                adapter.Fill(data);
                LoadDataGridView();
                int sl=data.Rows.Count;
                MessageBox.Show("Có " + sl + "nhân viên thuộc bộ phận" + cbBoPhan.SelectedValue.ToString());
            }
            finally
            {
                if (sqlConn != null)
                {
                    sqlConn.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
