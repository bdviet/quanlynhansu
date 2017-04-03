using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYNHANSU.GetData
{
    public class clsLayKhenThuong
    {
        DataService ds = new DataService();

        public DataTable LayKhenThuong()
        {
            SqlCommand com = new SqlCommand("select * from khenthuong");//where maphongban='" + maphong + "'
            ds.Load(com);
            return ds;
        }

        public DataTable LayKhenThuongTheoNhanVien(string manv)
        {
            SqlCommand com = new SqlCommand("select * from khenthuong where manv='" + manv + "'");//where maphongban='" + maphong + "'
            ds.Load(com);
            return ds;
        }

        public void ThemMoiKhenThuong(string makhenthuongg, string manv, string masoquyetdinh, string ngaykhen,string ngaythem)
        {
            string query = "insert into khenthuong values ('" + makhenthuongg + "','" + masoquyetdinh + "','" + manv + "',null,null,'" + ngaykhen + "',null,'" + ngaythem + "')";
            SqlCommand com = new SqlCommand(query);
            ds.Load(com);
        }

        public void CapNhatKhenThuong(string makhenthuongg, string masoquyetdinh,string manv, string lydo,string hinhthuc,string ngaykhen, string ghichu)
        {
            string query = "update khenthuong set masoquyetdinh='" + masoquyetdinh + "',manv='"+manv+"',lydokhen=N'" + lydo + "',hinhthuc=N'" + hinhthuc + "',ngaykhen='" + ngaykhen + "',ghichu=N'" + ghichu + "'where makhenthuong='" + makhenthuongg + "'";
            SqlCommand com = new SqlCommand(query);
            ds.Load(com);
        }
        public void Xoa(string ma)
        {
            string query = "delete from khenthuong where makhenthuong='" + ma + "'";
            SqlCommand com = new SqlCommand(query);
            ds.Load(com);
        }
    }
}
