using System;
using System.Collections.Generic;

namespace QLSCLAPI.Models;

public partial class PhanHoi
{
    public int MaPhanHoi { get; set; }

    public int? MaKhachHang { get; set; }

    public int? MaSan { get; set; }

    public string? NoiDung { get; set; }

    public int? DanhGia { get; set; }

    public DateTime? ThoiGianGopY { get; set; }

    public virtual KhachHang? MaKhachHangNavigation { get; set; }

    public virtual San? MaSanNavigation { get; set; }
}
