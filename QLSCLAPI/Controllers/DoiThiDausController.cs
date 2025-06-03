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
    public class DoiThiDausController : ControllerBase
    {
        private readonly QuanLySanCauLongContext _context;

        public DoiThiDausController(QuanLySanCauLongContext context)
        {
            _context = context;
        }

        // GET: api/DoiThiDaus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoiThiDau>>> GetDoiThiDaus()
        {
            return await _context.DoiThiDaus.ToListAsync();
        }

        // GET: api/DoiThiDaus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DoiThiDau>> GetDoiThiDau(int id)
        {
            var doiThiDau = await _context.DoiThiDaus.FindAsync(id);

            if (doiThiDau == null)
            {
                return NotFound();
            }

            return doiThiDau;
        }

        // PUT: api/DoiThiDaus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoiThiDau(int id, DoiThiDau doiThiDau)
        {
            if (id != doiThiDau.MaDoi)
            {
                return BadRequest();
            }

            _context.Entry(doiThiDau).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoiThiDauExists(id))
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

        // POST: api/DoiThiDaus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DoiThiDau>> PostDoiThiDau(DoiThiDau doiThiDau)
        {
            _context.DoiThiDaus.Add(doiThiDau);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoiThiDau", new { id = doiThiDau.MaDoi }, doiThiDau);
        }

        // DELETE: api/DoiThiDaus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoiThiDau(int id)
        {
            var doiThiDau = await _context.DoiThiDaus.FindAsync(id);
            if (doiThiDau == null)
            {
                return NotFound();
            }

            _context.DoiThiDaus.Remove(doiThiDau);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoiThiDauExists(int id)
        {
            return _context.DoiThiDaus.Any(e => e.MaDoi == id);
        }
    }
}
