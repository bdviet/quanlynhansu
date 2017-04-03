using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYNHANSU.GetData
{
    public class clsLayUngVien
    {
        DataService ds = new DataService();

        public DataTable LayUngVien()
        {
            SqlCommand com = new SqlCommand("select * from ungvien");//where maphongban='" + maphong + "'
            ds.Load(com);
            return ds;
        }
        public void CapNhatHinh(string maungvien, byte[] hinhanh)
        {
            SqlCommand com = new SqlCommand("update ungvien set hinhanh = @hinhanh where maungvien = @maungvien");
            com.Parameters.Add("hinhanh", SqlDbType.Image).Value = hinhanh;
            com.Parameters.Add("maungvien", SqlDbType.VarChar, 10).Value = maungvien;
            ds.Load(com);
        }

        public void XoaHinh(string maungvien)
        {
            SqlCommand com = new SqlCommand("update ungvien set [hinhanh] = null where maungvien = '" + maungvien + "'");
            ds.Load(com);
        }

        public DataTable LayHinhTheoUngVien(string maungvien)
        {
            SqlCommand com = new SqlCommand("select * from ungvien where maungvien='" + maungvien + "'");
            ds.Load(com);
            return ds;
        }

        public void CapNhat(string maungvien, string tenungvien, string cmnd, string ngaycap, string noicap, string ngaysinh, string gioitinh, string diachi, string email, string sdtrieng, string sdtnha, string tinhtranghonnhan, string dantoc, string tongiao, string bangcap, string ngoaingu, string tinhoc, int namkinhnghiem, string ngaynopHS,string trangthai, string madotPV, string ghichu)
        {
            string query;
            query = "update ungvien set tenungvien=N'" + tenungvien + "', cmnd='" + cmnd + "',ngaycap='" + ngaycap + "', noicap=N'" + noicap + "',ngaysinh='" + ngaysinh + "',gioitinh=N'" + gioitinh + "', diachi=N'" + diachi + "', email=N'" + email + "',sdtrieng='" + sdtrieng + "',sdtnha='" + sdtnha + "',tinhtranghonnhan=N'" + tinhtranghonnhan + "',dantoc=N'" + dantoc + "',tongiao=N'" + tongiao + "',bangcap=N'" + bangcap + "',ngoaingu=N'" + ngoaingu + "',tinhoc=N'" + tinhoc + "',sonamkinhnghiem=" + namkinhnghiem + ",ngaynophoso='" + ngaynopHS + "',trangthai=N'" + trangthai + "',madotphongvan='" + madotPV + "',ghichu=N'" + ghichu + "' where maungvien='" + maungvien + "'";
            SqlCommand com = new SqlCommand(query);
            ds.Load(com);
        }

        public void ThemMoi(string maungvien, string tenungvien, string cmnd, string ngaycap, string noicap, string ngaysinh, string gioitinh, string diachi, string email, string sdtrieng, string sdtnha, string tinhtranghonnhan, string dantoc, string tongiao, string bangcap, string ngoaingu, string tinhoc, int namkinhnghiem, string ngaynopHS,string trangthai, string madotPV, string ghichu,string ngaythem)
        {
            string query;
            query = "insert into ungvien values ('" + maungvien + "',N'" + tenungvien + "', '" + cmnd + "','" + ngaycap + "', N'" + noicap + "','" + ngaysinh + "',N'" + gioitinh + "', N'" + diachi + "', N'" + email + "','" + sdtrieng + "','" + sdtnha + "',N'" + tinhtranghonnhan + "',N'" + dantoc + "',N'" + tongiao + "',N'" + bangcap + "',N'" + ngoaingu + "',N'" + tinhoc + "'," + namkinhnghiem + ",'" + ngaynopHS + "',N'" + trangthai + "','" + madotPV + "',null,N'" + ghichu + "','" + ngaythem + "')";
            SqlCommand com = new SqlCommand(query);
            ds.Load(com);
        }
        public void XoaUngVien(string maungvien)
        {
            SqlCommand com = new SqlCommand("delete ungvien where maungvien='" + maungvien + "'");
            ds.Load(com);
        }
    }
}
