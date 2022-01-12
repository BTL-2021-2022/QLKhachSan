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
    public partial class fHoaDon : Form
    {
        string user;
        QLKhachSanContext db = new QLKhachSanContext();
        double tienPhong = 0;
        double tienDichVu = 0;
        public fHoaDon()
        {
            InitializeComponent();
        }
        public fHoaDon(string user)
        {
            InitializeComponent();
            this.user = user;
        }


        private void fHoaDon_Load(object sender, EventArgs e)
        {
            var nhanvien = from nv in db.NhanViens
                           select nv;
            //cboNhanVien.DataSource = nhanvien.ToList();
            //cboNhanVien.DisplayMember = "TenNhanVien";
            //cboNhanVien.ValueMember = "MaNhanVien";
            txtMaNhanVien.Text = user.ToString();
            dateTimePicker.Enabled = false;
            dateTimePicker.Value = DateTime.Now;
            txtTongTien.ReadOnly = true;
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            try
            {
                var khachhang = (from kh in db.KhachHangs
                                 where kh.SoCmnd.Equals(txtCMND.Text)
                                 select kh).FirstOrDefault();
                var phieuthue = (from pt in db.PhieuThuePhongs
                                 where pt.MaKh.Equals(khachhang.MaKh)
                                 select pt).FirstOrDefault();
                txtMpt.Text = phieuthue.MaPhieuThuePhong.ToString();
                txtTenKhachHang.Text = khachhang.TenKhach.ToString();
                DateTime ngaydi = Convert.ToDateTime(phieuthue.NgayDi);
                DateTime ngayden = Convert.ToDateTime(phieuthue.NgayDen);
                TimeSpan time = ngaydi - ngayden;
                txtSoNgay.Text = time.Days.ToString();
                var phong = from p in db.ChiTietThuePhongs
                            where p.MaPhieuThuePhong.Equals(phieuthue.MaPhieuThuePhong)
                            select p;

                foreach (var item in phong.ToList())
                {
                    var ph = (from p in db.Phongs
                              join lp in db.LoaiPhongs on p.MaLoaiPhong equals lp.MaLoaiPhong
                              where p.MaPhong.Equals(item.MaPhong)
                              select new
                              {
                                  dg = lp.DonGia
                              }).FirstOrDefault();
                    tienPhong += double.Parse(time.Days.ToString()) * ph.dg.Value;
                }
                txtTienPhong.Text = tienPhong.ToString();
                var phieudichvu = from dv in db.PhieuDichVus
                                  where dv.MaPhieuThuePhong.Equals(phieuthue.MaPhieuThuePhong)
                                  select dv;
                foreach (var item in phieudichvu)
                {
                    tienDichVu += item.TongTien.Value;
                }
                txtNgayDen.Text = phieuthue.NgayDen.ToString();
                txtNgayDi.Text = phieuthue.NgayDi.ToString();
                txtTienDichVu.Text = tienDichVu.ToString();
                txtTongTien.Text = (tienDichVu + tienPhong).ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("Lỗi nhập liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCMND.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                HoaDon hdMoi = new HoaDon();
                hdMoi.MaNhanVien = txtMaNhanVien.Text;
                hdMoi.MaPhieuThuePhong = txtMpt.Text;
                hdMoi.TongTien = double.Parse(txtTongTien.Text);
                hdMoi.NgayThanhToan = dateTimePicker.Value;
                db.HoaDons.Add(hdMoi);
                db.SaveChanges();
                MessageBox.Show("Lưu hóa đơn thành công", "Lưu Hóa Đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                MessageBox.Show("Lỗi nhập liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtCMND.Text = "";
            txtMpt.Text = "";
            txtNgayDen.Text = "";
            txtNgayDi.Text = "";
            txtSoNgay.Text = "";
            txtTenKhachHang.Text = "";
            txtTienDichVu.Text = "";
            txtTienPhong.Text = "";
            txtTongTien.Text = "";
           
           txtCMND.Focus();
        }
    }
}
