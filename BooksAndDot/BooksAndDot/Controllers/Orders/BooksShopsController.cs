using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BooksAndDot.Models;
using BooksAndDot.Models.Orders;

namespace BooksAndDot.Controllers.Orders
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksShopsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BooksShopsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/BooksShops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BooksShop>>> GetBooksShops()
        {
            return await _context.BooksShops.ToListAsync();
        }

        // GET: api/BooksShops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BooksShop>> GetBooksShop(int id)
        {
            var booksShop = await _context.BooksShops.FindAsync(id);

            if (booksShop == null)
            {
                return NotFound();
            }

            return booksShop;
        }

        // PUT: api/BooksShops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooksShop(int id, BooksShop booksShop)
        {
            if (id != booksShop.Id)
            {
                return BadRequest();
            }

            _context.Entry(booksShop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BooksShopExists(id))
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

        // POST: api/BooksShops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BooksShop>> PostBooksShop(BooksShop booksShop)
        {
            _context.BooksShops.Add(booksShop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBooksShop", new { id = booksShop.Id }, booksShop);
        }

        // DELETE: api/BooksShops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooksShop(int id)
        {
            var booksShop = await _context.BooksShops.FindAsync(id);
            if (booksShop == null)
            {
                return NotFound();
            }

            _context.BooksShops.Remove(booksShop);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BooksShopExists(int id)
        {
            return _context.BooksShops.Any(e => e.Id == id);
        }
    }
}
