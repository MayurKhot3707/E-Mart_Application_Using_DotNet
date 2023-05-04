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
    public class ProductMastersController : ControllerBase
    {
        private readonly EmartContext _context;

        public ProductMastersController(EmartContext context)
        {
            _context = context;
        }

        // GET: api/ProductMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductMaster>>> GetProductMaster()
        {
          if (_context.ProductMaster == null)
          {
              return NotFound();
          }
            return await _context.ProductMaster.ToListAsync();
        }

        // GET: api/ProductMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductMaster>> GetProductMaster(int id)
        {
          if (_context.ProductMaster == null)
          {
              return NotFound();
          }
            var productMaster = await _context.ProductMaster.FindAsync(id);

            if (productMaster == null)
            {
                return NotFound();
            }

            var result = from c in _context.CatMaster
                         join p in _context.ProductMaster on c.ProductID equals p.ProductID
                         join pt in _context.ProductDtlMaster on p.ProductID equals pt.ProductID
                         join ct in _context.ConfigMaster on pt.ConfigID equals ct.ConfigID
                         where p.ProductID == id
                         select new { c, p, pt, ct };
            return Ok(result.ToList()); 
        }

        // PUT: api/ProductMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductMaster(int id, ProductMaster productMaster)
        {
            if (id != productMaster.ProductID)
            {
                return BadRequest();
            }

            _context.Entry(productMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductMasterExists(id))
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

        // POST: api/ProductMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductMaster>> PostProductMaster(ProductMaster productMaster)
        {
          if (_context.ProductMaster == null)
          {
              return Problem("Entity set 'EmartContext.ProductMaster'  is null.");
          }
            _context.ProductMaster.Add(productMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductMaster", new { id = productMaster.ProductID }, productMaster);
        }

        // DELETE: api/ProductMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductMaster(int id)
        {
            if (_context.ProductMaster == null)
            {
                return NotFound();
            }
            var productMaster = await _context.ProductMaster.FindAsync(id);
            if (productMaster == null)
            {
                return NotFound();
            }

            _context.ProductMaster.Remove(productMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductMasterExists(int id)
        {
            return (_context.ProductMaster?.Any(e => e.ProductID == id)).GetValueOrDefault();
        }
    }
}
