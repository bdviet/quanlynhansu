using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYNHANSU.GetData
{
    public class clsLayThanNhan
    {
        DataService ds = new DataService();

        public DataTable LayThanNhanTheoNhanVien(string manv)
        {
            SqlCommand com = new SqlCommand("select * from thannhan where manv='" + manv + "'");
            ds.Load(com);
            return ds;
        }
        public DataTable LayThanNhan()
        {
            SqlCommand com = new SqlCommand("select * from thannhan");
            ds.Load(com);
            return ds;
        }

        public void ThemMoiTN(string mathannhan, string tentn, string manv, string quanhe, string trongngoai, string nuocdinhcu, string ghichu,string ngaythem)
        {
            string query = "insert into thannhan values ('" + mathannhan + "',N'" + tentn + "','" + manv + "',N'" + quanhe + "',N'" + trongngoai + "',N'" + nuocdinhcu + "',N'" + ghichu + "','" + ngaythem + "')";
            SqlCommand com = new SqlCommand(query);
            ds.Load(com);
        }
        public void CapNhatTN(string mathannhan, string tentn,string manv, string quanhe, string trongngoai, string nuocdinhcu, string ghichu)
        {
            string query = "update thannhan set tenthannhan=N'" + tentn + "',manv='"+manv+"',quanhe=N'" + quanhe + "',tronghayngoai=N'" + trongngoai + "',nuocdinhcu=N'" + nuocdinhcu + "',ghichu=N'" + ghichu + "'where mathannhan='" + mathannhan + "'";
            SqlCommand com = new SqlCommand(query);
            ds.Load(com);
        }
        public void Xoa(string ma)
        {
            string query = "delete from thannhan where mathannhan='" + ma + "'";
            SqlCommand com = new SqlCommand(query);
            ds.Load(com);
        }
    }
}
