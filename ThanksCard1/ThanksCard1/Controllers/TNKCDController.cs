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
    public class TNKCDController : ControllerBase
    {
        private readonly ThanksCardContext _context;

        public TNKCDController(ThanksCardContext context)
        {
            _context = context;
        }

        // GET: api/TNKCD
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TNKCD>>> GetTNKCDs()
        {
            return await _context.TNKCDs
                                       .Include(TNKCD　=> TNKCD.EmployeeFrom)
                                       .Include(TNKCD => TNKCD.EmployeeTo)
                                       .Include(TNKCD => TNKCD.Work)
                                       .ToListAsync();
           
        }



        // GET: api/TNKCD/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TNKCD>> GetTNKCD(int id)
        {
            var tNKCD = await _context.TNKCDs.FindAsync(id);

            if (tNKCD == null)
            {
                return NotFound();
            }

            return tNKCD;
        }

        // PUT: api/TNKCD/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTNKCD(int id, TNKCD tNKCD)
        {
            if (id != tNKCD.Id)
            {
                return BadRequest();
            }

            _context.Entry(tNKCD).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TNKCDExists(id))
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

        // POST: api/TNKCD
        [HttpPost]
        public async Task<ActionResult<TNKCD>> PostTNKCD(TNKCD tNKCD)
        {
            _context.TNKCDs.Add(tNKCD);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTNKCD", new { id = tNKCD.Id }, tNKCD);
        }

        // DELETE: api/TNKCD/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TNKCD>> DeleteTNKCD(int id)
        {
            var tNKCD = await _context.TNKCDs.FindAsync(id);
            if (tNKCD == null)
            {
                return NotFound();
            }

            _context.TNKCDs.Remove(tNKCD);
            await _context.SaveChangesAsync();

            return tNKCD;
        }

        private bool TNKCDExists(int id)
        {
            return _context.TNKCDs.Any(e => e.Id == id);
        }
    }
}
