using System;
using System.Collections.Generic;

namespace QLSCLAPI.Models;

public partial class DatSan
{
    public int MaDatSan { get; set; }

    public int MaKhachHang { get; set; }

    public int MaSan { get; set; }

    public DateOnly NgayDat { get; set; }

    public TimeOnly GioBatDau { get; set; }

    public int ThoiLuong { get; set; }

    public string? TrangThai { get; set; }

    public virtual HoaDon? HoaDon { get; set; }

    public virtual ICollection<HuyDatSan> HuyDatSans { get; set; } = new List<HuyDatSan>();

    public virtual KhachHang MaKhachHangNavigation { get; set; } = null!;

    public virtual San MaSanNavigation { get; set; } = null!;
}
