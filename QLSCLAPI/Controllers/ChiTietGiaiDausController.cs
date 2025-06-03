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
    public class ChiTietGiaiDausController : ControllerBase
    {
        private readonly QuanLySanCauLongContext _context;

        public ChiTietGiaiDausController(QuanLySanCauLongContext context)
        {
            _context = context;
        }

        // GET: api/ChiTietGiaiDaus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietGiaiDau>>> GetChiTietGiaiDaus()
        {
            return await _context.ChiTietGiaiDaus.ToListAsync();
        }

        // GET: api/ChiTietGiaiDaus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChiTietGiaiDau>> GetChiTietGiaiDau(int id)
        {
            var chiTietGiaiDau = await _context.ChiTietGiaiDaus.FindAsync(id);

            if (chiTietGiaiDau == null)
            {
                return NotFound();
            }

            return chiTietGiaiDau;
        }

        // PUT: api/ChiTietGiaiDaus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChiTietGiaiDau(int id, ChiTietGiaiDau chiTietGiaiDau)
        {
            if (id != chiTietGiaiDau.MaGiaiDau)
            {
                return BadRequest();
            }

            _context.Entry(chiTietGiaiDau).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietGiaiDauExists(id))
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

        // POST: api/ChiTietGiaiDaus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChiTietGiaiDau>> PostChiTietGiaiDau(ChiTietGiaiDau chiTietGiaiDau)
        {
            _context.ChiTietGiaiDaus.Add(chiTietGiaiDau);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChiTietGiaiDauExists(chiTietGiaiDau.MaGiaiDau))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChiTietGiaiDau", new { id = chiTietGiaiDau.MaGiaiDau }, chiTietGiaiDau);
        }

        // DELETE: api/ChiTietGiaiDaus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChiTietGiaiDau(int id)
        {
            var chiTietGiaiDau = await _context.ChiTietGiaiDaus.FindAsync(id);
            if (chiTietGiaiDau == null)
            {
                return NotFound();
            }

            _context.ChiTietGiaiDaus.Remove(chiTietGiaiDau);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChiTietGiaiDauExists(int id)
        {
            return _context.ChiTietGiaiDaus.Any(e => e.MaGiaiDau == id);
        }
    }
}
