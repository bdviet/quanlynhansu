using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QUANLYNHANSU.Controller;
using QUANLYNHANSU.GetData;

namespace QUANLYNHANSU
{
    public partial class frmBangChiLuong : Office2007Form
    {
        int goituchamcong = 0;
        int thangcc = 1;
        int namcc = 2009;
        string maphongcc = null;

        public frmBangChiLuong(int call,int thang,int nam,string maphong)
        {
            goituchamcong = call;
            thangcc = thang;
            namcc = nam;
            maphongcc = maphong;

            InitializeComponent();
        }
        public frmBangChiLuong()
        {
            InitializeComponent();
        }

        clsLayBangChiLuong bangchi = new clsLayBangChiLuong();
        clsLayBangNhanVien nhanvien = new clsLayBangNhanVien();
        clsLayBangChamCong chamcong = new clsLayBangChamCong();
        clsLayThongTinNganHang nganhang = new clsLayThongTinNganHang();
        clsLayChucVu getchucvu = new clsLayChucVu();

        clsBangChiLuongController control = new clsBangChiLuongController();

        DataTable dtCL = new DataTable();
        DataTable dtCC = new DataTable();
        DataTable dtCCtheothangnam = new DataTable();
        DataTable dtNV = new DataTable();
        DataTable dtNVDangLam = new DataTable();
        DataTable dtNH = new DataTable();
        DataTable dtCV = new DataTable();
        DataTable dtNVThuViec = new DataTable();

        public void frmBangChiLuong_Load(object sender, EventArgs e)
        {
            control.HienThiCombobox(cmbcolTenNV);
            control.HienThiComboboxPhongban(cmbPhong);
   
            for (int i = 1; i < 10; i++)
            {
                cmbThang.Items.Add("Tháng 0" + i);
            }
            for (int i = 10; i < 13; i++)
            {
                cmbThang.Items.Add("Tháng " + i);
            }

            if (goituchamcong == 0)
                cmbThang.SelectedIndex = 0;
            else
                cmbThang.SelectedIndex = thangcc - 1;

            for (int i = 1900; i < 2301; i++)
            {
                cmbNam.Items.Add("Năm " + i);
            }

            if (goituchamcong == 0)
            {
                cmbThang.SelectedIndex = 0;
                cmbNam.SelectedIndex = 109;
                cmbPhong.SelectedIndex = 0;
            }
            else
            {
                cmbThang.SelectedIndex = thangcc - 1;
                cmbNam.SelectedIndex = namcc - 1900;
                cmbPhong.SelectedValue = maphongcc;
            }
            bntChiLuong_Click(sender, e);
        }

        double LuongCB;

