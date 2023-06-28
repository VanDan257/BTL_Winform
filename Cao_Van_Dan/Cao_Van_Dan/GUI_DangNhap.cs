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
    public partial class GUI_DangNhap : Form
    {
        BUS_TaiKhoan bus_tk = new BUS_TaiKhoan();
        public GUI_DangNhap()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi ứng dụng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }

        private void txtUser_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text))
            {
                e.Cancel = true;
                txtUser.Focus();
                errUser.SetError(txtUser, "Ban cần nhập username!!!");
            }
            else
            {
                e.Cancel = false;
                errUser.SetError(txtUser, "");
            }
        }

        private void txtPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPass.Text))
            {
                e.Cancel = true;
                txtPass.Focus();
                errPass.SetError(txtPass, "Bạn cần nhập Password!!!");

            }
            else
            {
                e.Cancel = false;
                errPass.SetError(txtPass, "");
            }
        }

        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShow.Checked)
                txtPass.PasswordChar = (char)0;
            else
                txtPass.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string tk = txtUser.Text;
            string mk = txtPass.Text;
            int role = bus_tk.DangNhap(tk, mk);
            if (role == 0)
            {
                MessageBox.Show("Chào mừng User đăng nhập!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Program.code = 0;
                GUI_CanHo frm_canho = new GUI_CanHo();
                this.Hide();
                frm_canho.ShowDialog();
            }
            else if(role == 1)
            {
                MessageBox.Show("Chào mừng quý khách đăng nhập!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Program.code = 1;
                GUI_CanHo frm_canho = new GUI_CanHo();
                this.Hide();
                frm_canho.ShowDialog();
            }
            else if (role == 2)
            {
                MessageBox.Show("Bạn nhập sai thông tin đăng nhập!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Program.code = 2;
                GUI_CanHo frm_canho = new GUI_CanHo();
                this.Hide();
                frm_canho.ShowDialog();
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GUI_DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void linkDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GUI_DangKy frmdangKy = new GUI_DangKy();
            this.Hide();
            frmdangKy.ShowDialog();
        }
    }
}
