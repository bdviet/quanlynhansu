using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYNHANSU.GetData
{
    public class clsLayKyLuat
    {
        DataService ds = new DataService();

        public DataTable LayKyLuat()
        {
            SqlCommand com = new SqlCommand("select * from kyluatphat");//where maphongban='" + maphong + "'
            ds.Load(com);
            return ds;
        }

        public DataTable LayKyLuatTheoNhanVien(string manv)
        {
            SqlCommand com = new SqlCommand("select * from kyluatphat where manv='" + manv + "'");//where maphongban='" + maphong + "'
            ds.Load(com);
            return ds;
        }

        public void ThemMoiKyLuat(string makyluat,string masoquyetdinh, string manv, string ngaykl, string ngaythem)
        {
            string query = "insert into kyluatphat values ('" + makyluat + "','" + manv + "','" + masoquyetdinh + "',null,null,'" + ngaykl + "',null,'" + ngaythem + "')";
            SqlCommand com = new SqlCommand(query);
            ds.Load(com);
        }

        public void CapNhatKyLuat(string makyluat, string masoquyetdinh,string manv, string lydo, string hinhthuc, string ngaykl, string ghichu)
        {
            string query = "update kyluatphat set masoquyetdinh='" + masoquyetdinh + "',manv='" + manv + "',lydo=N'" + lydo + "',hinhthuc=N'" + hinhthuc + "',ngaykyluat='" + ngaykl + "',ghichu=N'" + ghichu + "'where makyluat='" + makyluat + "'";
            SqlCommand com = new SqlCommand(query);
            ds.Load(com);
        }
        public void Xoa(string ma)
        {
            string query = "delete from kyluatphat where makyluat='" + ma + "'";
            SqlCommand com = new SqlCommand(query);
            ds.Load(com);
        }
    }
}
