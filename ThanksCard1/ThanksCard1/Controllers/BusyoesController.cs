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
    public class BusyoesController : ControllerBase
    {
        private readonly ThanksCardContext _context;

        public BusyoesController(ThanksCardContext context)
        {
            _context = context;
        }

        // GET: api/Busyoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Busyo>>> GetBusyoes()
        {
            return await _context.Busyoes.ToListAsync();
                                         
        }

        // GET: api/Busyoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Busyo>> GetBusyo(int id)
        {
            var busyo = await _context.Busyoes.FindAsync(id);

            if (busyo == null)
            {
                return NotFound();
            }

            return busyo;
        }

        // PUT: api/Busyoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusyo(int id, Busyo busyo)
        {
            if (id != busyo.Id)
            {
                return BadRequest();
            }

            _context.Entry(busyo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusyoExists(id))
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

        // POST: api/Busyoes
        [HttpPost]
        public async Task<ActionResult<Busyo>> PostBusyo(Busyo busyo)
        {
            _context.Busyoes.Add(busyo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusyo", new { id = busyo.Id }, busyo);
        }

        // DELETE: api/Busyoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Busyo>> DeleteBusyo(int id)
        {
            var busyo = await _context.Busyoes.FindAsync(id);
            if (busyo == null)
            {
                return NotFound();
            }

            _context.Busyoes.Remove(busyo);
            await _context.SaveChangesAsync();

            return busyo;
        }

        private bool BusyoExists(int id)
        {
            return _context.Busyoes.Any(e => e.Id == id);
        }
    }
}
