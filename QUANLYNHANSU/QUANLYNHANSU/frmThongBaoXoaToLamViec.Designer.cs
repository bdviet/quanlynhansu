namespace QUANLYNHANSU
{
    partial class frmThongBaoXoaToLamViec
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cmbToLamViec = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dtgNhanVien = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.bntTuyChon = new DevComponents.DotNetBar.ButtonX();
            this.bntKoChuyen = new DevComponents.DotNetBar.ButtonX();
            this.bntChuyenHet = new DevComponents.DotNetBar.ButtonX();
            this.cmbPhongBan = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX3
            // 
            this.labelX3.Location = new System.Drawing.Point(98, 376);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 20);
            this.labelX3.TabIndex = 18;
            this.labelX3.Text = "Tổ làm việc";
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(98, 338);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 20);
            this.labelX2.TabIndex = 17;
            this.labelX2.Text = "Phòng ban";
            // 
            // cmbToLamViec
            // 
            this.cmbToLamViec.DisplayMember = "Text";
            this.cmbToLamViec.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbToLamViec.FormattingEnabled = true;
            this.cmbToLamViec.ItemHeight = 14;
            this.cmbToLamViec.Location = new System.Drawing.Point(179, 376);
            this.cmbToLamViec.Name = "cmbToLamViec";
            this.cmbToLamViec.Size = new System.Drawing.Size(121, 20);
            this.cmbToLamViec.TabIndex = 16;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.dtgNhanVien);
            this.groupPanel1.Location = new System.Drawing.Point(0, 1);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(476, 261);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel1.TabIndex = 15;
            this.groupPanel1.Text = "Danh sách nhân viên";
            // 
            // dtgNhanVien
            // 
            this.dtgNhanVien.AllowUserToAddRows = false;
            this.dtgNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgNhanVien.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgNhanVien.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dtgNhanVien.Location = new System.Drawing.Point(0, 0);
            this.dtgNhanVien.Name = "dtgNhanVien";
            this.dtgNhanVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgNhanVien.Size = new System.Drawing.Size(470, 240);
            this.dtgNhanVien.TabIndex = 0;
            // 
            // bntTuyChon
            // 
            this.bntTuyChon.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bntTuyChon.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bntTuyChon.Location = new System.Drawing.Point(179, 428);
            this.bntTuyChon.Name = "bntTuyChon";
            this.bntTuyChon.Size = new System.Drawing.Size(121, 23);
            this.bntTuyChon.TabIndex = 14;
            this.bntTuyChon.Text = "Chuyển theo tùy chọn";
            this.bntTuyChon.Click += new System.EventHandler(this.bntChuyenTuyChon_Click);
            // 
            // bntKoChuyen
            // 
            this.bntKoChuyen.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bntKoChuyen.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bntKoChuyen.Location = new System.Drawing.Point(342, 428);
            this.bntKoChuyen.Name = "bntKoChuyen";
            this.bntKoChuyen.Size = new System.Drawing.Size(85, 23);
            this.bntKoChuyen.TabIndex = 13;
            this.bntKoChuyen.Text = "Không chuyển";
            this.bntKoChuyen.Click += new System.EventHandler(this.bntKoChuyen_Click);
            // 
            // bntChuyenHet
            // 
            this.bntChuyenHet.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bntChuyenHet.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bntChuyenHet.Location = new System.Drawing.Point(58, 428);
            this.bntChuyenHet.Name = "bntChuyenHet";
            this.bntChuyenHet.Size = new System.Drawing.Size(75, 23);
            this.bntChuyenHet.TabIndex = 12;
            this.bntChuyenHet.Text = "Chuyển hết";
            this.bntChuyenHet.Click += new System.EventHandler(this.bntChuyenHet_Click);
            // 
            // cmbPhongBan
            // 
            this.cmbPhongBan.DisplayMember = "Text";
            this.cmbPhongBan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPhongBan.FormattingEnabled = true;
            this.cmbPhongBan.ItemHeight = 14;
            this.cmbPhongBan.Location = new System.Drawing.Point(179, 338);
            this.cmbPhongBan.Name = "cmbPhongBan";
            this.cmbPhongBan.Size = new System.Drawing.Size(121, 20);
            this.cmbPhongBan.TabIndex = 11;
            this.cmbPhongBan.SelectedIndexChanged += new System.EventHandler(this.cmbphongban_SelectedIndexChanged);
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(28, 282);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(416, 39);
            this.labelX1.TabIndex = 10;
            this.labelX1.Text = "Nếu bạn xóa phòng ban này thì nhân viên của phòng này sẽ chuyển qua phòng nào?\r\n*" +
                "**Lưu ý :Bạn phải chuyển hết nhân viên thì mới xóa được phòng ban";
            // 
            // frmThongBaoXoaToLamViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 465);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.cmbToLamViec);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.bntTuyChon);
            this.Controls.Add(this.bntKoChuyen);
            this.Controls.Add(this.bntChuyenHet);
            this.Controls.Add(this.cmbPhongBan);
            this.Controls.Add(this.labelX1);
            this.Name = "frmThongBaoXoaToLamViec";
            this.Text = "frmThongBaoXoaToLamViec";
            this.Load += new System.EventHandler(this.frmThongBaoXoaToLamViec_Load);
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgNhanVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbToLamViec;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dtgNhanVien;
        private DevComponents.DotNetBar.ButtonX bntTuyChon;
        private DevComponents.DotNetBar.ButtonX bntKoChuyen;
        private DevComponents.DotNetBar.ButtonX bntChuyenHet;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbPhongBan;
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}