using System;
using System.Collections.Generic;

namespace QLSCLAPI.Models;

public partial class DoiThiDau
{
    public int MaDoi { get; set; }

    public string TenDoi { get; set; } = null!;

    public string? DaiDien { get; set; }

    public string? SoDienThoai { get; set; }

    public virtual ICollection<ChiTietGiaiDau> ChiTietGiaiDaus { get; set; } = new List<ChiTietGiaiDau>();

    public virtual ICollection<TranDau> TranDauMaDoi1Navigations { get; set; } = new List<TranDau>();

    public virtual ICollection<TranDau> TranDauMaDoi2Navigations { get; set; } = new List<TranDau>();
}
