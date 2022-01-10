using System;
using System.Collections.Generic;

#nullable disable

namespace BaiTapLon.DataModels
{
    public partial class Phong
    {
        public Phong()
        {
            ChiTietDatPhongs = new HashSet<ChiTietDatPhong>();
            ChiTietThuePhongs = new HashSet<ChiTietThuePhong>();
        }

        public string MaPhong { get; set; }
        public string MaLoaiPhong { get; set; }
        public string TrangThai { get; set; }

        public virtual LoaiPhong MaLoaiPhongNavigation { get; set; }
        public virtual ICollection<ChiTietDatPhong> ChiTietDatPhongs { get; set; }
        public virtual ICollection<ChiTietThuePhong> ChiTietThuePhongs { get; set; }
    }
}
