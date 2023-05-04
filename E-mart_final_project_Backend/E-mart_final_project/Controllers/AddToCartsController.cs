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
    public class AddToCartsController : ControllerBase
    {
        private readonly EmartContext _context;

        public AddToCartsController(EmartContext context)
        {
            _context = context;
        }

        // GET: api/AddToCarts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddToCart>>> GetAddToCarts()
        {
          if (_context.AddToCarts == null)
          {
              return NotFound();
          }
            return await _context.AddToCarts.ToListAsync();
        }

        // GET: api/AddToCarts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddToCart>> GetAddToCart(int id)
        {
          if (_context.AddToCarts == null)
          {
              return NotFound();
          }
            var addToCart = await _context.AddToCarts.FindAsync(id);

            if (addToCart == null)
            {
                return NotFound();
            }

            return addToCart;
        }

        // PUT: api/AddToCarts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddToCart(int id, AddToCart addToCart)
        {
            if (id != addToCart.CartID)
            {
                return BadRequest();
            }

            _context.Entry(addToCart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddToCartExists(id))
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

        // POST: api/AddToCarts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AddToCart>> PostAddToCart(AddToCart addToCart)
        {
          if (_context.AddToCarts == null)
          {
              return Problem("Entity set 'EmartContext.AddToCarts'  is null.");
          }
            _context.AddToCarts.Add(addToCart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddToCart", new { id = addToCart.CartID }, addToCart);
        }

        // DELETE: api/AddToCarts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddToCart(int id)
        {
            if (_context.AddToCarts == null)
            {
                return NotFound();
            }
            var addToCart = await _context.AddToCarts.FindAsync(id);
            if (addToCart == null)
            {
                return NotFound();
            }

            _context.AddToCarts.Remove(addToCart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddToCartExists(int id)
        {
            return (_context.AddToCarts?.Any(e => e.CartID == id)).GetValueOrDefault();
        }
    }
}
