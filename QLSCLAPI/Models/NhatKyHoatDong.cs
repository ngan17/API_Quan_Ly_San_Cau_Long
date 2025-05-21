using System;
using System.Collections.Generic;

namespace QLSCLAPI.Models;

public partial class NhatKyHoatDong
{
    public int MaNhatKy { get; set; }

    public int? MaNguoiDung { get; set; }

    public string? HanhDong { get; set; }

    public string? BangTacDong { get; set; }

    public int? MaBanGhi { get; set; }

    public DateTime? ThoiGian { get; set; }

    public string? MoTa { get; set; }

    public virtual NguoiDung? MaNguoiDungNavigation { get; set; }
}
