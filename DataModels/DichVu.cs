using System;
using System.Collections.Generic;

#nullable disable

namespace BaiTapLon.DataModels
{
    public partial class DichVu
    {
        public DichVu()
        {
            PhieuDichVus = new HashSet<PhieuDichVu>();
        }

        public string MaDv { get; set; }
        public string MaLoaiDv { get; set; }
        public string TenDv { get; set; }
        public double? DonGiaDv { get; set; }

        public virtual LoaiDichVu MaLoaiDvNavigation { get; set; }
        public virtual ICollection<PhieuDichVu> PhieuDichVus { get; set; }
    }
}
