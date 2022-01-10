using System;
using System.Collections.Generic;

#nullable disable

namespace BaiTapLon.DataModels
{
    public partial class LoaiPhong
    {
        public LoaiPhong()
        {
            Phongs = new HashSet<Phong>();
        }

        public string MaLoaiPhong { get; set; }
        public string TenLoai { get; set; }
        public double? DonGia { get; set; }
        public int? SoNguoiToiDa { get; set; }

        public virtual ICollection<Phong> Phongs { get; set; }
    }
}
