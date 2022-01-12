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
                         join kh in db.KhachHangs on phong.MaKh equals kh.MaKh
                         select new { phong.MaPhieuThuePhong, phong.MaKh, phong.NgayDen, phong.NgayDi, pho.MaPhong,kh.SoCmnd };
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
            phong();
            phieuthuephong();
            dichvu();
        }

        private void btnTimPhieuThue_Click(object sender, EventArgs e)
        {
            Phong ptpTim = (from pdp in db.Phongs
                            join chitiet in db.ChiTietThuePhongs on pdp.MaPhong equals chitiet.MaPhong
                            join phieuthue in db.PhieuThuePhongs on chitiet.MaPhieuThuePhong equals phieuthue.MaPhieuThuePhong
                            join kh in db.KhachHangs on phieuthue.MaKh equals kh.MaKh
                            where pdp.MaPhong == txtMaPhieuThue.Text || kh.SoCmnd == txtCccd.Text
                            select pdp).FirstOrDefault();

            var query1 = from phong in db.PhieuThuePhongs
                         join chitiet in db.ChiTietThuePhongs on phong.MaPhieuThuePhong equals chitiet.MaPhieuThuePhong
                         join pho in db.Phongs on chitiet.MaPhong equals pho.MaPhong
                         join kh in db.KhachHangs on phong.MaKh equals kh.MaKh
                         where (pho.MaPhong==txtMaPhieuThue.Text  || kh.SoCmnd==txtCccd.Text )
                         select new { phong.MaPhieuThuePhong, phong.MaKh, phong.NgayDen, phong.NgayDi, pho.MaPhong, kh.SoCmnd };

            if (ptpTim == null)
            {
                MessageBox.Show("Không tồn tại mã phòng !" + txtMaDichVu.Text);
                txtMaPhong.Focus();
                phieuthuephong();
            }
            else
            {
                ViewPhieuThuePhong.DataSource = query1.ToList();

            }
        }

        private void btnTimPhong_Click(object sender, EventArgs e)
        {
            Phong ptpTim = (from pdp in db.Phongs
                            where pdp.MaPhong == txtMaPhong.Text
                            select pdp).FirstOrDefault();
            var query = from phong in db.Phongs
                        join loaiphong in db.LoaiPhongs on phong.MaLoaiPhong equals loaiphong.MaLoaiPhong
                        where phong.MaPhong == txtMaPhong.Text
                        select new { phong.MaPhong, phong.MaLoaiPhong, loaiphong.TenLoai, loaiphong.DonGia };

            if (ptpTim == null)
            {
                MessageBox.Show("Không tồn tại mã phòng !" + txtMaDichVu.Text);
                txtMaPhong.Focus();
                phong();
            }
            else
            {
                ViewPhong.DataSource = query.ToList();

            }
        }

        private void btnTimDichVu_Click(object sender, EventArgs e)
        {
            DichVu ptpTim = (from pdp in db.DichVus
                             where pdp.MaDv == txtMaDichVu.Text
                             select pdp).FirstOrDefault();
            var query = from PhieuDichVu in db.PhieuDichVus
                        join dichvu in db.DichVus on PhieuDichVu.MaDv equals dichvu.MaDv
                        where dichvu.MaDv == txtMaDichVu.Text
                        select new { PhieuDichVu.MaDv, PhieuDichVu.MaPhieuThuePhong, PhieuDichVu.SoLuong, PhieuDichVu.TongTien, dichvu.TenDv, dichvu.DonGiaDv };

            if (ptpTim == null)
            {
                MessageBox.Show("Không tồn tại mã phiếu dịch vụ !" + txtMaDichVu.Text);
                txtMaDichVu.Focus();
                dichvu();
            }
            else
            {
                viewPhieuDichVu.DataSource = query.ToList();

            }
        }
    }
}
