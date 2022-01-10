using System;
using System.Collections.Generic;

#nullable disable

namespace BaiTapLon.DataModels
{
    public partial class ChiTietThuePhong
    {
        public string MaPhong { get; set; }
        public string MaPhieuThuePhong { get; set; }

        public virtual PhieuThuePhong MaPhieuThuePhongNavigation { get; set; }
        public virtual Phong MaPhongNavigation { get; set; }
    }
}
