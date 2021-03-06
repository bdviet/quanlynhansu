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

using System.IO;

namespace QUANLYNHANSU
{
    public partial class frmThongTinUngVien : Office2007Form
    {
        public frmThongTinUngVien()
        {
            InitializeComponent();
        }

        clsUngVienController ungviencontrol = new clsUngVienController();
        clsLayUngVien ungvien = new clsLayUngVien();
        clsLayBangNhanVien nhanvien = new clsLayBangNhanVien();

        DataTable dtUngVien = new DataTable();
        DataTable dtNhanVien = new DataTable();

        private void frmThongTinUngVien_Load(object sender, EventArgs e)
        {
            ungviencontrol.HienThiNgaySinh(colNgaysinh);
            ungviencontrol.HienThiNgayCap(colNgaycap);
            ungviencontrol.HienThiNgayNopHS(cmbcolNgayNopHS);
            ungviencontrol.HienThiGridDotPV(cmbcolDotPV);
            ungviencontrol.HienThiComboboxDotPV(cmbDotPV);

            ungviencontrol.HienThiDataGridView(txtMauv, txtTenuv, txtCMND, dteNgayCap, txtNoiCap, dteNgaySinh, cmbGioiTinh, txtDiaChi, txtEmail, txtDTrieng, txtDTnha, cmbHonnhan, txtNamKinhNghiem, dteNgayNopHS, cmbDanToc, cmbTonGiao, cmbBangCap, cmbTrangThai, cmbDotPV, txtTinHoc, txtNgoaiNgu, dtgUngVien, bnUngVien);
        }

