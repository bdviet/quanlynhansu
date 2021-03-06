using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace QUANLYNHANSU
{
    public partial class frmChinh : Office2007Form
    {
        public frmChinh()
        {
            InitializeComponent();
        }

        string quyenthaotac = null;

        private void frmChinh_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            KiemTraDN();
        }

        public void KiemTraDN()
        {
            notifyIcon1.Visible = false;
            frmDangNhap dangnhap = new frmDangNhap();
            dangnhap.ShowDialog();

            if (dangnhap.hople == 0)
                this.Close();
            else
            {
                this.Visible = true;
                notifyIcon1.Visible = true;
                username.Text = dangnhap.user;
                quyenthaotac = dangnhap.quyenthaotac;
            }

            if (dangnhap.user == null)
                this.Close();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            KiemTraDN();
        }

        //Gọi các form

        frmNhanVien fnv = null;
        private void toolStripButtonKH_Click(object sender, EventArgs e)
        {
            if (quyenthaotac.Contains("frmNhanVien"))
            {
                if (fnv == null || fnv.IsDisposed)
                    fnv = new frmNhanVien();
                fnv.MdiParent = this;
                fnv.FormBorderStyle = FormBorderStyle.None;
                fnv.Show();
                fnv.Activate();
            }
            else
                MessageBoxEx.Show("Bạn không được quyền truy cập vào quản lý nhân viên","Thông Báo");
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //int close = 0;
            //if (tabStrip1.Tabs.Count != 0)
            //{
            //    if (tabStrip1.Tabs[tabStrip1.SelectedTabIndex].Text == "Nhân viên" && close == 0)
            //    {
            //        close = 1;
            //        fnv.Close();
            //    }
            //    if (tabStrip1.Tabs[tabStrip1.SelectedTabIndex].Text == "Bảng Chấm Công" && close == 0)
            //    {
            //        close = 1;
            //        chamcong.Close();
            //    }
            //}
        }

        frmBangChamCong chamcong = null;
        private void toolStripButtonDV_Click(object sender, EventArgs e)
        {
            if (quyenthaotac.Contains("frmChamCong"))
            {
                if (chamcong == null || chamcong.IsDisposed)
                    chamcong = new frmBangChamCong();
                chamcong.MdiParent = this;
                chamcong.FormBorderStyle = FormBorderStyle.None;
                chamcong.Show();
            }
            else
                MessageBoxEx.Show("Bạn không được quyền truy cập vào bảng chấm công", "Thông Báo");
        }

        frmHistory history = null;
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (history == null || history.IsDisposed)
                history = new frmHistory();
            history.MdiParent = this;
            history.FormBorderStyle = FormBorderStyle.None;
            history.Show();
        }
        frmNguoiDung nguoidung = null;
        private void ngườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (quyenthaotac.Contains("frmNguoiDung"))
            {
                if (nguoidung == null || nguoidung.IsDisposed)
                    nguoidung = new frmNguoiDung();
                nguoidung.MdiParent = this;
                nguoidung.FormBorderStyle = FormBorderStyle.None;
                nguoidung.Show();
            }
            else
                MessageBoxEx.Show("Bạn không phải là Admin nên không được truy cập vào bảng người dùng", "Thông Báo");
        }


        frmBangChiLuong chiluong =null;
        private void toolStripButtonHDON_Click(object sender, EventArgs e)
        {
            if (quyenthaotac.Contains("frmChamCong"))
            {
                if (chiluong == null || chiluong.IsDisposed)
                    chiluong = new frmBangChiLuong();
                chiluong.MdiParent = this;
                chiluong.FormBorderStyle = FormBorderStyle.None;
                chiluong.Show();
            }
            else
                MessageBoxEx.Show("Bạn không được quyền truy cập vào bảng chấm công", "Thông Báo");      
        }
    }
}