        public void Them(int thuviec, string manhanvien, string thangchi, string namchi)
        {
            //MessageBox.Show("them");
            string macl = "CL";

            string masothutu;

            string thang = DateTime.Now.Month.ToString();
            if (thang.Length == 1)
                thang = "0" + thang;

            string nam = DateTime.Now.Year.ToString();
            string nam02 = nam[2].ToString() + nam[3].ToString();

            string thangnam = thang + nam02;
            dtCL = bangchi.LayBangLuong();
            int phantu = 0;

            foreach (DataRow dt in dtCL.Rows)
            {
                string ma = dt["maluong"].ToString();
                string mathangnam = ma[2].ToString() + ma[3].ToString() + ma[4].ToString() + ma[5].ToString();
                string mathutu = ma[6].ToString() + ma[7].ToString() + ma[8].ToString() + ma[9].ToString();

                if (thangnam == mathangnam)
                {
                    int stt = Convert.ToInt32(mathutu);
                    if (stt > phantu)
                        phantu = stt;
                }
            }
            if (phantu != 0)
            {
                phantu++;

                if (phantu.ToString().Length == 1)
                    masothutu = "000" + phantu.ToString();
                else if (phantu.ToString().Length == 2)
                    masothutu = "00" + phantu.ToString();
                else if (phantu.ToString().Length == 3)
                    masothutu = "0" + phantu.ToString();
                else
                    masothutu = phantu.ToString();

                macl = macl + thangnam + masothutu;
            }
            else
            {
                macl = macl + thangnam + "0001";
            }

            //lay luong CB
            dtNH = nganhang.LayThongTinNganHang();
            DataRow drLCB = dtNH.Rows[0];
            LuongCB = Convert.ToDouble(drLCB["luongCB"].ToString());
            //MessageBox.Show(LuongCB.ToString());

            if (thuviec == 0)
            {
                
                double heso = 1;
                string chucvu = null;
                int thamnien = 1;
                dtNV = nhanvien.LayNhanVien();
                foreach (DataRow dr in dtNV.Rows)
                {
                    if (manhanvien == dr["manv"].ToString())
                    {
                        heso = Convert.ToDouble(dr["heso"].ToString());
                        chucvu = dr["machucvu"].ToString();
                        thamnien = Convert.ToInt32(dr["thamnien"].ToString());
                        break;
                    }
                }
                double LuongThang;
                LuongThang = LuongCB * heso;

                dtCV = getchucvu.LayChucVu();
                double phucapchucvu = 0;
                foreach (DataRow dr in dtCV.Rows)
                {
                    if (chucvu == dr["machucvu"].ToString())
                    {
                        phucapchucvu = Convert.ToDouble(dr["phucap"].ToString());
                        break;
                    }
                }

                double LuongPhuCap;
                LuongPhuCap = LuongCB * phucapchucvu;

                double tongluong = LuongThang + LuongPhuCap;
                double BHXH = tongluong * 0.06;
                double BHYT = tongluong * 0.01;
                double doanphi = tongluong * 0.01;
                double thuclanh = tongluong * 0.92;

                if (thamnien == 1)
                    thuclanh = thuclanh * 90 / 100;

                dtCCtheothangnam = chamcong.LayBangChamCongTheoThangNam(Convert.ToInt32(thangchi), Convert.ToInt32(namchi));
                int ngaylamviec = 0;
                foreach (DataRow dr in dtCCtheothangnam.Rows)
                    if (manhanvien == dr["manv"].ToString())
                    {
                        ngaylamviec = Convert.ToInt32(dr["ngaydilam"].ToString());
                        break;
                    }

                bangchi.ThemMoi(macl, thangchi + "/01" + "/" + namchi, manhanvien, ngaylamviec, LuongThang, 0, LuongPhuCap, 0, 0, 0, 0, 0, tongluong, BHXH, BHYT, doanphi, thuclanh);
            }
            if (thuviec == 1)
            {
                double thuclanh = LuongCB * 70 / 100;
                bangchi.ThemMoi(macl, thangchi + "/01" + "/" + namchi, manhanvien, 26, LuongCB, 0, 0, 0, 0, 0, 0, 0, LuongCB, 0, 0, 0, thuclanh);
            }
        }

