using System;
using System.Collections.Generic;

#nullable disable

namespace BaiTapLon.DataModels
{
    public partial class LoaiDichVu
    {
        public LoaiDichVu()
        {
            DichVus = new HashSet<DichVu>();
        }

        public string MaLoaiDv { get; set; }
        public string TenLoaiDv { get; set; }

        public virtual ICollection<DichVu> DichVus { get; set; }
    }
}
