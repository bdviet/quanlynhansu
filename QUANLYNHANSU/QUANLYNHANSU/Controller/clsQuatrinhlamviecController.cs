using System;
using System.Collections.Generic;
using System.Text;
using QUANLYNHANSU.GetData;
using DevComponents.DotNetBar.Controls;
using System.Windows.Forms;

namespace QUANLYNHANSU.Controller
{
    public class clsQuatrinhlamviecController
    {
        clsLayQuaTrinhLamViec lamviec = new clsLayQuaTrinhLamViec();
        clsLayCongViec congviec = new clsLayCongViec();
        clsLayBangNhanVien nv = new clsLayBangNhanVien();

        public void HienthiCongviec(ComboBox cmb)
        {
            cmb.DataSource = congviec.LayCongViec();
            cmb.DisplayMember = "tencongviec";
            cmb.ValueMember = "macongviec";
        }

        public void HienthiGridCongviec(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = congviec.LayCongViec();
            cmb.DisplayMember = "tencongviec";
            cmb.ValueMember = "macongviec";
            cmb.DataPropertyName = "macongviec";
        }

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

        public void HienThiLamviec(TextBoxX txtMalav,TextBoxX ten,ComboBoxEx cmbNV, ComboBoxEx cmbCV, DateTimePicker dteNgayBD, DateTimePicker dteNgayKT, TextBoxX txtNoilam, TextBoxX txtGhichu, string manv, DataGridViewX dtg, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = lamviec.LayQuatrinhlamviec(manv);
            dtg.DataSource = bs;
            bn.BindingSource = bs;

            txtMalav.DataBindings.Clear();
            txtMalav.DataBindings.Add("Text", bs, "maquatrinh");

            ten.DataBindings.Clear();
            ten.DataBindings.Add("Text", bs, "tenquatrinh");

            cmbCV.DataBindings.Clear();
            cmbCV.DataBindings.Add("SelectedValue", bs, "macongviec");

            cmbNV.DataBindings.Clear();
            cmbNV.DataBindings.Add("SelectedValue", bs, "manv");

            dteNgayBD.DataBindings.Clear();
            dteNgayBD.DataBindings.Add("Text", bs, "ngaybatdau");

            dteNgayKT.DataBindings.Clear();
            dteNgayKT.DataBindings.Add("Text", bs, "ngayketthuc");

            txtNoilam.DataBindings.Clear();
            txtNoilam.DataBindings.Add("Text", bs, "noilamviec");

            txtGhichu.DataBindings.Clear();
            txtGhichu.DataBindings.Add("Text", bs, "ghichu");
        }
    }
}
