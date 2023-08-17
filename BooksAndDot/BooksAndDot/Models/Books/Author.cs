using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAndDot.Models.Books {
    public class Author {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Book> Books { get; set; }
        public override bool Equals(object obj)
        {
           if (obj is Author)
            {
                var author = obj as Author;
                return FirstName == author.FirstName && LastName == author.LastName;
            } else
            {
                return false;
            }
        }
    }
}
