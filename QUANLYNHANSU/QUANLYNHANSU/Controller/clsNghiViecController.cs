using System;
using System.Collections.Generic;
using System.Text;
using QUANLYNHANSU.GetData;
using DevComponents.DotNetBar.Controls;
using System.Windows.Forms;
using System.Data;

namespace QUANLYNHANSU.Controller
{
    public class clsNghiViecController
    {
        clsLayNghiViec nghiviec = new clsLayNghiViec();

        public void HienThiNghiViec(TextBoxX txtMaNghiViec,ComboBoxEx cmbSQD,ComboBoxEx cmbNV,DateTimePicker dteNgayQD,DateTimePicker dteNgayHieuLuc,TextBoxX txtLyDo,TextBoxX txtTienBoiThuong,TextBoxX txtTienKhac,TextBoxX txtLyDoTienKhac,TextBoxX txtGhiChu,DataGridViewX dtg,BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = nghiviec.LayNghiViec();
            dtg.DataSource = bs;
            bn.BindingSource = bs;
        }
    }
}
