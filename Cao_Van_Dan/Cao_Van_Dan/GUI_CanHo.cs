using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using Entities;

namespace Cao_Van_Dan
{
    public partial class GUI_CanHo : Form
    {
        BUS_CanHo bus_ch = new BUS_CanHo();
        BUS_DayCanHo bus_dch = new BUS_DayCanHo();
        void loaddgv()
        {
            dgvSanPham.DataSource = bus_ch.getData();
            dgvSanPham.Columns[0].HeaderText = "Số nhà";
            dgvSanPham.Columns[1].HeaderText = "Diện tích";
            dgvSanPham.Columns[2].HeaderText = "Giá bán";
            dgvSanPham.Columns[3].HeaderText = "Tình trạng";
            dgvSanPham.Columns[4].HeaderText = "Mã dãy";
        }
        void loadcbb()
        {
            cbbDayCH.DataSource = bus_dch.getData();
            cbbDayCH.DisplayMember = "TenDay";
            cbbDayCH.ValueMember = "MaDay";
        }
        
        public GUI_CanHo()
        {
            InitializeComponent();
        }

        private void FormSP_Load(object sender, EventArgs e)
        {
            loaddgv();
            loadcbb();
            if (Program.code == 0)
            {
                mnBCTK.Enabled = true;
            }
            else
            {
                mnBCTK.Enabled = false;
            }
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtSoNha.Text = dgvSanPham[0, i].Value.ToString();
            cbbDayCH.Text = bus_dch.valuecbbDCH(dgvSanPham[4, i].Value.ToString());
            txtTT.Text = dgvSanPham[3, i].Value.ToString();
            txtDG.Text = dgvSanPham[2, i].Value.ToString();
            txtDienTich.Text = dgvSanPham[1, i].Value.ToString();
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in groupBox1.Controls)
            {
                if (ctr is TextBox || ctr is ComboBox || ctr is DateTimePicker)
                {
                    ctr.Text = "";
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            CanHo ch = new CanHo();
            ch.SoNha = txtSoNha.Text;
            ch.MaDay = cbbDayCH.SelectedValue.ToString();
            ch.DienTich = float.Parse(txtDienTich.Text);
            ch.TinhTrang = txtTT.Text;
            ch.GiaBan = float.Parse(txtDG.Text);
            if (bus_ch.kiemtramatrung(txtSoNha.Text) == 1)
            {
                MessageBox.Show("Mã đã tồn tại, vui lòng nhập lại mã!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (bus_ch.ThemCH(ch) == true)
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    loaddgv();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            CanHo ch = new CanHo();
            ch.SoNha = txtSoNha.Text;
            ch.MaDay = cbbDayCH.SelectedValue.ToString();
            ch.DienTich = float.Parse(txtDienTich.Text);
            ch.TinhTrang = txtTT.Text;
            ch.GiaBan = float.Parse(txtDG.Text);
            if (bus_ch.SuaCH(ch) == true)
            {
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                loaddgv();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtSoNha.Text;
            if (bus_ch.XoaCH(ma) == true)
            {
                MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                loaddgv();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi ứng dụng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }
        void loaddgvTimKiemSP(string masp, string dientich, string giaban)
        {
            dgvSanPham.DataSource = bus_ch.TimKiem(masp, dientich, giaban);
            if (dgvSanPham.DataSource == null)
            {
                MessageBox.Show("Bạn chưa nhập thông tin tìm kiếm sản phẩm!!!");
            }
            else
            {
                dgvSanPham.Columns[0].HeaderText = "Số nhà";
                dgvSanPham.Columns[1].HeaderText = "Diện tích";
                dgvSanPham.Columns[2].HeaderText = "Giá bán";
                dgvSanPham.Columns[3].HeaderText = "Tình trạng";
                dgvSanPham.Columns[4].HeaderText = "Mã dãy";
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sonha = txtTimKiemsonha.Text;
            string dientich = txtTimKiemdtch.Text;
            string giaban = txtTimKiemgbch.Text;
            loaddgvTimKiemSP(sonha, dientich, giaban);
        }

        private void pbThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi ứng dụng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void mnTimKiem_Click(object sender, EventArgs e)
        {
            GUI_TimKiem frmTimKiem = new GUI_TimKiem();
            this.Hide();
            frmTimKiem.ShowDialog();
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

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            GUI_CanHo frmCanHo = new GUI_CanHo();
            this.Hide();
            frmCanHo.ShowDialog();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            GUI_HoaDon frmHoaDon = new GUI_HoaDon();
            this.Hide();
            frmHoaDon.ShowDialog();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            GUI_NhanVien frmNhanVien = new GUI_NhanVien();
            this.Hide();
            frmNhanVien.ShowDialog();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            GUI_KhachHang frmKhachHang = new GUI_KhachHang();
            this.Hide();
            frmKhachHang.ShowDialog();
        }

        private void mnBCTK_Click(object sender, EventArgs e)
        {
            GUI_ThongKe_BaoCao frm_TK_BC = new GUI_ThongKe_BaoCao();
            this.Hide();
            frm_TK_BC.ShowDialog();
        }
    }
}
