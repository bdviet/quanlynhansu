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
    public partial class frmPhanQuyenNguoiDungMoi : Office2007Form
    {
        public frmPhanQuyenNguoiDungMoi()
        {
            InitializeComponent();
        }
        clsLayNguoiDung nguoidung = new clsLayNguoiDung();
        DataTable dtNguoiDung = new DataTable();

        private void bntTao_Click(object sender, EventArgs e)
        {
            int hople = 1;
            dtNguoiDung = nguoidung.LayNguoiDung();

            foreach (DataRow dr in dtNguoiDung.Rows)
            {
                if (txtUser.Text == dr["username"].ToString())
                {
                    MessageBoxEx.Show("Người dùng này đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    hople = 0;
                    break;
                }
            }

            if(hople==1)
                if (txtUser.Text.Length == 0 || txtPass.Text.Length == 0)
                {
                    hople = 0;
                    MessageBoxEx.Show("Username hoặc Password không được rỗng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            if (hople == 1)
                if (txtPass.Text != txtRepass.Text)
                {
                    hople = 0;
                    MessageBoxEx.Show("Password và xác nhận Password không giống nhau", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            if (hople == 1)
            {
                KiemTraCheckNodeVaInsert();
            }

        }

        public void KiemTraCheckNodeVaInsert()
        {
            string formthaotac = null;

            if (node6.Checked)
                formthaotac += "frmNguoiDung";
            if (node2.Checked)
                formthaotac += "frmNhanVien";
            if (node3.Checked)
                formthaotac += "frmPhongBan";
            if (node4.Checked)
                formthaotac += "frmNghiViec";
            if (node5.Checked)
                formthaotac += "frmDaiHan";
            if (node8.Checked)
                formthaotac += "frmSQD";
            if (node9.Checked)
                formthaotac += "frmChucVu";
            if (node10.Checked)
                formthaotac += "frmDaoTao";
            if (node11.Checked)
                formthaotac += "frmCongViec";
            if (node13.Checked)
                formthaotac += "frmChamCong";
            if (node14.Checked)
                formthaotac += "frmChiLuongg";
            if (node16.Checked)
                formthaotac += "frmPhongVan";
            if (node17.Checked)
                formthaotac += "frmTuyenDung";
            if (node18.Checked)
                formthaotac += "frmUngVien";
            if (node19.Checked)
                formthaotac += "frmChuyen";

            if (formthaotac != null)
            {
                nguoidung.ThemMoiNguoiDung(txtUser.Text, txtPass.Text, formthaotac);
                MessageBoxEx.Show("Bạn đã thêm thành công", "Chúc mừng");
            }
            else
                MessageBoxEx.Show("Bạn phải phân quyền quản lý cho người dùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
           
        }

        private void bntExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void NodeThongTin()
        {
            if (node1.Checked)
            {
                node1.Nodes[0].Checked = true;
                node1.Nodes[1].Checked = true;
                node1.Nodes[2].Checked = true;
                node1.Nodes[3].Checked = true;
            }
            else
            {
                node1.Nodes[0].Checked = false;
                node1.Nodes[1].Checked = false;
                node1.Nodes[2].Checked = false;
                node1.Nodes[3].Checked = false;
            }
        }

        private void node1_NodeClick(object sender, EventArgs e)
        {
            NodeThongTin();
        }

        private void node1_NodeDoubleClick(object sender, EventArgs e)
        {
            NodeThongTin();
        }

        public void NodeQuanLy()
        {
            if (node7.Checked)
            {
                node7.Nodes[0].Checked = true;
                node7.Nodes[1].Checked = true;
                node7.Nodes[2].Checked = true;
                node7.Nodes[3].Checked = true;
            }
            else
            {
                node7.Nodes[0].Checked = false;
                node7.Nodes[1].Checked = false;
                node7.Nodes[2].Checked = false;
                node7.Nodes[3].Checked = false;
            }
        }

        private void node7_NodeClick(object sender, EventArgs e)
        {
            NodeQuanLy();
        }

        private void node7_NodeDoubleClick(object sender, EventArgs e)
        {
            NodeQuanLy();
        }

        public void NodeLuongBong()
        {
            if (node12.Checked)
            {
                node12.Nodes[0].Checked = true;
                node12.Nodes[1].Checked = true;
            }
            else
            {
                node12.Nodes[0].Checked = false;
                node12.Nodes[1].Checked = false;
            }
        }

        private void node12_NodeClick(object sender, EventArgs e)
        {
            NodeLuongBong();
        }

        private void node12_NodeDoubleClick(object sender, EventArgs e)
        {
            NodeLuongBong();
        }

        public void NodeTuyenDung()
        {
            if (node15.Checked)
            {
                node15.Nodes[0].Checked = true;
                node15.Nodes[1].Checked = true;
                node15.Nodes[2].Checked = true;
                node15.Nodes[3].Checked = true;
            }
            else
            {
                node15.Nodes[0].Checked = false;
                node15.Nodes[1].Checked = false;
                node15.Nodes[2].Checked = false;
                node15.Nodes[3].Checked = false;
            }
        }

        private void node15_NodeClick(object sender, EventArgs e)
        {
            NodeTuyenDung();
        }

        private void node15_NodeDoubleClick(object sender, EventArgs e)
        {
            NodeTuyenDung();
        }

    }
}