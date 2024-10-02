using QLNhanSu.dangnhap;
using QLNhanSu.fdChamCong;
using QLNhanSu.fdLuong;
using QLNhanSu.Main;
using QLNhanSu.TimKiem;
using QLNhanSu.TTNhanSu;
using QLNhanSu.xuatbaocao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhanSu
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmDangNhap());
        }
    }
}
