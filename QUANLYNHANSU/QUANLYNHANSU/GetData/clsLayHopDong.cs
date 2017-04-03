using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYNHANSU.GetData
{
    public class clsLayHopDong
    {
        DataService ds = new DataService();

        public DataTable LayHopDong()
        {
            SqlCommand com = new SqlCommand("select * from hopdong");
            ds.Load(com);
            return ds;
        }
        public DataTable LayHopDongTheoNhanVien(string manv)
        {
            SqlCommand com = new SqlCommand("select * from hopdong where manv='" + manv + "'");//where maphongban='" + maphong + "'
            ds.Load(com);
            return ds;
        }

        public void ThemMoiHopDong(string mahopdong, string manv, string ngaybatdau,string ngayketthuc,int lanky,string noidung,string ngayky,string nguoiky,string ghichu, string ngaythem)
        {
            string query = "insert into hopdong values ('" + mahopdong + "','" + manv + "','" + ngaybatdau + "','" + ngayketthuc + "'," + lanky + ",null,'" + ngayky + "','" + nguoiky + "',null,'" + ngaythem + "')";
            SqlCommand com = new SqlCommand(query);
            ds.Load(com);
        }

        public void CapNhatHopDong(string mahopdong, string manv, string ngaybatdau, string ngayketthuc, int lanky, string noidung, string ngayky, string nguoiky, string ghichu)
        {
            string query = "update hopdong set manv='" + manv + "',ngaybatdau='" + ngaybatdau + "',ngayketthuc='" + ngayketthuc + "',lanky=" + lanky + ",noidung=N'" + noidung + "',ngayky='" + ngayky + "',manguoiky='" + nguoiky + "',ghichu=N'" + ghichu + "' where mahopdong='" + mahopdong + "'";
            SqlCommand com = new SqlCommand(query);
            ds.Load(com);
        }
        public void Xoa(string ma)
        {
            string query = "delete from hopdong where mahopdong='" + ma + "'";
            SqlCommand com = new SqlCommand(query);
            ds.Load(com);
        }
    }
}
