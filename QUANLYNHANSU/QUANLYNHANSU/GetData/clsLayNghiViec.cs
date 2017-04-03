using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYNHANSU.GetData
{
    public class clsLayNghiViec
    {
        DataService ds = new DataService();

        public DataTable LayNghiViec()
        {
            SqlCommand com = new SqlCommand("select * from nghiviec");//where maphongban='" + maphong + "'
            ds.Load(com);
            return ds;
        }
    }
}
