using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BooksAndDot.Models;
using BooksAndDot.Models.Books;
using BooksAndDot.Services;
using Microsoft.AspNetCore.Authorization;

namespace BooksAndDot.Controllers.Books
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
//      [Authorize]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            //return await _context.Books.ToListAsync();
            /*return await _context.Books
                .Include(b => b.Authors)
                .Include(b => b.Categories)
                .ToListAsync();
            */
            BookServices bs = new BookServices(_context);
            return await bs.ListBooks();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            BookServices bs = new BookServices(_context);
            Book book = bs.GetBook(id);

            if (book == null) {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutBook(int id, Book book) {
            if (id != book.Id) {
                return BadRequest();
            }

            BookServices bs = new BookServices(_context);
            var newBook = bs.UpdateBook(id, book);
            if (newBook == null) { return NotFound(); }
            /*
            _context.Entry(book).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!BookExists(id)) {
                    return NotFound();
                }
                else {
                    throw;
                }
            }
            */

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            /*_context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
            */
            BookServices bs = new BookServices(_context);
            var result = bs.AddBook(book);
            return result == null ? BadRequest("Ошибка в книге") : result;
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteBook(int id) {
            /*
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            */
            BookServices bs = new BookServices(_context);
            var book = bs.DeleteBook(id);
            if (book != null) {
                return Ok();
            }
            return NoContent();
        }

    }
}
