using System;
using System.Collections.Generic;
using System.Text;
using QUANLYNHANSU.GetData;
using DevComponents.DotNetBar.Controls;
using GenericDataGridView;
using System.Windows.Forms;


namespace QUANLYNHANSU.Controller
{
    public class clsChuyenNhanVienController
    {
        clsLayChuyenNhanVien cnv = new clsLayChuyenNhanVien();
        clsLaySoQuyetDinh sqd = new clsLaySoQuyetDinh();
        clsLayPhongBan pb = new clsLayPhongBan();
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

        public void HienthiPhongban(ComboBox cmb)
        {
            cmb.DataSource = pb.LayPhongBan();
            cmb.DisplayMember = "tenphong";
            cmb.ValueMember = "maphong";
        }

        public void HienthiGridPhongban(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = pb.LayPhongBan();
            cmb.DisplayMember = "tenphong";
            cmb.ValueMember = "maphong";
            cmb.DataPropertyName = "maphongmoi";
        }

        public void HienthiNV(ComboBox cmb)
        {
            cmb.DataSource = nv.LayNhanVien();
            cmb.DisplayMember = "tennv";
            cmb.ValueMember = "manv";
        }

        public void HienthiGridNV(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = nv.LayNhanVien();
            cmb.DisplayMember = "tennv";
            cmb.ValueMember = "manv";
            cmb.DataPropertyName = "manv";
        }

        public void HienThi(TextBoxX txtma,ComboBoxEx cmbNV,ComboBoxEx cmbSQD,DateTimePicker dteNgayChuyen,ComboBoxEx cmbtrongngoai,TextBoxX txtDonviden,ComboBoxEx cmbPhong,TextBoxX txtGhiChu, DataGridViewX dtg,BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = cnv.LayChuyenNhanVien();
            dtg.DataSource = bs;
            bn.BindingSource = bs;

            txtma.DataBindings.Clear();
            txtma.DataBindings.Add("Text", bs, "machuyennv");

            cmbNV.DataBindings.Clear();
            cmbNV.DataBindings.Add("SelectedValue", bs, "manv");

            cmbSQD.DataBindings.Clear();
            cmbSQD.DataBindings.Add("SelectedValue", bs, "masoquyetdinh");

            dteNgayChuyen.DataBindings.Clear();
            dteNgayChuyen.DataBindings.Add("Text", bs, "ngaychuyen");

            cmbtrongngoai.DataBindings.Clear();
            cmbtrongngoai.DataBindings.Add("Text", bs, "tronghayngoai");

            txtDonviden.DataBindings.Clear();
            txtDonviden.DataBindings.Add("Text", bs, "donviden");

            cmbPhong.DataBindings.Clear();
            cmbPhong.DataBindings.Add("SelectedValue", bs, "maphongmoi");

            txtGhiChu.DataBindings.Clear();
            txtGhiChu.DataBindings.Add("Text", bs, "ghichu");
        }
    }
}
