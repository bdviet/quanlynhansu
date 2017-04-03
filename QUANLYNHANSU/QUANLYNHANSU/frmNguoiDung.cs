using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QUANLYNHANSU.GetData;
using DevComponents.DotNetBar;

namespace QUANLYNHANSU
{
    public partial class frmNguoiDung : Office2007Form
    {
        public frmNguoiDung()
        {
            InitializeComponent();
        }
        clsLayNguoiDung nguoidung = new clsLayNguoiDung();
        private void frmNguoiDung_Load(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = nguoidung.LayNguoiDung();
            dtgNguoiDung.DataSource = bs;
            bnNguoiDung.BindingSource = bs;
        }

        private void bntThem_Click(object sender, EventArgs e)
        {
            frmPhanQuyenNguoiDungMoi phanquyen = new frmPhanQuyenNguoiDungMoi();
            phanquyen.ShowDialog();
            frmNguoiDung_Load(sender, e);
        }
    }
}