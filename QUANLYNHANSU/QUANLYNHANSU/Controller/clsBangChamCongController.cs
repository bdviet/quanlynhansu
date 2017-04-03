using System;
using System.Collections.Generic;
using System.Text;
using QUANLYNHANSU.GetData;
using DevComponents.DotNetBar.Controls;
using System.Windows.Forms;
using System.Data;

namespace QUANLYNHANSU.Controller
{
    public class clsBangChamCongController
    {
        clsLayBangChamCong GetBangChamCong = new clsLayBangChamCong();
        clsLayBangNhanVien nv = new clsLayBangNhanVien();

        public void HienThiComboboxTenNV(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = nv.LayNhanVien();
            cmb.DisplayMember = "tennv";
            cmb.ValueMember = "manv";
            cmb.DataPropertyName = "manv";
        }
        public void HienThiCombobox1(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataPropertyName = "ngay1";
        }
        public void HienThiCombobox2(DataGridViewComboBoxColumn cmb)
        {
            //cmb.DataSource = GetBangChamCong.LayBangChamCong();
            cmb.DataPropertyName = "ngay2";
        }
        public void HienThiCombobox3(DataGridViewComboBoxColumn cmb)
        {
            //cmb.DataSource = GetBangChamCong.LayBangChamCong();
            cmb.DataPropertyName = "ngay3";
        }
        public void HienThiCombobox4(DataGridViewComboBoxColumn cmb)
        {
            //cmb.DataSource = GetBangChamCong.LayBangChamCong();
            cmb.DataPropertyName = "ngay4";
        }
        public void HienThiCombobox5(DataGridViewComboBoxColumn cmb)
        {
            //cmb.DataSource = GetBangChamCong.LayBangChamCong();
            cmb.DataPropertyName = "ngay5";
        }
        public void HienThiCombobox6(DataGridViewComboBoxColumn cmb)
        {
            //cmb.DataSource = GetBangChamCong.LayBangChamCong();
            cmb.DataPropertyName = "ngay6";
        }
        public void HienThiCombobox7(DataGridViewComboBoxColumn cmb)
        {
            //cmb.DataSource = GetBangChamCong.LayBangChamCong();
            cmb.DataPropertyName = "ngay7";
        }
        public void HienThiCombobox8(DataGridViewComboBoxColumn cmb)
        {
            //cmb.DataSource = GetBangChamCong.LayBangChamCong();
            cmb.DataPropertyName = "ngay8";
        }
        public void HienThiCombobox9(DataGridViewComboBoxColumn cmb)
        {
            //cmb.DataSource = GetBangChamCong.LayBangChamCong();
            cmb.DataPropertyName = "ngay9";
        }
        public void HienThiCombobox10(DataGridViewComboBoxColumn cmb)
        {
            //cmb.DataSource = GetBangChamCong.LayBangChamCong();
            cmb.DataPropertyName = "ngay10";
        }
        public void HienThiCombobox11(DataGridViewComboBoxColumn cmb)
        {
            //cmb.DataSource = GetBangChamCong.LayBangChamCong();
            cmb.DataPropertyName = "ngay11";
        }
        public void HienThiCombobox12(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataPropertyName = "ngay12";
        }
        public void HienThiCombobox13(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataPropertyName = "ngay13";
        }
        public void HienThiCombobox14(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataPropertyName = "ngay14";
        }
        public void HienThiCombobox15(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataPropertyName = "ngay15";
        }
        public void HienThiCombobox16(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataPropertyName = "ngay16";
        }
        public void HienThiCombobox17(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataPropertyName = "ngay17";
        }
        public void HienThiCombobox18(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataPropertyName = "ngay18";
        }
        public void HienThiCombobox19(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataPropertyName = "ngay19";
        }
        public void HienThiCombobox20(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataPropertyName = "ngay20";
        }
        public void HienThiCombobox21(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataPropertyName = "ngay21";
        }
        public void HienThiCombobox22(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataPropertyName = "ngay22";
        }
        public void HienThiCombobox23(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataPropertyName = "ngay23";
        }
        public void HienThiCombobox24(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataPropertyName = "ngay24";
        }
        public void HienThiCombobox25(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataPropertyName = "ngay25";
        }
        public void HienThiCombobox26(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataPropertyName = "ngay26";
        }
        public void HienThiCombobox27(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataPropertyName = "ngay27";
        }
        public void HienThiCombobox28(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataPropertyName = "ngay28";
        }
        public void HienThiCombobox29(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataPropertyName = "ngay29";
        }
        public void HienThiCombobox30(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataPropertyName = "ngay30";
        }
        public void HienThiCombobox31(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataPropertyName = "ngay31";
        }

        public void HienThiGridTheoThangNam(DataTable dt, DataGridViewX dtg,BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            bn.BindingSource = bs;
            dtg.DataSource = bs;
        }
        
    }
}