        public void bntChiLuong_Click(object sender, EventArgs e)
        {
            string thang = cmbThang.SelectedItem.ToString();
            string nam = cmbNam.SelectedItem.ToString();
            thang = thang[6].ToString() + thang[7].ToString();
            nam = nam[4].ToString() + nam[5].ToString() + nam[6].ToString() + nam[7].ToString();

            //dtCL = bangchi.LayBangLuongTheoThangNam(Convert.ToInt32(thang), Convert.ToInt32(nam));
            if (cmbPhong.SelectedValue != null)
                dtNV = nhanvien.LayNhanVienTheoPhongBan(cmbPhong.SelectedValue.ToString());

            dtCC = chamcong.LayBangChamCongTheoThangNam(Convert.ToInt32(thang), Convert.ToInt32(nam));

            if (dtNV.Rows.Count != 0)
            {
                DataTable dtCCTheoPhong = new DataTable();
                dtCCTheoPhong = dtCC.Clone();
                foreach (DataRow dr1 in dtCC.Rows)
                    foreach (DataRow dr2 in dtNV.Rows)
                    {
                        if (dr1["manv"].ToString() == dr2["manv"].ToString())
                            dtCCTheoPhong.ImportRow(dr1);
                    }


                    dtCL = bangchi.LayBangLuongTheoThangNam(Convert.ToInt32(thang), Convert.ToInt32(nam));
                    DataTable dtCLTheoPhong = new DataTable();
                    dtCLTheoPhong = dtCL.Clone();
                    foreach (DataRow dr1 in dtCL.Rows)
                        foreach (DataRow dr2 in dtNV.Rows)
                        {
                            if (dr1["manv"].ToString() == dr2["manv"].ToString())
                                dtCLTheoPhong.ImportRow(dr1);
                        }

                    if (dtCCTheoPhong.Rows.Count == dtCLTheoPhong.Rows.Count)
                    {
                        //dtNVThuViec = nhanvien.LayNhanVienThuViecTheoPhong(cmbPhong.SelectedValue.ToString());
                        //if (dtNVThuViec.Rows.Count != 0)
                        //{
                        //    string[] manv = new string[100];
                        //    int stt = 0;
                        //    foreach (DataRow dr in dtNVThuViec.Rows)
                        //    {
                        //        manv[stt] = dr["manv"].ToString();
                        //        stt++;
                        //    }
                        //    for (int i = 0; i < manv.Length; i++)
                        //    {
                        //        if (manv[i] != null)
                        //            Them(1, manv[i], thang, nam);
                        //        else
                        //            break;
                        //    }
                        //}

                        dtCL = bangchi.LayBangLuongTheoThangNam(Convert.ToInt32(thang), Convert.ToInt32(nam));
                        dtNV = nhanvien.LayNhanVienTheoPhongBan(cmbPhong.SelectedValue.ToString());
                        dtCLTheoPhong = new DataTable();
                        dtCLTheoPhong = dtCL.Clone();
                        foreach (DataRow dr1 in dtCL.Rows)
                            foreach (DataRow dr2 in dtNV.Rows)
                            {
                                if (dr1["manv"].ToString() == dr2["manv"].ToString())
                                    dtCLTheoPhong.ImportRow(dr1);
                            }
                    }

                    control.HienThiGridTheoThangNam(dtCLTheoPhong, dtgBangChiLuong, bnBangChiLuong);
                //}
                //else
                //    MessageBoxEx.Show("Bạn phải chấm công tháng này!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBoxEx.Show("Không có nhân viên của phòng ban này!!!", "Thông Báo");
        }

        public void Luu()
        {
            int donghh = dtgBangChiLuong.CurrentRow.Index;
            bangchi.CapNhat(dtgBangChiLuong["maluong", donghh].Value.ToString(), Convert.ToDouble(dtgBangChiLuong["tongluong", donghh].Value.ToString()), Convert.ToDouble(dtgBangChiLuong["thuclanh", donghh].Value.ToString()), Convert.ToDouble(dtgBangChiLuong["phucapdochai", donghh].Value.ToString()), Convert.ToDouble(dtgBangChiLuong["trocaptrachnhiem", donghh].Value.ToString()), Convert.ToDouble(dtgBangChiLuong["trocapantrua", donghh].Value.ToString()), Convert.ToDouble(dtgBangChiLuong["trocapxanha", donghh].Value.ToString()), Convert.ToDouble(dtgBangChiLuong["trocapQLDN", donghh].Value.ToString()));
        }

        private void frmBangChiLuong_Activated(object sender, EventArgs e)
        {
            bntChiLuong_Click(sender, e);
            //string thang = cmbThang.SelectedItem.ToString();
            //string nam = cmbNam.SelectedItem.ToString();
            //thang = thang[6].ToString() + thang[7].ToString();
            //nam = nam[4].ToString() + nam[5].ToString() + nam[6].ToString() + nam[7].ToString();

            //dtCL = bangchi.LayBangLuongTheoThangNam(Convert.ToInt32(thang), Convert.ToInt32(nam));
            //if (cmbPhong.SelectedValue != null)
            //    dtNV = nhanvien.LayNhanVienTheoPhongBan(cmbPhong.SelectedValue.ToString());
            //dtCC = chamcong.LayBangChamCongTheoThangNam(Convert.ToInt32(thang), Convert.ToInt32(nam));

            //DataTable dtCCTheoPhong = new DataTable();
            //dtCCTheoPhong = dtCC.Clone();
            //foreach (DataRow dr1 in dtCC.Rows)
            //    foreach (DataRow dr2 in dtNV.Rows)
            //    {
            //        if (dr1["manv"].ToString() == dr2["manv"].ToString())
            //            dtCCTheoPhong.ImportRow(dr1);
            //    }
            //if (dtCCTheoPhong.Rows.Count != 0)
            //{
            //    DataTable dtCLTheoPhong = new DataTable();
            //    dtCLTheoPhong = dtCL.Clone();
            //    foreach (DataRow dr1 in dtCL.Rows)
            //        foreach (DataRow dr2 in dtNV.Rows)
            //        {
            //            if (dr1["manv"].ToString() == dr2["manv"].ToString())
            //                dtCLTheoPhong.ImportRow(dr1);
            //        }

            //    control.HienThiGridTheoThangNam(dtCLTheoPhong, dtgBangChiLuong, bnBangChiLuong);
            //}
        }

        private void dtgBangChiLuong_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int donghienhanh = dtgBangChiLuong.CurrentRow.Index;

            if (dtgBangChiLuong["BHXH", donghienhanh].Value.ToString().Length != 1)
            {
                double luongthang = Convert.ToDouble(dtgBangChiLuong["luongthang", donghienhanh].Value.ToString());
                double phucapchucvu = Convert.ToDouble(dtgBangChiLuong["phucapchucvu", donghienhanh].Value.ToString());
                double phucapdochai = Convert.ToDouble(dtgBangChiLuong["phucapdochai", donghienhanh].Value.ToString());
                double trocaptrachnhiem = Convert.ToDouble(dtgBangChiLuong["trocaptrachnhiem", donghienhanh].Value.ToString());
                double trocapantrua = Convert.ToDouble(dtgBangChiLuong["trocapantrua", donghienhanh].Value.ToString());
                double trocapxanha = Convert.ToDouble(dtgBangChiLuong["trocapxanha", donghienhanh].Value.ToString());
                double trocapQLDN = Convert.ToDouble(dtgBangChiLuong["trocapQLDN", donghienhanh].Value.ToString());
                double tongluong = luongthang + phucapchucvu + phucapdochai + trocaptrachnhiem + trocapantrua + trocapxanha + trocapQLDN;
                dtgBangChiLuong["tongluong", donghienhanh].Value = tongluong;
                dtgBangChiLuong["BHXH", donghienhanh].Value = tongluong * 0.06;
                dtgBangChiLuong["BHYT", donghienhanh].Value = tongluong * 0.01;
                dtgBangChiLuong["doanphi", donghienhanh].Value = tongluong * 0.01;

                int thamnien = 1;
                dtNV = nhanvien.LayNhanVien();
                foreach (DataRow dr in dtNV.Rows)
                {
                    if (dtgBangChiLuong["cmbcolTenNV", donghienhanh].Value.ToString() == dr["manv"].ToString())
                    {
                        thamnien = Convert.ToInt32(dr["thamnien"].ToString());
                        break;
                    }
                }
                if (thamnien == 1)
                    dtgBangChiLuong["thuclanh", donghienhanh].Value = ((tongluong * 0.92) - Convert.ToDouble(dtgBangChiLuong["truluong", donghienhanh].Value.ToString())) * 90 / 100;
                else
                    dtgBangChiLuong["thuclanh", donghienhanh].Value = (tongluong * 0.92) - Convert.ToDouble(dtgBangChiLuong["truluong", donghienhanh].Value.ToString());
                Luu();
            }
            //else
            //    MessageBoxEx.Show("Đây là nhân viên thử việc","Thông Báo");
        }

        private void dtgBangChiLuong_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCellStyle style1 = new DataGridViewCellStyle();
            style1.ForeColor = Color.Olive;
            style1.BackColor = Color.WhiteSmoke;

            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            style2.ForeColor = Color.MediumBlue;
            style2.BackColor = Color.Pink;

            for (int i = dtgBangChiLuong.RowCount - 1; i >= 0; i--)
            {
                if (i % 2 == 0)
                    dtgBangChiLuong.Rows[i].DefaultCellStyle = style1;
                else
                    dtgBangChiLuong.Rows[i].DefaultCellStyle = style2;
            }
        }

    }
}