using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYNHANSU.GetData
{
    public class clsLayBangChiLuong
    {
        DataService ds = new DataService();

        public DataTable LayBangLuongTheoThangNam(int thang, int nam)
        {
            SqlCommand com = new SqlCommand("select * from bangluong where month(thangchi)='" + thang + "' and year(thangchi)='" + nam + "'");
            ds.Load(com);
            return ds;
        }

        public DataTable LayBangLuong()
        {
            SqlCommand com = new SqlCommand("select * from bangluong");
            ds.Load(com);
            return ds;
        }

        public void CapNhatNgayLamTheoThangNam(int thang,int nam,string manv,int ngaylammoi)
        {
            SqlCommand com = new SqlCommand("update bangluong set ngaylamviec = '" + ngaylammoi + "' where manv = '" + manv + "' and month(thangchi)='"+thang+"'and year(thangchi)='"+nam+"'");
            ds.Load(com);
        }
        public void CapNhatTruLuong(int thang, int nam, string manv, double truluong,double thuclanh)
        {
            SqlCommand com = new SqlCommand("update bangluong set truluong = " + truluong + ",thuclanh="+thuclanh+" where manv = '" + manv + "' and month(thangchi)='" + thang + "'and year(thangchi)='" + nam + "'");
            ds.Load(com);
        }
        public void CapNhatThucLanh(int thang, int nam, string manv, double thuclanh)
        {
            SqlCommand com = new SqlCommand("update bangluong set thuclanh = '" + thuclanh + "' where manv = '" + manv + "' and month(thangchi)='" + thang + "'and year(thangchi)='" + nam + "'");
            ds.Load(com);
        }

        public void CapNhat(string maluong, double tongluong,double thuclanh,double phucapdochai, double trocaptrachnhiem, double trocapantrua, double trocapxanha, double trocapQLDN)
        {
            string query = "update bangluong set phucapdochai=" + phucapdochai + ",trocaptrachnhiem=" + trocaptrachnhiem + ",trocapantrua=" + trocapantrua + ",trocapxanha=" + trocapxanha + ",trocapQLDN=" + trocapQLDN + ",tongluong=" + tongluong + ",thuclanh='" + thuclanh + "' where maluong= '" + maluong + "'";
            SqlCommand com = new SqlCommand(query);
            ds.Load(com);
        }

        public void ThemMoi(string maluong, string thangchi, string manv, int ngaylamviec, double luongthang, double truluong, double phucapchucvu, double phucapdochai, double trocaptrachnhiem, double trocapantrua, double trocapxanha, double trocapQLDN, double tongluong, double BHXH, double BHYT, double doanphi,double thuclanh)
        {
            string query = "insert into bangluong values ('" + maluong + "','" + thangchi + "','" + manv + "'," + ngaylamviec + "," + luongthang + "," + truluong + "," + phucapchucvu + "," + phucapdochai + "," + trocaptrachnhiem + "," + trocapantrua + "," + trocapxanha + "," + trocapQLDN + "," + tongluong + "," + BHXH + "," + BHYT + "," + doanphi + "," + thuclanh + ")";
            SqlCommand com = new SqlCommand(query);
            ds.Load(com);
        }
        public DataTable LayBangChiLuongTheoThangNamPhongBanTheoTenNV(int thang, int nam, string maphong)
        {
            SqlCommand com = new SqlCommand("select * from bangluong,nhanvien where bangluong.manv=nhanvien.manv and month(thangchi)='" + thang + "' and year(thangchi)='" + nam + "'and phongban='" + maphong + "'");
            ds.Load(com);
            return ds;
        }
        public void Xoa(string maluong)
        {
            string query = "delete from bangluong where maluong='" + maluong + "'";
            SqlCommand com = new SqlCommand(query);
            ds.Load(com);
        }
    }
}
