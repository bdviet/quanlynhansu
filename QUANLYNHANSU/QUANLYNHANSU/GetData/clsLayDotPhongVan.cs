using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYNHANSU.GetData
{
    public class clsLayDotPhongVan
    {
        DataService ds = new DataService();

        public DataTable LayDotPhongVan()
        {
            SqlCommand com = new SqlCommand("select * from dotphongvan");
            ds.Load(com);
            return ds;
        }
    }
}
