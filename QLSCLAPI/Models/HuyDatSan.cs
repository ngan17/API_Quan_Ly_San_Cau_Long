using System;
using System.Collections.Generic;

namespace QLSCLAPI.Models;

public partial class HuyDatSan
{
    public int MaHuy { get; set; }

    public int? MaDatSan { get; set; }

    public DateTime? ThoiGianHuy { get; set; }

    public string? LyDo { get; set; }

    public virtual DatSan? MaDatSanNavigation { get; set; }
}
