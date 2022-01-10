using System;
using System.Collections.Generic;

#nullable disable

namespace BaiTapLon.DataModels
{
    public partial class PhieuThuePhong
    {
        public PhieuThuePhong()
        {
            ChiTietThuePhongs = new HashSet<ChiTietThuePhong>();
            HoaDons = new HashSet<HoaDon>();
            PhieuDichVus = new HashSet<PhieuDichVu>();
        }

        public string MaPhieuThuePhong { get; set; }
        public string MaKh { get; set; }
        public DateTime? NgayDen { get; set; }
        public DateTime? NgayDi { get; set; }

        public virtual KhachHang MaKhNavigation { get; set; }
        public virtual ICollection<ChiTietThuePhong> ChiTietThuePhongs { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
        public virtual ICollection<PhieuDichVu> PhieuDichVus { get; set; }
    }
}
