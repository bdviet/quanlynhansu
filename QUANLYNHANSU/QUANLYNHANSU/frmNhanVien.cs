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
    public partial class frmNhanVien : Office2007Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        clsNhanVienController control = new clsNhanVienController();
        clsQuatrinhlamviecController lamvieccontrol = new clsQuatrinhlamviecController();
        clsBoiduongController boiduongcontrol = new clsBoiduongController();
        clsThanNhanController thannhancontrol = new clsThanNhanController();
        clsKhenThuongController khenthuongcontrol = new clsKhenThuongController();
        clsKyLuatController kyluatcontrol = new clsKyLuatController();
        clsHopDongController hopdongcontrol = new clsHopDongController();

        clsLayToLamViec to = new clsLayToLamViec();
        clsLayBangNhanVien nhanvien = new clsLayBangNhanVien();
        clsLayQuaTrinhLamViec lamviec = new clsLayQuaTrinhLamViec();
        clsLayQuatrinhboiduong boiduong = new clsLayQuatrinhboiduong();
        clsLayThanNhan thannhan = new clsLayThanNhan();
        clsLayKhenThuong khenthuong = new clsLayKhenThuong();
        clsLayKyLuat kyluat = new clsLayKyLuat();
        clsLayHopDong hopdong = new clsLayHopDong();

        DataTable dtTo = new DataTable();
        DataTable dtTotheophong = new DataTable();
        DataTable dtNhanVien = new DataTable();
        DataTable dtLamViec = new DataTable();
        DataTable dtBoiDuong = new DataTable();
        DataTable dtThanNhan = new DataTable();
        DataTable dtKhenThuong = new DataTable();
        DataTable dtKyLuat = new DataTable();
        DataTable dtHopDong = new DataTable();

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            control.HienthiGioitinh(cmbcolGioiTinh);
            control.HienthiHocvi(cmbcolHocVi);
            control.HienthiMau(cmbcolMau);
            control.Hienthihonnhan(cmbcolHonnhan);
            control.Hienthilamviec(cmbcolLamviec);

            control.HienthiChucvu(cmbChucvu);
            control.HienthiGridChucvu(cmbcolChucvu);
            control.HienthiPhongban(cmbPhongban);
            control.HienthiGridPhongban(cmbcolPhongban);
            control.HienthiTolamviec(cmbTo);
            control.HienthiGridTolamviec(cmbcolToLamviec);

            control.HienThiQuanHe(cmbcolQuanhe);
            control.HienThiTrongNgoai(cmbcolDinhcu);

            lamvieccontrol.HienthiCongviec(cmbCongviec);
            lamvieccontrol.HienthiGridCongviec(cmbcolCongViec);

            lamvieccontrol.HienthiNhanVien(cmbNVLamViec);
            lamvieccontrol.HienthiGridNhanVien(cmbcolNVLamViec);

            boiduongcontrol.HienthiSQD(cmbSoquyetdinh);
            boiduongcontrol.HienthiGridSQD(cmbcolSQD);

            boiduongcontrol.HienthiNhanVien(cmbNVBD);
            boiduongcontrol.HienthiGridNhanVien(cmbcolNVBD);

            thannhancontrol.HienthiNhanVien(cmbNVTN);
            thannhancontrol.HienthiGridNhanVien(cmbcolNVThanNhan);

            khenthuongcontrol.HienthiSQD(cmbSQDKT);
            khenthuongcontrol.HienthiGridSQD(cmbcolSQDKT);

            khenthuongcontrol.HienthiNhanVien(cmbNVKT);
            khenthuongcontrol.HienthiGridNhanVien(cmbcolNVKT);

            kyluatcontrol.HienthiSQD(cmbSQDKL);
            kyluatcontrol.HienthiGridSQD(cmbcolSQDKL);

            kyluatcontrol.HienthiNhanVien(cmbNVKL);
            kyluatcontrol.HienthiGridNhanVien(cmbcolNVKL);

            khenthuongcontrol.HienthiNhanVien(cmbNVHopDong);//hien thi len hop dong
            khenthuongcontrol.HienthiGridNhanVien(cmbcolNVHopDong);//hien thi len hop dong

            hopdongcontrol.HienthiNhanVienChucVu(cmbNguoiKyHD);
            hopdongcontrol.HienthiGridNhanVienChucVu(cmbcolNguoiKyHD);

            if (cmbPhongban.SelectedValue != null && cmbPhongban.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                dtTotheophong = to.LayToLamViecTheoPhong(cmbPhongban.SelectedValue.ToString());
                if (dtTotheophong.Rows.Count == 0)
                {
                    cmbTo.Enabled = false;
                    cmbTo.Text = null;
                }
                else
                    cmbTo.Enabled = true;
            }
            cmbChonXem.SelectedIndex = 0;

            for (int i = 0; i < dtgNhanVien.RowCount; i++)
            {
                int thamnien = 0;
                DateTime ngayvao = Convert.ToDateTime(dtgNhanVien["cmbcolNgayvaolam", i].Value);
                thamnien = DateTime.Now.Year - ngayvao.Year + 1;
                dtgNhanVien["thamnien", i].Value = thamnien;
            }
            string[] headertext ={ "Mã", "Tên", "Bí danh", "CMND", "Ngày cấp", "Nơi cấp", "Ngày sinh", "Giới tính", "Địa chỉ", "Email", "ĐT NH", "ĐT riêng", "ĐT nhà", "Hôn nhân", "Phòng ban", "Tổ làm việc", "Chức vụ", "Ngày vào làm", "Thâm niên", "Hệ số", "Tình trạng", "", "Tuyển dụng", "Tin học", "Ngoại ngữ", "Học vị", "BHXH", "BHYT", "Cân nặng", "Cao", "Nhóm máu", "Sức khỏe", "Số tài khoản" };

            for (int cot = 0; cot < dtgNhanVien.Columns.Count - 1; cot++)
            {
                dtgNhanVien.Columns[cot].DisplayIndex = cot;
                dtgNhanVien.Columns[cot].HeaderText = headertext[cot];
            }

            dtgNhanVien.Columns["manv"].ReadOnly = true;
            dtgNhanVien.Columns["manv"].Width = 80;
            dtgNhanVien.Columns["ngaythem"].Visible = false;
            dtgNhanVien.Columns["hinhanh"].Visible = false;
        }

        public void ThemNhanVien()
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

            DataRowView row = (DataRowView)bnNhanVien.BindingSource.AddNew();

            row["manv"] = manhanvien;
            row["tennv"] = "Name";
            row["ngaycap"] = DateTime.Now.Date.ToString();
            row["ngaysinh"] = DateTime.Now.Date.ToString();
            row["gioitinh"] = "Nam";
            row["tinhtranghonnhan"] = "Độc thân";
            row["tinhtranglamviec"] = "Đang làm việc";
            row["tinhtrangsuckhoe"] = "Tốt";
            row["hocvi"] = "Cử nhân";
            row["heso"] = 2.33;
            row["nhommau"] = "O";
            row["ngayvaolam"] = DateTime.Now.Date.ToString();
            row["thamnien"] = 1;
            row["cannang"] = 0;
            row["cao"] = 0;
            row["ngaythem"] = DateTime.Now.Date.ToString();
            row["cmnd"] = "123456789";

            string ngayhienhanh = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString();

            cmbPhongban.SelectedIndex = 0;
            row["phongban"] = cmbPhongban.SelectedValue.ToString();
            cmbChucvu.SelectedIndex = 0;
            row["machucvu"] = cmbChucvu.SelectedValue.ToString();

            nhanvien.ThemMoi(manhanvien, "Name", null, "123456789", ngayhienhanh, null, ngayhienhanh, "Nam", null, null, null, null, null, "Độc thân", cmbPhongban.SelectedValue.ToString(), null, cmbChucvu.SelectedValue.ToString(), ngayhienhanh, 1, 2.33, "Đang làm việc", null, null, null, "Cử nhân", null, null, 0, 0, "O", "Tốt", null, ngayhienhanh);

            LuuTruHistory("Thêm mới 1 nhân viên");
        }

        public void ThemQuaTrinhLamViec(string manv, string tennv)
        {
            string malamviec = "LV";

            string masothutu;

            string thang = DateTime.Now.Month.ToString();
            if (thang.Length == 1)
                thang = "0" + thang;

            string nam = DateTime.Now.Year.ToString();
            string nam02 = nam[2].ToString() + nam[3].ToString();

            string thangnam = thang + nam02;

            int phantu = 0;
            dtLamViec = lamviec.LayLamViec();

            foreach (DataRow dr in dtLamViec.Rows)
            {
                string ma = dr["maquatrinh"].ToString();
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

                malamviec = malamviec + thangnam + masothutu;
            }
            else
            {
                malamviec = malamviec + thangnam + "0001";
            }

            DataRowView row = (DataRowView)bnLamviec.BindingSource.AddNew();

            row["maquatrinh"] = malamviec;
            row["manv"] = manv;
            row["ngaybatdau"] = "1/9/2009";
            row["ngayketthuc"] = "1/9/2009";
            string congviec = null;
            cmbCongviec.SelectedIndex = 0;
            if (cmbCongviec.SelectedValue != null)
                congviec = cmbCongviec.SelectedValue.ToString();
            row["macongviec"] = congviec;

            string ngayhienhanh = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString();
            lamviec.ThemMoiQTLV(malamviec, manv, congviec, ngayhienhanh);

            LuuTruHistory("Thêm mới 1 quá trình làm việc của nhân viên " + tennv);
        }

        public void LuuQuaTrinhLamViec()
        {
            if (dtgLamviec.RowCount != 0)
            {
                dtgLamviec.EndEdit();
                if (dtgLamviec.CurrentRow.Index != dtgLamviec.RowCount - 1)
                    bnLamviec.BindingSource.MoveNext();
                else
                    bnLamviec.BindingSource.MovePrevious();

                for (int i = 0; i < dtgLamviec.RowCount; i++)
                {
                    string ngaybatdau = dtgLamviec["calNgayBD", i].Value.ToString();
                    ngaybatdau = ngaybatdau[3].ToString() + ngaybatdau[4].ToString() + ngaybatdau[2].ToString() + ngaybatdau[0].ToString() + ngaybatdau[1].ToString() + ngaybatdau[5].ToString() + ngaybatdau[6].ToString() + ngaybatdau[7].ToString() + ngaybatdau[8].ToString() + ngaybatdau[9].ToString();
                    string ngayketthuc = dtgLamviec["calNgayKT", i].Value.ToString();
                    ngayketthuc = ngayketthuc[3].ToString() + ngayketthuc[4].ToString() + ngayketthuc[2].ToString() + ngayketthuc[0].ToString() + ngayketthuc[1].ToString() + ngayketthuc[5].ToString() + ngayketthuc[6].ToString() + ngayketthuc[7].ToString() + ngayketthuc[8].ToString() + ngayketthuc[9].ToString();

                    lamviec.CapNhatQTLV(dtgLamviec["maquatrinh", i].Value.ToString(), dtgLamviec["tenquatrinh", i].Value.ToString(), dtgLamviec["cmbcolNVLamViec", i].Value.ToString(), dtgLamviec["cmbcolCongViec", i].Value.ToString(), ngaybatdau, ngayketthuc, dtgLamviec["noilamviec", i].Value.ToString(), dtgLamviec["noilamviec", i].Value.ToString());
                }
                MessageBoxEx.Show("Bạn đã lưu thành công", "Chúc mừng");
            }
        }

        public void LuuQuaTrinhBoiDuong()
        {
            if (dtgBoiduong.RowCount != 0)
            {
                dtgBoiduong.EndEdit();
                if (dtgBoiduong.CurrentRow.Index != dtgBoiduong.RowCount - 1)
                    bnBoiDuong.BindingSource.MoveNext();
                else
                    bnBoiDuong.BindingSource.MovePrevious();

                for (int i = 0; i < dtgBoiduong.RowCount; i++)
                {
                    string ngaybatdau = dtgBoiduong["calNgayBDBoiDuong", i].Value.ToString();
                    ngaybatdau = ngaybatdau[3].ToString() + ngaybatdau[4].ToString() + ngaybatdau[2].ToString() + ngaybatdau[0].ToString() + ngaybatdau[1].ToString() + ngaybatdau[5].ToString() + ngaybatdau[6].ToString() + ngaybatdau[7].ToString() + ngaybatdau[8].ToString() + ngaybatdau[9].ToString();
                    string ngayketthuc = dtgBoiduong["calNgayKTBoiDuong", i].Value.ToString();
                    ngayketthuc = ngayketthuc[3].ToString() + ngayketthuc[4].ToString() + ngayketthuc[2].ToString() + ngayketthuc[0].ToString() + ngayketthuc[1].ToString() + ngayketthuc[5].ToString() + ngayketthuc[6].ToString() + ngayketthuc[7].ToString() + ngayketthuc[8].ToString() + ngayketthuc[9].ToString();

                    boiduong.CapNhatQTBD(dtgBoiduong["maboiduong", i].Value.ToString(), dtgBoiduong["tenboiduong", i].Value.ToString(), dtgBoiduong["cmbcolNVBD", i].Value.ToString(), dtgBoiduong["cmbcolSQD", i].Value.ToString(), ngaybatdau, ngayketthuc, dtgBoiduong["chuyennganh", i].Value.ToString(), dtgBoiduong["noidaotao", i].Value.ToString(), dtgBoiduong["ghichu", i].Value.ToString());
                }
                MessageBoxEx.Show("Bạn đã lưu thành công", "Chúc mừng");
            }
        }

        public void ThemQuaTrinhBoiDuong(string manv, string tennv)
        {
            string maboiduong = "BD";

            string masothutu;

            string thang = DateTime.Now.Month.ToString();
            if (thang.Length == 1)
                thang = "0" + thang;

            string nam = DateTime.Now.Year.ToString();
            string nam02 = nam[2].ToString() + nam[3].ToString();

            string thangnam = thang + nam02;

            int phantu = 0;
            dtBoiDuong = boiduong.LayBoiDuong();

            foreach (DataRow dr in dtBoiDuong.Rows)
            {
                string ma = dr["maboiduong"].ToString();
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

                maboiduong = maboiduong + thangnam + masothutu;
            }
            else
            {
                maboiduong = maboiduong + thangnam + "0001";
            }

            DataRowView row = (DataRowView)bnBoiDuong.BindingSource.AddNew();

            row["maboiduong"] = maboiduong;
            row["manv"] = manv;
            row["ngaybatdau"] = "1/9/2009";
            row["ngayketthuc"] = "1/9/2009";

            if (cmbSoquyetdinh.Items.Count != 0)
                cmbSoquyetdinh.SelectedIndex = 0;
            string soquyetdinh = null;
            if (cmbSoquyetdinh.SelectedValue != null)
                soquyetdinh = cmbSoquyetdinh.SelectedValue.ToString();


            row["masoquyetdinh"] = soquyetdinh;

            string ngayhienhanh = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString();

            boiduong.ThemMoiQTBD(maboiduong, manv, soquyetdinh, ngayhienhanh);

            LuuTruHistory("Thêm mới 1 quá trình bồi dưỡng của nhân viên : " + tennv);
        }

        int cohinh = 0;

        private void dtgNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgNhanVien.CurrentRow != null)
            {
                string manv = dtgNhanVien["manv", dtgNhanVien.CurrentRow.Index].Value.ToString();
                lamvieccontrol.HienThiLamviec(txtMalamviec, txtTenLamViec, cmbNVLamViec, cmbCongviec, dteNgayBD, dteNgayKT, txtNoilamviec, txtghichu, manv, dtgLamviec, bnLamviec);
                boiduongcontrol.HienThiBoiDuong(txtMaboiduong, txtTenBoiDuong, cmbNVBD, cmbSoquyetdinh, dteNgayBDBoiDuong, dteNgayKTBoiDuong, txtChuyennganh, txtNoiboiduong, txtghichuboiduong, manv, dtgBoiduong, bnBoiDuong);
                thannhancontrol.HienThi(txtMathannhan, txtTenthannhan, cmbNVTN, cmbQuanHe, cmbTrongngoai, txtNuocngoai, txtGhichuthannhan, manv, bnThanNhan, dtgThanNhan);
                khenthuongcontrol.HienThiKhenThuong(txtMaKT, cmbSQDKT, cmbNVKT, dteNgayKhen, txtLyDoKhen, txtHinhThuc, txtGhiChuKT, manv, dtgKhenThuong, bnKhenThuong);
                kyluatcontrol.HienThiKyLuat(txtMaKL, cmbSQDKL, cmbNVKL, dteNgayKL, txtLyDoKL, txtHinhThuc, txtGhiChuKL, manv, dtgKyLuat, bnKyLuat);
                hopdongcontrol.HienThiHopDong(manv, txtMaHopDong, cmbNVHopDong, dteNgayBDHD, dteNgayKTHD, numLanKy, txtNoiDungHD, dteNgayKyHD, cmbNguoiKyHD, txtGhiChuHD, dtgHopDong, bnHopDong);

                if (dtgNhanVien["hinhanh", dtgNhanVien.CurrentRow.Index].Value.ToString().Length != 0)
                {
                    //MessageBox.Show(dtgNhanVien["hinhanh", dtgNhanVien.CurrentRow.Index].Value.ToString().Length.ToString());
                    DataTable dt = new DataTable();
                    dt = nhanvien.LayHinhTheoNhanVien(dtgNhanVien["manv", dtgNhanVien.CurrentRow.Index].Value.ToString());
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
        }

        private void dtgNhanVien_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //e.Cancel = true;
        }

        public void Luu()
        {
            if (dtgNhanVien.RowCount != 0)
            {
                dtgNhanVien.EndEdit();
                if (dtgNhanVien.CurrentRow.Index != dtgNhanVien.RowCount - 1)
                    bnNhanVien.BindingSource.MoveNext();
                else
                    bnNhanVien.BindingSource.MovePrevious();

                for (int i = 0; i < dtgNhanVien.Rows.Count; i++)
                {
                    string gioitinh = "";
                    string mau = "";
                    string honnhan = "";
                    string ngaycapcmnd = "";
                    string ngaysinh = "";
                    string hocvi = "";
                    string phongban = "";
                    string tolamviec = "";
                    string chucvu = "";
                    string ngayvaolam = "";
                    string lamviec = null;

                    int thamnien = 0;
                    double heso = 0;
                    int cannang = 0;
                    double cao = 0;

                    if (dtgNhanVien["cmbcolGioitinh", i].Value != null)
                        gioitinh = dtgNhanVien["cmbcolGioitinh", i].Value.ToString();

                    if (dtgNhanVien["cmbcolMau", i].Value != null)
                        mau = dtgNhanVien["cmbcolMau", i].Value.ToString();

                    if (dtgNhanVien["cmbcolHonnhan", i].Value != null)
                        honnhan = dtgNhanVien["cmbcolHonnhan", i].Value.ToString();

                    if (dtgNhanVien["cmbcolLamviec", i].Value != null)
                        lamviec = dtgNhanVien["cmbcolLamviec", i].Value.ToString();

                    if (dtgNhanVien["colNgaycap", i].Value != null)
                    {
                        ngaycapcmnd = dtgNhanVien["colNgaycap", i].Value.ToString();
                        ngaycapcmnd = ngaycapcmnd[3].ToString() + ngaycapcmnd[4].ToString() + ngaycapcmnd[2].ToString() + ngaycapcmnd[0].ToString() + ngaycapcmnd[1].ToString() + ngaycapcmnd[5].ToString() + ngaycapcmnd[6].ToString() + ngaycapcmnd[7].ToString() + ngaycapcmnd[8].ToString() + ngaycapcmnd[9].ToString();
                    }

                    if (dtgNhanVien["colNgaysinh", i].Value != null)
                    {
                        ngaysinh = dtgNhanVien["colNgaysinh", i].Value.ToString();
                        ngaysinh = ngaysinh[3].ToString() + ngaysinh[4].ToString() + ngaysinh[2].ToString() + ngaysinh[0].ToString() + ngaysinh[1].ToString() + ngaysinh[5].ToString() + ngaysinh[6].ToString() + ngaysinh[7].ToString() + ngaysinh[8].ToString() + ngaysinh[9].ToString();
                    }

                    if (dtgNhanVien["cmbcolHocvi", i].Value != null)
                        hocvi = dtgNhanVien["cmbcolHocvi", i].Value.ToString();

                    if (dtgNhanVien["cmbcolPhongban", i].Value != null)
                        phongban = dtgNhanVien["cmbcolPhongban", i].Value.ToString();

                    if (dtgNhanVien["cmbcolTolamviec", i].Value != null)
                        tolamviec = dtgNhanVien["cmbcolTolamviec", i].Value.ToString();

                    if (dtgNhanVien["cmbcolChucvu", i].Value != null)
                        chucvu = dtgNhanVien["cmbcolChucvu", i].Value.ToString();

                    if (dtgNhanVien["cmbcolNgayvaolam", i].Value != null)
                    {
                        ngayvaolam = dtgNhanVien["cmbcolNgayvaolam", i].Value.ToString();
                        ngayvaolam = ngayvaolam[3].ToString() + ngayvaolam[4].ToString() + ngayvaolam[2].ToString() + ngayvaolam[0].ToString() + ngayvaolam[1].ToString() + ngayvaolam[5].ToString() + ngayvaolam[6].ToString() + ngayvaolam[7].ToString() + ngayvaolam[8].ToString() + ngayvaolam[9].ToString();
                    }

                    if (dtgNhanVien["thamnien", i].Value != null)
                        thamnien = Convert.ToInt32(dtgNhanVien["thamnien", i].Value.ToString());

                    if (dtgNhanVien["heso", i].Value != null)
                        heso = Convert.ToDouble(dtgNhanVien["heso", i].Value.ToString());

                    if (dtgNhanVien["cannang", i].Value != null)
                    {
                        //MessageBox.Show(dtgNhanVien["cannang", i].Value.ToString());
                        cannang = Convert.ToInt32(dtgNhanVien["cannang", i].Value.ToString());
                    }

                    if (dtgNhanVien["cao", i].Value != null)
                        cao = Convert.ToDouble(dtgNhanVien["cao", i].Value.ToString());

                    nhanvien.CapNhat(dtgNhanVien["manv", i].Value.ToString(), dtgNhanVien["tennv", i].Value.ToString(), dtgNhanVien["bidanh", i].Value.ToString(), dtgNhanVien["cmnd", i].Value.ToString(), ngaycapcmnd, dtgNhanVien["noicap", i].Value.ToString(), ngaysinh, gioitinh, dtgNhanVien["diachi", i].Value.ToString(), dtgNhanVien["email", i].Value.ToString(), dtgNhanVien["sdtcty", i].Value.ToString(), dtgNhanVien["sdtrieng", i].Value.ToString(), dtgNhanVien["sdtnha", i].Value.ToString(), honnhan, phongban, tolamviec, chucvu, ngayvaolam, thamnien, heso, lamviec, dtgNhanVien["hinhthuctuyendung", i].Value.ToString(), dtgNhanVien["tinhoc", i].Value.ToString(), dtgNhanVien["ngoaingu", i].Value.ToString(), hocvi, dtgNhanVien["soBHXH", i].Value.ToString(), dtgNhanVien["soBHYT", i].Value.ToString(), cannang, cao, mau, dtgNhanVien["tinhtrangsuckhoe", i].Value.ToString(), dtgNhanVien["taikhoanNH", i].Value.ToString());
                }
                MessageBoxEx.Show("Bạn đã lưu thành công!!!", "Chúc mừng");
            }
        }

        public void LuuHinh(byte[] HinhAnh)
        {
            if (dtgNhanVien.RowCount != 0)
                nhanvien.CapNhatHinh(dtgNhanVien["manv", dtgNhanVien.CurrentRow.Index].Value.ToString(), HinhAnh);
        }

        private void dtgNhanVien_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int donghh = dtgNhanVien.CurrentRow.Index;
            dtTotheophong = to.LayToLamViecTheoPhong(dtgNhanVien["cmbcolPhongban", donghh].Value.ToString());
            if (dtTotheophong.Rows.Count == 0)
            {
                dtgNhanVien["cmbcolTolamviec", donghh].ReadOnly = true;
                dtgNhanVien["cmbcolTolamviec", donghh].Value = null;
            }
            else
                dtgNhanVien["cmbcolTolamviec", donghh].ReadOnly = false;

            int hople = 1;

            if (dtgNhanVien["tennv", donghh].Value.ToString().Length == 0)
            {
                MessageBoxEx.Show("Bạn phải nhập tên nhân viên!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtgNhanVien["tennv", donghh].Value = "Tên nhân viên";
                hople = 0;
            }

            if (hople == 1)
                if (dtgNhanVien["cmnd", donghh].Value.ToString().Length != 9)
                {
                    MessageBoxEx.Show("Bạn phải nhập đúng số chứng minh!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtgNhanVien["cmnd", donghh].Value = "123456789";
                    hople = 0;
                }

            if (hople == 1)
                if (dtgNhanVien["heso", donghh].Value.ToString().Length == 0)
                {
                    MessageBoxEx.Show("Bạn phải nhập hệ số!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtgNhanVien["heso", donghh].Value = 0;
                    hople = 0;
                }

            if (hople == 1)
                if (Convert.ToDouble(dtgNhanVien["heso", donghh].Value.ToString()) < 0)
                {
                    MessageBoxEx.Show("Hệ số không được âm!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    string heso = dtgNhanVien["heso", donghh].Value.ToString();
                    string hesoduong = null;
                    for (int i = 1; i < heso.Length; i++)
                        hesoduong = hesoduong + heso[i].ToString();
                    dtgNhanVien["heso", donghh].Value = hesoduong;
                    hople = 0;
                }

            if (hople == 1)
                if (dtgNhanVien["cannang", donghh].Value.ToString().Length == 0)
                {
                    MessageBoxEx.Show("Bạn phải nhập cân nặng!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtgNhanVien["cannang", donghh].Value = 0;
                    hople = 0;
                }

            if (hople == 1)
                if (Convert.ToInt32(dtgNhanVien["cannang", donghh].Value.ToString()) < 0)
                {
                    MessageBoxEx.Show("Cân nặng không được âm!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    string cannang = dtgNhanVien["cannang", donghh].Value.ToString();
                    string cannangduong = null;
                    for (int i = 1; i < cannang.Length; i++)
                        cannangduong = cannangduong + cannang[i].ToString();
                    dtgNhanVien["heso", donghh].Value = cannangduong;
                    hople = 0;
                }

            if (hople == 1)
                if (dtgNhanVien["cao", donghh].Value.ToString().Length == 0)
                {

                    MessageBoxEx.Show("Bạn phải nhập chiều cao!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtgNhanVien["cao", donghh].Value = 0;
                    hople = 0;
                }

            if (hople == 1)
                if (Convert.ToDouble(dtgNhanVien["cao", donghh].Value.ToString()) < 0)
                {
                    MessageBoxEx.Show("Chiều cao không được âm!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    string cao = dtgNhanVien["cao", donghh].Value.ToString();
                    string caoduong = null;
                    for (int i = 1; i < cao.Length; i++)
                        caoduong = caoduong + cao[i].ToString();
                    dtgNhanVien["cao", donghh].Value = caoduong;
                    hople = 0;
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

        private void bntHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Hình ảnh|*.jpg;*.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                PicHinh.SizeMode = PictureBoxSizeMode.Zoom;
                PicHinh.Image = Image.FromFile(open.FileName);
                byte[] HinhAnh = ChuyenSangByte(PicHinh.Image);
                dtgNhanVien["hinhanh", dtgNhanVien.CurrentRow.Index].Value = HinhAnh;
                LuuHinh(HinhAnh);
                cohinh = 1;
            }
        }

        private void bntThem_Click(object sender, EventArgs e)
        {
            ThemNhanVien();
        }

        private void bntThemLamViec_Click(object sender, EventArgs e)
        {
            if (dtgNhanVien.RowCount != 0)
                ThemQuaTrinhLamViec(dtgNhanVien["manv", dtgNhanVien.CurrentRow.Index].Value.ToString(), dtgNhanVien["tennv", dtgNhanVien.CurrentRow.Index].Value.ToString());
        }

        private void bntThemBoiDuong_Click(object sender, EventArgs e)
        {
            if (dtgNhanVien.RowCount != 0)
                ThemQuaTrinhBoiDuong(dtgNhanVien["manv", dtgNhanVien.CurrentRow.Index].Value.ToString(), dtgNhanVien["tennv", dtgNhanVien.CurrentRow.Index].Value.ToString());
        }

        public void ThemThanNhan(string manv, string tennv)
        {
            if (dtgNhanVien.RowCount != 0)
            {
                string mathannhan = "TN";

                string masothutu;

                string thang = DateTime.Now.Month.ToString();
                if (thang.Length == 1)
                    thang = "0" + thang;

                string nam = DateTime.Now.Year.ToString();
                string nam02 = nam[2].ToString() + nam[3].ToString();

                string thangnam = thang + nam02;

                int phantu = 0;
                dtThanNhan = thannhan.LayThanNhan();

                foreach (DataRow dr in dtThanNhan.Rows)
                {
                    string ma = dr["mathannhan"].ToString();
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

                    mathannhan = mathannhan + thangnam + masothutu;
                }
                else
                {
                    mathannhan = mathannhan + thangnam + "0001";
                }

                DataRowView row = (DataRowView)bnThanNhan.BindingSource.AddNew();

                row["mathannhan"] = mathannhan;
                row["manv"] = manv;

                cmbQuanHe.SelectedIndex = 0;
                row["quanhe"] = cmbQuanHe.SelectedItem.ToString();
                cmbTrongngoai.SelectedIndex = 0;
                row["tronghayngoai"] = cmbTrongngoai.SelectedItem.ToString();

                string ngayhienhanh = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString();

                thannhan.ThemMoiTN(mathannhan, null, manv, cmbQuanHe.SelectedItem.ToString(), cmbTrongngoai.SelectedItem.ToString(), null, null, ngayhienhanh);

                LuuTruHistory("Thêm mới 1 thân nhân của nhân viên : " + tennv);
            }
        }

        private void bntThemThanNhan_Click(object sender, EventArgs e)
        {
            if (dtgNhanVien.RowCount != 0)
                ThemThanNhan(dtgNhanVien["manv", dtgNhanVien.CurrentRow.Index].Value.ToString(), dtgNhanVien["tennv", dtgNhanVien.CurrentRow.Index].Value.ToString());
        }

        private void PicHinh_DoubleClick(object sender, EventArgs e)
        {
            if (PicHinh.Image != null)
            {
                if (cohinh == 1)
                {
                    frmHinh hinh = new frmHinh(PicHinh.Image, dtgNhanVien["tennv", dtgNhanVien.CurrentRow.Index].Value.ToString());
                    hinh.ShowDialog();
                    byte[] HinhAnh = ChuyenSangByte(PicHinh.Image);
                    //dtgNhanVien["hinhanh", dtgNhanVien.CurrentRow.Index].Value = HinhAnh;
                    LuuHinh(HinhAnh);
                }
            }
        }

        private void dtgLamviec_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCellStyle style1 = new DataGridViewCellStyle();
            //style1.ForeColor = Color.SpringGreen;
            style1.BackColor = Color.Honeydew;
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            style2.ForeColor = Color.MediumBlue;
            style2.BackColor = Color.BurlyWood;
            for (int i = dtgLamviec.RowCount - 1; i >= 0; i--)
            {
                if (i % 2 == 0)
                    dtgLamviec.Rows[i].DefaultCellStyle = style1;
                else
                    dtgLamviec.Rows[i].DefaultCellStyle = style2;
            }
        }

        private void dtgNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCellStyle style1 = new DataGridViewCellStyle();
            style1.ForeColor = Color.Olive;
            style1.BackColor = Color.WhiteSmoke;
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            style2.ForeColor = Color.MediumBlue;
            style2.BackColor = Color.Pink;
            for (int i = dtgNhanVien.RowCount - 1; i >= 0; i--)
            {
                if (i % 2 == 0)
                    dtgNhanVien.Rows[i].DefaultCellStyle = style1;
                else
                    dtgNhanVien.Rows[i].DefaultCellStyle = style2;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Luu();
            frmNhanVien_Load(sender, e);
        }

        private void bntLuuLamViec_Click(object sender, EventArgs e)
        {
            LuuQuaTrinhLamViec();
        }

        private void dtgBoiduong_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void bntLuuQTBD_Click(object sender, EventArgs e)
        {
            LuuQuaTrinhBoiDuong();
        }

        private void dtgBoiduong_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCellStyle style1 = new DataGridViewCellStyle();
            //style1.ForeColor = Color.SpringGreen;
            style1.BackColor = Color.Honeydew;
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            style2.ForeColor = Color.MediumBlue;
            style2.BackColor = Color.BurlyWood;
            for (int i = dtgBoiduong.RowCount - 1; i >= 0; i--)
            {
                if (i % 2 == 0)
                    dtgBoiduong.Rows[i].DefaultCellStyle = style1;
                else
                    dtgBoiduong.Rows[i].DefaultCellStyle = style2;
            }
        }

        private void bntXoaHinh_Click(object sender, EventArgs e)
        {
            nhanvien.XoaHinh(dtgNhanVien["manv", dtgNhanVien.CurrentRow.Index].Value.ToString());
            dtgNhanVien["hinhanh", dtgNhanVien.CurrentRow.Index].Value = null;

            if (File.Exists(Application.StartupPath + "\\Images\\NoImage.bmp"))
            {
                PicHinh.SizeMode = PictureBoxSizeMode.StretchImage;
                PicHinh.Image = Image.FromFile(Application.StartupPath + "\\Images\\NoImage.bmp");
            }
            cohinh = 0;
        }

        public void LuuThanNhan()
        {
            if (dtgThanNhan.RowCount != 0)
            {
                dtgThanNhan.EndEdit();
                if (dtgThanNhan.CurrentRow.Index != dtgThanNhan.RowCount - 1)
                    bnThanNhan.BindingSource.MoveNext();
                else
                    bnThanNhan.BindingSource.MovePrevious();

                for (int i = 0; i < dtgThanNhan.RowCount; i++)
                {
                    thannhan.CapNhatTN(dtgThanNhan["mathannhan", i].Value.ToString(), dtgThanNhan["tenthannhan", i].Value.ToString(), dtgThanNhan["cmbcolNVThanNhan", i].Value.ToString(), dtgThanNhan["cmbcolQuanhe", i].Value.ToString(), dtgThanNhan["cmbcolDinhcu", i].Value.ToString(), dtgThanNhan["nuocdinhcu", i].Value.ToString(), dtgThanNhan["ghichu", i].Value.ToString());
                }
                MessageBoxEx.Show("Bạn đã lưu thành công", "Chúc mừng");
            }
        }

        private void bntLuuTN_Click(object sender, EventArgs e)
        {
            LuuThanNhan();
        }

        public void LuuTruHistory(string noidungthaotac)
        {
            string ngaygiohienhanh = DateTime.Now.ToString();
            string ngaygiohienhanh1 = null;
            string thanghienhanh = ngaygiohienhanh[3].ToString() + ngaygiohienhanh[4].ToString() + ngaygiohienhanh[2].ToString();
            for (int i = 0; i < ngaygiohienhanh.Length; i++)
            {
                if (ngaygiohienhanh[i].ToString() != null)
                {
                    if (i != 2 && i != 3 && i != 4)
                        ngaygiohienhanh1 = ngaygiohienhanh1 + ngaygiohienhanh[i].ToString();
                }
                else
                    break;
            }
            ngaygiohienhanh1 = thanghienhanh + ngaygiohienhanh1;
            frmHistory his = new frmHistory();
            his.Them(ngaygiohienhanh1, noidungthaotac);
        }

        public void ThemKhenThuong(string manv, string tennv)
        {
            string makt = "KT";

            string masothutu;

            string thang = DateTime.Now.Month.ToString();
            if (thang.Length == 1)
                thang = "0" + thang;

            string nam = DateTime.Now.Year.ToString();
            string nam02 = nam[2].ToString() + nam[3].ToString();

            string thangnam = thang + nam02;

            int phantu = 0;
            dtKhenThuong = khenthuong.LayKhenThuong();

            foreach (DataRow dr in dtKhenThuong.Rows)
            {
                string ma = dr["makhenthuong"].ToString();
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

                makt = makt + thangnam + masothutu;
            }
            else
            {
                makt = makt + thangnam + "0001";
            }

            DataRowView row = (DataRowView)bnKhenThuong.BindingSource.AddNew();

            row["makhenthuong"] = makt;
            row["manv"] = manv;
            row["ngaykhen"] = "1/9/2009";

            if (cmbSoquyetdinh.Items.Count != 0)
                cmbSoquyetdinh.SelectedIndex = 0;
            string soquyetdinh = null;
            if (cmbSoquyetdinh.SelectedValue != null)
                soquyetdinh = cmbSoquyetdinh.SelectedValue.ToString();

            string ngayhienhanh = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString();
            row["masoquyetdinh"] = soquyetdinh;

            khenthuong.ThemMoiKhenThuong(makt, manv, soquyetdinh, ngayhienhanh, ngayhienhanh);

            LuuTruHistory("Thêm mới 1 khen thưởng của nhân viên : " + tennv);
        }

        private void bntThemKhenThuong_Click(object sender, EventArgs e)
        {
            if (dtgNhanVien.RowCount != 0)
                ThemKhenThuong(dtgNhanVien["manv", dtgNhanVien.CurrentRow.Index].Value.ToString(), dtgNhanVien["tennv", dtgNhanVien.CurrentRow.Index].Value.ToString());
        }

        public void LuuKhenThuong()
        {
            if (dtgKhenThuong.RowCount != 0)
            {
                dtgKhenThuong.EndEdit();
                if (dtgKhenThuong.CurrentRow.Index != dtgKhenThuong.RowCount - 1)
                    bnKhenThuong.BindingSource.MoveNext();
                else
                    bnKhenThuong.BindingSource.MovePrevious();

                for (int i = 0; i < dtgKhenThuong.RowCount; i++)
                {
                    string ngaykhen = dtgKhenThuong["calNgayKhen", i].Value.ToString();
                    ngaykhen = ngaykhen[3].ToString() + ngaykhen[4].ToString() + ngaykhen[2].ToString() + ngaykhen[0].ToString() + ngaykhen[1].ToString() + ngaykhen[5].ToString() + ngaykhen[6].ToString() + ngaykhen[7].ToString() + ngaykhen[8].ToString() + ngaykhen[9].ToString();

                    khenthuong.CapNhatKhenThuong(dtgKhenThuong["makhenthuong", i].Value.ToString(), dtgKhenThuong["cmbcolSQDKT", i].Value.ToString(), dtgKhenThuong["cmbcolNVKT", i].Value.ToString(), dtgKhenThuong["lydokhen", i].Value.ToString(), dtgKhenThuong["hinhthuc", i].Value.ToString(), ngaykhen, dtgKhenThuong["ghichu", i].Value.ToString());
                }
                MessageBoxEx.Show("Bạn đã lưu thành công", "Chúc mừng");
            }
        }

        private void bntLuuKT_Click(object sender, EventArgs e)
        {
            LuuKhenThuong();
        }

        public void ThemKyLuat(string manv, string tennv)
        {
            string makyluat = "KL";

            string masothutu;

            string thang = DateTime.Now.Month.ToString();
            if (thang.Length == 1)
                thang = "0" + thang;

            string nam = DateTime.Now.Year.ToString();
            string nam02 = nam[2].ToString() + nam[3].ToString();

            string thangnam = thang + nam02;

            int phantu = 0;
            dtKyLuat = kyluat.LayKyLuat();

            foreach (DataRow dr in dtKyLuat.Rows)
            {
                string ma = dr["makyluat"].ToString();
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

                makyluat = makyluat + thangnam + masothutu;
            }
            else
            {
                makyluat = makyluat + thangnam + "0001";
            }

            DataRowView row = (DataRowView)bnKyLuat.BindingSource.AddNew();

            row["makyluat"] = makyluat;
            row["manv"] = manv;
            row["ngaykyluat"] = "1/9/2009";

            string soquyetdinh = null;
            if (cmbSoquyetdinh.Items.Count != 0)
            {
                cmbSoquyetdinh.SelectedIndex = 0;
                soquyetdinh = cmbSoquyetdinh.SelectedValue.ToString();
            }

            string ngayhienhanh = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString();
            row["masoquyetdinh"] = soquyetdinh;

            kyluat.ThemMoiKyLuat(makyluat, manv, soquyetdinh, ngayhienhanh, ngayhienhanh);

            LuuTruHistory("Thêm mới 1 kỷ luật của nhân viên : " + tennv);
        }

        private void bntThemKL_Click(object sender, EventArgs e)
        {
            if (dtgNhanVien.RowCount != 0)
                ThemKyLuat(dtgNhanVien["manv", dtgNhanVien.CurrentRow.Index].Value.ToString(), dtgNhanVien["tennv", dtgNhanVien.CurrentRow.Index].Value.ToString());
        }

        public void LuuKyLuat()
        {
            if (dtgKyLuat.RowCount != 0)
            {
                dtgKyLuat.EndEdit();
                if (dtgKyLuat.CurrentRow.Index != dtgKyLuat.RowCount - 1)
                    bnKyLuat.BindingSource.MoveNext();
                else
                    bnKyLuat.BindingSource.MovePrevious();

                for (int i = 0; i < dtgKyLuat.RowCount; i++)
                {
                    string ngaykhen = dtgKyLuat["calNgayKyLuat", i].Value.ToString();
                    ngaykhen = ngaykhen[3].ToString() + ngaykhen[4].ToString() + ngaykhen[2].ToString() + ngaykhen[0].ToString() + ngaykhen[1].ToString() + ngaykhen[5].ToString() + ngaykhen[6].ToString() + ngaykhen[7].ToString() + ngaykhen[8].ToString() + ngaykhen[9].ToString();

                    kyluat.CapNhatKyLuat(dtgKyLuat["makyluat", i].Value.ToString(), dtgKyLuat["cmbcolSQDKL", i].Value.ToString(), dtgKyLuat["cmbcolNVKL", i].Value.ToString(), dtgKyLuat["lydo", i].Value.ToString(), dtgKyLuat["hinhthuc", i].Value.ToString(), ngaykhen, dtgKyLuat["ghichu", i].Value.ToString());
                }
                MessageBoxEx.Show("Bạn đã lưu thành công", "Chúc mừng");
            }
        }

        private void bntLuuKL_Click(object sender, EventArgs e)
        {
            LuuKyLuat();
        }

        public void ThemHopDong(string manv, string tennv)
        {
            string mahd = "HD";

            string masothutu;

            string thang = DateTime.Now.Month.ToString();
            if (thang.Length == 1)
                thang = "0" + thang;

            string nam = DateTime.Now.Year.ToString();
            string nam02 = nam[2].ToString() + nam[3].ToString();

            string thangnam = thang + nam02;

            int phantu = 0;
            dtHopDong = hopdong.LayHopDong();

            foreach (DataRow dr in dtHopDong.Rows)
            {
                string ma = dr["mahopdong"].ToString();
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

                mahd = mahd + thangnam + masothutu;
            }
            else
            {
                mahd = mahd + thangnam + "0001";
            }

            DataRowView row = (DataRowView)bnHopDong.BindingSource.AddNew();

            row["mahopdong"] = mahd;
            row["manv"] = manv;
            row["ngayky"] = "1/9/2009";
            row["ngaybatdau"] = "1/9/2009";
            row["ngayketthuc"] = "1/9/2009";

            string nhanvien = null;
            if (cmbNVHopDong.Items.Count != 0)
            {
                cmbNVHopDong.SelectedIndex = 0;
                nhanvien = cmbNVHopDong.SelectedValue.ToString();
            }

            string ngayhienhanh = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString();
            row["manguoiky"] = nhanvien;

            hopdong.ThemMoiHopDong(mahd, manv, ngayhienhanh, ngayhienhanh, 1, null, ngayhienhanh, nhanvien, null, ngayhienhanh);

            LuuTruHistory("Thêm mới 1 hợp đồng của nhân viên : " + tennv);
        }

        private void bntThemHopDong_Click(object sender, EventArgs e)
        {
            if (dtgNhanVien.RowCount != 0)
                ThemHopDong(dtgNhanVien["manv", dtgNhanVien.CurrentRow.Index].Value.ToString(), dtgNhanVien["tennv", dtgNhanVien.CurrentRow.Index].Value.ToString());
        }

        public void LuuHopDong()
        {
            if (dtgHopDong.RowCount != 0)
            {
                dtgHopDong.EndEdit();
                if (dtgHopDong.CurrentRow.Index != dtgHopDong.RowCount - 1)
                    bnHopDong.BindingSource.MoveNext();
                else
                    bnHopDong.BindingSource.MovePrevious();

                for (int i = 0; i < dtgHopDong.RowCount; i++)
                {
                    DateTime datengayky = Convert.ToDateTime(dtgHopDong["calNgayKyHD", i].Value);
                    string ngayky = datengayky.Month.ToString() + "/" + datengayky.Day.ToString() + "/" + datengayky.Year.ToString();

                    DateTime datengaybatdau = Convert.ToDateTime(dtgHopDong["calNgayBDHopDong", i].Value);
                    string ngaybatdau = datengaybatdau.Month.ToString() + "/" + datengaybatdau.Day.ToString() + "/" + datengaybatdau.Year.ToString();

                    DateTime datengayketthuc = Convert.ToDateTime(dtgHopDong["calNgayKTHopDong", i].Value);
                    string ngayketthuc = datengayketthuc.Month.ToString() + "/" + datengayketthuc.Day.ToString() + "/" + datengayketthuc.Year.ToString();

                    int lanky = 1;
                    if (dtgHopDong["lanky", i].Value.ToString().Length != 0)
                        lanky = Convert.ToInt32(dtgHopDong["lanky", i].Value.ToString());

                    hopdong.CapNhatHopDong(dtgHopDong["mahopdong", i].Value.ToString(), dtgHopDong["cmbcolNVHopDong", i].Value.ToString(), ngaybatdau, ngayketthuc,lanky, dtgHopDong["noidung", i].Value.ToString(), ngayky, dtgHopDong["cmbcolNguoiKyHD", i].Value.ToString(), dtgHopDong["ghichu", i].Value.ToString());
                }
                MessageBoxEx.Show("Bạn đã lưu thành công", "Chúc mừng");
            }
        }

        private void bntLuuHD_Click(object sender, EventArgs e)
        {
            LuuHopDong();
        }

        private void bntXemLai_Click(object sender, EventArgs e)
        {
            cmbChonXem_SelectedIndexChanged(sender, e);
            txtTimKiemNV.Text = null;
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTimKiemNV_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable dtTimKiemTheoTen = new DataTable();
            dtTimKiemTheoTen = nhanvien.LayNhanVienTheoTenTheoTinhTrang(txtTimKiemNV.Text, cmbChonXem.SelectedItem.ToString());
            DataTable dtTimKiemTheoTen1 = new DataTable();
            dtTimKiemTheoTen1 = dtTimKiemTheoTen.Clone();

            foreach (DataRow dr in dtTimKiemTheoTen.Rows)
                dtTimKiemTheoTen1.ImportRow(dr);

            control.HienThiGrid(dtTimKiemTheoTen1, txtManv, txtTennv, txtCMND, dteNgaycap, txtNoiCap, dteNgaySinhNV, cmbGioiTinh, txtDiaChi, txtEmail, txtDTnganhang, txtDTrieng, txtDTnha, cmbHonnhan, cmbLamviec, cmbPhongban, cmbTo, cmbChucvu, txtNgayvaolam, txtThamnien, txtHeso, txtSoTK, txtHinhThuctuyendung, txtTinhoc, txtNgoaingu, cmbHocVi, txtCannang, txtCao, cmbMau, txtSucKhoe, txtBHXH, txtBHYT, dtgNhanVien, bnNhanVien);
        }

        private void frmNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtNhanVien = nhanvien.LayNhanVien();

            for (int i = 0; i < dtgNhanVien.Rows.Count; i++)
            {
                foreach (DataRow dr in dtNhanVien.Rows)
                {
                    if (dtgNhanVien["manv", i].Value.ToString() == dr["manv"].ToString())
                    {
                        for (int cot = 0; cot < dtgNhanVien.Columns.Count; cot++)
                        {
                            if (dtgNhanVien[cot, i].Value.ToString() != dr[cot].ToString())
                            {
                                DialogResult d = MessageBoxEx.Show("Đã có một số thay đổi.Bạn có muốn lưu lại không?", "Thông Báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                                if (d == DialogResult.Yes)
                                    Luu();
                                if (d == DialogResult.Cancel)
                                    e.Cancel = true;

                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }

        private void cmbTo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbTo.SelectedValue != null && cmbTo.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                dtTo = to.LayToLamViec();
                foreach (DataRow dr in dtTo.Rows)
                {
                    if (dr["mato"].ToString() == cmbTo.SelectedValue.ToString())
                    {
                        cmbPhongban.SelectedValue = dr["maphongban"];
                        break;
                    }
                }
            }
        }

        private void cmbChonXem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChonXem.SelectedItem.ToString().Length != 0)
            {

                DataTable dtNvTheoTinhTrang = new DataTable();
                dtNhanVien = nhanvien.LayNhanVien();
                dtNvTheoTinhTrang = dtNhanVien.Clone();

                if (cmbChonXem.Text == "Tất cả")
                {
                    foreach (DataRow dr in dtNhanVien.Rows)
                    {
                        dtNvTheoTinhTrang.ImportRow(dr);
                    }
                }
                else
                {
                    foreach (DataRow dr in dtNhanVien.Rows)
                    {
                        if (dr["tinhtranglamviec"].ToString() == cmbChonXem.Text)
                        {
                            dtNvTheoTinhTrang.ImportRow(dr);
                        }
                    }
                }
                control.HienThiGrid(dtNvTheoTinhTrang, txtManv, txtTennv, txtCMND, dteNgaycap, txtNoiCap, dteNgaySinhNV, cmbGioiTinh, txtDiaChi, txtEmail, txtDTnganhang, txtDTrieng, txtDTnha, cmbHonnhan, cmbLamviec, cmbPhongban, cmbTo, cmbChucvu, txtNgayvaolam, txtThamnien, txtHeso, txtSoTK, txtHinhThuctuyendung, txtTinhoc, txtNgoaingu, cmbHocVi, txtCannang, txtCao, cmbMau, txtSucKhoe, txtBHXH, txtBHYT, dtgNhanVien, bnNhanVien);
            }
        }

        private void cmbPhongban_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPhongban.SelectedValue != null && cmbPhongban.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                dtTotheophong = to.LayToLamViecTheoPhong(cmbPhongban.SelectedValue.ToString());
                if (dtTotheophong.Rows.Count == 0)
                {
                    cmbTo.Enabled = false;
                    cmbTo.Text = null;
                }
                else
                    cmbTo.Enabled = true;
            }
        }

        private void them6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bntThem_Click(sender, e);
        }

        private void lưuLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton1_Click(sender, e);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            bntHinh_Click(sender, e);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bntXemLai_Click(sender, e);
        }

        public void XoaLamViec()
        {
            string[] ma = new string[100];
            for (int i = 0; i < dtgLamviec.SelectedRows.Count; i++)
                ma[i] = dtgLamviec["maquatrinh", dtgLamviec.SelectedRows[i].Index].Value.ToString();
            for (int i = 0; i < 100; i++)
            {
                if (ma[i] != null)
                    lamviec.XoaQTLV(ma[i]);
                else
                    break;
            }
            lamvieccontrol.HienThiLamviec(txtMalamviec, txtTenLamViec, cmbNVLamViec, cmbCongviec, dteNgayBD, dteNgayKT, txtNoilamviec, txtghichu, dtgNhanVien["manv", dtgNhanVien.CurrentRow.Index].Value.ToString(), dtgLamviec, bnLamviec);
        }

        private void bntXoaLamViec_Click(object sender, EventArgs e)
        {
            XoaLamViec();
        }

        public void XoaBoiDuong()
        {
            string[] ma = new string[100];
            for (int i = 0; i < dtgBoiduong.SelectedRows.Count; i++)
                ma[i] = dtgBoiduong["maboiduong", dtgBoiduong.SelectedRows[i].Index].Value.ToString();
            for (int i = 0; i < 100; i++)
            {
                if (ma[i] != null)
                    boiduong.XoaQTBD(ma[i]);
                else
                    break;
            }
            boiduongcontrol.HienThiBoiDuong(txtMaboiduong, txtTenBoiDuong, cmbNVBD, cmbSoquyetdinh, dteNgayBDBoiDuong, dteNgayKTBoiDuong, txtChuyennganh, txtNoiboiduong, txtghichuboiduong, dtgNhanVien["manv", dtgNhanVien.CurrentRow.Index].Value.ToString(), dtgBoiduong, bnBoiDuong);
        }

        private void bntXoaBoiDuong_Click(object sender, EventArgs e)
        {
            XoaBoiDuong();
        }

        public void XoaThanNhan()
        {
            string[] ma = new string[100];
            for (int i = 0; i < dtgThanNhan.SelectedRows.Count; i++)
                ma[i] = dtgThanNhan["mathannhan", dtgThanNhan.SelectedRows[i].Index].Value.ToString();
            for (int i = 0; i < 100; i++)
            {
                if (ma[i] != null)
                    thannhan.Xoa(ma[i]);
                else
                    break;
            }
            thannhancontrol.HienThi(txtMathannhan, txtTenthannhan, cmbNVTN, cmbQuanHe, cmbTrongngoai, txtNuocngoai, txtGhichuthannhan, dtgNhanVien["manv", dtgNhanVien.CurrentRow.Index].Value.ToString(), bnThanNhan, dtgThanNhan);
        }

        private void bntXoaThanNhan_Click(object sender, EventArgs e)
        {
            XoaThanNhan();
        }

        public void XoaKhenThuong()
        {
            string[] ma = new string[100];
            for (int i = 0; i < dtgKhenThuong.SelectedRows.Count; i++)
                ma[i] = dtgKhenThuong["makhenthuong", dtgKhenThuong.SelectedRows[i].Index].Value.ToString();
            for (int i = 0; i < 100; i++)
            {
                if (ma[i] != null)
                    khenthuong.Xoa(ma[i]);
                else
                    break;
            }
            khenthuongcontrol.HienThiKhenThuong(txtMaKT, cmbSQDKT, cmbNVKT, dteNgayKhen, txtLyDoKhen, txtHinhThuc, txtGhiChuKT, dtgNhanVien["manv",dtgNhanVien.CurrentRow.Index].Value.ToString(), dtgKhenThuong, bnKhenThuong);
        }

        private void bntXoaKhenThuong_Click(object sender, EventArgs e)
        {
            XoaKhenThuong();
        }

        public void XoaKyLuat()
        {
            string[] ma = new string[100];
            for (int i = 0; i < dtgKyLuat.SelectedRows.Count; i++)
                ma[i] = dtgKyLuat["makyluat", dtgKyLuat.SelectedRows[i].Index].Value.ToString();
            for (int i = 0; i < 100; i++)
            {
                if (ma[i] != null)
                    kyluat.Xoa(ma[i]);
                else
                    break;
            }
            kyluatcontrol.HienThiKyLuat(txtMaKL, cmbSQDKL, cmbNVKL, dteNgayKL, txtLyDoKL, txtHinhThuc, txtGhiChuKL, dtgNhanVien["manv", dtgNhanVien.CurrentRow.Index].Value.ToString(), dtgKyLuat, bnKyLuat);
        }

        private void bntXoaKyLuat_Click(object sender, EventArgs e)
        {
            XoaKyLuat();
        }

        public void XoaHopDong()
        {
            string[] ma = new string[100];
            for (int i = 0; i < dtgHopDong.SelectedRows.Count; i++)
                ma[i] = dtgHopDong["mahopdong", dtgHopDong.SelectedRows[i].Index].Value.ToString();
            for (int i = 0; i < 100; i++)
            {
                if (ma[i] != null)
                    hopdong.Xoa(ma[i]);
                else
                    break;
            }
            hopdongcontrol.HienThiHopDong(dtgNhanVien["manv", dtgNhanVien.CurrentRow.Index].Value.ToString(), txtMaHopDong, cmbNVHopDong, dteNgayBDHD, dteNgayKTHD, numLanKy, txtNoiDungHD, dteNgayKyHD, cmbNguoiKyHD, txtGhiChuHD, dtgHopDong, bnHopDong);
        }

        private void bntXoaHopDong_Click(object sender, EventArgs e)
        {
            XoaHopDong();
        }

    }
}
                
                
                
