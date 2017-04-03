using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYNHANSU.GetData
{
    public class clsLayNguoiDung
    {
        DataService ds = new DataService();

        public DataTable LayNguoiDung()
        {
            SqlCommand com = new SqlCommand("select * from nguoidung");
            ds.Load(com);
            return ds;
        }
        public DataTable ThemMoiNguoiDung(string username,string pass,string chophep)
        {
            SqlCommand com = new SqlCommand("insert into nguoidung values ('" + username + "','" + pass + "','" + chophep + "')");
            ds.Load(com);
            return ds;
        }
    }
}
