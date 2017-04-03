using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYNHANSU.GetData
{
    public class clsLayCongViec
    {
        DataService ds = new DataService();

        public DataTable LayCongViec()
        {
            SqlCommand com = new SqlCommand("select * from congviec");
            ds.Load(com);
            return ds;
        }

        public void CapNhat()
        {
            ds.Update();
        }
    }
}
