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

namespace QLNhanSu.fdChamCong
{
    public partial class frmChamCong : MetroFramework.Forms.MetroForm
    {
        KetNoi kn = new KetNoi();
        DataTable tblNV;
        private BindingSource bdsource = new BindingSource();
        public frmChamCong()
        {
            InitializeComponent();
        }
        public void LoadDataGridView()
        {
            string sql;
            sql = "select * from ChamCong";
            tblNV = kn.GetDataToTable(sql); //lấy dữ liệu
            dgvChamCong.DataSource = tblNV;
            dgvChamCong.Columns[0].HeaderText = "Mã Chấm Công";

            dgvChamCong.Columns[1].HeaderText = "Mã Nhân Viên";
            dgvChamCong.Columns[2].HeaderText = "Tình Trạng";
            dgvChamCong.Columns[3].HeaderText = "Ngày Chấm Công";
            dgvChamCong.Columns[0].Width = 100;
            dgvChamCong.Columns[1].Width = 150;
            dgvChamCong.Columns[2].Width = 100;
            dgvChamCong.Columns[3].Width = 100;

            dgvChamCong.AllowUserToAddRows = false;
            dgvChamCong.EditMode = DataGridViewEditMode.EditProgrammatically;

        }
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vitri = dgvChamCong.CurrentCell.RowIndex;
            txtMaChamCong.Text = dgvChamCong.Rows[vitri].Cells[0].Value.ToString();
            cbMaNV.Text = dgvChamCong.Rows[vitri].Cells[1].Value.ToString();
            dtpNgayChamcong.Text = dgvChamCong.Rows[vitri].Cells[3].Value.ToString();
            cbTinhTrang.Text = dgvChamCong.Rows[vitri].Cells[2].Value.ToString();
            

        }
      
        public void loadcombo()
        {
            KetNoi.FillCombo("select * from NhanVien", cbMaNV, "MaNV", "TenNV");

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string sql,check;
            DateTime dt = dtpNgayChamcong.Value;

            check = "SELECT COUNT(*) FROM ChamCong WHERE MaNV = N'" + cbMaNV.SelectedValue.ToString() + "' AND NgayChamCong = N'" + dt.ToString("yyyy-MM-dd") + "'";
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-BBNPL2V;Initial Catalog=QLNS;Integrated Security=True"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(check, connection))
                {
                    command.Parameters.AddWithValue("MaNV", cbMaNV.SelectedValue.ToString());
                    command.Parameters.AddWithValue("NgayChamCong", dt.ToString("yyyy-MM-dd"));
                    int existingRecords = (int)command.ExecuteScalar();

                    if (existingRecords > 0)
                    {
                        MessageBox.Show("Dữ liệu đã tồn tại cho mã nhân viên và ngày chấm công đã chọn. Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        sql = "INSERT INTO ChamCong(MaChamCong,MaNV,TinhTrang,NgayChamCong) VALUES (N'" + txtMaChamCong.Text + "',N'" + cbMaNV.SelectedValue.ToString() + "',N'" + cbTinhTrang.SelectedItem.ToString() + "',N'" + dt + "')";
                        loadcombo();
                        kn.EXECUTENONQUERY(sql);
                        LoadDataGridView();
                    }
                }
            }
                
            
        }
        private void frmChamCong_Load(object sender, EventArgs e)
        {
            loadcombo();
            cbTinhTrang.Items.Add("Có làm");
            cbTinhTrang.Items.Add("Nghỉ có phép");
            cbTinhTrang.Items.Add("Có làm");
            cbTinhTrang.SelectedIndex = 0; // Chọn "Có làm" làm giá trị mặc định
            LoadDataGridView();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            MessageBox.Show("Đã xóa thành công", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Error);
            sql = "Delete ChamCong Where MaChamCong='" + txtMaChamCong.Text + "'";
            kn.EXECUTENONQUERY(sql);
            LoadDataGridView();
        }
    }
    
}
