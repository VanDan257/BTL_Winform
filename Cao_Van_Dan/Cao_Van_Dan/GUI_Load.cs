using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cao_Van_Dan
{
    public partial class GUI_Load : Form
    {
        public GUI_Load()
        {
            InitializeComponent();
        }
        private void GUI_TrangChu_Load(object sender, EventArgs e)
        {

        }

        private void GUI_Load_KeyPress(object sender, KeyPressEventArgs e)
        {
            GUI_DangNhap frmDangNhap = new GUI_DangNhap();
            this.Hide();
            frmDangNhap.ShowDialog();
        }
    }
}
