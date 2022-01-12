using BaiTapLon.DataModels;
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
    public partial class DangNhap : Form
    {
        QLKhachSanContext db = new QLKhachSanContext();
        public DangNhap()
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(200, Color.White);
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            var manv = (from nv in db.NhanViens
                        select nv).ToList();
            comboBox1.Text = manv.FirstOrDefault().MaNhanVien;
            foreach (var n in manv)
            {
                
                comboBox1.Items.Add(n.MaNhanVien);
                
            }
           
        }
        public bool DuLieuHopLe()
        {
            if(comboBox1.Text != "")
            {
                if(textBox1.Text!= "")
                {
                    if (textBox2.Text != "")
                    {
                        return true;

                    }
                    else
                    {
                        MessageBox.Show("Bạn cần nhập mật khẩu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Bạn cần nhập tên đăng nhập !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                }
                
            }
            else
            {
                MessageBox.Show("Bạn cần chọn mã nhân viên !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox1.Focus();
            }
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(DuLieuHopLe())
            {
              
              var manv = (from nv in db.NhanViens
                          where nv.MaNhanVien== comboBox1.Text&& nv.TaiKhoan == textBox1.Text && nv.MatKhau == textBox2.Text
                               select nv).ToList();
                if (manv.Count >0)
                {
                    Form1 frm = new Form1(comboBox1.Text);
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Vui lòng kiểm tra lại tài khoản và mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
