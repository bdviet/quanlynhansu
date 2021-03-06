using System;
using System.Collections.Generic;
using System.Text;
using DevComponents.DotNetBar;
using System.Data.SqlClient;
using System.Data;

namespace QUANLYNHANSU
{
    public class clsKiemTraKetNoi
    {
        public string server = null;
        public string database = null;
        public int ketnoisql = 2005;

        public clsKiemTraKetNoi(string ser,string db,int sql)
        {
            server = ser;
            database = db;
            ketnoisql = sql;
        }

        //string strCon = "server = "+server;database = QUANLYNHANSU; trusted_connection = true";//SQL 2000
        ////static string strCon = "Data Source = .\\SQLEXPRESS;Inintal Catalog = QUANLYNHANSU; trusted_connection = SSPI";//SQL 2005
        //static SqlConnection connection = new SqlConnection();

        public void OpenConnection()
        {
            string strCon = null;

            if (ketnoisql == 2000)
                strCon = "server = " + server + ";database = " + database + "; trusted_connection = true";//SQL 2000
            else
                strCon = "Data Source = " + server + ";Inintal Catalog = " + database + "; trusted_connection = SSPI";//SQL 2005

            SqlConnection connection = new SqlConnection();


            connection.ConnectionString = strCon;
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    MessageBoxEx.Show("Kết nối thành công", "Thông Báo");
                }
                catch (Exception e)
                {
                    MessageBoxEx.Show("Kết nối không thành công", "Thông Báo");
                }
            }
        }
    }
}
