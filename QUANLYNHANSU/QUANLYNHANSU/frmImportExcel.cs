using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QUANLYNHANSU
{
    public partial class frmImportExcel : Form
    {
        public frmImportExcel()
        {
            InitializeComponent();
        }

        private void frmImportExcel_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                string excelConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + open.FileName + ";Extended Properties=Excel 8.0;;Persist Security Info=False";
                OleDbConnection cn = new OleDbConnection(excelConnectionString);
                OleDbDataAdapter da = new OleDbDataAdapter("Select * from [Sheet1$]", cn);
                DataTable dt = new DataTable();
                cn.Open();
                da.Fill(dt);
                this.dataGridViewX1.DataSource = dt;
            }
        }
    }
}