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
    public partial class QuanLyDatPhong : Form
    {
        public QuanLyDatPhong()
        {
            InitializeComponent();
        }
        QLKhachSanContext db = new QLKhachSanContext();
        private void QuanLyDatPhong_Load(object sender, EventArgs e)
        {
            ThongTinPhong();
            PhieuNhanPhong();
        }
        private void PhieuNhanPhong()
        {
            var query1 = from phong in db.PhieuDatPhongs
                         join lp in db.KhachHangs on phong.MaKh equals lp.MaKh

                         select new { phong.MaPhieuDatPhong, phong.NgayNhan, phong.MaKh, lp.TenKhach };
            ViewPhieuNhanPhong.DataSource = query1.ToList();
        }
        private void ThongTinPhong()
        {
            var query = from phong in db.Phongs
                        join lp1 in db.LoaiPhongs on phong.MaLoaiPhong equals lp1.MaLoaiPhong
                        select new
                        {
                            phong.MaPhong,
                            phong.MaLoaiPhong,
                            phong.TrangThai,
                            lp1.TenLoai,
                            lp1.DonGia,
                            lp1.SoNguoiToiDa
                        };
            ViewThongTinPhong.DataSource = query.ToList();
        }
    }
}
