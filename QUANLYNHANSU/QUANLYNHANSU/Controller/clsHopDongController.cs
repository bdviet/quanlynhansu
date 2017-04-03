using System;
using System.Collections.Generic;
using System.Text;
using QUANLYNHANSU.GetData;
using DevComponents.DotNetBar.Controls;
using GenericDataGridView;
using System.Windows.Forms;

namespace QUANLYNHANSU.Controller
{
    public class clsHopDongController
    {
        clsLayBangNhanVien nv = new clsLayBangNhanVien();
        clsLayHopDong hopdong = new clsLayHopDong();

        public void HienthiNhanVienChucVu(ComboBox cmb)
        {
            cmb.DataSource = nv.LayChucVuNhanVien();
            cmb.DisplayMember = "tennv";
            cmb.ValueMember = "manv";
        }

        public void HienthiGridNhanVienChucVu(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = nv.LayChucVuNhanVien();
            cmb.DisplayMember = "tennv";
            cmb.ValueMember = "manv";
            cmb.DataPropertyName = "manguoiky";
        }

        public void HienThiHopDong(string manv, TextBoxX txtMa, ComboBoxEx cmbnv, DateTimePicker dteNgayBD, DateTimePicker dteNgayKT, NumericUpDown numlanky, TextBoxX txtNoiDung, DateTimePicker dteNgayKy, ComboBoxEx cmbNguoiKy, TextBoxX txtGhiChu, DataGridViewX dtg, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = hopdong.LayHopDongTheoNhanVien(manv);
            dtg.DataSource = bs;
            bn.BindingSource = bs;

            txtMa.DataBindings.Clear();
            txtMa.DataBindings.Add("Text", bs, "mahopdong");

            cmbnv.DataBindings.Clear();
            cmbnv.DataBindings.Add("SelectedValue", bs, "manv");

            dteNgayBD.DataBindings.Clear();
            dteNgayBD.DataBindings.Add("Text", bs, "ngaybatdau");

            dteNgayKT.DataBindings.Clear();
            dteNgayKT.DataBindings.Add("Text", bs, "ngayketthuc");

            numlanky.DataBindings.Clear();
            numlanky.DataBindings.Add("Text", bs, "lanky");

            txtNoiDung.DataBindings.Clear();
            txtNoiDung.DataBindings.Add("Text", bs, "noidung");

            dteNgayKy.DataBindings.Clear();
            dteNgayKy.DataBindings.Add("Text", bs, "ngayky");

            cmbNguoiKy.DataBindings.Clear();
            cmbNguoiKy.DataBindings.Add("SelectedValue", bs, "manguoiky");

            txtGhiChu.DataBindings.Clear();
            txtGhiChu.DataBindings.Add("Text", bs, "ghichu");
        }
    }
}
