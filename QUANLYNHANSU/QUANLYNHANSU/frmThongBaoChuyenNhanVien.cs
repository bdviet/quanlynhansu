using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QUANLYNHANSU.GetData;

namespace QUANLYNHANSU
{
    public partial class frmThongBaoChuyenNhanVien : Office2007Form
    {
        public frmThongBaoChuyenNhanVien()
        {
            InitializeComponent();
        }

        clsLayPhongBan pb = new clsLayPhongBan();
        clsLayToLamViec to = new clsLayToLamViec();
        clsLayChucVu cv = new clsLayChucVu();

        DataTable dtTo = new DataTable();

        public string maphong = null;
        public string mato = null;
        public string machucvu = null;
        public int chuyen = 0;

        private void frmThongBaoChuyenNhanVien_Load(object sender, EventArgs e)
        {
            cmbPhongBan.DataSource = pb.LayPhongBan();
            cmbPhongBan.DisplayMember = "tenphong";
            cmbPhongBan.ValueMember = "maphong";

            cmbPhongBan.SelectedIndex = 0;

            cmbTo.DataSource = to.LayToLamViecTheoPhong(cmbPhongBan.SelectedValue.ToString());
            cmbTo.DisplayMember = "tento";
            cmbTo.ValueMember = "mato";

            //cmbTo.SelectedIndex = 0;

            cmbChucVu.DataSource = cv.LayChucVu();
            cmbChucVu.DisplayMember = "ten";
            cmbChucVu.ValueMember = "machucvu";

            cmbChucVu.SelectedIndex = 0;

            dtTo = to.LayToLamViecTheoPhong(cmbPhongBan.SelectedValue.ToString());
            if (dtTo.Rows.Count == 0)
            {
                cmbTo.Enabled = false;
                cmbTo.Text = null;
            }
            else
            {
                cmbTo.Enabled = true;
                cmbTo.DataSource = to.LayToLamViecTheoPhong(cmbPhongBan.SelectedValue.ToString());
            }
        }

        private void cmbPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtTo = to.LayToLamViecTheoPhong(cmbPhongBan.SelectedValue.ToString());
            if (dtTo.Rows.Count == 0)
            {
                cmbTo.Enabled = false;
                cmbTo.Text = null;
            }
            else
            {
                cmbTo.Enabled = true;
                cmbTo.DataSource = to.LayToLamViecTheoPhong(cmbPhongBan.SelectedValue.ToString());
            }
        }

        private void bntChuyen_Click(object sender, EventArgs e)
        {
            chuyen = 1;
            maphong = cmbPhongBan.SelectedValue.ToString();
            if (cmbTo.Enabled == true)
                mato = cmbTo.SelectedValue.ToString();
            machucvu = cmbChucVu.SelectedValue.ToString();
            this.Close();
        }

        private void bntKhong_Click(object sender, EventArgs e)
        {
            chuyen = 0;
            this.Close();
        }
    }
}