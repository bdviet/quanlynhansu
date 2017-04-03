using System;
using System.Collections.Generic;
using System.Text;
using QUANLYNHANSU.GetData;
using DevComponents.DotNetBar.Controls;
using GenericDataGridView;
using System.Windows.Forms;

namespace QUANLYNHANSU.Controller
{
    public class clsThanNhanController
    {
        clsLayThanNhan thanhnhan = new clsLayThanNhan();
        clsLayBangNhanVien nv = new clsLayBangNhanVien();

        public void HienthiNhanVien(ComboBox cmb)
        {
            cmb.DataSource = nv.LayNhanVien();
            cmb.DisplayMember = "tennv";
            cmb.ValueMember = "manv";
        }

        public void HienthiGridNhanVien(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = nv.LayNhanVien();
            cmb.DisplayMember = "tennv";
            cmb.ValueMember = "manv";
            cmb.DataPropertyName = "manv";
        }

        public void HienThi(TextBoxX txtMa, TextBoxX txtTen,ComboBoxEx cmbNV, ComboBoxEx cmbQuanHe, ComboBoxEx cmbDangO, TextBoxX txtNuoc, TextBoxX txtGhiChu, string manv, BindingNavigator bn, DataGridViewX dtg)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = thanhnhan.LayThanNhanTheoNhanVien(manv);
            bn.BindingSource = bs;
            dtg.DataSource = bs;

            txtMa.DataBindings.Clear();
            txtMa.DataBindings.Add("Text", bs, "mathannhan");

            txtTen.DataBindings.Clear();
            txtTen.DataBindings.Add("Text", bs, "tenthannhan");

            cmbQuanHe.DataBindings.Clear();
            cmbQuanHe.DataBindings.Add("Text", bs, "quanhe");

            cmbNV.DataBindings.Clear();
            cmbNV.DataBindings.Add("SelectedValue", bs, "manv");

            cmbDangO.DataBindings.Clear();
            cmbDangO.DataBindings.Add("Text", bs, "tronghayngoai");

            txtNuoc.DataBindings.Clear();
            txtNuoc.DataBindings.Add("Text", bs, "nuocdinhcu");

            txtGhiChu.DataBindings.Clear();
            txtGhiChu.DataBindings.Add("Text", bs, "ghichu");
        }
    }
}
