using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLSCLAPI.Models;

namespace QLSCLAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private readonly QuanLySanCauLongContext _context;

        public TaiKhoanController(QuanLySanCauLongContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            var tenDangNhap = model.TenDangNhap.Trim();
            var matKhau = model.MatKhau;

            // Cho phép đăng nhập bằng SĐT hoặc Email
            var user = await _context.NguoiDungs
                .FirstOrDefaultAsync(u =>
                    u.TenDangNhap == tenDangNhap ||
                    _context.KhachHangs.Any(k =>
                        (k.Email == tenDangNhap || k.SoDienThoai == tenDangNhap) &&
                        k.MaNguoiDung == u.MaNguoiDung));

            if (user == null || user.MatKhauHash != matKhau)
                return Unauthorized("Tên đăng nhập hoặc mật khẩu không đúng");

            // Lấy MaKhachHang nếu là khách
            var khachHang = await _context.KhachHangs
                .FirstOrDefaultAsync(k => k.MaNguoiDung == user.MaNguoiDung);

            var token = Guid.NewGuid().ToString();

            var phien = new PhienDangNhap
            {
                MaNguoiDung = user.MaNguoiDung,
                Token = token,
                ThoiGianTao = DateTime.Now,
                HetHan = DateTime.Now.AddDays(7),
                DiaChiIp = HttpContext.Connection?.RemoteIpAddress?.ToString(),
                ThietBi = model.DeviceToken
            };

            _context.PhienDangNhaps.Add(phien);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Token = token,
                TenDangNhap = user.TenDangNhap,
                MaNguoiDung = user.MaNguoiDung,
                VaiTro = user.VaiTro,
                MaKhachHang = khachHang?.MaKhachHang,
                TenKhachHang = khachHang?.TenKhachHang
            });
        }
    }

 
}
