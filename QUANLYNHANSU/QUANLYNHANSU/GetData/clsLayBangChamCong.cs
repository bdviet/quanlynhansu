using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYNHANSU.GetData
{
    public class clsLayBangChamCong
    {
        DataService ds = new DataService();

        public DataTable LayBangChamCongTheoThangNam(int thang,int nam)
        {
            SqlCommand com = new SqlCommand("select * from bangchamcong where month(thangchamcong)='" + thang + "' and year(thangchamcong)='" + nam + "'");
            ds.Load(com);
            return ds;
        }
        public DataTable LayBangChamCongRong()
        {
            SqlCommand com = new SqlCommand("select * from bangchamcong where machamcong=''");
            ds.Load(com);
            return ds;
        }
        public DataTable LayBangChamCongTheoThangNamPhongBanTheoTenNV(int thang, int nam,string maphong)
        {
            SqlCommand com = new SqlCommand("select * from bangchamcong,nhanvien where bangchamcong.manv=nhanvien.manv and month(thangchamcong)='" + thang + "' and year(thangchamcong)='" + nam + "'and phongban='" + maphong + "'");
            ds.Load(com);
            return ds;
        }


        public DataTable LayBangChamCongTheoNamCuaNhanVien(int nam,string manv)
        {
            SqlCommand com = new SqlCommand("select * from bangchamcong where year(thangchamcong)='" + nam + "' and manv = '" + manv + "'");
            ds.Load(com);
            return ds;
        }

        public DataTable LayBangChamCong()
        {
            SqlCommand com = new SqlCommand("select * from bangchamcong");
            ds.Load(com);
            return ds;
        }

        public void CapNhat(string machamcong,string ngay1, string ngay2, string ngay3, string ngay4, string ngay5, string ngay6, string ngay7, string ngay8, string ngay9, string ngay10, string ngay11, string ngay12, string ngay13, string ngay14, string ngay15, string ngay16, string ngay17, string ngay18, string ngay19, string ngay20, string ngay21, string ngay22, string ngay23, string ngay24, string ngay25, string ngay26, string ngay27, string ngay28, string ngay29, string ngay30, string ngay31,int ngaydilam,int ngayvang)
        {
            string query = "update bangchamcong set ngay1='" + ngay1 + "',ngay2='" + ngay2 + "',ngay3='" + ngay3 + "',ngay4='" + ngay4 + "',ngay5='" + ngay5 + "',ngay6='" + ngay6 + "',ngay7='" + ngay7 + "',ngay8='" + ngay8 + "',ngay9='" + ngay9 + "',ngay10='" + ngay10 + "',ngay11='" + ngay11 + "',ngay12='" + ngay12 + "',ngay13='" + ngay13 + "',ngay14='" + ngay14 + "',ngay15='" + ngay15 + "',ngay16='" + ngay16 + "',ngay17='" + ngay17 + "',ngay18='" + ngay18 + "',ngay19='" + ngay19 + "',ngay20='" + ngay20 + "',ngay21='" + ngay21 + "',ngay22='" + ngay22 + "',ngay23='" + ngay23 + "',ngay24='" + ngay24 + "',ngay25='" + ngay25 + "',ngay26='" + ngay26 + "',ngay27='" + ngay27 + "',ngay28='" + ngay28 + "',ngay29='" + ngay29 + "',ngay30='" + ngay30 + "',ngay31='" + ngay31 + "',ngaydilam='"+ngaydilam+"',vang='"+ngayvang+"' where machamcong= '" + machamcong + "'";
            SqlCommand com = new SqlCommand(query);
            ds.Load(com);
        }

        public void ThemMoi(string machamcong,string thang,string manv, string ngay1, string ngay2, string ngay3, string ngay4, string ngay5, string ngay6, string ngay7, string ngay8, string ngay9, string ngay10, string ngay11, string ngay12, string ngay13, string ngay14, string ngay15, string ngay16, string ngay17, string ngay18, string ngay19, string ngay20, string ngay21, string ngay22, string ngay23, string ngay24, string ngay25, string ngay26, string ngay27, string ngay28, string ngay29, string ngay30, string ngay31,int tongsongay, int ngaydilam, int ngayvang)
        {
            string query = "insert into bangchamcong values( '" + machamcong + "','" + thang + "','" + manv + "', '" + ngay1 + "','" + ngay2 + "','" + ngay3 + "','" + ngay4 + "','" + ngay5 + "','" + ngay6 + "','" + ngay7 + "','" + ngay8 + "','" + ngay9 + "','" + ngay10 + "','" + ngay11 + "','" + ngay12 + "','" + ngay13 + "','" + ngay14 + "','" + ngay15 + "','" + ngay16 + "','" + ngay17 + "','" + ngay18 + "','" + ngay19 + "','" + ngay20 + "','" + ngay21 + "','" + ngay22 + "','" + ngay23 + "','" + ngay24 + "','" + ngay25 + "','" + ngay26 + "','" + ngay27 + "','" + ngay28 + "','" + ngay29 + "','" + ngay30 + "','" + ngay31 + "','" + tongsongay + "','" + ngaydilam + "','" + ngayvang + "')";
            SqlCommand com = new SqlCommand(query);
            ds.Load(com);
        }

        public void Xoa(string machamcong)
        {
            string query = "delete from bangchamcong where machamcong='" + machamcong + "'";
            SqlCommand com = new SqlCommand(query);
            ds.Load(com);
        }

    }
}
