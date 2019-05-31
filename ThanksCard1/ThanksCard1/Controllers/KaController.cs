using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThanksCard1.Models;

namespace ThanksCard1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KaController : ControllerBase
    {
        private readonly ThanksCardContext _context;

        public KaController(ThanksCardContext context)
        {
            _context = context;
        }

        // GET: api/Ka
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ka>>> GetKas()
        {
            return await _context.Kas.ToListAsync();
        }

        // GET: api/Ka/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ka>> GetKa(int id)
        {
            var ka = await _context.Kas.FindAsync(id);

            if (ka == null)
            {
                return NotFound();
            }

            return ka;
        }

        // PUT: api/Ka/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKa(int id, Ka ka)
        {
            if (id != ka.Id)
            {
                return BadRequest();
            }

            _context.Entry(ka).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KaExists(id))
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

        // POST: api/Ka
        [HttpPost]
        public async Task<ActionResult<Ka>> PostKa(Ka ka)
        {
            // Parent Department には既に存在している部署が入るため、更新の対象から外す。
            

            _context.Kas.Add(ka);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKa", new { id = ka.Id }, ka);
        }

        // DELETE: api/Ka/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ka>> DeleteKa(int id)
        {
            var ka = await _context.Kas.FindAsync(id);
            if (ka == null)
            {
                return NotFound();
            }

            _context.Kas.Remove(ka);
            await _context.SaveChangesAsync();

            return ka;
        }

        private bool KaExists(int id)
        {
            return _context.Kas.Any(e => e.Id == id);
        }
    }
}
