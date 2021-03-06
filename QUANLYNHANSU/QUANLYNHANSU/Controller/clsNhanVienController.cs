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
    public class clsNhanVienController
    {
        clsLayBangNhanVien nhanvien = new clsLayBangNhanVien();
        clsLayPhongBan pb = new clsLayPhongBan();
        clsLayToLamViec to = new clsLayToLamViec();
        clsLayChucVu chucvu = new clsLayChucVu();
        
        clsLaySoQuyetDinh sqd = new clsLaySoQuyetDinh();

        public void HienthiGioitinh(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataPropertyName = "gioitinh";
        }

        public void HienthiHocvi(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataPropertyName = "hocvi";
        }

        public void HienthiMau(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataPropertyName = "nhommau";
        }

        public void Hienthihonnhan(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataPropertyName = "tinhtranghonnhan";
        }

        public void Hienthilamviec(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataPropertyName = "tinhtranglamviec";
        }

        public void Hienthingaycap(GenericDataGridView.GenericDataGridView.CalendarColumn cal)
        {
            cal.DataPropertyName = "ngaycap";
        }

        public void Hienthingaysinh(GenericDataGridView.GenericDataGridView.CalendarColumn cal)
        {
            cal.DataPropertyName = "ngaysinh";
        }

        public void HienthiGridPhongban(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = pb.LayPhongBan();
            cmb.DisplayMember = "tenphong";
            cmb.ValueMember = "maphong";
            cmb.DataPropertyName = "phongban";
        }

        public void HienthiTolamviec(ComboBox cmb)
        {
            cmb.DataSource = to.LayToLamViec();
            cmb.DisplayMember = "tento";
            cmb.ValueMember = "mato";
        }

        public void HienthiGridTolamviec(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = to.LayToLamViec();
            cmb.DisplayMember = "tento";
            cmb.ValueMember = "mato";
            cmb.DataPropertyName = "tophutrach";
        }

        public void HienthiGridChucvu(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = chucvu.LayChucVu();
            cmb.DisplayMember = "ten";
            cmb.ValueMember = "machucvu";
            cmb.DataPropertyName = "machucvu";
        }

        public void HienthiPhongban(ComboBox cmb)
        {
            cmb.DataSource = pb.LayPhongBan();
            cmb.DisplayMember = "tenphong";
            cmb.ValueMember = "maphong";
        }

        public void HienthiChucvu(ComboBox cmb)
        {
            cmb.DataSource = chucvu.LayChucVu();
            cmb.DisplayMember = "ten";
            cmb.ValueMember = "machucvu";
        }
        public void HienThiQuanHe(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataPropertyName = "quanhe";
        }
        public void HienThiTrongNgoai(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataPropertyName = "tronghayngoai";
        }
        public void HienThiNgayVaoLam(GenericDataGridView.GenericDataGridView.CalendarColumn cal)
        {
            cal.DataPropertyName = "ngayvaolam";
        }

        public void HienthiNhanVienTheoPhong(string maphong, DataGridViewX dtg, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = nhanvien.LayNhanVienTheoPhongBan(maphong);
            bn.BindingSource = bs;
            dtg.DataSource = bs;
        }
        public void HienthiNhanVienTheoTo(DataTable DT, DataGridViewX dtg, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = DT;
            bn.BindingSource = bs;
            dtg.DataSource = bs;
        }

        public void HienThiGrid(DataTable dtNv, TextBoxX txtManv, TextBoxX txttennv, TextBoxX txtCMND, DevComponents.Editors.DateTimeAdv.DateTimeInput dteNgaycap, TextBoxX txtNoicap, DateTimePicker dteNgaysinh, ComboBoxEx cmbGioitinh, TextBoxX txtDiachi, TextBoxX txtEmail, TextBoxX txtDTNH, TextBoxX txtDTR, TextBoxX txtDTN, ComboBoxEx cmbHonnhan, ComboBoxEx cmbLamviec, ComboBoxEx cmbPhongban, ComboBoxEx cmbTolamviec, ComboBoxEx cmbchucvu, TextBoxX txtNgayvaolam, TextBoxX txtThamnien, TextBoxX txtheso, TextBoxX txtSoTK, TextBoxX txtHinhthuc, TextBoxX txttinhoc, TextBoxX txtngoaingu, ComboBoxEx cmbhocvi, TextBoxX txtCan, TextBoxX txtCao, ComboBoxEx cmbMau, TextBoxX txtSuckhoe, TextBoxX txtBHXH, TextBoxX txtBHYT, DataGridViewX dtg, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dtNv;
            bn.BindingSource = bs;
            dtg.DataSource = bs;

            txtManv.DataBindings.Clear();
            txtManv.DataBindings.Add("Text", bs, "manv");

            txttennv.DataBindings.Clear();
            txttennv.DataBindings.Add("Text", bs, "tennv");

            txtCMND.DataBindings.Clear();
            txtCMND.DataBindings.Add("Text", bs, "CMND");

            dteNgaycap.DataBindings.Clear();
            dteNgaycap.DataBindings.Add("Value", bs, "ngaycap");

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

            txtDTN.DataBindings.Clear();
            txtDTN.DataBindings.Add("Text", bs, "sdtnha");

            txtDTNH.DataBindings.Clear();
            txtDTNH.DataBindings.Add("Text", bs, "sdtcty");

            txtDTR.DataBindings.Clear();
            txtDTR.DataBindings.Add("Text", bs, "sdtrieng");

            cmbHonnhan.DataBindings.Clear();
            cmbHonnhan.DataBindings.Add("Text", bs, "tinhtranghonnhan");

            cmbLamviec.DataBindings.Clear();
            cmbLamviec.DataBindings.Add("Text", bs, "tinhtranglamviec");

            cmbPhongban.DataBindings.Clear();
            cmbPhongban.DataBindings.Add("SelectedValue", bs, "phongban");

            cmbTolamviec.DataBindings.Clear();
            cmbTolamviec.DataBindings.Add("SelectedValue", bs, "tophutrach");

            cmbchucvu.DataBindings.Clear();
            cmbchucvu.DataBindings.Add("SelectedValue", bs, "machucvu");

            txtNgayvaolam.DataBindings.Clear();
            txtNgayvaolam.DataBindings.Add("Text", bs, "ngayvaolam");

            txtThamnien.DataBindings.Clear();
            txtThamnien.DataBindings.Add("Text", bs, "thamnien");

            txtheso.DataBindings.Clear();
            txtheso.DataBindings.Add("Text", bs, "heso");

            txtSoTK.DataBindings.Clear();
            txtSoTK.DataBindings.Add("Text", bs, "taikhoanNH");

            txtHinhthuc.DataBindings.Clear();
            txtHinhthuc.DataBindings.Add("Text", bs, "hinhthuctuyendung");

            txttinhoc.DataBindings.Clear();
            txttinhoc.DataBindings.Add("Text", bs, "tinhoc");

            txtngoaingu.DataBindings.Clear();
            txtngoaingu.DataBindings.Add("Text", bs, "ngoaingu");

            cmbhocvi.DataBindings.Clear();
            cmbhocvi.DataBindings.Add("Text", bs, "hocvi");

            txtCan.DataBindings.Clear();
            txtCan.DataBindings.Add("Text", bs, "cannang");

            txtCao.DataBindings.Clear();
            txtCao.DataBindings.Add("Text", bs, "cao");

            cmbMau.DataBindings.Clear();
            cmbMau.DataBindings.Add("Text", bs, "nhommau");

            txtSuckhoe.DataBindings.Clear();
            txtSuckhoe.DataBindings.Add("Text", bs, "tinhtrangsuckhoe");

            txtBHXH.DataBindings.Clear();
            txtBHXH.DataBindings.Add("Text", bs, "soBHXH");

            txtBHYT.DataBindings.Clear();
            txtBHYT.DataBindings.Add("Text", bs, "soBHYT");
        }
    }
}
