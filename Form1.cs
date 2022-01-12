
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Show_Panel(Form frm)
        {
            panel1.Controls.Clear();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }
        private void phòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyDichVu frm2 = new QuanLyDichVu();
            frm2.Show();           
        }

        private void dịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
        }

        private void thốngKêTheoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoanhThuPhong frm = new DoanhThuPhong();
            frm.Show();
        }

        private void trảPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyTraPhong f = new QuanLyTraPhong();
            f.Show();
        }

        private void doanhThuDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoanhThuDichVu frm = new DoanhThuDichVu();
            frm.Show();
        }
    }
}
