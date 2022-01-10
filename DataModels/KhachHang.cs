using System;
using System.Collections.Generic;

#nullable disable

namespace BaiTapLon.DataModels
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            PhieuDatPhongs = new HashSet<PhieuDatPhong>();
            PhieuThuePhongs = new HashSet<PhieuThuePhong>();
        }

        public string MaKh { get; set; }
        public string SoCmnd { get; set; }
        public string TenKhach { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }

        public virtual ICollection<PhieuDatPhong> PhieuDatPhongs { get; set; }
        public virtual ICollection<PhieuThuePhong> PhieuThuePhongs { get; set; }
    }
}
