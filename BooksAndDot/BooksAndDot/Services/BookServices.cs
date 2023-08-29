using BooksAndDot.Models;
using BooksAndDot.Models.Books;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace BooksAndDot.Services { 
    public class BookServices {
        private AppDbContext _context;
        public BookServices(AppDbContext context) {
            _context = context;
        }
        public Book AddBook(Book book) {
            if (book.YearPublish < 0 || 
                book.YearPublish > DateTime.Now.Year + 1 ||
                book.Price < 0) {
                return null;
            }
            book.Title = book.Title.Trim();
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }
    }
}
