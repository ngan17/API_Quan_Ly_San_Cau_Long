using System;
using System.Collections.Generic;

namespace QLSCLAPI.Models;

public partial class TranDau
{
    public int MaTranDau { get; set; }

    public int? MaGiaiDau { get; set; }

    public int? MaDoi1 { get; set; }

    public int? MaDoi2 { get; set; }

    public DateTime? ThoiGian { get; set; }

    public string? SanThiDau { get; set; }

    public string? TySo { get; set; }

    public virtual DoiThiDau? MaDoi1Navigation { get; set; }

    public virtual DoiThiDau? MaDoi2Navigation { get; set; }

    public virtual GiaiDau? MaGiaiDauNavigation { get; set; }
}
