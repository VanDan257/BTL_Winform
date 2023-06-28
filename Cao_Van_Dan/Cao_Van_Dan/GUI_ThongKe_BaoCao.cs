using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using BUS;

namespace Cao_Van_Dan
{
    public partial class GUI_ThongKe_BaoCao : Form
    {
        BUS_ChiTietHDB bus_cthdb = new BUS_ChiTietHDB();
        public GUI_ThongKe_BaoCao()
        {
            InitializeComponent();
        }
        void loaddgvHDBTheoThang(string thang, string nam)
        {
            dgvHoaDonBan.DataSource = bus_cthdb.ThongKeHoaDonTheoThang(thang, nam);
            dgvHoaDonBan.Columns[0].HeaderText = "Mã HDB";
            dgvHoaDonBan.Columns[1].HeaderText = "Mã NV";
            dgvHoaDonBan.Columns[2].HeaderText = "Mã KH";
            dgvHoaDonBan.Columns[3].HeaderText = "Ngày bán";
            dgvHoaDonBan.Columns[4].HeaderText = "Số nhà";
            dgvHoaDonBan.Columns[5].HeaderText = "Đơn giá";
            dgvHoaDonBan.Columns[6].HeaderText = "Giảm giá";
            dgvHoaDonBan.Columns[7].HeaderText = "Thành tiền";
        }
        void loaddgvHDBTheoNam(string nam)
        {
            dgvHoaDonBan.DataSource = bus_cthdb.ThongKeHoaDonTheoNam(nam);
            dgvHoaDonBan.Columns[0].HeaderText = "Mã HDB";
            dgvHoaDonBan.Columns[1].HeaderText = "Mã NV";
            dgvHoaDonBan.Columns[2].HeaderText = "Mã KH";
            dgvHoaDonBan.Columns[3].HeaderText = "Ngày bán";
            dgvHoaDonBan.Columns[4].HeaderText = "Số nhà";
            dgvHoaDonBan.Columns[5].HeaderText = "Đơn giá";
            dgvHoaDonBan.Columns[6].HeaderText = "Giảm giá";
            dgvHoaDonBan.Columns[7].HeaderText = "Thành tiền";
        }

        private void GUI_ThongKe_BaoCao_Load(object sender, EventArgs e)
        {
            if (Program.code == 0)
            {
                mnBCTK.Enabled = true;
            }
            else
            {
                mnBCTK.Enabled = false;
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            string thang = txtThang.Text;
            string nam = txtNam1.Text;
            double doanhthu = bus_cthdb.ThongKeDoanhThuTheoThang(thang, nam);
            lblDoanhThuThang.Text = doanhthu.ToString();
            loaddgvHDBTheoThang(thang, nam);
        }
        private void btnThongKeTheoNam_Click(object sender, EventArgs e)
        {
            string nam = txtNam3.Text;
            double doanhthu = bus_cthdb.ThongKeDoanhThuTheoNam(nam);
            lblDoanhThuNam.Text = doanhthu.ToString();
            loaddgvHDBTheoNam(nam);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            GUI_DangNhap frmDangNhap = new GUI_DangNhap();
            this.Hide();
            frmDangNhap.ShowDialog();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi ứng dụng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }

        private void mnTimKiem_Click(object sender, EventArgs e)
        {
            GUI_TimKiem frmTimKiem = new GUI_TimKiem();
            this.Hide();
            frmTimKiem.ShowDialog();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            GUI_KhachHang frm_KhachHang = new GUI_KhachHang();
            this.Hide();
            frm_KhachHang.ShowDialog();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            GUI_HoaDon frmHoaDon = new GUI_HoaDon();
            this.Hide();
            frmHoaDon.ShowDialog();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            GUI_CanHo frmCanHo = new GUI_CanHo();
            this.Hide();
            frmCanHo.ShowDialog();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            GUI_HoaDon frmHoaDon = new GUI_HoaDon();
            this.Hide();
            frmHoaDon.ShowDialog();
        }
    }
}
