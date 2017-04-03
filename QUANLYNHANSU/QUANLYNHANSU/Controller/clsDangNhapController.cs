using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QUANLYNHANSU.GetData;

namespace QUANLYNHANSU.Controller
{
    public class clsDangNhapController
    {
        clsLayNguoiDung nguoidung = new clsLayNguoiDung();

        DataTable dtNDung = new DataTable();

        public bool TestDangNhap(string username, string password)
        {
            bool dn = false;
            dtNDung = nguoidung.LayNguoiDung();

            foreach (DataRow dr in dtNDung.Rows)
            {
                if (username == dr["username"].ToString())
                {
                    if (password == dr["pass"].ToString())
                    {
                        dn = true;
                        break;
                    }
                }
            }
            return dn;
        }
    }
}
