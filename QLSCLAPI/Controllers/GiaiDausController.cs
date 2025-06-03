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
    public class GiaiDausController : ControllerBase
    {
        private readonly QuanLySanCauLongContext _context;

        public GiaiDausController(QuanLySanCauLongContext context)
        {
            _context = context;
        }

        // GET: api/GiaiDaus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GiaiDau>>> GetGiaiDaus()
        {
            return await _context.GiaiDaus.Include(g => g.ChiTietGiaiDaus)  // Load các đội
        .ToListAsync(); 
        }

        // GET: api/GiaiDaus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GiaiDau>> GetGiaiDau(int id)
        {
            var giaiDau = await _context.GiaiDaus.FindAsync(id);

            if (giaiDau == null)
            {
                return NotFound();
            }

            return giaiDau;
        }

        // PUT: api/GiaiDaus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGiaiDau(int id, GiaiDau giaiDau)
        {
            if (id != giaiDau.MaGiaiDau)
            {
                return BadRequest();
            }

            _context.Entry(giaiDau).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiaiDauExists(id))
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

        // POST: api/GiaiDaus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GiaiDau>> PostGiaiDau(GiaiDau giaiDau)
        {
            _context.GiaiDaus.Add(giaiDau);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGiaiDau", new { id = giaiDau.MaGiaiDau }, giaiDau);
        }

        // DELETE: api/GiaiDaus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGiaiDau(int id)
        {
            var giaiDau = await _context.GiaiDaus.FindAsync(id);
            if (giaiDau == null)
            {
                return NotFound();
            }

            _context.GiaiDaus.Remove(giaiDau);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GiaiDauExists(int id)
        {
            return _context.GiaiDaus.Any(e => e.MaGiaiDau == id);
        }
    }
}
