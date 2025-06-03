using System;
using System.Collections.Generic;

namespace QLSCLAPI.Models;

public partial class GiaiDau
{
    public int MaGiaiDau { get; set; }

    public string TenGiai { get; set; } = null!;

    public string? MoTa { get; set; }

    public DateOnly NgayBatDau { get; set; }

    public DateOnly NgayKetThuc { get; set; }

    public string? DiaDiem { get; set; }

    public decimal? GiaiThuong { get; set; }

    public string? TrangThai { get; set; }

    public virtual ICollection<ChiTietGiaiDau> ChiTietGiaiDaus { get; set; } = new List<ChiTietGiaiDau>();

    public virtual ICollection<TranDau> TranDaus { get; set; } = new List<TranDau>();
}
