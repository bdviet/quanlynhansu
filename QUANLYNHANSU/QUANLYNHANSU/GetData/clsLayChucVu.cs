using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYNHANSU.GetData
{
    public class clsLayChucVu
    {
        DataService ds = new DataService();

        public DataTable LayChucVu()
        {
            SqlCommand com = new SqlCommand("select * from chucvu");
            ds.Load(com);
            return ds;
        }

        public void CapNhat()
        {
            ds.Update();
        }
    }
}
