using System;
using System.Collections.Generic;

#nullable disable

namespace BaiTapLon.DataModels
{
    public partial class ChiTietDatPhong
    {
        public string MaPhieuDatPhong { get; set; }
        public string MaPhong { get; set; }

        public virtual PhieuDatPhong MaPhieuDatPhongNavigation { get; set; }
        public virtual Phong MaPhongNavigation { get; set; }
    }
}
