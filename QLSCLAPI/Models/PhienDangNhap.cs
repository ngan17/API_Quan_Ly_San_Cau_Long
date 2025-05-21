using System;
using System.Collections.Generic;

namespace QLSCLAPI.Models;

public partial class PhienDangNhap
{
    public int MaPhien { get; set; }

    public int MaNguoiDung { get; set; }

    public string Token { get; set; } = null!;

    public DateTime? ThoiGianTao { get; set; }

    public DateTime HetHan { get; set; }

    public string? DiaChiIp { get; set; }

    public string? ThietBi { get; set; }

    public virtual NguoiDung MaNguoiDungNavigation { get; set; } = null!;
}
