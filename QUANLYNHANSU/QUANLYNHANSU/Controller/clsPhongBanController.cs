using System;
using System.Collections.Generic;
using System.Text;
using QUANLYNHANSU.GetData;
using DevComponents.DotNetBar.Controls;
using GenericDataGridView;
using System.Windows.Forms;

namespace QUANLYNHANSU.Controller
{
    public class clsPhongBanController
    {
        clsLayPhongBan phongban = new clsLayPhongBan();
        clsLayBangNhanVien nhanvien = new clsLayBangNhanVien();

        public void HienThitruongphong(ComboBoxEx cmb)
        {
            cmb.DataSource = nhanvien.LayNhanVien();
            cmb.DisplayMember = "tennv";
            cmb.ValueMember = "manv";
        }
        public void HienThiGridtruongphong(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = nhanvien.LayNhanVien();
            cmb.DisplayMember = "tennv";
            cmb.ValueMember = "manv";
            cmb.DataPropertyName = "matruongphong";
        }
        public void HienThiNgay(GenericDataGridView.GenericDataGridView.CalendarColumn cal)
        {
            cal.DataPropertyName = "ngaynhanchuc";
        }
        public void HienThi(TextBoxX txtMa,TextBoxX txtTen,ComboBoxEx cmbTruong,DateTimePicker dteNgay,TextBoxX txtghichu, DataGridViewX dtg,BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = phongban.LayPhongBan();
            dtg.DataSource = bs;
            bn.BindingSource = bs;

            txtMa.DataBindings.Clear();
            txtMa.DataBindings.Add("Text", bs, "maphong");

            txtTen.DataBindings.Clear();
            txtTen.DataBindings.Add("Text", bs, "tenphong");

            cmbTruong.DataBindings.Clear();
            cmbTruong.DataBindings.Add("SelectedValue", bs, "matruongphong");

            dteNgay.DataBindings.Clear();
            dteNgay.DataBindings.Add("Text", bs, "ngaynhanchuc");

            txtghichu.DataBindings.Clear();
            txtghichu.DataBindings.Add("Text", bs, "ghichu");
        }
    }
}
