using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaiTapLon.DataModels;
namespace BaiTapLon
{
    public partial class QuanLyTraPhong : Form
    {
        public QuanLyTraPhong()
        {
            InitializeComponent();
        }
        QLKhachSanContext db = new QLKhachSanContext();
        private void phieuthuephong()
        {
            var query1 = from phong in db.PhieuThuePhongs
                         join chitiet in db.ChiTietThuePhongs on phong.MaPhieuThuePhong equals chitiet.MaPhieuThuePhong
                         join pho in db.Phongs on chitiet.MaPhong equals pho.MaPhong
                         select new { phong.MaPhieuThuePhong, phong.MaKh, phong.NgayDen, phong.NgayDi, pho.MaPhong };
            ViewPhieuThuePhong.DataSource = query1.ToList();
        }
        private void dichvu()
        {
            var query1 = from PhieuDichVu in db.PhieuDichVus
                         join dichvu in db.DichVus on PhieuDichVu.MaDv equals dichvu.MaDv
                         select new { PhieuDichVu.MaDv, PhieuDichVu.MaPhieuThuePhong, PhieuDichVu.SoLuong, PhieuDichVu.TongTien, dichvu.TenDv, dichvu.DonGiaDv };
            viewPhieuDichVu.DataSource = query1.ToList();
        }
        private void phong()
        {
            var query1 = from phong in db.Phongs
                         join loaiphong in db.LoaiPhongs on phong.MaLoaiPhong equals loaiphong.MaLoaiPhong

                         select new { phong.MaPhong, phong.MaLoaiPhong, loaiphong.TenLoai, loaiphong.DonGia };
            ViewPhong.DataSource = query1.ToList();
        }
        private void QuanLyTraPhong_Load(object sender, EventArgs e)
        {

        }
    }
}
