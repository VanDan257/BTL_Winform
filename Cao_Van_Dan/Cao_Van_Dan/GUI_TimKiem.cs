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
    public partial class GUI_TimKiem : Form
    {
        BUS_CanHo bus_sp = new BUS_CanHo();
        BUS_NhanVien bus_nv = new BUS_NhanVien();
        BUS_HoaDon bus_hd = new BUS_HoaDon();
        BUS_ChiTietHDB bus_cthdb = new BUS_ChiTietHDB();
        public GUI_TimKiem()
        {
            InitializeComponent();
        }
        void loaddgvTimKiemSP(string sonha, string dientich, string giaban)
        {
            dgvTimKiem.DataSource = bus_sp.TimKiem(sonha, dientich, giaban);
            if (dgvTimKiem.DataSource == null)
            {
                MessageBox.Show("Bạn chưa nhập thông tin tìm kiếm sản phẩm!!!");
            }
            else
            {
                dgvTimKiem.Columns[0].HeaderText = "Số nhà";
                dgvTimKiem.Columns[1].HeaderText = "Diện tích";
                dgvTimKiem.Columns[2].HeaderText = "Giá bán";
                dgvTimKiem.Columns[3].HeaderText = "Tình trạng";
                dgvTimKiem.Columns[4].HeaderText = "Mã dãy";
            }
        }
        void loaddgvTimKiemNV(string manv, string tennv, string diachi)
        {
            dgvTimKiem.DataSource = bus_nv.TimKiem(manv, tennv, diachi);
            if(dgvTimKiem.DataSource == null)
            {
                MessageBox.Show("Bạn chưa nhập thông tin tìm kiếm nhân viên!!!");
            }
            else
            {
                dgvTimKiem.Columns[0].HeaderText = "Mã NV";
                dgvTimKiem.Columns[1].HeaderText = "Tên NV";
                dgvTimKiem.Columns[2].HeaderText = "Địa chỉ";
                dgvTimKiem.Columns[3].HeaderText = "Số điện thoại";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string manv = txtmanv.Text;
            string tennv = txttennv.Text;
            string diachi = txtdiachi.Text;
            loaddgvTimKiemNV(manv, tennv, diachi);
        }
        void loaddgvTimKiemHDB(string mahdb, string manv, string makh)
        {
            dgvTimKiem.DataSource = bus_hd.TimKiem(mahdb, manv, makh);
            dgvTimKiem.Columns[0].HeaderText = "Mã HDB";
            dgvTimKiem.Columns[1].HeaderText = "Mã NV";
            dgvTimKiem.Columns[2].HeaderText = "Mã KH";
            dgvTimKiem.Columns[3].HeaderText = "Ngày bán";
            dgvTimKiem.Columns[4].HeaderText = "Tổng tiền";
        }
        private void btnTimKiemHDB_Click(object sender, EventArgs e)
        {
            string mahdb = txtmahdb.Text;
            string manv = txttmanv_hdb.Text;
            string makh = txtmakh_hdb.Text;
            loaddgvTimKiemHDB(mahdb, manv, makh);
        }
        void loaddgvTimKiemCTHDB(string mahd, string masp)
        {
            dgvTimKiem.DataSource = bus_cthdb.TimKiem(mahd, masp);
            dgvTimKiem.Columns[0].HeaderText = "Mã HDB";
            dgvTimKiem.Columns[1].HeaderText = "Số nhà";
            dgvTimKiem.Columns[2].HeaderText = "Đơn giá";
            dgvTimKiem.Columns[3].HeaderText = "Giảm giá";
            dgvTimKiem.Columns[4].HeaderText = "Thành tiền";
        }
        private void btnTimKiemCTHDB_Click(object sender, EventArgs e)
        {
            string mahd = txtmacthdb.Text;
            string masp = txtmasp_cthdb.Text;
            loaddgvTimKiemCTHDB(mahd, masp);
        }

        private void GUI_TimKiem_Load(object sender, EventArgs e)
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            string sonha = txtmasp.Text;
            string dientich = txttensp.Text;
            string giaban = txtGiaBan.Text;
            loaddgvTimKiemSP(sonha, dientich, giaban);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            GUI_DangNhap frmDangNhap = new GUI_DangNhap();
            this.Hide();
            frmDangNhap.ShowDialog();
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
            //GUI_ frmNhanVien = new GUI_NhanVien();
            //this.Hide();
            //frmNhanVien.ShowDialog();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi ứng dụng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }

        private void mnBCTK_Click(object sender, EventArgs e)
        {
            GUI_ThongKe_BaoCao frm_TK_BC = new GUI_ThongKe_BaoCao();
            this.Hide();
            frm_TK_BC.ShowDialog();
        }
    }
}
