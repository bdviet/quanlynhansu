namespace QUANLYNHANSU
{
    partial class frmDangNhap
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
            this.txtUsername = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.OK = new DevComponents.DotNetBar.ButtonX();
            this.reflectionLabel1 = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.reflectionLabel2 = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.txtPass = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.reflectionLabel3 = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            // 
            // 
            // 
            this.txtUsername.Border.Class = "TextBoxBorder";
            this.txtUsername.ForeColor = System.Drawing.Color.Blue;
            this.txtUsername.Location = new System.Drawing.Point(175, 65);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(129, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // OK
            // 
            this.OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.OK.ImageFixedSize = new System.Drawing.Size(30, 30);
            this.OK.Location = new System.Drawing.Point(140, 183);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(55, 23);
            this.OK.TabIndex = 2;
            this.OK.Text = "OK";
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // reflectionLabel1
            // 
            this.reflectionLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reflectionLabel1.ForeColor = System.Drawing.Color.Lime;
            this.reflectionLabel1.Location = new System.Drawing.Point(101, 65);
            this.reflectionLabel1.Name = "reflectionLabel1";
            this.reflectionLabel1.Size = new System.Drawing.Size(68, 32);
            this.reflectionLabel1.TabIndex = 4;
            this.reflectionLabel1.Text = "User name";
            // 
            // reflectionLabel2
            // 
            this.reflectionLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reflectionLabel2.ForeColor = System.Drawing.Color.Lime;
            this.reflectionLabel2.Location = new System.Drawing.Point(101, 92);
            this.reflectionLabel2.Name = "reflectionLabel2";
            this.reflectionLabel2.Size = new System.Drawing.Size(68, 32);
            this.reflectionLabel2.TabIndex = 6;
            this.reflectionLabel2.Text = "Password";
            // 
            // txtPass
            // 
            // 
            // 
            // 
            this.txtPass.Border.Class = "TextBoxBorder";
            this.txtPass.ForeColor = System.Drawing.Color.Blue;
            this.txtPass.Location = new System.Drawing.Point(175, 98);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(129, 20);
            this.txtPass.TabIndex = 1;
            this.txtPass.UseSystemPasswordChar = true;
            this.txtPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPass_KeyDown);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.ImageFixedSize = new System.Drawing.Size(30, 30);
            this.buttonX1.Location = new System.Drawing.Point(201, 183);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(62, 23);
            this.buttonX1.TabIndex = 3;
            this.buttonX1.Text = "Cancel";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // reflectionLabel3
            // 
            this.reflectionLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reflectionLabel3.ForeColor = System.Drawing.Color.Cyan;
            this.reflectionLabel3.Location = new System.Drawing.Point(76, 27);
            this.reflectionLabel3.Name = "reflectionLabel3";
            this.reflectionLabel3.Size = new System.Drawing.Size(267, 32);
            this.reflectionLabel3.TabIndex = 8;
            this.reflectionLabel3.Text = "Bạn phải đăng nhập trước khi truy cập vào hệ thống";
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(425, 284);
            this.Controls.Add(this.reflectionLabel3);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.reflectionLabel2);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.reflectionLabel1);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.txtUsername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDangNhap";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmDangNhap_MouseUp);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmDangNhap_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmDangNhap_MouseDown);
            //this.Load += new System.EventHandler(this.frmDangNhap_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtUsername;
        private DevComponents.DotNetBar.ButtonX OK;
        private DevComponents.DotNetBar.Controls.ReflectionLabel reflectionLabel1;
        private DevComponents.DotNetBar.Controls.ReflectionLabel reflectionLabel2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPass;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.ReflectionLabel reflectionLabel3;

    }
}