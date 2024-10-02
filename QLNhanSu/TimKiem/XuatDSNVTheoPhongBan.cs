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
    public partial class XuatDSNVTheoPhongBan : MetroFramework.Forms.MetroForm
    {
        public XuatDSNVTheoPhongBan()
        {
            InitializeComponent();
        }
        private BindingSource bdsource = new BindingSource();

        KetNoi data = new KetNoi();
        SqlConnection sqlConn = new SqlConnection("Data Source=DESKTOP-BBNPL2V;Initial Catalog=QLNS;Integrated Security=True");

        private void XuatDSNVTheoPhongBan_Load(object sender, EventArgs e)
        {
            KetNoi.FillCombo("select * from PhongBan", cbPhongBan, "MaPB", "TenPB");

        }
        public void LoadDataGridView()
        {
            string sql;
            sql = "select * from NhanVien NV join PhongBan PB on NV.MaPB=PB.MaPB";
            bdsource.DataSource = data.GetDataToTable(sql);
            dgvDSPB.DataSource = bdsource;
            dgvDSPB.Columns[0].HeaderText = "Mã nhân viên";
            dgvDSPB.Columns[1].HeaderText = "Tên nhân viên";
            dgvDSPB.Columns[2].HeaderText = "Giới tính";
            dgvDSPB.Columns[3].HeaderText = "Ngày sinh";
            dgvDSPB.Columns[4].HeaderText = "Điện thoại";
            dgvDSPB.Columns[5].HeaderText = "Địa chỉ";
            dgvDSPB.Columns[6].HeaderText = "CCCD";
            dgvDSPB.Columns[7].HeaderText = "Tên Phòng Ban";
            dgvDSPB.Columns[0].Width = 100;
            dgvDSPB.Columns[1].Width = 150;
            dgvDSPB.Columns[2].Width = 100;
            dgvDSPB.Columns[3].Width = 150;
            dgvDSPB.Columns[4].Width = 100;
            dgvDSPB.Columns[5].Width = 100;
            dgvDSPB.Columns[6].Width = 100;
            dgvDSPB.Columns[7].Width = 100;


            dgvDSPB.AllowUserToAddRows = false;
            dgvDSPB.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string str = @"select MaNV, TenNV, GioiTinh,NgaySinh,SDT,DiaChi,CCCD,
                PB.TenPB from NhanVien NV join PhongBan PB on NV.MaPB=PB.MaPB
                 where PB.MaPB='" + cbPhongBan.SelectedValue.ToString() + "'";

                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(str, sqlConn);
                adapter.Fill(data);
                LoadDataGridView();
                int sl = data.Rows.Count;
                MessageBox.Show("Có " + sl + "nhân viên thuộc bộ phận" + cbPhongBan.SelectedValue.ToString());
            }
            finally
            {
                if (sqlConn != null)
                {
                    sqlConn.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
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
