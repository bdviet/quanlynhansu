using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QUANLYNHANSU.Controller;
using QUANLYNHANSU.GetData;
using DevComponents.DotNetBar;

namespace QUANLYNHANSU
{
    public partial class frmChuyenNhanVien : Office2007Form
    {
        public frmChuyenNhanVien()
        {
            InitializeComponent();
        }
        clsChuyenNhanVienController cnvcontrol = new clsChuyenNhanVienController();
        clsLayChuyenNhanVien chuyen = new clsLayChuyenNhanVien();
        clsLayBangNhanVien nhanvien = new clsLayBangNhanVien();

        DataTable dtChuyen = new DataTable();

        private void frmChuyenNhanVien_Load(object sender, EventArgs e)
        {
            cnvcontrol.HienthiNV(cmbNV);
            cnvcontrol.HienthiGridNV(cmbcolNV);

            cnvcontrol.HienthiSQD(cmbSQD);
            cnvcontrol.HienthiGridSQD(cmbcolSQD);

            cnvcontrol.HienthiPhongban(cmbPB);
            cnvcontrol.HienthiGridPhongban(cmbcolPBMoi);

            cnvcontrol.HienThi(txtMa,cmbNV,cmbSQD,dteNgayChuyen,cmbtrongNgoai,txtDonViDen,cmbPB,txtghiChu, dtgChuyenNV, bnChuyenNV);
        }

        private void cmbtrongNgoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbtrongNgoai.SelectedItem.ToString() == "Trong")
            {
                txtDonViDen.Text = null;
                cmbPB.Enabled = true;
                txtDonViDen.Enabled = false;
            }
            else
            {
                cmbPB.Text = null;
                cmbPB.Enabled = false;
                txtDonViDen.Enabled = true;
            }
        }

        private void dtgChuyenNV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgChuyenNV["cmbcolTrongHayNgoai", dtgChuyenNV.CurrentRow.Index].Value.ToString() == "Trong")
                dtgChuyenNV["donviden", dtgChuyenNV.CurrentRow.Index].Value = null;
            else
                dtgChuyenNV["cmbcolPBMoi", dtgChuyenNV.CurrentRow.Index].Value = null;
        }

        public void ThemChuyenNhanVien()
        {
            string machuyen = "CH";

            string masothutu;

            string thang = DateTime.Now.Month.ToString();
            if (thang.Length == 1)
                thang = "0" + thang;

            string nam = DateTime.Now.Year.ToString();
            string nam02 = nam[2].ToString() + nam[3].ToString();

            string thangnam = thang + nam02;

            int phantu = 0;
            dtChuyen = chuyen.LayChuyenNhanVien();

            foreach (DataRow dr in dtChuyen.Rows)
            {
                string ma = dr["machuyennv"].ToString();
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

                machuyen = machuyen + thangnam + masothutu;
            }
            else
            {
                machuyen = machuyen + thangnam + "0001";
            }

            DataRowView row = (DataRowView)bnChuyenNV.BindingSource.AddNew();

            row["machuyennv"] = machuyen;
            row["tronghayngoai"] = "Trong";

            string maphong = null;

            if (cmbPB.Items.Count != 0)
            {
                cmbPB.SelectedIndex = 0;
                maphong = cmbPB.SelectedValue.ToString();
            }

            row["maphongmoi"] = maphong;
            row["ngaychuyen"] = DateTime.Now.Date.ToString();
            row["ngaythem"] = DateTime.Now.Date.ToString();

            string ngayhienhanh = DateTime.Now.Date.ToString();
            ngayhienhanh = ngayhienhanh[3].ToString() + ngayhienhanh[4].ToString() + ngayhienhanh[2].ToString() + ngayhienhanh[0].ToString() + ngayhienhanh[1].ToString() + ngayhienhanh[5].ToString() + ngayhienhanh[6].ToString() + ngayhienhanh[7].ToString() + ngayhienhanh[8].ToString() + ngayhienhanh[9].ToString();

            chuyen.ThemMoiChuyen(machuyen, null, null, ngayhienhanh, "Trong", null, maphong, null, ngayhienhanh);
        }

        private void bntThem_Click(object sender, EventArgs e)
        {
            ThemChuyenNhanVien();
        }

        public void LuuChuyenNV()
        {
            if (dtgChuyenNV.RowCount != 0)
            {
                dtgChuyenNV.EndEdit();
                if (dtgChuyenNV.CurrentRow.Index != dtgChuyenNV.RowCount - 1)
                    bnChuyenNV.BindingSource.MoveNext();
                else
                    bnChuyenNV.BindingSource.MovePrevious();

                for (int i = 0; i < dtgChuyenNV.Rows.Count; i++)
                {
                    string ngaychuyen = "";


                    if (dtgChuyenNV["calNgayChuyen", i].Value.ToString().Length != 0)
                    {
                        ngaychuyen = dtgChuyenNV["calNgayChuyen", i].Value.ToString();
                        ngaychuyen = ngaychuyen[3].ToString() + ngaychuyen[4].ToString() + ngaychuyen[2].ToString() + ngaychuyen[0].ToString() + ngaychuyen[1].ToString() + ngaychuyen[5].ToString() + ngaychuyen[6].ToString() + ngaychuyen[7].ToString() + ngaychuyen[8].ToString() + ngaychuyen[9].ToString();
                    }

                    chuyen.CapNhatChuyen(dtgChuyenNV["machuyennv", i].Value.ToString(), dtgChuyenNV["cmbcolNV", i].Value.ToString(), dtgChuyenNV["cmbcolSQD", i].Value.ToString(), ngaychuyen, dtgChuyenNV["cmbcolTrongHayNgoai", i].Value.ToString(), dtgChuyenNV["donviden", i].Value.ToString(), dtgChuyenNV["cmbcolPBMoi", i].Value.ToString(), dtgChuyenNV["ghichu", i].Value.ToString());
                    if (dtgChuyenNV["cmbcolTrongHayNgoai", i].Value.ToString() == "Trong")
                        nhanvien.UpdatePhongBanMoi(dtgChuyenNV["cmbcolPBMoi", i].Value.ToString(), null, dtgChuyenNV["cmbcolNV", i].Value.ToString());
                    if (dtgChuyenNV["cmbcolTrongHayNgoai", i].Value.ToString() == "Ngoài")
                        nhanvien.UpdateNhanVienTheoTinhTrang(dtgChuyenNV["cmbcolNV", i].Value.ToString(), "Nghĩ việc");
                }
                //cnvcontrol.HienThi(dtgChuyenNV, bnChuyenNV);
                MessageBoxEx.Show("Bạn đã chuyển thành công!!!", "Chúc mừng");
            }
        }

        private void bntLuu_Click(object sender, EventArgs e)
        {
            LuuChuyenNV();
        }
    }
}