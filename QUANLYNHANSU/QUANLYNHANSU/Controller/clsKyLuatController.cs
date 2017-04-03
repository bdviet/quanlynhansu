using System;
using System.Collections.Generic;
using System.Text;
using QUANLYNHANSU.GetData;
using DevComponents.DotNetBar.Controls;
using System.Windows.Forms;

namespace QUANLYNHANSU.Controller
{
    public class clsKyLuatController
    {
        clsLaySoQuyetDinh sqd = new clsLaySoQuyetDinh();
        clsLayKyLuat kl = new clsLayKyLuat();
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
        public void HienThiKyLuat(TextBoxX txtMa, ComboBoxEx cmbSQD,ComboBoxEx cmbNV, DateTimePicker NgayKL, TextBoxX txtLyDo, TextBoxX txtHinhThuc, TextBoxX txtGhichu, string manv, DataGridViewX dtg, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = kl.LayKyLuatTheoNhanVien(manv);
            dtg.DataSource = bs;
            bn.BindingSource = bs;

            //ten.DataBindings.Clear();
            //ten.DataBindings.Add("Text", bs, "tenboiduong");

            txtMa.DataBindings.Clear();
            txtMa.DataBindings.Add("Text", bs, "makyluat");

            cmbSQD.DataBindings.Clear();
            cmbSQD.DataBindings.Add("SelectedValue", bs, "masoquyetdinh");

            cmbNV.DataBindings.Clear();
            cmbNV.DataBindings.Add("SelectedValue", bs, "manv");

            NgayKL.DataBindings.Clear();
            NgayKL.DataBindings.Add("Text", bs, "ngaykyluat");

            //NgayKT.DataBindings.Clear();
            //NgayKT.DataBindings.Add("Text", bs, "ngayketthuc");

            txtLyDo.DataBindings.Clear();
            txtLyDo.DataBindings.Add("Text", bs, "lydo");

            txtHinhThuc.DataBindings.Clear();
            txtHinhThuc.DataBindings.Add("Text", bs, "hinhthuc");

            txtGhichu.DataBindings.Clear();
            txtGhichu.DataBindings.Add("Text", bs, "ghichu");
        }

    }
}
