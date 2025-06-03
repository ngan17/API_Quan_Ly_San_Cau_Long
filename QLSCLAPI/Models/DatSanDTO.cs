namespace QLSCLAPI.Models
{
    public class DatSanDTO
    {
        public int MaKhachHang { get; set; }
        public int MaSan { get; set; }
        public DateOnly NgayDat { get; set; }
        public TimeOnly GioBatDau { get; set; }
        public int ThoiLuong { get; set; }
        public string TrangThai { get; set; }
    }
}

