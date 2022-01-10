using System;
using System.Collections.Generic;

#nullable disable

namespace BaiTapLon.DataModels
{
    public partial class HoaDon
    {
        public string MaHoaDon { get; set; }
        public string MaNhanVien { get; set; }
        public string MaPhieuThuePhong { get; set; }
        public double? TongTien { get; set; }
        public DateTime? NgayThanhToan { get; set; }
        

        public virtual NhanVien MaNhanVienNavigation { get; set; }
        public virtual PhieuThuePhong MaPhieuThuePhongNavigation { get; set; }
    }
    
}
