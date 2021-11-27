using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CCSB_Bentelo.Models;

namespace CCSB_Bentelo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactuurController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FactuurController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Factuur
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factuur>>> GetFactuur()
        {
            return await _context.Factuur.ToListAsync();
        }

        // GET: api/Factuur/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Factuur>> GetFactuur(string id)
        {
            var factuur = await _context.Factuur.FindAsync(id);

            if (factuur == null)
            {
                return NotFound();
            }

            return factuur;
        }

        // PUT: api/Factuur/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactuur(string id, Factuur factuur)
        {
            if (id != factuur.FactuurId)
            {
                return BadRequest();
            }

            _context.Entry(factuur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactuurExists(id))
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

        // POST: api/Factuur
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Factuur>> PostFactuur(Factuur factuur)
        {
            _context.Factuur.Add(factuur);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FactuurExists(factuur.FactuurId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFactuur", new { id = factuur.FactuurId }, factuur);
        }

        // DELETE: api/Factuur/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactuur(string id)
        {
            var factuur = await _context.Factuur.FindAsync(id);
            if (factuur == null)
            {
                return NotFound();
            }

            _context.Factuur.Remove(factuur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FactuurExists(string id)
        {
            return _context.Factuur.Any(e => e.FactuurId == id);
        }
    }
}
