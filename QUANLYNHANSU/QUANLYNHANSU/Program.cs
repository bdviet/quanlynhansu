using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QUANLYNHANSU
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DataService.OpenConnection();
            Application.Run(new frmChinh());
            //Application.Run(new frmBangChamCong());
            //Application.Run(new frmDotPhongVan());
            //Application.Run(new frmHistory());
            //Application.Run(new frmBangChiLuong());
            //Application.Run(new frmNhanVien());
            //Application.Run(new frmrptChiLuong());
            //Application.Run(new frmChuyenNhanVien());
            //Application.Run(new frmImportExcel());
            //Application.Run(new frmKiemTraKetNoi());
            //Application.Run(new frmThongTinUngVien());
            //Application.Run(new frmPhongBan());
            DataService.CloseConnection();
        }
    }
}