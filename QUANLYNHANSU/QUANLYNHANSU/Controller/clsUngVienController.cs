using System;
using System.Collections.Generic;
using System.Text;
using QUANLYNHANSU.GetData;
using DevComponents.DotNetBar.Controls;
using GenericDataGridView;
using System.Windows.Forms;

namespace QUANLYNHANSU.Controller
{
    public class clsUngVienController
    {
        clsLayUngVien ungvien = new clsLayUngVien();
        clsLayDotPhongVan pv = new clsLayDotPhongVan();

        public void HienThiNgaySinh(GenericDataGridView.GenericDataGridView.CalendarColumn cal)
        {
            cal.DataPropertyName = "ngaysinh";
        }
        public void HienThiNgayCap(GenericDataGridView.GenericDataGridView.CalendarColumn cal)
        {
            cal.DataPropertyName = "ngaycap";
        }
        public void HienThiNgayNopHS(GenericDataGridView.GenericDataGridView.CalendarColumn cal)
        {
            cal.DataPropertyName = "ngaynophoso";
        }
        public void HienThiGridDotPV(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = pv.LayDotPhongVan();
            cmb.DisplayMember = "ten";
            cmb.ValueMember = "madotphongvan";
            cmb.DataPropertyName = "madotphongvan";
        }
        public void HienThiComboboxDotPV(ComboBoxEx cmb)
        {
            cmb.DataSource = pv.LayDotPhongVan();
            cmb.DisplayMember = "ten";
            cmb.ValueMember = "madotphongvan";
        }

        public void HienThiDataGridView(TextBoxX txtMa, TextBoxX txtTen, TextBoxX txtCMND, DateTimePicker dteNgaycap, TextBoxX txtNoicap, DateTimePicker dteNgaysinh, ComboBoxEx cmbGioitinh, TextBoxX txtDiachi, TextBoxX txtEmail, TextBoxX txtDTR, TextBoxX txtDTN, ComboBoxEx cmbHonnhan, TextBoxX txtSoNam, DateTimePicker dteNgayNopHS, ComboBoxEx cmbDanToc, ComboBoxEx cmbTonGiao, ComboBoxEx cmbBangCap, ComboBoxEx cmbTrangThai, ComboBoxEx cmbDotPV, TextBoxX txttinhoc, TextBoxX txtngoaingu, DataGridViewX dtg, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = ungvien.LayUngVien();
            bn.BindingSource = bs;
            dtg.DataSource = bs;

            txtMa.DataBindings.Clear();
            txtMa.DataBindings.Add("Text", bs, "maungvien");

            txtTen.DataBindings.Clear();
            txtTen.DataBindings.Add("Text", bs, "tenungvien");

            txtCMND.DataBindings.Clear();
            txtCMND.DataBindings.Add("Text", bs, "cmnd");

            dteNgaycap.DataBindings.Clear();
            dteNgaycap.DataBindings.Add("Text", bs, "ngaycap");

            txtNoicap.DataBindings.Clear();
            txtNoicap.DataBindings.Add("Text", bs, "noicap");

            dteNgaysinh.DataBindings.Clear();
            dteNgaysinh.DataBindings.Add("Text", bs, "ngaysinh");

            cmbGioitinh.DataBindings.Clear();
            cmbGioitinh.DataBindings.Add("Text", bs, "gioitinh");

            txtDiachi.DataBindings.Clear();
            txtDiachi.DataBindings.Add("Text", bs, "diachi");

            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text", bs, "email");

            txtDTR.DataBindings.Clear();
            txtDTR.DataBindings.Add("Text", bs, "sdtrieng");

            txtDTN.DataBindings.Clear();
            txtDTN.DataBindings.Add("Text", bs, "sdtnha");

            cmbHonnhan.DataBindings.Clear();
            cmbHonnhan.DataBindings.Add("Text", bs, "tinhtranghonnhan");

            txtSoNam.DataBindings.Clear();
            txtSoNam.DataBindings.Add("Text", bs, "sonamkinhnghiem");

            dteNgayNopHS.DataBindings.Clear();
            dteNgayNopHS.DataBindings.Add("Text", bs, "ngaynophoso");

            cmbDanToc.DataBindings.Clear();
            cmbDanToc.DataBindings.Add("Text", bs, "dantoc");

            cmbTonGiao.DataBindings.Clear();
            cmbTonGiao.DataBindings.Add("Text", bs, "tongiao");

            cmbBangCap.DataBindings.Clear();
            cmbBangCap.DataBindings.Add("Text", bs, "bangcap");

            cmbTrangThai.DataBindings.Clear();
            cmbTrangThai.DataBindings.Add("Text", bs, "trangthai");

            cmbDotPV.DataBindings.Clear();
            cmbDotPV.DataBindings.Add("SelectedValue", bs, "madotphongvan");

            txttinhoc.DataBindings.Clear();
            txttinhoc.DataBindings.Add("Text", bs, "tinhoc");

            txtngoaingu.DataBindings.Clear();
            txtngoaingu.DataBindings.Add("Text", bs, "ngoaingu");
        }
    }
}
