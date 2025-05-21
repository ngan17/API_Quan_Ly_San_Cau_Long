using System;
using System.Collections.Generic;

namespace QLSCLAPI.Models;

public partial class San
{
    public int MaSan { get; set; }

    public string TenSan { get; set; } = null!;

    public string? TinhTrang { get; set; }

    public virtual ICollection<DatSan> DatSans { get; set; } = new List<DatSan>();

    public virtual ICollection<PhanHoi> PhanHois { get; set; } = new List<PhanHoi>();
}
