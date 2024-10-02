using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using Microsoft.AnalysisServices;

namespace QLNhanSu.xuatbaocao
{
    public partial class BaoCaoNhanVien : Form
    {
        KetNoi kn=new KetNoi();
        SqlConnection sqlConn = new SqlConnection("Data Source=DESKTOP-BBNPL2V;Initial Catalog=QLNS;Integrated Security=True");

        public BaoCaoNhanVien()
        {
            InitializeComponent();
        }

        private void BaoCaoNhanVien_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM NhanVien ",sqlConn );

            SqlDataAdapter d2 = new SqlDataAdapter(command);
            DataTable dt2 = new DataTable();
            d2.Fill(dt2);

            rptBaoCaoNV.LocalReport.DataSources.Clear();
            ReportDataSource source1 = new ReportDataSource("BaoCaoNV", dt2);
            rptBaoCaoNV.LocalReport.ReportPath = "BaoCaoNV.rdlc";
            rptBaoCaoNV.LocalReport.DataSources.Add(source1);
            this.rptBaoCaoNV.RefreshReport();
        }

        private void rptBaoCaoNV_Load(object sender, EventArgs e)
        {

        }
    }
}
