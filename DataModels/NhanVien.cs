using System;
using System.Collections.Generic;

#nullable disable

namespace BaiTapLon.DataModels
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        public string MaNhanVien { get; set; }
        public string ChucVu { get; set; }
        public string TenNhanVien { get; set; }
        public string DiaChi { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
