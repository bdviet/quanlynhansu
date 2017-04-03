using System;
using System.Collections.Generic;
using System.Text;
using QUANLYNHANSU.GetData;
using DevComponents.DotNetBar.Controls;
using System.Windows.Forms;
using System.Data;

namespace QUANLYNHANSU.Controller
{
    public class clsBangChiLuongController
    {
        clsLayBangChiLuong bangluong = new clsLayBangChiLuong();
        clsLayBangNhanVien nv = new clsLayBangNhanVien();
        clsLayPhongBan pb = new clsLayPhongBan();

        public void HienThiCombobox(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = nv.LayNhanVien(); 
            cmb.DisplayMember = "tennv";
            cmb.ValueMember = "manv";
            cmb.DataPropertyName = "manv";
        }
        public void HienThiComboboxPhongban(ComboBoxEx cmb)
        {
            cmb.DataSource = pb.LayPhongBan();
            cmb.DisplayMember = "tenphong";
            cmb.ValueMember = "maphong";
        }

        public void HienThiGridTheoThangNam(DataTable dt, DataGridViewX dtg, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            bn.BindingSource = bs;
            dtg.DataSource = bs;
        }
       
    }
}
