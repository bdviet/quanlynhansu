using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.IO;

namespace QUANLYNHANSU
{
    public partial class frmHienThiHinhTheoNhanVien : Office2007Form
    {
        byte[] HinhAnh = new byte[0];
        public frmHienThiHinhTheoNhanVien(byte[] Hinh)
        {
            InitializeComponent();
            HinhAnh = Hinh;
        }

        private void frmHienThiHinhTheoNhanVien_Load(object sender, EventArgs e)
        {
            MemoryStream stream = new MemoryStream(HinhAnh);
            pichinh.SizeMode = PictureBoxSizeMode.StretchImage;
            pichinh.Image = Image.FromStream(stream);
            //reflectionImage1.Image = Image.FromStream(stream);
        }
    }
}