using System;
using System.Collections.Generic;

namespace QLSCLAPI.Models;

public partial class HoaDon
{
    public int MaHoaDon { get; set; }

    public int? MaDatSan { get; set; }

    public decimal SoTien { get; set; }

    public DateTime? ThoiGianThanhToan { get; set; }

    public string? PhuongThucThanhToan { get; set; }

    public string? TrangThai { get; set; }

    public virtual DatSan? MaDatSanNavigation { get; set; }
}
