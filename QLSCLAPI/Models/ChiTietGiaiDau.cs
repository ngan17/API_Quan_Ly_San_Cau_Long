using System;
using System.Collections.Generic;

namespace QLSCLAPI.Models;

public partial class ChiTietGiaiDau
{
    public int MaGiaiDau { get; set; }

    public int MaDoi { get; set; }

    public string? VongDau { get; set; }

    public string? KetQua { get; set; }

    public virtual DoiThiDau MaDoiNavigation { get; set; } = null!;

    public virtual GiaiDau MaGiaiDauNavigation { get; set; } = null!;
}
