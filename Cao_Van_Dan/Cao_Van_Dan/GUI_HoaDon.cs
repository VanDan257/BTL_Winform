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
    public partial class GUI_HoaDon : Form
    {
        private BUS_HoaDon bus_hd = new BUS_HoaDon();
        private BUS_ChiTietHDB bus_cthdb = new BUS_ChiTietHDB();
        private BUS_NhanVien bus_nv = new BUS_NhanVien();
        private BUS_KhachHang bus_kh = new BUS_KhachHang();
        private BUS_CanHo bus_ch = new BUS_CanHo();

        private void loaddgvHoaDonBan()
        {
            dgvHoaDonBan.DataSource = bus_hd.getData();
            dgvHoaDonBan.Columns[0].HeaderText = "Mã hoá đơn";
            dgvHoaDonBan.Columns[1].HeaderText = "Mã nhân viên";
            dgvHoaDonBan.Columns[2].HeaderText = "Mã khách hàng";
            dgvHoaDonBan.Columns[3].HeaderText = "Ngày bán";
            dgvHoaDonBan.Columns[4].HeaderText = "Tổng tiền";
        }

        private void loaddgvChiTietHDB(string ma)
        {
            dgvcthdb.DataSource = bus_cthdb.getData(ma);
            dgvcthdb.Columns[0].HeaderText = "Mã hoá đơn";
            dgvcthdb.Columns[1].HeaderText = "Số nhà";
            dgvcthdb.Columns[2].HeaderText = "Đơn giá";
            dgvcthdb.Columns[3].HeaderText = "Giảm giá";
            dgvcthdb.Columns[4].HeaderText = "Thành tiền";
        }

        private void loadcbbNV()
        {
            cbbNV.DataSource = bus_nv.getData();
            cbbNV.DisplayMember = "TenNV";
            cbbNV.ValueMember = "MaNV";
        }

        private void loadcbbKH()
        {
            cbbKH.DataSource = bus_kh.getData();
            cbbKH.DisplayMember = "TenKH";
            cbbKH.ValueMember = "MaKH";
        }

        private void loaddgvCanHo(string ma, string dt = "", string gb = "")
        {
            dgvcthdb.DataSource = bus_ch.TimKiem(ma, dt, gb);
            dgvcthdb.Columns[0].HeaderText = "Số nhà";
            dgvcthdb.Columns[1].HeaderText = "Diện tích";
            dgvcthdb.Columns[2].HeaderText = "Giá bán";
            dgvcthdb.Columns[3].HeaderText = "Tình trạng";
            dgvcthdb.Columns[4].HeaderText = "Mã dãy";
        }

        public GUI_HoaDon()
        {
            InitializeComponent();
        }

        private void GUI_HoaDon_Load(object sender, EventArgs e)
        {
            loaddgvHoaDonBan();
            loadcbbNV();
            loadcbbKH();
            if (Program.code == 0)
            {
                mnBCTK.Enabled = true;
            }
            else
            {
                mnBCTK.Enabled = false;
            }
        }

        private void pbThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi ứng dụng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            GUI_DangNhap frmDangNhap = new GUI_DangNhap();
            this.Hide();
            frmDangNhap.ShowDialog();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            GUI_NhanVien frmNhanVien = new GUI_NhanVien();
            this.Hide();
            frmNhanVien.ShowDialog();
        }

        private void mnBCTK_Click(object sender, EventArgs e)
        {
            GUI_ThongKe_BaoCao frm_TK_BC = new GUI_ThongKe_BaoCao();
            this.Hide();
            frm_TK_BC.ShowDialog();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            GUI_KhachHang frmKhachHang = new GUI_KhachHang();
            this.Hide();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            GUI_CanHo frmCanHo = new GUI_CanHo();
            this.Hide();
            frmCanHo.ShowDialog();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi ứng dụng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            GUI_HoaDon frmHoaDon = new GUI_HoaDon();
            this.Hide();
            frmHoaDon.ShowDialog();
        }

        private void mnTimKiem_Click(object sender, EventArgs e)
        {
            GUI_TimKiem frmTimKiem = new GUI_TimKiem();
            this.Hide();
            frmTimKiem.ShowDialog();
        }

        private void dgvHoaDonBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtMaHDB.Text = dgvHoaDonBan[0, i].Value.ToString();
            loaddgvChiTietHDB(dgvHoaDonBan[0, i].Value.ToString());
            cbbNV.Text = bus_nv.valuecbbNV(dgvHoaDonBan[1, i].Value.ToString());
            cbbKH.Text = bus_kh.valuecbbKH(dgvHoaDonBan[2, i].Value.ToString());
            dtNgayBan.Text = dgvHoaDonBan[3, i].Value.ToString();
            lblTongTien.Text = dgvHoaDonBan[4, i].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtthanhtien.Text != "")
            {
                string TT = (float.Parse(txtthanhtien.Text) + float.Parse(lblTongTien.Text)).ToString();
                lblTongTien.Text = TT;
            }
            HoaDon hd = new HoaDon();
            hd.MaHDB = txtMaHDB.Text;
            hd.NhanVien = cbbNV.SelectedValue.ToString();
            hd.KhachHang = cbbKH.SelectedValue.ToString();
            string datebirthday = string.Format("{2}-{1}-{0}", dtNgayBan.Value.Day, dtNgayBan.Value.Month, dtNgayBan.Value.Year);
            hd.NgayBan = datebirthday;
            hd.TongTien = float.Parse(lblTongTien.Text);
            if (bus_hd.kiemtramatrung(txtMaHDB.Text) > 0)
            {
                MessageBox.Show("Mã hoá đơn đã tồn tại! Vui lòng nhập mã khác!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (bus_hd.ThemHD(hd))
                {
                    MessageBox.Show("Thêm thành công!!!");
                    loaddgvHoaDonBan();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            HoaDon hd = new HoaDon();
            hd.MaHDB = txtMaHDB.Text;
            hd.NhanVien = cbbNV.SelectedValue.ToString();
            hd.KhachHang = cbbKH.SelectedValue.ToString();
            hd.NgayBan = dtNgayBan.Text;

            if (bus_hd.SuaHD(hd))
            {
                MessageBox.Show("Thêm thành công!!!");
                loaddgvHoaDonBan();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaHDB.Text;
            DialogResult kq = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                if (bus_hd.XoaHD(ma))
                {
                    MessageBox.Show("Xóa thành công ");
                    loaddgvHoaDonBan();
                }
            }
        }

        private void btnThemCT_Click(object sender, EventArgs e)
        {
            ChiTietHoaDonBan hd = new ChiTietHoaDonBan();
            HoaDon hdb = new HoaDon();
            hd.MaHDB = txtMaHDB.Text;
            hd.SoNha = txtSoNha.Text;
            hd.DonGia = float.Parse(txtdongia.Text);
            hd.GiamGia = float.Parse(txtgiamgia.Text);
            hd.ThanhTien = float.Parse(txtthanhtien.Text);
            if (bus_cthdb.kiemtramatrung(txtSoNha.Text) > 0)
            {
                MessageBox.Show("Căn hộ có mã " + txtSoNha.Text + " đã được bán! Vui lòng nhập số nhà khác!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (bus_cthdb.ThemCTHDB(hd))
                {
                    MessageBox.Show("Thêm thành công!!!");
                    loaddgvChiTietHDB(txtMaHDB.Text);
                }
            }
        }

        private void btnSuaCT_Click(object sender, EventArgs e)
        {
            ChiTietHoaDonBan hd = new ChiTietHoaDonBan();
            hd.MaHDB = txtMaHDB.Text;
            hd.SoNha = txtSoNha.Text;
            hd.DonGia = float.Parse(txtdongia.Text);
            hd.GiamGia = float.Parse(txtgiamgia.Text);
            hd.ThanhTien = float.Parse(txtthanhtien.Text);
            if (bus_cthdb.SuaCTHDB(hd))
            {
                MessageBox.Show("Sửa thành công!!!");
                loaddgvChiTietHDB(txtMaHDB.Text);
            }
        }

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            string ma = txtSoNha.Text;
            DialogResult kq = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                if (bus_cthdb.XoaCTHDB(ma))
                {
                    MessageBox.Show("Xóa thành công ");
                    loaddgvHoaDonBan();
                }
            }
        }

        private void dgvcthdb_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtSoNha.Text = dgvHoaDonBan[0, i].Value.ToString();
            txtdongia.Text = dgvHoaDonBan[1, i].Value.ToString();
            txtgiamgia.Text = dgvHoaDonBan[2, i].Value.ToString();
            txtthanhtien.Text = dgvHoaDonBan[3, i].Value.ToString();
        }

        private void txtSoNha_TextChanged(object sender, EventArgs e)
        {
            string ma = txtSoNha.Text;
            if (ma != "")
                loaddgvCanHo(ma);
        }

        private void txtgiamgia_TextChanged(object sender, EventArgs e)
        {
            string giamgia = txtgiamgia.Text;
            float dongia = float.Parse(txtdongia.Text);
            if (giamgia != "")
            {
                txtthanhtien.Text = (dongia - (float.Parse(giamgia) * dongia)).ToString();
            }
        }
    }
}