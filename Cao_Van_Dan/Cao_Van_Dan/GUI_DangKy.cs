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
    public partial class GUI_DangKy : Form
    {
        
        public GUI_DangKy()
        {
            InitializeComponent();
        }
        BUS_TaiKhoan bus_tk = new BUS_TaiKhoan();
        //List<TaiKhoan> listcbb = new List<TaiKhoan>()
        //{
        //    new TaiKhoan(){Per = 0},
        //    new TaiKhoan(){Per = 1}
        //};
        private void GUI_DangKy_Load(object sender, EventArgs e)
        {
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi ứng dụng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }

        private void linkDangNhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GUI_DangNhap frm_dangnhap = new GUI_DangNhap();
            this.Hide();
            frm_dangnhap.ShowDialog();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if(txtPass.Text != txtconfirmpass.Text)
            {
                MessageBox.Show("Xác nhận mật khẩu phải giống với mật khẩu!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtconfirmpass.SelectAll();
                txtconfirmpass.Focus();
            }
            else
            {
                TaiKhoan tk = new TaiKhoan();
                tk.UserID = txtUser.Text;
                tk.Pass = txtPass.Text;
                if (cbbPer.SelectedIndex == 0)
                {
                    tk.Per = 0;
                }
                else
                {
                    tk.Per = 1;
                }

                if (chkShow.Checked == false)
                {
                    MessageBox.Show("Vui lòng đồng ý điều khoản của chúng tôi !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bus_tk.kiemtramatrung(txtUser.Text) > 0)
                    {
                        MessageBox.Show("UserID đã tồn tại, Vui lòng nhập mã khác !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (bus_tk.ThemUser(tk))
                        {
                            MessageBox.Show("Thêm user mới thành công");
                        }
                    }
                }
            }
        }

        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
