using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYNHANSU.GetData
{
    public class clsLayHistory
    {
        DataService ds = new DataService();

        public DataTable LayHistory()
        {
            SqlCommand com = new SqlCommand("select * from lichsuthaotac");
            ds.Load(com);
            return ds;
        }
        public void Them(string ma, string ngay, string noidung)
        {
            SqlCommand com = new SqlCommand("insert into lichsuthaotac values('" + ma + "','" + ngay + "',N'" + noidung + "')");
            ds.Load(com);
        }
        public void Xoa(string ma)
        {
            SqlCommand com = new SqlCommand("delete from lichsuthaotac where stt='" + ma + "'");
            ds.Load(com);
        }
        public void XoaHet()
        {
            SqlCommand com = new SqlCommand("delete from lichsuthaotac");
            ds.Load(com);
        }
    }
}
