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
    public class ConfigMastersController : ControllerBase
    {
        private readonly EmartContext _context;

        public ConfigMastersController(EmartContext context)
        {
            _context = context;
        }

        // GET: api/ConfigMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConfigMaster>>> GetConfigMaster()
        {
          if (_context.ConfigMaster == null)
          {
              return NotFound();
          }
            return await _context.ConfigMaster.ToListAsync();
        }

        // GET: api/ConfigMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConfigMaster>> GetConfigMaster(int id)
        {
          if (_context.ConfigMaster == null)
          {
              return NotFound();
          }
            var configMaster = await _context.ConfigMaster.FindAsync(id);

            if (configMaster == null)
            {
                return NotFound();
            }

            return configMaster;
        }

        // PUT: api/ConfigMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfigMaster(int id, ConfigMaster configMaster)
        {
            if (id != configMaster.ConfigID)
            {
                return BadRequest();
            }

            _context.Entry(configMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfigMasterExists(id))
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

        // POST: api/ConfigMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConfigMaster>> PostConfigMaster(ConfigMaster configMaster)
        {
          if (_context.ConfigMaster == null)
          {
              return Problem("Entity set 'EmartContext.ConfigMaster'  is null.");
          }
            _context.ConfigMaster.Add(configMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConfigMaster", new { id = configMaster.ConfigID }, configMaster);
        }

        // DELETE: api/ConfigMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfigMaster(int id)
        {
            if (_context.ConfigMaster == null)
            {
                return NotFound();
            }
            var configMaster = await _context.ConfigMaster.FindAsync(id);
            if (configMaster == null)
            {
                return NotFound();
            }

            _context.ConfigMaster.Remove(configMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConfigMasterExists(int id)
        {
            return (_context.ConfigMaster?.Any(e => e.ConfigID == id)).GetValueOrDefault();
        }
    }
}
