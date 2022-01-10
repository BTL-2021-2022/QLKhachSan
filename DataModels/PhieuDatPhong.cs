using System;
using System.Collections.Generic;

#nullable disable

namespace BaiTapLon.DataModels
{
    public partial class PhieuDatPhong
    {
        public PhieuDatPhong()
        {
            ChiTietDatPhongs = new HashSet<ChiTietDatPhong>();
        }

        public string MaPhieuDatPhong { get; set; }
        public string MaKh { get; set; }
        public DateTime? NgayNhan { get; set; }

        public virtual KhachHang MaKhNavigation { get; set; }
        public virtual ICollection<ChiTietDatPhong> ChiTietDatPhongs { get; set; }
    }
}
