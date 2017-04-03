using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace QUANLYNHANSU.GetData
{
    public class clsLayChuyenNhanVien
    {
        DataService ds = new DataService();

        public DataTable LayChuyenNhanVien()
        {
            SqlCommand com = new SqlCommand("select * from chuyennhanvien");//where maphongban='" + maphong + "'
            ds.Load(com);
            return ds;
        }

        public void ThemMoiChuyen(string machuyennv, string manv, string masoquyetdinh, string ngaychuyen, string tronghayngoai, string donviden,string maphongmoi,string ghichu, string ngaythem)
        {
            string query = "insert into chuyennhanvien values ('" + machuyennv + "','" + manv + "','" + masoquyetdinh + "','" + ngaychuyen + "',N'" + tronghayngoai + "',N'" + donviden + "','" + maphongmoi + "',N'" + ghichu + "','" + ngaythem + "')";
            SqlCommand com = new SqlCommand(query);
            ds.Load(com);
        }

        public void CapNhatChuyen(string machuyennv, string manv, string masoquyetdinh, string ngaychuyen, string tronghayngoai, string donviden, string maphongmoi, string ghichu)
        {
            string query = "update chuyennhanvien set manv='" + manv + "',masoquyetdinh='" + masoquyetdinh + "',ngaychuyen='" + ngaychuyen + "',tronghayngoai=N'" + tronghayngoai + "',donviden=N'" + donviden + "',maphongmoi='" + maphongmoi + "',ghichu=N'" + ghichu + "'";
            SqlCommand com = new SqlCommand(query);
            ds.Load(com);
        }
    }
}
