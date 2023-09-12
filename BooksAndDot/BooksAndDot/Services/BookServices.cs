using BooksAndDot.Models;
using BooksAndDot.Models.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAndDot.Services { 
    public class BookServices {
        private AppDbContext _context;
        public BookServices(AppDbContext context) {
            _context = context;
        }
        public Book AddBook(Book book) {
            /*if (book.YearPublish < 0 || 
                book.YearPublish > DateTime.Now.Year + 1 ||
                book.Price < 0) {
                return null;
            }*/
            book.Title = book.Title.Trim();
            _context.Books.Add(book);
            
            _context.SaveChanges();
            return book;
        }
        public Book DeleteBook(int id) {
            var book = _context.Books.Find(id);
            if (book == null) {
                return null;
            }
            var books = _context.Orders.Where(b => b.Books.Contains(book)).ToList();
            if (books.Count > 0) {
                return null;
            }
            if (_context.BooksShops.Count(b => b.BookId  == id) > 0) {
                return null;
            }

            _context.Books.Remove(book);
            _context.SaveChangesAsync();

            return book;
        }
        public Book UpdateBook(int id, Book book) {
            _context.Entry(book).State = EntityState.Modified;

            try
            {
                _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return book;
        }
        public async Task<ActionResult<IEnumerable<Book>>> ListBooks() {
            return await _context.Books
                .Include(b => b.Authors)
                .Include(b => b.Categories)
                .ToListAsync();
        }
        public Book GetBook(int id) {
            var book = _context.Books.Find(id);
            return book;
        }

        private bool BookExists(int id) {
            return _context.Books.Any(e => e.Id == id);
        }

    }
}