        private void bntHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Hình ảnh|*.jpg;*.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                PicHinh.SizeMode = PictureBoxSizeMode.Zoom;
                PicHinh.Image = Image.FromFile(open.FileName);
                byte[] HinhAnh = ChuyenSangByte(PicHinh.Image);
                dtgUngVien["hinhanh", dtgUngVien.CurrentRow.Index].Value = HinhAnh;
                LuuHinh(HinhAnh);
                cohinh = 1;
            }
        }

        public byte[] ChuyenSangByte(Image hinh)
        {
            MemoryStream ms = new MemoryStream();
            byte[] bmpBytes = null;
            hinh.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            bmpBytes = ms.GetBuffer();
            ms.Close();
            ms.Dispose();
            return bmpBytes;
        }

        public void LuuHinh(byte[] HinhAnh)
        {
            if (dtgUngVien.RowCount != 0)
                ungvien.CapNhatHinh(dtgUngVien["maungvien", dtgUngVien.CurrentRow.Index].Value.ToString(), HinhAnh);
        }

        int cohinh = 0;

        private void bntXoaHinh_Click(object sender, EventArgs e)
        {
            ungvien.XoaHinh(dtgUngVien["maungvien", dtgUngVien.CurrentRow.Index].Value.ToString());
            dtgUngVien["hinhanh", dtgUngVien.CurrentRow.Index].Value = null;

            if (File.Exists(Application.StartupPath + "\\Images\\NoImage.bmp"))
            {
                PicHinh.SizeMode = PictureBoxSizeMode.StretchImage;
                PicHinh.Image = Image.FromFile(Application.StartupPath + "\\Images\\NoImage.bmp");
            }
            cohinh = 0;
        }

        private void dtgUngVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgUngVien["hinhanh", dtgUngVien.CurrentRow.Index].Value.ToString().Length != 0)
            {
                //MessageBox.Show(dtgNhanVien["hinhanh", dtgNhanVien.CurrentRow.Index].Value.ToString().Length.ToString());
                DataTable dt = new DataTable();
                dt = ungvien.LayHinhTheoUngVien(dtgUngVien["maungvien", dtgUngVien.CurrentRow.Index].Value.ToString());
                DataRow dr;
                dr = dt.Rows[0];
                byte[] Hinh = new byte[0];
                Hinh = (byte[])dr["hinhanh"];
                MemoryStream stream = new MemoryStream(Hinh);
                PicHinh.SizeMode = PictureBoxSizeMode.Zoom;
                PicHinh.Image = Image.FromStream(stream);

                cohinh = 1;

                PicHinh.Refresh();
            }
            else
            {
                if (File.Exists(Application.StartupPath + "\\Images\\NoImage.bmp"))
                {
                    PicHinh.SizeMode = PictureBoxSizeMode.StretchImage;
                    PicHinh.Image = Image.FromFile(Application.StartupPath + "\\Images\\NoImage.bmp");
                }

                cohinh = 0;
            }
        }

        private void PicHinh_DoubleClick(object sender, EventArgs e)
        {
            if (PicHinh.Image != null)
            {
                if (cohinh == 1)
                {
                    frmHinh hinh = new frmHinh(PicHinh.Image, dtgUngVien["tenungvien", dtgUngVien.CurrentRow.Index].Value.ToString());
                    hinh.ShowDialog();
                    byte[] HinhAnh = ChuyenSangByte(PicHinh.Image);
                    //dtgNhanVien["hinhanh", dtgNhanVien.CurrentRow.Index].Value = HinhAnh;
                    LuuHinh(HinhAnh);
                }
            }
        }

        public void ThemUngVien()
        {
            string maungvien = "UV";

            string masothutu;

            string thang = DateTime.Now.Month.ToString();
            if (thang.Length == 1)
                thang = "0" + thang;

            string nam = DateTime.Now.Year.ToString();
            string nam02 = nam[2].ToString() + nam[3].ToString();

            string thangnam = thang + nam02;

            int phantu = 0;
            dtUngVien = ungvien.LayUngVien();

            foreach (DataRow dr in dtUngVien.Rows)
            {
                string ma = dr["maungvien"].ToString();
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

                maungvien = maungvien + thangnam + masothutu;
            }
            else
            {
                maungvien = maungvien + thangnam + "0001";
            }

            DataRowView row = (DataRowView)bnUngVien.BindingSource.AddNew();

            row["maungvien"] = maungvien;
            row["tenungvien"] = "Name";
            row["ngaycap"] = DateTime.Now.Date.ToString();
            row["ngaysinh"] = DateTime.Now.Date.ToString();
            row["gioitinh"] = "Nam";
            row["tinhtranghonnhan"] = "Độc thân";
            row["dantoc"] = "Kinh";
            row["tongiao"] = "Phật";
            row["bangcap"] = "Cử nhân";
            row["trangthai"] = "Đang phỏng vấn";

            row["ngaythem"] = DateTime.Now.Date.ToString();
            row["ngaynophoso"] = DateTime.Now.Date.ToString();
            row["cmnd"] = "123456789";

            string ngayhienhanh = DateTime.Now.Date.ToString();
            ngayhienhanh = ngayhienhanh[3].ToString() + ngayhienhanh[4].ToString() + ngayhienhanh[2].ToString() + ngayhienhanh[0].ToString() + ngayhienhanh[1].ToString() + ngayhienhanh[5].ToString() + ngayhienhanh[6].ToString() + ngayhienhanh[7].ToString() + ngayhienhanh[8].ToString() + ngayhienhanh[9].ToString();
            string madotphongvan = null;
            if (cmbDotPV.Items.Count != 0)
            {
                cmbDotPV.SelectedIndex = 0;
                madotphongvan= cmbDotPV.SelectedValue.ToString();
                row["madotphongvan"] = madotphongvan;
            }

            ungvien.ThemMoi(maungvien, "Name", "123456789", ngayhienhanh, null, ngayhienhanh, "Nam", null, null, null, null, "Độc thân", "Kinh", "Phật", "Cử nhân", null, null, 0, ngayhienhanh, "Đang phỏng vấn", madotphongvan, null, ngayhienhanh);
        }

        private void bntThemUV_Click(object sender, EventArgs e)
        {
            ThemUngVien();
        }

        public void Luu()
        {
            if (dtgUngVien.RowCount != 0)
            {
                dtgUngVien.EndEdit();
                if (dtgUngVien.CurrentRow.Index != dtgUngVien.RowCount - 1)
                    bnUngVien.BindingSource.MoveNext();
                else
                    bnUngVien.BindingSource.MovePrevious();

                for (int i = 0; i < dtgUngVien.Rows.Count; i++)
                {
                    string gioitinh = "";
                    string dantoc = null;
                    string honnhan = "";
                    string tongiao = null;
                    string ngaycapcmnd = "";
                    string ngaysinh = "";
                    string bangcap = "";
                    string dotphongvan = "";
                    string ngaynopHS = "";
                    string trangthai = "";
                    
                    int namkinhnghiem = 0;

                    if (dtgUngVien["sonamkinhnghiem", i].Value.ToString().Length != 0)
                        namkinhnghiem = Convert.ToInt32(dtgUngVien["sonamkinhnghiem", i].Value.ToString());

                    if (dtgUngVien["cmbcolGioiTinh", i].Value != null)
                        gioitinh = dtgUngVien["cmbcolGioiTinh", i].Value.ToString();

                    if (dtgUngVien["cmbcolDT", i].Value != null)
                        dantoc = dtgUngVien["cmbcolDT", i].Value.ToString();

                    if (dtgUngVien["cmbcolHonNhan", i].Value != null)
                        honnhan = dtgUngVien["cmbcolHonnhan", i].Value.ToString();

                    if (dtgUngVien["cmbcolTonGiao", i].Value != null)
                        tongiao = dtgUngVien["cmbcolTonGiao", i].Value.ToString();

                    if (dtgUngVien["colNgaycap", i].Value.ToString().Length != 0)
                    {
                        ngaycapcmnd = dtgUngVien["colNgaycap", i].Value.ToString();
                        //MessageBox.Show(dtgUngVien["colNgaycap", i].Value.ToString());
                        ngaycapcmnd = ngaycapcmnd[3].ToString() + ngaycapcmnd[4].ToString() + ngaycapcmnd[2].ToString() + ngaycapcmnd[0].ToString() + ngaycapcmnd[1].ToString() + ngaycapcmnd[5].ToString() + ngaycapcmnd[6].ToString() + ngaycapcmnd[7].ToString() + ngaycapcmnd[8].ToString() + ngaycapcmnd[9].ToString();
                    }

                    if (dtgUngVien["colNgaysinh", i].Value.ToString().Length != 0)
                    {
                        ngaysinh = dtgUngVien["colNgaysinh", i].Value.ToString();
                        ngaysinh = ngaysinh[3].ToString() + ngaysinh[4].ToString() + ngaysinh[2].ToString() + ngaysinh[0].ToString() + ngaysinh[1].ToString() + ngaysinh[5].ToString() + ngaysinh[6].ToString() + ngaysinh[7].ToString() + ngaysinh[8].ToString() + ngaysinh[9].ToString();
                    }

                    if (dtgUngVien["cmbcolBangCap", i].Value != null)
                        bangcap = dtgUngVien["cmbcolBangCap", i].Value.ToString();

                    if (dtgUngVien["cmbcolDotPV", i].Value != null)
                        dotphongvan = dtgUngVien["cmbcolDotPV", i].Value.ToString();

                    if (dtgUngVien["cmbcolTrangThai", i].Value != null)
                        trangthai = dtgUngVien["cmbcolTrangThai", i].Value.ToString();

                    if (dtgUngVien["cmbcolNgayNopHS", i].Value.ToString().Length != 0)
                    {
                        ngaynopHS = dtgUngVien["cmbcolNgayNopHS", i].Value.ToString();
                        ngaynopHS = ngaynopHS[3].ToString() + ngaynopHS[4].ToString() + ngaynopHS[2].ToString() + ngaynopHS[0].ToString() + ngaynopHS[1].ToString() + ngaynopHS[5].ToString() + ngaynopHS[6].ToString() + ngaynopHS[7].ToString() + ngaynopHS[8].ToString() + ngaynopHS[9].ToString();
                    }

                    ungvien.CapNhat(dtgUngVien["maungvien", i].Value.ToString(), dtgUngVien["tenungvien", i].Value.ToString(), dtgUngVien["cmnd", i].Value.ToString(), ngaycapcmnd, dtgUngVien["noicap", i].Value.ToString(), ngaysinh, gioitinh, dtgUngVien["diachi", i].Value.ToString(), dtgUngVien["email", i].Value.ToString(), dtgUngVien["sdtrieng", i].Value.ToString(), dtgUngVien["sdtnha", i].Value.ToString(), honnhan, dantoc, tongiao, bangcap, dtgUngVien["ngoaingu", i].Value.ToString(), dtgUngVien["tinhoc", i].Value.ToString(), namkinhnghiem,ngaynopHS,trangthai, dotphongvan, dtgUngVien["ghichu", i].Value.ToString());
                }
                MessageBoxEx.Show("Bạn đã lưu thành công!!!", "Chúc mừng");
            }
        }

        private void bntLuuUV_Click(object sender, EventArgs e)
        {
            Luu();
        }

        private void bntXoa_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBoxEx.Show("Bạn có chắc chắn xóa ứng viên này", "Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                ungvien.XoaUngVien(dtgUngVien["maungvien", dtgUngVien.CurrentRow.Index].Value.ToString());
                bnUngVien.BindingSource.RemoveCurrent();
            }
        }

        public void ThemNhanVien(int luuhinh,string tenungvien, string cmnd, string ngaycap, string noicap, string ngaysinh, string gioitinh, string diachi, string email, string sdtrieng, string sdtnha, string tinhtranghonnhan, string bangcap, string ngoaingu, string tinhoc, byte[] hinhanh,string maphong,string mato,string machucvu)
        {
            string manhanvien = "NV";

            string masothutu;

            string thang = DateTime.Now.Month.ToString();
            if (thang.Length == 1)
                thang = "0" + thang;

            string nam = DateTime.Now.Year.ToString();
            string nam02 = nam[2].ToString() + nam[3].ToString();

            string thangnam = thang + nam02;

            int phantu = 0;
            dtNhanVien = nhanvien.LayNhanVien();

            foreach (DataRow dr in dtNhanVien.Rows)
            {
                string ma = dr["manv"].ToString();
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

                manhanvien = manhanvien + thangnam + masothutu;
            }
            else
            {
                manhanvien = manhanvien + thangnam + "0001";
            }

            string ngayhienhanh = DateTime.Now.Date.ToString();
            ngayhienhanh = ngayhienhanh[3].ToString() + ngayhienhanh[4].ToString() + ngayhienhanh[2].ToString() + ngayhienhanh[0].ToString() + ngayhienhanh[1].ToString() + ngayhienhanh[5].ToString() + ngayhienhanh[6].ToString() + ngayhienhanh[7].ToString() + ngayhienhanh[8].ToString() + ngayhienhanh[9].ToString();

            nhanvien.ThemMoi(manhanvien, tenungvien, null, cmnd, ngaycap, noicap, ngaysinh, gioitinh, diachi, email, null, sdtrieng, sdtnha, tinhtranghonnhan, maphong, mato, machucvu, ngayhienhanh, 1, 2.33, "Đang làm việc", "Phỏng vấn", tinhoc, ngoaingu, bangcap, null, null, 0, 0, "O", "Tốt",null, ngayhienhanh);
            if (luuhinh == 1)
                nhanvien.CapNhatHinh(manhanvien, hinhanh);
        }

        private void bntChuyen_Click(object sender, EventArgs e)
        {
            frmThongBaoChuyenNhanVien chuyen = new frmThongBaoChuyenNhanVien();
            chuyen.ShowDialog();
            if (chuyen.chuyen == 1)
            {
                for (int i = 0; i < dtgUngVien.SelectedRows.Count; i++)
                {
                    int dongchon = dtgUngVien.SelectedRows[i].Index;
                    byte[] hinhanh = null;
                    int luuhinh = 0;
                    if (dtgUngVien["hinhanh", dongchon].Value.ToString().Length != 0)
                    {
                        hinhanh = (byte[])dtgUngVien["hinhanh", dongchon].Value;
                        luuhinh = 1;
                    }

                    string ngaycapcmnd = "";
                    string ngaysinh = "";



                    if (dtgUngVien["colNgaycap", dongchon].Value != null)
                    {
                        ngaycapcmnd = dtgUngVien["colNgaycap", dongchon].Value.ToString();
                        ngaycapcmnd = ngaycapcmnd[3].ToString() + ngaycapcmnd[4].ToString() + ngaycapcmnd[2].ToString() + ngaycapcmnd[0].ToString() + ngaycapcmnd[1].ToString() + ngaycapcmnd[5].ToString() + ngaycapcmnd[6].ToString() + ngaycapcmnd[7].ToString() + ngaycapcmnd[8].ToString() + ngaycapcmnd[9].ToString();
                    }

                    if (dtgUngVien["colNgaysinh", dongchon].Value != null)
                    {
                        ngaysinh = dtgUngVien["colNgaysinh", dongchon].Value.ToString();
                        ngaysinh = ngaysinh[3].ToString() + ngaysinh[4].ToString() + ngaysinh[2].ToString() + ngaysinh[0].ToString() + ngaysinh[1].ToString() + ngaysinh[5].ToString() + ngaysinh[6].ToString() + ngaysinh[7].ToString() + ngaysinh[8].ToString() + ngaysinh[9].ToString();
                    }

                    ThemNhanVien(luuhinh, dtgUngVien["tenungvien", dongchon].Value.ToString(), dtgUngVien["cmnd", dongchon].Value.ToString(), ngaycapcmnd, dtgUngVien["noicap", dongchon].Value.ToString(), ngaysinh, dtgUngVien["cmbcolGioiTinh", dongchon].Value.ToString(), dtgUngVien["diachi", dongchon].Value.ToString(), dtgUngVien["email", dongchon].Value.ToString(), dtgUngVien["sdtrieng", dongchon].Value.ToString(), dtgUngVien["sdtnha", dongchon].Value.ToString(), dtgUngVien["cmbcolHonNhan", dongchon].Value.ToString(), dtgUngVien["cmbcolBangCap", dongchon].Value.ToString(), dtgUngVien["ngoaingu", dongchon].Value.ToString(), dtgUngVien["tinhoc", dongchon].Value.ToString(), hinhanh, chuyen.maphong, chuyen.mato, chuyen.machucvu);

                    ungvien.XoaUngVien(dtgUngVien["maungvien", dongchon].Value.ToString());
                    bnUngVien.BindingSource.RemoveCurrent();

                    MessageBoxEx.Show("Bạn đã chuyển thành công", "Chúc mừng");
                }
            }
        }

        private void bntNV_Click(object sender, EventArgs e)
        {
            frmNhanVien nv = new frmNhanVien();
            nv.Show();
        }
    }
}