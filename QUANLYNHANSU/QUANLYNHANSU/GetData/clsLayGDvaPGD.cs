using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace QUANLYNHANSU.GetData
{
    public class clsLayGDvaPGD
    {
        DataService ds = new DataService();
        public DataTable LayGDvaPGD()
        {
            SqlCommand com = new SqlCommand("select * from nhanvien,chucvu,soquyetdinh where (nhanvien.manv=soquyetdinh.nguoiquyetdinh and nhanvien.machucvu=chucvu.machucvu) and(chucvu.ten='Pho GD' or chucvu.ten='Giam Doc')");
            ds.Load(com);
            return ds;
        }
    }
}
