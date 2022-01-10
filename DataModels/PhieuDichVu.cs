using System;
using System.Collections.Generic;

#nullable disable

namespace BaiTapLon.DataModels
{
    public partial class PhieuDichVu
    {
        public string MaPhieuDichVu { get; set; }
        public string MaDv { get; set; }
        public string MaPhieuThuePhong { get; set; }
        public int? SoLuong { get; set; }
        public double? TongTien { get; set; }

        public virtual DichVu MaDvNavigation { get; set; }
        public virtual PhieuThuePhong MaPhieuThuePhongNavigation { get; set; }
    }
}
