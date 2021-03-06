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
    public partial class frmBangChamCong : Office2007Form
    {
        public frmBangChamCong()
        {
            InitializeComponent();
        }
        clsLayBangChamCong laybangchamcong = new clsLayBangChamCong();
        clsLayBangNhanVien laynhanvien = new clsLayBangNhanVien();
        clsLayBangChiLuong chiluong = new clsLayBangChiLuong();
        clsLayPhongBan phongban = new clsLayPhongBan();

        clsBangChamCongController control = new clsBangChamCongController();
        clsBangChiLuongController chicontrol = new clsBangChiLuongController();

        DataTable dtCC = new DataTable();
        DataTable dtCCtrongnam = new DataTable();
        DataTable dtNV = new DataTable();
        DataTable dtChiLuongTheoThangNam = new DataTable();
        DataTable dtNVTheoPhong = new DataTable();
        DataTable dtNVTheoPhongDangLam = new DataTable();
        DataTable dtNVThuViec = new DataTable();


        private void frmBangChamCong_Load(object sender, EventArgs e)
        {
            control.HienThiComboboxTenNV(cmbTenNV);

            control.HienThiCombobox1(n1);
            control.HienThiCombobox2(n2);
            control.HienThiCombobox3(n3);
            control.HienThiCombobox4(n4);
            control.HienThiCombobox5(n5);
            control.HienThiCombobox6(n6);
            control.HienThiCombobox7(n7);
            control.HienThiCombobox8(n8);
            control.HienThiCombobox9(n9);
            control.HienThiCombobox10(n10);
            control.HienThiCombobox11(n11);
            control.HienThiCombobox12(n12);
            control.HienThiCombobox13(n13);
            control.HienThiCombobox14(n14);
            control.HienThiCombobox15(n15);
            control.HienThiCombobox16(n16);
            control.HienThiCombobox17(n17);
            control.HienThiCombobox18(n18);
            control.HienThiCombobox19(n19);
            control.HienThiCombobox20(n20);
            control.HienThiCombobox21(n21);
            control.HienThiCombobox22(n22);
            control.HienThiCombobox23(n23);
            control.HienThiCombobox24(n24);
            control.HienThiCombobox25(n25);
            control.HienThiCombobox26(n26);
            control.HienThiCombobox27(n27);
            control.HienThiCombobox28(n28);
            control.HienThiCombobox29(n29);
            control.HienThiCombobox30(n30);
            control.HienThiCombobox31(n31);

            for (int i = 1; i < 10; i++)
            {
                cmbThang.Items.Add("Tháng 0" + i);
            }
            for (int i = 10; i < 13; i++)
            {
                cmbThang.Items.Add("Tháng " + i);
            }
            cmbThang.SelectedIndex = 0;
            for (int i = 1900; i < 2301; i++)
            {
                cmbNam.Items.Add("Năm " + i);
            }
            cmbNam.SelectedIndex = 109;

            cmbPhongBan.DataSource = phongban.LayPhongBan();
            cmbPhongBan.DisplayMember = "tenphong";
            cmbPhongBan.ValueMember = "maphong";
            cmbPhongBan.SelectedIndex = 0;

            dtCC = laybangchamcong.LayBangChamCongRong();
            control.HienThiGridTheoThangNam(dtCC, dtgBangChamCong, bnBangChamCong);

            HienThiChamCong(1);
        }

        public void Them(string manhanvien, string thangthem, string namthem)
        {
            string macc = "CC";

            string masothutu;

            string thang = DateTime.Now.Month.ToString();
            if (thang.Length == 1)
                thang = "0" + thang;

            string nam = DateTime.Now.Year.ToString();
            string nam02 = nam[2].ToString() + nam[3].ToString();

            string thangnam = thang + nam02;

            int phantu = 0;
            dtCC = laybangchamcong.LayBangChamCong();

            foreach(DataRow dr in dtCC.Rows)
            {
                string ma = dr["machamcong"].ToString();
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

                macc = macc + thangnam + masothutu;
            }
            else
            {
                macc = macc + thangnam + "0001";
            }

            DataRowView row = (DataRowView)bnBangChamCong.BindingSource.AddNew();

            row["machamcong"] = macc;
            row["manv"] = manhanvien;
            row["thangchamcong"] = "01/" + thangthem + "/" + namthem;
            row["vang"] = 0;

            //int ngaydilam=0;
            //int tongsongay=0;

            for (int i = 1; i < 32; i++)
            {
                if (i != 7 && i != 14 && i != 21 && i != 28)
                {
                    row["ngay" + i.ToString()] = "x";
                }
            }
                if (thangthem == "02")
                {
                    row["ngay29"] = "";
                    row["ngay30"] = "";
                    row["ngay31"] = "";
                    row["ngaydilam"] = 24;
                    row["tongsongay"] = 24;

                    laybangchamcong.ThemMoi(macc, thangthem + "/01" + "/" + namthem, manhanvien, "x", "x", "x", "x", "x", "x", null, "x", "x", "x", "x", "x", "x", null, "x", "x", "x", "x", "x", "x", null, "x", "x", "x", "x", "x", "x", null, null, null, null, 24, 24, 0);
                }
                else
                {
                    if (thangthem == "04" || thangthem == "06" || thangthem == "09" || thangthem == "10" || thangthem == "11")
                    {
                        row["ngay31"] = "";
                        row["ngaydilam"] = 26;
                        row["tongsongay"] = 26;

                        laybangchamcong.ThemMoi(macc, thangthem+"/01" + "/" + namthem, manhanvien, "x", "x", "x", "x", "x", "x", null, "x", "x", "x", "x", "x", "x", null, "x", "x", "x", "x", "x", "x", null, "x", "x", "x", "x", "x", "x", null, "x", "x", null, 26, 26, 0);
                    }
                    else
                    {
                        row["ngaydilam"] = 27;
                        row["tongsongay"] = 27;

                        laybangchamcong.ThemMoi(macc, thangthem + "/01" + "/" + namthem, manhanvien, "x", "x", "x", "x", "x", "x", null, "x", "x", "x", "x", "x", "x", null, "x", "x", "x", "x", "x", "x", null, "x", "x", "x", "x", "x", "x", null, "x", "x", "x", 27, 27, 0);
                    }
                }
        }

        public void HienThiChamCong(int load)
        {
            //dtNVTheoPhong = laynhanvien.LayNhanVienTheoPhongBan(cmbPhongBan.SelectedValue.ToString());
            if (cmbThang.SelectedItem.ToString() == "Tháng 02")
            {
                dtgBangChamCong.Columns["n29"].ReadOnly = true;
                dtgBangChamCong.Columns["n30"].ReadOnly = true;
                dtgBangChamCong.Columns["n31"].ReadOnly = true;
            }
            else
            {
                if (cmbThang.SelectedItem.ToString() == "Tháng 04" || cmbThang.SelectedItem.ToString() == "Tháng 06" || cmbThang.SelectedItem.ToString() == "Tháng 09" || cmbThang.SelectedItem.ToString() == "Tháng 10" || cmbThang.SelectedItem.ToString() == "Tháng 11")
                    dtgBangChamCong.Columns["n31"].ReadOnly = true;
                else
                {
                    dtgBangChamCong.Columns["n29"].ReadOnly = false;
                    dtgBangChamCong.Columns["n30"].ReadOnly = false;
                    dtgBangChamCong.Columns["n31"].ReadOnly = false;
                }
            }

            string thang = cmbThang.SelectedItem.ToString();
            string nam = cmbNam.SelectedItem.ToString();

            thang = thang[6].ToString() + thang[7].ToString();
            nam = nam[4].ToString() + nam[5].ToString() + nam[6].ToString() + nam[7].ToString();

            dtNVTheoPhong = laynhanvien.LayNhanVienTheoPhongBan(cmbPhongBan.SelectedValue.ToString());
            dtCC = laybangchamcong.LayBangChamCongTheoThangNam(Convert.ToInt32(thang), Convert.ToInt32(nam));


            if (dtNVTheoPhong.Rows.Count != 0)
            {
                DataTable dtCCNVTheoPhong = new DataTable();
                dtCCNVTheoPhong = dtCC.Clone();
                //MessageBox.Show("dtNVTheoPhong : " + dtNVTheoPhong.Rows.Count.ToString());
                foreach (DataRow dr1 in dtCC.Rows)
                {
                    foreach (DataRow dr2 in dtNVTheoPhong.Rows)
                    {
                        if (dr1["manv"].ToString() == dr2["manv"].ToString())
                        {
                            dtCCNVTheoPhong.ImportRow(dr1);
                            break;
                        }
                    }
                }
                if (dtCCNVTheoPhong.Rows.Count != 0)
                    control.HienThiGridTheoThangNam(dtCCNVTheoPhong, dtgBangChamCong, bnBangChamCong);

                else
                {
                    if (load == 0)
                    {
                        dtNVTheoPhongDangLam = new DataTable();
                        dtNVTheoPhongDangLam = laynhanvien.LayNhanVienTheoPhongBanDangLam(cmbPhongBan.SelectedValue.ToString());
                        MessageBox.Show(dtNVTheoPhongDangLam.Rows.Count.ToString());
                        string[] manv = new string[100];
                        int stt = 0;
                        foreach (DataRow dr in dtNVTheoPhongDangLam.Rows)
                        {
                            manv[stt] = dr["manv"].ToString();
                            stt++;
                        }

                        for (int i = 0; i < manv.Length; i++)
                        {
                            if (manv[i] != null)
                            {
                                Them(manv[i], thang, nam);

                                frmBangChiLuong fchiluong = new frmBangChiLuong();
                                fchiluong.Them(0, manv[i], thang, nam);
                            }
                            else
                                break;
                        }

                        dtNVThuViec = laynhanvien.LayNhanVienThuViecTheoPhong(cmbPhongBan.SelectedValue.ToString());
                        //MessageBox.Show(dtNVThuViec.Rows.Count.ToString());
                        if (dtNVThuViec.Rows.Count != 0)
                        {
                            string[] manvthuviec = new string[100];
                            int sttthuviec = 0;
                            foreach (DataRow dr in dtNVThuViec.Rows)
                            {
                                manvthuviec[sttthuviec] = dr["manv"].ToString();
                                sttthuviec++;
                            }
                            for (int i = 0; i < manvthuviec.Length; i++)
                            {
                                if (manvthuviec[i] != null)
                                {
                                    //MessageBox.Show(manvthuviec[i]);
                                    frmBangChiLuong fchiluong = new frmBangChiLuong();
                                    fchiluong.Them(1, manvthuviec[i], thang, nam);
                                }
                                else
                                    break;
                            }
                        }

                        HienThiChamCong(load);
                    }
                }
            }
            else
            {
                MessageBoxEx.Show("Không có nhân viên của phòng ban này", "Thông Báo");

                DataTable dtCCNVTheoPhong = new DataTable();
                dtCCNVTheoPhong = dtCC.Clone();
                control.HienThiGridTheoThangNam(dtCCNVTheoPhong, dtgBangChamCong, bnBangChamCong);
            }

        }

        public void Luu()
        {
            dtgBangChamCong.EndEdit();
            int donghh = dtgBangChamCong.CurrentRow.Index;
            laybangchamcong.CapNhat(dtgBangChamCong["machamcong", donghh].Value.ToString(), dtgBangChamCong["n1", donghh].Value.ToString(), dtgBangChamCong["n2", donghh].Value.ToString(), dtgBangChamCong["n3", donghh].Value.ToString(), dtgBangChamCong["n4", donghh].Value.ToString(), dtgBangChamCong["n5", donghh].Value.ToString(), dtgBangChamCong["n6", donghh].Value.ToString(), dtgBangChamCong["n7", donghh].Value.ToString(), dtgBangChamCong["n8", donghh].Value.ToString(), dtgBangChamCong["n9", donghh].Value.ToString(), dtgBangChamCong["n10", donghh].Value.ToString(), dtgBangChamCong["n11", donghh].Value.ToString(), dtgBangChamCong["n12", donghh].Value.ToString(), dtgBangChamCong["n13", donghh].Value.ToString(), dtgBangChamCong["n14", donghh].Value.ToString(), dtgBangChamCong["n15", donghh].Value.ToString(), dtgBangChamCong["n16", donghh].Value.ToString(), dtgBangChamCong["n17", donghh].Value.ToString(), dtgBangChamCong["n18", donghh].Value.ToString(), dtgBangChamCong["n19", donghh].Value.ToString(), dtgBangChamCong["n20", donghh].Value.ToString(), dtgBangChamCong["n21", donghh].Value.ToString(), dtgBangChamCong["n22", donghh].Value.ToString(), dtgBangChamCong["n23", donghh].Value.ToString(), dtgBangChamCong["n24", donghh].Value.ToString(), dtgBangChamCong["n25", donghh].Value.ToString(), dtgBangChamCong["n26", donghh].Value.ToString(), dtgBangChamCong["n27", donghh].Value.ToString(), dtgBangChamCong["n28", donghh].Value.ToString(), dtgBangChamCong["n29", donghh].Value.ToString(), dtgBangChamCong["n30", donghh].Value.ToString(), dtgBangChamCong["n31", donghh].Value.ToString(), Convert.ToInt32(dtgBangChamCong["ngaydilam", donghh].Value.ToString()), Convert.ToInt32(dtgBangChamCong["vang", donghh].Value.ToString()));
        }

        int dathongbao = 0;

        private void dtgBangChamCong_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int dong = dtgBangChamCong.CurrentRow.Index;
            int ngaydilam = 0;
            int vang = 0;

            for (int i = 01; i < 32; i++)
            {
                if (dtgBangChamCong["n" + i.ToString(), dong].Value.ToString() == "x")
                    ngaydilam++;
                if (dtgBangChamCong["n" + i.ToString(), dong].Value.ToString() == "P")
                    vang++;
            }
            dtgBangChamCong["ngaydilam", dong].Value = ngaydilam;
            dtgBangChamCong["vang", dong].Value = vang;

            Luu();

            if (vang > 5 && dathongbao == 0)
            {
                MessageBoxEx.Show("Nhân viên này đã nghĩ trên 5 ngày trong tháng!Đề nghị cho thôi việc");
                dathongbao = 1;
            }

            DateTime nam = Convert.ToDateTime(dtgBangChamCong["thangchamcong", dtgBangChamCong.CurrentRow.Index].Value);
            
            dtCCtrongnam = laybangchamcong.LayBangChamCongTheoNamCuaNhanVien(nam.Year, dtgBangChamCong["cmbTenNV", dtgBangChamCong.CurrentRow.Index].Value.ToString());
            int vangtrongnam = 0;

            foreach (DataRow dr in dtCCtrongnam.Rows)
            {
                vangtrongnam += Convert.ToInt32(dr["vang"].ToString());
            }
            if (vangtrongnam > 20)
            {
                MessageBoxEx.Show("Nhân viên này đã nghĩ trên 20 ngày trong năm!Đề nghị cho thôi việc");
                dathongbao = 1;
            }

            CapNhatChoChiLuong(vangtrongnam);
        }

        public void CapNhatChoChiLuong(int ngayvang)
        {
            string thang = cmbThang.SelectedItem.ToString();
            string nam = cmbNam.SelectedItem.ToString();
            thang = thang[6].ToString() + thang[7].ToString();
            nam = nam[4].ToString() + nam[5].ToString() + nam[6].ToString() + nam[7].ToString();
            int thamnien = 1;

            dtNV = laynhanvien.LayNhanVien();
         
            foreach (DataRow dr in dtNV.Rows)
            {
                if (dtgBangChamCong["cmbTenNV", dtgBangChamCong.CurrentRow.Index].Value.ToString() == dr["manv"].ToString())
                {
                    thamnien = Convert.ToInt32(dr["thamnien"].ToString());
                    break;
                }

            }
            dtChiLuongTheoThangNam = chiluong.LayBangLuongTheoThangNam(Convert.ToInt32(thang), Convert.ToInt32(nam));

            foreach (DataRow dr in dtChiLuongTheoThangNam.Rows)
            {
                if (dtgBangChamCong["cmbTenNV", dtgBangChamCong.CurrentRow.Index].Value.ToString() == dr["manv"].ToString())
                {
                    chiluong.CapNhatNgayLamTheoThangNam(Convert.ToInt32(thang), Convert.ToInt32(nam), dr["manv"].ToString(), Convert.ToInt32(dtgBangChamCong["ngaydilam", dtgBangChamCong.CurrentRow.Index].Value.ToString()));
                    break;
                }
            }

            int ngayvangchophep = 12 - ngayvang; 

            if (ngayvangchophep < 0)
            {
                dtChiLuongTheoThangNam = chiluong.LayBangLuongTheoThangNam(Convert.ToInt32(thang), Convert.ToInt32(nam));

                foreach (DataRow dr1 in dtChiLuongTheoThangNam.Rows)
                {
                    if (dtgBangChamCong["cmbTenNV", dtgBangChamCong.CurrentRow.Index].Value.ToString() == dr1["manv"].ToString())
                    {
                        double truluong = Convert.ToDouble(dr1["tongluong"].ToString()) / 26;
                        truluong = truluong * (-ngayvangchophep);
                        double thuclanh = (Convert.ToDouble(dr1["tongluong"].ToString()) * 0.92) - truluong;
                        
                        if (thamnien == 1)
                            thuclanh = thuclanh * 90 / 100;

                        chiluong.CapNhatTruLuong(Convert.ToInt32(thang), Convert.ToInt32(nam), dr1["manv"].ToString(), truluong, thuclanh);
                        break;
                    }
                }
            }
        }
        int xoa=0;
        private void buttonX1_Click(object sender, EventArgs e)
        {
            xoa = 0;
            string thang = cmbThang.SelectedItem.ToString();
            string nam = cmbNam.SelectedItem.ToString();
            thang = thang[6].ToString() + thang[7].ToString();
            nam = nam[4].ToString() + nam[5].ToString() + nam[6].ToString() + nam[7].ToString();
            frmBangChiLuong fchiluong = null;
            fchiluong = new frmBangChiLuong(1, Convert.ToInt32(thang), Convert.ToInt32(nam), cmbPhongBan.SelectedValue.ToString());

            fchiluong.StartPosition = FormStartPosition.CenterScreen;
            fchiluong.ShowDialog();
        }

        private void dtgBangChamCong_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCellStyle style1 = new DataGridViewCellStyle();
            style1.ForeColor = Color.Olive;
            style1.BackColor = Color.WhiteSmoke;

            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            style2.ForeColor = Color.MediumBlue;
            style2.BackColor = Color.Pink;

            for (int i = dtgBangChamCong.RowCount - 1; i >= 0; i--)
            {
                if (i % 2 == 0)
                    dtgBangChamCong.Rows[i].DefaultCellStyle = style1;
                else
                    dtgBangChamCong.Rows[i].DefaultCellStyle = style2;
            }
        }

        private void bntXoa_Click(object sender, EventArgs e)
        {
            xoa = 1;
            string thang = cmbThang.SelectedItem.ToString();
            string nam = cmbNam.SelectedItem.ToString();

            thang = thang[6].ToString() + thang[7].ToString();
            nam = nam[4].ToString() + nam[5].ToString() + nam[6].ToString() + nam[7].ToString();

            dtCC = laybangchamcong.LayBangChamCongTheoThangNam(Convert.ToInt32(thang), Convert.ToInt32(nam));
            dtChiLuongTheoThangNam = chiluong.LayBangLuongTheoThangNam(Convert.ToInt32(thang), Convert.ToInt32(nam));
            //MessageBox.Show(dtCC.Rows.Count.ToString());
            MessageBox.Show(dtChiLuongTheoThangNam.Rows.Count.ToString());

            string[] ma = new string[500];
            int stt = 0;
            foreach (DataRow dr in dtCC.Rows)
            {
                ma[stt] = dr["machamcong"].ToString();
                stt++;
            }
            for (int i = 0; i < 100; i++)
            {
                if (ma[i] != null)
                    laybangchamcong.Xoa(ma[i]);
                else
                    break;
            }

            string[] macl = new string[500];
            int sttcl = 0;
            foreach (DataRow dr in dtChiLuongTheoThangNam.Rows)
            {
                macl[sttcl] = dr["maluong"].ToString();
                sttcl++;
            }
            for (int i = 0; i < 100; i++)
            {
                if (macl[i] != null)
                {
                    MessageBox.Show(macl[i]);
                    chiluong.Xoa(macl[i]);
                }
                else
                    break;
            }
            dtCC = laybangchamcong.LayBangChamCongRong();
            control.HienThiGridTheoThangNam(dtCC, dtgBangChamCong, bnBangChamCong);
        }


        private void bntCC_Click(object sender, EventArgs e)
        {
            HienThiChamCong(0);
        }
    }
}