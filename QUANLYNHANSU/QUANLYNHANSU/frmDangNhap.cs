using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QUANLYNHANSU.GetData;
using QUANLYNHANSU.Controller;
//using System.Drawing;
using System.Collections;
using System.Drawing.Drawing2D;
using DevComponents.DotNetBar;


namespace QUANLYNHANSU
{
    public partial class frmDangNhap : Office2007Form
    {
        public int hople = 1;

        public frmDangNhap()
        {
            InitializeComponent();
        }

        clsDangNhapController control = new clsDangNhapController();
        clsLayNguoiDung nd = new clsLayNguoiDung();
        DataTable dtND = new DataTable();

        protected override void OnPaint(PaintEventArgs e)
        {
           
            Graphics grfx = e.Graphics;

            grfx.SmoothingMode = SmoothingMode.HighQuality;

           
            GraphicsPath grfxPath1 = new GraphicsPath();

            Rectangle rec1 = new Rectangle(0, 0, 400, 150);
            grfxPath1.AddEllipse(rec1);
            Rectangle rec2 = new Rectangle(100, 149, 200, 80);
            grfxPath1.AddEllipse(rec2);


           
            grfx.SetClip(grfxPath1, CombineMode.Replace);

          
            Brush b = new SolidBrush(Color.Black);
            grfx.FillEllipse(b, rec1);
            grfx.FillEllipse(b, rec2);

          
            Pen p = new Pen(Color.Red, 5f);
            grfx.DrawPath(p, grfxPath1);


        }

        public string user = null;
        public string quyenthaotac = null;


        public void DangNhap()
        {
            bool DangNhap = false;

            DangNhap = control.TestDangNhap(txtUsername.Text, txtPass.Text);

            if (DangNhap == true)
            {
                user = txtUsername.Text;
                dtND = nd.LayNguoiDung();

                foreach (DataRow dr in dtND.Rows)
                {
                    if (dr["username"].ToString() == user)
                    {
                        quyenthaotac = dr["chophepthaotac"].ToString();
                        break;
                    }
                }

                MessageBoxEx.Show("Bạn đăng nhập thành công","Chúc mừng");
                this.Close();

            }
            else
            {
                MessageBoxEx.Show("Bạn đăng nhập thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult d = MessageBoxEx.Show("Bạn có muốn đăng nhập lại???", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (d == DialogResult.OK)
                {
                    this.Show();
                    txtUsername.Focus();
                    txtPass.Text = null;
                }
                else
                {
                    hople = 0;
                    this.Close();
                }
            }
        }
        public void OK_Click(object sender, EventArgs e)
        {
            DangNhap();
        }

        Point MouseCurrrnetPos, MouseNewPos, formPos, formNewPos;

        bool mouseDown = false;

        private void frmDangNhap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = true;
                MouseCurrrnetPos = Control.MousePosition;
                formPos = Location;

            }
        }

        private void frmDangNhap_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                mouseDown = false;
        }

        private void frmDangNhap_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {

                MouseNewPos = Control.MousePosition;             // get the position of the mouse in the screen
                formNewPos.X = MouseNewPos.X - MouseCurrrnetPos.X + formPos.X;
                formNewPos.Y = MouseNewPos.Y - MouseCurrrnetPos.Y + formPos.Y;
                Location = formNewPos;
                formPos = formNewPos;
                MouseCurrrnetPos = MouseNewPos;

            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
            hople = 0;
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DangNhap();
            }
        } 
    }
}