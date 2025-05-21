using System;
using System.Collections.Generic;

namespace QLSCLAPI.Models;

public partial class KhachHang
{
    public int MaKhachHang { get; set; }

    public string TenKhachHang { get; set; } = null!;

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public int? MaNguoiDung { get; set; }

    public virtual ICollection<DatSan> DatSans { get; set; } = new List<DatSan>();

    public virtual NguoiDung? MaNguoiDungNavigation { get; set; }

    public virtual ICollection<PhanHoi> PhanHois { get; set; } = new List<PhanHoi>();
}
