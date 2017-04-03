using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace QUANLYNHANSU
{
    public partial class frmKiemTraKetNoi : Office2007Form
    {
        public frmKiemTraKetNoi()
        {
            InitializeComponent();
        }

        private void bntKiemTra_Click(object sender, EventArgs e)
        {
            int sql = 2005;
            if (comboBoxEx1.SelectedIndex == 0)
                sql = 2000;
            else
                sql = 2005;

            clsKiemTraKetNoi testconnection = new clsKiemTraKetNoi(txtSer.Text, txtDB.Text, sql);
            testconnection.OpenConnection();
        }

        private void frmKiemTraKetNoi_Load(object sender, EventArgs e)
        {
            comboBoxEx1.SelectedIndex = 0;
        }
    }
}