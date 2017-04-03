using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYNHANSU.GetData
{
    public class clsLayQuaTrinhLamViec
    {
        DataService ds = new DataService();

        public DataTable LayQuatrinhlamviec(string manv)
        {
            SqlCommand com = new SqlCommand("select * from quatrinhlamviec where manv='" + manv + "'");
            ds.Load(com);
            return ds;
        }

        public DataTable LayLamViec()
        {
            SqlCommand com = new SqlCommand("select * from quatrinhlamviec");
            ds.Load(com);
            return ds;
        }

        public void ThemMoiQTLV( string maquatrinh,string manhanvien,string macongviec,string ngaythem)
        {
            string query = "insert into quatrinhlamviec values('" + maquatrinh + "',null,'" + manhanvien + "','" + macongviec + "',1/9/2009,1/9/2009,null,null," + ngaythem + ")";
            SqlCommand com = new SqlCommand(query);
            ds.Load(com);
        }

        public void CapNhatQTLV(string maquatrinh, string tenqt,string manv, string macongviec, string ngaybatdau,string ngayketthuc,string noilamviec,string ghichu)
        {
            string query = "update quatrinhlamviec set tenquatrinh=N'" + tenqt + "',manv='" + manv + "',macongviec='" + macongviec + "',ngaybatdau='" + ngaybatdau + "',ngayketthuc='" + ngayketthuc + "',noilamviec=N'" + noilamviec + "',ghichu=N'" + ghichu + "' where maquatrinh='" + maquatrinh + "'";
            SqlCommand com = new SqlCommand(query);
            ds.Load(com);
        }
        public void XoaQTLV(string maquatrinh)
        {
            string query = "delete from quatrinhlamviec where maquatrinh='" + maquatrinh + "'";
            SqlCommand com = new SqlCommand(query);
            ds.Load(com);
        }
    }
}
