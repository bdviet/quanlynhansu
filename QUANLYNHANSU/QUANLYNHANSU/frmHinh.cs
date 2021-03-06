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
    public partial class frmHinh : Office2007Form
    {
        Image hinh = null;
        string tennv = null;
        public frmHinh(Image img,string ten)
        {
            InitializeComponent();
            hinh = img;
            tennv = ten;
        }

        private void frmHinh_Load(object sender, EventArgs e)
        {
            this.Text = "Ảnh của nhân viên : " + tennv;
            PicHinh.SizeMode = PictureBoxSizeMode.Zoom;
            PicHinh.Image = hinh;
            click = 0;
        }

        private void bntXoay1_Click(object sender, EventArgs e)
        {
            PicHinh.Image.RotateFlip(RotateFlipType.Rotate270FlipXY);
            PicHinh.Refresh();
            click = 0;
        }

        private void bntXoay2_Click(object sender, EventArgs e)
        {
           PicHinh.Image.RotateFlip(RotateFlipType.Rotate90FlipXY);
           PicHinh.Refresh();
           click = 0;
        }

        private void bntXoay3_Click(object sender, EventArgs e)
        {
            PicHinh.Image.RotateFlip(RotateFlipType.RotateNoneFlipXY);
            PicHinh.Refresh();//xoaylen
            click = 0;
        }

        private void bntXoay4_Click(object sender, EventArgs e)
        {
            PicHinh.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            PicHinh.Refresh();//xoaylen
            click = 0;
        }

        private void bntOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int click = 0;
        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (PicHinh.Image != null)
            {
                PicHinh.Height += 20;
                PicHinh.Width += 20;
                click = 1;
            }
        }

        private void PicHinh_Click(object sender, EventArgs e)
        {
            if (click == 1)
            {
                PicHinh.Cursor = Cursors.Hand;
                PicHinh.Height += 20;
                PicHinh.Width += 20;
            }
            else
                PicHinh.Cursor = Cursors.Default;
        }

        private void frmHinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.N)
            {
                MessageBox.Show("tan");
                click = 0;
            }
        }

        private void PicHinh_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.N)
            {
                MessageBox.Show("tan");
                click = 0;
            }
        }
    }
}