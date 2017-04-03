using System;
using System.Collections.Generic;
using System.Text;
using QUANLYNHANSU.GetData;
using DevComponents.DotNetBar.Controls;
using GenericDataGridView;
using System.Windows.Forms;
using System.Data;

namespace QUANLYNHANSU.Controller
{
    public class clsSoQuyetDinhController
    {
        clsLayBangSoQuyetDinh soquyetdinh = new clsLayBangSoQuyetDinh();
        clsLayGDvaPGD GDvaPGD = new clsLayGDvaPGD();

        public void HienThicmbLoaiQuyetDinh(ComboBoxEx cmb)
        {
            cmb.DataSource = soquyetdinh.LaySoQuyetDinh();
            cmb.DisplayMember = "loaiquyetdinh";
            cmb.ValueMember = "loaiquyetdinh";
        }

        public void HienThiGridcmbLoaiQuyetDinh(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = soquyetdinh.LaySoQuyetDinh();
            cmb.DisplayMember = "loaiquyetdinh";
            cmb.ValueMember = "loaiquyetdinh";
            cmb.DataPropertyName = "loaiquyetdinh";
        }

        public void HienThicmbNguoiQuyetDinh(ComboBoxEx cmb)
        {
            cmb.DataSource = GDvaPGD.LayGDvaPGD();
            cmb.DisplayMember = "tennv";
            cmb.ValueMember = "manv";
        }

        public void HienThiGridcmbNguoiQuyetDinh(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = GDvaPGD.LayGDvaPGD();
            cmb.DisplayMember = "tennv";
            cmb.ValueMember = "nguoiquyetdinh";
            cmb.DataPropertyName = "nguoiquyetdinh";
        }
        
        public void HienThiGrid(TextBoxX txtMaSoQuyetDinh, DateTimePicker dteNgayQuyetDinh, DateTimePicker dteNgayThem, TextBoxX txtGhiChu, TextBoxX txtNoiDung, BindingNavigator bnSoQuyetDinh, DataGridViewX dtgSoQuyetDinh)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = soquyetdinh.LaySoQuyetDinh();
            bnSoQuyetDinh.BindingSource = bs;
            dtgSoQuyetDinh.DataSource = bs;

            txtMaSoQuyetDinh.DataBindings.Clear();
            txtMaSoQuyetDinh.DataBindings.Add("Text", bs, "masoquyetdinh");
            txtMaSoQuyetDinh.ReadOnly = true;

            dteNgayQuyetDinh.DataBindings.Clear();
            dteNgayQuyetDinh.DataBindings.Add("Value", bs, "ngayquyetdinh");

            dteNgayThem.DataBindings.Clear();
            dteNgayThem.DataBindings.Add("Value", bs, "ngaythem");

            txtGhiChu.DataBindings.Clear();
            txtGhiChu.DataBindings.Add("Text", bs, "ghichu");

            txtNoiDung.DataBindings.Clear();
            txtNoiDung.DataBindings.Add("Text", bs, "noidung");
        }

        public void HienThiGridTimKiem(DataTable dtsqd, TextBoxX txtMaSoQuyetDinh, DateTimePicker dteNgayQuyetDinh, DateTimePicker dteNgayThem, TextBoxX txtGhiChu, TextBoxX txtNoiDung, BindingNavigator bnSoQuyetDinh, DataGridViewX dtgSoQuyetDinh)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dtsqd;
            bnSoQuyetDinh.BindingSource = bs;
            dtgSoQuyetDinh.DataSource = bs;

            txtMaSoQuyetDinh.DataBindings.Clear();
            txtMaSoQuyetDinh.DataBindings.Add("Text", bs, "masoquyetdinh");
            txtMaSoQuyetDinh.ReadOnly = true;

            dteNgayQuyetDinh.DataBindings.Clear();
            dteNgayQuyetDinh.DataBindings.Add("Value", bs, "ngayquyetdinh");

            dteNgayThem.DataBindings.Clear();
            dteNgayThem.DataBindings.Add("Value", bs, "ngaythem");

            txtGhiChu.DataBindings.Clear();
            txtGhiChu.DataBindings.Add("Text", bs, "ghichu");

            txtNoiDung.DataBindings.Clear();
            txtNoiDung.DataBindings.Add("Text", bs, "noidung");
        }
    }
}
