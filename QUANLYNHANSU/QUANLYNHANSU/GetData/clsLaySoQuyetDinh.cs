using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYNHANSU.GetData
{
    class clsLaySoQuyetDinh
    {
        DataService ds = new DataService();

        public DataTable LaySQD()
        {
            SqlCommand com = new SqlCommand("select * from soquyetdinh");
            ds.Load(com);
            return ds;
        }

        public void ThemSQD(string masqd, string loaiqd, string ngayqd, string nguoiqd, string ngaythemqd)
        {
            string query = "insert into soquyetdinh values('" + masqd + "','" + loaiqd + "','" + ngayqd + "',null,'" + nguoiqd + "',null,'" + ngaythemqd + "')";
            SqlCommand com = new SqlCommand(query);
            ds.Load(com);
        }

        public DataTable LaySQDTheoMa(string ma)
        {
            string query = "select * from soquyetdinh where loaiquyetdinh like '%" + ma + "%'";
            SqlCommand com = new SqlCommand(query);
            ds.Load(com);
            return ds;
        }

        public void CapNhat()
        {
            ds.Update();
        }
    }
}
