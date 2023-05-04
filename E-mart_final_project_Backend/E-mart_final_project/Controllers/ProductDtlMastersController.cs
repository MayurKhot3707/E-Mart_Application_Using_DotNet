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
    public class ProductDtlMastersController : ControllerBase
    {
        private readonly EmartContext _context;

        public ProductDtlMastersController(EmartContext context)
        {
            _context = context;
        }

        // GET: api/ProductDtlMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDtlMaster>>> GetProductDtlMaster()
        {
          if (_context.ProductDtlMaster == null)
          {
              return NotFound();
          }
            return await _context.ProductDtlMaster.ToListAsync();
        }

        // GET: api/ProductDtlMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDtlMaster>> GetProductDtlMaster(int id)
        {
          if (_context.ProductDtlMaster == null)
          {
              return NotFound();
          }
            var productDtlMaster = await _context.ProductDtlMaster.FindAsync(id);

            if (productDtlMaster == null)
            {
                return NotFound();
            }

            return productDtlMaster;
        }

        // PUT: api/ProductDtlMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductDtlMaster(int id, ProductDtlMaster productDtlMaster)
        {
            if (id != productDtlMaster.ProductDtlID)
            {
                return BadRequest();
            }

            _context.Entry(productDtlMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductDtlMasterExists(id))
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

        // POST: api/ProductDtlMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductDtlMaster>> PostProductDtlMaster(ProductDtlMaster productDtlMaster)
        {
          if (_context.ProductDtlMaster == null)
          {
              return Problem("Entity set 'EmartContext.ProductDtlMaster'  is null.");
          }
            _context.ProductDtlMaster.Add(productDtlMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductDtlMaster", new { id = productDtlMaster.ProductDtlID }, productDtlMaster);
        }

        // DELETE: api/ProductDtlMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDtlMaster(int id)
        {
            if (_context.ProductDtlMaster == null)
            {
                return NotFound();
            }
            var productDtlMaster = await _context.ProductDtlMaster.FindAsync(id);
            if (productDtlMaster == null)
            {
                return NotFound();
            }

            _context.ProductDtlMaster.Remove(productDtlMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductDtlMasterExists(int id)
        {
            return (_context.ProductDtlMaster?.Any(e => e.ProductDtlID == id)).GetValueOrDefault();
        }
    }
}
