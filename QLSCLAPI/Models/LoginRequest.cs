namespace QLSCLAPI.Models
{
    public class LoginRequest
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string? DeviceToken { get; set; }
    }

}
