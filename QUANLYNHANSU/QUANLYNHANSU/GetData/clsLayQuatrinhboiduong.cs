using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYNHANSU.GetData
{
    public class clsLayQuatrinhboiduong
    {
        DataService ds = new DataService();

        public DataTable LayQuatrinhboiduong(string manv)
        {
            SqlCommand com = new SqlCommand("select * from quatrinhboiduong where manv='" + manv + "'");
            ds.Load(com);
            return ds;
        }

        public DataTable LayBoiDuong()
        {
            SqlCommand com = new SqlCommand("select * from quatrinhboiduong");
            ds.Load(com);
            return ds;
        }

        public void ThemMoiQTBD(string maboiduong,string manv,string masoquyetdinh, string ngaythem)
        {
            string query = "insert into quatrinhboiduong values ('" + maboiduong + "',null,'" + manv + "','" + masoquyetdinh + "','1/1/2009','1/1/2009',null,null,null,'" + ngaythem + "')";
            SqlCommand com = new SqlCommand(query);
            ds.Load(com);
        }

        public void CapNhatQTBD(string maboiduong, string tenboiduong,string manv, string masoquyetdinh,string ngaybatdau,string ngayketthuc,string chuyennganh,string noidaotao,string ghichu)
        {
            string query = "update quatrinhboiduong set tenboiduong=N'" + tenboiduong + "',manv='"+manv+"',masoquyetdinh='" + masoquyetdinh + "',ngaybatdau='" + ngaybatdau + "',ngayketthuc='" + ngayketthuc + "',chuyennganh=N'" + chuyennganh + "',noidaotao=N'" + noidaotao + "',ghichu=N'" + ghichu + "'where maboiduong='" + maboiduong + "'";
            SqlCommand com = new SqlCommand(query);
            ds.Load(com);
        }
        public void XoaQTBD(string maboiduong)
        {
            string query = "delete from quatrinhboiduong where maboiduong='" + maboiduong + "'";
            SqlCommand com = new SqlCommand(query);
            ds.Load(com);
        }
    }
}
