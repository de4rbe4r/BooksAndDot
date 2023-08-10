using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAndDot.Models.Books {
    public class Book {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearPublish { get; set; }
        public double Price { get; set; }
        public List<Author> Authors { get; set; }
        public List<Category> Categories { get; set; }
    }
}
