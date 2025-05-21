using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLSCLAPI.Models;

namespace QLSCLAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatSansController : ControllerBase
    {
        private readonly QuanLySanCauLongContext _context;

        public DatSansController(QuanLySanCauLongContext context)
        {
            _context = context;
        }

        // GET: api/DatSans
        [HttpGet]
        [HttpGet("api/DatSans")]
        public IActionResult GetAll()
        {
            var result = _context.DatSans
                .Include(d => d.MaKhachHangNavigation)
                .Select(d => new {
                    d.MaDatSan,
                    d.MaKhachHang,
                    TenKhachHang = d.MaKhachHangNavigation.TenKhachHang, // 👈 Thêm dòng này
                    d.MaSan,
                    d.NgayDat,
                    d.GioBatDau,
                    d.ThoiLuong,
                    d.TrangThai,
                })
                .ToList();

            return Ok(result);
        }


        // GET: api/DatSans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DatSan>> GetDatSan(int id)
        {
            var datSan = await _context.DatSans.FindAsync(id);

            if (datSan == null)
            {
                return NotFound();
            }

            return datSan;
        }

        // PUT: api/DatSans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDatSan(int id, DatSan datSan)
        {
            if (id != datSan.MaDatSan)
            {
                return BadRequest();
            }

            _context.Entry(datSan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DatSanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DatSans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DatSan>> PostDatSan(DatSan datSan)
        {
            _context.DatSans.Add(datSan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDatSan", new { id = datSan.MaDatSan }, datSan);
        }

        // DELETE: api/DatSans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDatSan(int id)
        {
            var datSan = await _context.DatSans.FindAsync(id);
            if (datSan == null)
            {
                return NotFound();
            }

            _context.DatSans.Remove(datSan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DatSanExists(int id)
        {
            return _context.DatSans.Any(e => e.MaDatSan == id);
        }
    }
}
