using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYNHANSU.GetData
{
    public class clsLayPhongBan
    {
        DataService ds = new DataService();

        public DataTable LayPhongBan()
        {
            SqlCommand com = new SqlCommand("select * from phongban");
            ds.Load(com);
            return ds;
        }

        public DataTable LayPhongBanLoaiTruPhongXoa(string maphong)
        {
            SqlCommand com = new SqlCommand("select * from phongban where maphong !='" + maphong + "'");
            ds.Load(com);
            return ds;
        }

        public void CapNhat(string maphong,string tenphong,string matruongphong,string ngaynhanchuc,string ghichu)
        {
            SqlCommand com = new SqlCommand("update phongban set tenphong=N'" + tenphong + "',matruongphong='" + matruongphong + "',ngaynhanchuc='" + ngaynhanchuc + "',ghichu=N'" + ghichu + "'where maphong ='" + maphong + "'");
            ds.Load(com);
        }
        public void ThemMoi(string maphong, string tenphong, string matruongphong, string ngaynhanchuc, string ghichu, string ngaythem)
        {
            SqlCommand com = new SqlCommand("insert into phongban values('" + maphong + "',N'" + tenphong + "','" + matruongphong + "','" + ngaynhanchuc + "',N'" + ghichu + "','" + ngaythem + "')");
            ds.Load(com);
        }
    }
}
