using System;
using System.Collections.Generic;
using System.Text;
using QUANLYNHANSU.GetData;
using DevComponents.DotNetBar.Controls;
using GenericDataGridView;
using System.Windows.Forms;

namespace QUANLYNHANSU.Controller
{
    public class clsToLamViecController
    {
        clsLayToLamViec tolamviec = new clsLayToLamViec();
        clsLayBangNhanVien nhanvien = new clsLayBangNhanVien();
        clsLayPhongBan phongban = new clsLayPhongBan();


        public void HienThiToTruong(ComboBoxEx cmb)
        {
            cmb.DataSource = nhanvien.LayNhanVien();
            cmb.DisplayMember = "tennv";
            cmb.ValueMember = "manv";
        }
        public void HienThiGridToTruong(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = nhanvien.LayNhanVien();
            cmb.DisplayMember = "tennv";
            cmb.ValueMember = "manv";
            cmb.DataPropertyName = "matotruong";
        }
        public void HienThiPhongBan(ComboBoxEx cmb)
        {
            cmb.DataSource = phongban.LayPhongBan();
            cmb.DisplayMember = "tenphong";
            cmb.ValueMember = "maphong";
        }
        public void HienThiGridPhongBan(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = phongban.LayPhongBan();
            cmb.DisplayMember = "tenphong";
            cmb.ValueMember = "maphong";
            cmb.DataPropertyName = "maphongban";
        }
        public void HienThi(string maphong,TextBoxX txtMaTo,TextBoxX txtTenTo,ComboBoxEx cmbToTruong,ComboBoxEx cmbPhongBan,TextBoxX txtGhiChu, DataGridViewX dtg, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = tolamviec.LayToLamViecTheoPhong(maphong);
            dtg.DataSource = bs;
            bn.BindingSource = bs;

            txtMaTo.DataBindings.Clear();
            txtMaTo.DataBindings.Add("Text", bs, "mato");

            txtTenTo.DataBindings.Clear();
            txtTenTo.DataBindings.Add("Text", bs, "tento");

            cmbToTruong.DataBindings.Clear();
            cmbToTruong.DataBindings.Add("SelectedValue", bs, "matotruong");

            cmbPhongBan.DataBindings.Clear();
            cmbPhongBan.DataBindings.Add("SelectedValue", bs, "maphongban");

            txtGhiChu.DataBindings.Clear();
            txtGhiChu.DataBindings.Add("Text", bs, "mato");

        }
    }
}
