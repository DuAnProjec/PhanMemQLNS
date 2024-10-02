using Microsoft.Reporting.WinForms;
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

namespace QLNhanSu.xuatbaocao
{
    public partial class BaoCaoPhuCap : Form
    {
        KetNoi kn = new KetNoi();
        SqlConnection sqlConn = new SqlConnection("Data Source=DESKTOP-BBNPL2V;Initial Catalog=QLNS;Integrated Security=True");
        public BaoCaoPhuCap()
        {
            InitializeComponent();
        }

        private void BaoCaoPhuCap_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM PhuCap ", sqlConn);

            SqlDataAdapter d2 = new SqlDataAdapter(command);
            DataTable dt2 = new DataTable();
            d2.Fill(dt2);

            rptPhuCap.LocalReport.DataSources.Clear();
            ReportDataSource source1 = new ReportDataSource("DataPhuCap", dt2);
            rptPhuCap.LocalReport.ReportPath = "BaoCaoPhuCap.rdlc";
            rptPhuCap.LocalReport.DataSources.Add(source1);
            this.rptPhuCap.RefreshReport();
        }
    }
}
