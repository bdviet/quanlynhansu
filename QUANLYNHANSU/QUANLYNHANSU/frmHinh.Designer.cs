namespace QUANLYNHANSU
{
    partial class frmHinh
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bntXoay1 = new DevComponents.DotNetBar.ButtonX();
            this.bntXoay2 = new DevComponents.DotNetBar.ButtonX();
            this.bntXoay3 = new DevComponents.DotNetBar.ButtonX();
            this.bntXoay4 = new DevComponents.DotNetBar.ButtonX();
            this.bntOK = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PicHinh = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicHinh)).BeginInit();
            this.SuspendLayout();
            // 
            // bntXoay1
            // 
            this.bntXoay1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bntXoay1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bntXoay1.Location = new System.Drawing.Point(60, 601);
            this.bntXoay1.Name = "bntXoay1";
            this.bntXoay1.Size = new System.Drawing.Size(75, 23);
            this.bntXoay1.TabIndex = 1;
            this.bntXoay1.Text = "Xoay phải";
            this.bntXoay1.Click += new System.EventHandler(this.bntXoay1_Click);
            // 
            // bntXoay2
            // 
            this.bntXoay2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bntXoay2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bntXoay2.Location = new System.Drawing.Point(188, 601);
            this.bntXoay2.Name = "bntXoay2";
            this.bntXoay2.Size = new System.Drawing.Size(75, 23);
            this.bntXoay2.TabIndex = 2;
            this.bntXoay2.Text = "Xoay trái";
            this.bntXoay2.Click += new System.EventHandler(this.bntXoay2_Click);
            // 
            // bntXoay3
            // 
            this.bntXoay3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bntXoay3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bntXoay3.Location = new System.Drawing.Point(324, 601);
            this.bntXoay3.Name = "bntXoay3";
            this.bntXoay3.Size = new System.Drawing.Size(75, 23);
            this.bntXoay3.TabIndex = 3;
            this.bntXoay3.Text = "Xoay xuống";
            this.bntXoay3.Click += new System.EventHandler(this.bntXoay3_Click);
            // 
            // bntXoay4
            // 
            this.bntXoay4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bntXoay4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bntXoay4.Location = new System.Drawing.Point(445, 601);
            this.bntXoay4.Name = "bntXoay4";
            this.bntXoay4.Size = new System.Drawing.Size(75, 23);
            this.bntXoay4.TabIndex = 4;
            this.bntXoay4.Text = "Xoay lên";
            this.bntXoay4.Click += new System.EventHandler(this.bntXoay4_Click);
            // 
            // bntOK
            // 
            this.bntOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bntOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bntOK.Location = new System.Drawing.Point(324, 639);
            this.bntOK.Name = "bntOK";
            this.bntOK.Size = new System.Drawing.Size(75, 23);
            this.bntOK.TabIndex = 5;
            this.bntOK.Text = "OK";
            this.bntOK.Click += new System.EventHandler(this.bntOK_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(569, 601);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.TabIndex = 6;
            this.buttonX1.Text = "Lớn lên";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.PicHinh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(701, 582);
            this.panel1.TabIndex = 7;
            // 
            // PicHinh
            // 
            this.PicHinh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PicHinh.Dock = System.Windows.Forms.DockStyle.Top;
            this.PicHinh.Location = new System.Drawing.Point(0, 0);
            this.PicHinh.Name = "PicHinh";
            this.PicHinh.Size = new System.Drawing.Size(701, 579);
            this.PicHinh.TabIndex = 1;
            this.PicHinh.TabStop = false;
            this.PicHinh.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.PicHinh_PreviewKeyDown);
            this.PicHinh.Click += new System.EventHandler(this.PicHinh_Click);
            // 
            // frmHinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 674);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.bntOK);
            this.Controls.Add(this.bntXoay4);
            this.Controls.Add(this.bntXoay3);
            this.Controls.Add(this.bntXoay2);
            this.Controls.Add(this.bntXoay1);
            this.Name = "frmHinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHinh";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmHinh_KeyDown);
            this.Load += new System.EventHandler(this.frmHinh_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicHinh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX bntXoay1;
        private DevComponents.DotNetBar.ButtonX bntXoay2;
        private DevComponents.DotNetBar.ButtonX bntXoay3;
        private DevComponents.DotNetBar.ButtonX bntXoay4;
        private DevComponents.DotNetBar.ButtonX bntOK;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox PicHinh;
    }
}