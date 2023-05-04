using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_mart_final_project.models;

namespace E_mart_final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatMastersController : ControllerBase
    {
        private readonly EmartContext _context;

        public CatMastersController(EmartContext context)
        {
            _context = context;
        }

        // GET: api/CatMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatMaster>>> GetCatMaster()
        {
          if (_context.CatMaster == null)
          {
              return NotFound();
          }
            return await _context.CatMaster.Where(p => p.SubCatID == null).ToListAsync();
        }

        // GET: api/CatMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CatMaster>>> GetCatMaster(int id)
        {
          if (_context.CatMaster == null)
          {
              return NotFound();
          }
            var catMaster = await _context.CatMaster.FindAsync(id);

            if (catMaster == null)
            {
                return NotFound();
            }

            if (catMaster.SubCatID == null && catMaster.ProductID == null)
            {
                return await _context.CatMaster.Where(p => p.SubCatID == catMaster.CatID).ToListAsync();
            }
            else
            {
                var result = from c in _context.CatMaster
                             join p in _context.ProductMaster
                             on c.ProductID equals p.ProductID
                             where c.SubCatID == catMaster.CatID
                             select new { c, p };
                return Ok(result.ToList());
            }
        }

        // PUT: api/CatMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatMaster(int id, CatMaster catMaster)
        {
            if (id != catMaster.CatMasterID)
            {
                return BadRequest();
            }

            _context.Entry(catMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatMasterExists(id))
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

        // POST: api/CatMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CatMaster>> PostCatMaster(CatMaster catMaster)
        {
          if (_context.CatMaster == null)
          {
              return Problem("Entity set 'EmartContext.CatMaster'  is null.");
          }
            _context.CatMaster.Add(catMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatMaster", new { id = catMaster.CatMasterID }, catMaster);
        }

        // DELETE: api/CatMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatMaster(int id)
        {
            if (_context.CatMaster == null)
            {
                return NotFound();
            }
            var catMaster = await _context.CatMaster.FindAsync(id);
            if (catMaster == null)
            {
                return NotFound();
            }

            _context.CatMaster.Remove(catMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CatMasterExists(int id)
        {
            return (_context.CatMaster?.Any(e => e.CatMasterID == id)).GetValueOrDefault();
        }
    }
}
