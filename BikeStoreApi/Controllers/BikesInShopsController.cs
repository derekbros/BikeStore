using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BikeAgencyLibrary;
using BikeStoreApi.Models;


namespace BikeStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikesInShopsController : ControllerBase
    {
        private readonly BikeRentalContext _context;

        public BikesInShopsController(BikeRentalContext context)
        {
            _context = context;
        }

        // GET: api/BikesInShops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BikesInShop>>> GetBikesInShops()
        {
            return await _context.BikesInShops.ToListAsync();
        }

        // GET: api/BikesInShops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BikesInShop>> GetBikesInShop(int id)
        {
            var bikesInShop = await _context.BikesInShops.FindAsync(id);

            if (bikesInShop == null)
            {
                return NotFound();
            }

            return bikesInShop;
        }

        // PUT: api/BikesInShops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBikesInShop(int id, BikesInShop bikesInShop)
        {
            if (id != bikesInShop.BikesInShopId)
            {
                return BadRequest();
            }

            _context.Entry(bikesInShop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BikesInShopExists(id))
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

        // POST: api/BikesInShops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BikesInShop>> PostBikesInShop(BikesInShop bikesInShop)
        {
            _context.BikesInShops.Add(bikesInShop);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BikesInShopExists(bikesInShop.BikesInShopId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBikesInShop", new { id = bikesInShop.BikesInShopId }, bikesInShop);
        }

        // DELETE: api/BikesInShops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBikesInShop(int id)
        {
            var bikesInShop = await _context.BikesInShops.FindAsync(id);
            if (bikesInShop == null)
            {
                return NotFound();
            }

            _context.BikesInShops.Remove(bikesInShop);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BikesInShopExists(int id)
        {
            return _context.BikesInShops.Any(e => e.BikesInShopId == id);
        }
    }
}
