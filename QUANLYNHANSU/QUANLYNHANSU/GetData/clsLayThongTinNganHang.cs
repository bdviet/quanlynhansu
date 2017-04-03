using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYNHANSU.GetData
{
    public class clsLayThongTinNganHang
    {
        DataService ds = new DataService();

        public DataTable LayThongTinNganHang()
        {
            SqlCommand com = new SqlCommand("select * from thongtinnganhang");//where maphongban='" + maphong + "'
            ds.Load(com);
            return ds;
        }

        public void CapNhat()
        {
            ds.Update();
        }
    }
}
