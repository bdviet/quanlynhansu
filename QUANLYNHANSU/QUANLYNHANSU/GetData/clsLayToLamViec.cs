using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYNHANSU.GetData
{
    class clsLayToLamViec
    {
        DataService ds = new DataService();

        public DataTable LayToLamViec()
        {
            SqlCommand com = new SqlCommand("select * from tolamviec");
            ds.Load(com);
            return ds;
        }

        public DataTable LayToLamViecTheoPhong(string maphong)
        {
            SqlCommand com = new SqlCommand("select * from tolamviec where maphongban='" + maphong + "'");//where maphongban='" + maphong + "'
            ds.Load(com);
            return ds;
        }
        public DataTable LayNhanVienTheoToLamViec(string mato)
        {
            SqlCommand com = new SqlCommand("select * from nhanvien where tophutrach='" + mato + "'");
            ds.Load(com);
            return ds;
        }

        public void XoaToLamViecTheoPhong(string mato)
        {
            SqlCommand com = new SqlCommand("delete tolamviec where mato='" + mato + "'");//where maphongban='" + maphong + "'
            ds.Load(com);
        }
        public DataTable LayToLamViecTheoPhongLoaiTruToXoa(string maphong, string matoxoa)
        {
            SqlCommand com = new SqlCommand("select * from tolamviec where maphongban='" + maphong + "' and mato!='" + matoxoa + "'");
            ds.Load(com);
            return ds;
        }

        public void CapNhat(string mato, string tento, string matotruong, string maphong, string ghichu, string ngaythem)
        {
            SqlCommand com = new SqlCommand("update tolamviec set tento='" + tento + "',matotruong='" + matotruong + "',maphong='" + maphong + "',ghichu='" + ghichu + "',ngaythem='" + ngaythem + "'where maphong ='" + maphong + "'");
            ds.Load(com);
        }
        public void ThemMoi(string mato, string tento, string matotruong, string maphong, string ghichu, string ngaythem)
        {
            SqlCommand com = new SqlCommand("insert into tolamviec values('" + mato + "',N'" + tento + "','" + matotruong + "','" + maphong + "',N'" + ghichu + "','" + ngaythem + "')");
            ds.Load(com);
        }
    }
}
