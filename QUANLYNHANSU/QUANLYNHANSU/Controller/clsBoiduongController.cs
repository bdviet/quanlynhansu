using System;
using System.Collections.Generic;
using System.Text;
using QUANLYNHANSU.GetData;
using DevComponents.DotNetBar.Controls;
using System.Windows.Forms;

namespace QUANLYNHANSU.Controller
{
    public class clsBoiduongController
    {
        clsLayQuatrinhboiduong boiduong = new clsLayQuatrinhboiduong();
        clsLaySoQuyetDinh sqd = new clsLaySoQuyetDinh();
        clsLayBangNhanVien nv = new clsLayBangNhanVien();

        public void HienthiSQD(ComboBox cmb)
        {
            cmb.DataSource = sqd.LaySQD();
            cmb.DisplayMember = "loaiquyetdinh";
            cmb.ValueMember = "masoquyetdinh";
        }

        public void HienthiGridSQD(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = sqd.LaySQD();
            cmb.DisplayMember = "loaiquyetdinh";
            cmb.ValueMember = "masoquyetdinh";
            cmb.DataPropertyName = "masoquyetdinh";
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
        public void HienThiBoiDuong(TextBoxX txtMabd,TextBoxX ten, ComboBoxEx cmbNV, ComboBoxEx cmbSQD, DateTimePicker NgayBD, DateTimePicker NgayKT, TextBoxX txtChuyennganh, TextBoxX txtNoiboiduong, TextBoxX txtGhichu, string manv, DataGridViewX dtg, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = boiduong.LayQuatrinhboiduong(manv);
            dtg.DataSource = bs;
            bn.BindingSource = bs;

            ten.DataBindings.Clear();
            ten.DataBindings.Add("Text", bs, "tenboiduong");

            txtMabd.DataBindings.Clear();
            txtMabd.DataBindings.Add("Text", bs, "maboiduong");

            cmbSQD.DataBindings.Clear();
            cmbSQD.DataBindings.Add("SelectedValue", bs, "masoquyetdinh");

            cmbNV.DataBindings.Clear();
            cmbNV.DataBindings.Add("SelectedValue", bs, "manv");

            NgayBD.DataBindings.Clear();
            NgayBD.DataBindings.Add("Text", bs, "ngaybatdau");

            NgayKT.DataBindings.Clear();
            NgayKT.DataBindings.Add("Text", bs, "ngayketthuc");

            txtChuyennganh.DataBindings.Clear();
            txtChuyennganh.DataBindings.Add("Text", bs, "chuyennganh");

            txtNoiboiduong.DataBindings.Clear();
            txtNoiboiduong.DataBindings.Add("Text", bs, "noidaotao");

            txtGhichu.DataBindings.Clear();
            txtGhichu.DataBindings.Add("Text", bs, "ghichu");
        }
    }
}
