using Microsoft.ReportingServices.Diagnostics.Internal;
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

namespace QLNhanSu.fdLuong
{
    public partial class frmBangLuong : Form
    {
        public frmBangLuong()
        {
            InitializeComponent();
        }
        //KetNoi kn = new KetNoi();
        //SqlDataReader dr;
        //DataTable dt = new DataTable();
        //int thang = DateTime.Now.Month, nam = DateTime.Now.Year, ngay = DateTime.Now.Day, luongcoban = 0, tongluong = 0, tienthuong = 0, tienphat = 0, phucap = 0, m = 0;
        //string manv = null, songaylam = null, songaynghicophep = null, songaynghikhongphep = null, chucvu = null;
        //private void load()
        //{
        //    DateTime ngaydau, ngaycuoi;
        //    songaylam = "0"; luongcoban = 0; tongluong = 0; tienthuong = 0; tienphat = 0; phucap = 0;
        //    if (m == 0)
        //    {
        //        ngaydau = Convert.ToDateTime(thang + "/" + "01/" + nam);
        //        ngaycuoi = Convert.ToDateTime(thang + "/" + "30/" + nam);
        //    }
        //    else
        //    {
        //        ngaydau = Convert.ToDateTime(txtThang.Text + "/" + "01/" + cboNam.Text);
        //        ngaycuoi = Convert.ToDateTime(txtThang.Text + "/" + "30/" + cboNam.Text);
        //    }
          
        //    dt.Clear();
        //    //dt = kn.TongLuongNV("0");
        //    dgvBangLuong.DataSource = dt;
        //    for (int i = 0; i < dgvBangLuong.RowCount; i++)
        //    {
        //        manv = dgvBangLuong.Rows[i].Cells["Ma"].Value.ToString();
        //        dgvBangLuong.Rows[i].Cells["SNL"].Value = LaySoNgayLam(manv, ngaydau, ngaycuoi);
        //        dgvBangLuong.Rows[i].Cells["T"].Value = TienThuong(manv, ngaydau, ngaycuoi);
        //        dgvBangLuong.Rows[i].Cells["P"].Value = TienPhat(manv, ngaydau, ngaycuoi);
        //        dgvBangLuong.Rows[i].Cells["PhuCap"].Value = tienPhuCap(manv, ngaycuoi);
        //        tongluong = TinhLuong1(manv, songaylam, tienthuong.ToString(), tienphat.ToString(), ngaydau, ngaycuoi);
        //        dgvBangLuong.Rows[i].Cells["TL"].Value = String.Format("{0:0,0}", tongluong);
        //        //MessageBox.Show(songaylam + "\n" + tienthuong + "\n" + tienphat + "\n" + tongluong.ToString());

        //    }


        }
    }

