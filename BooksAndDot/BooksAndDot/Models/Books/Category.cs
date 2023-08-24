using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BooksAndDot.Models.Books {
    public class Category {
        public int Id { get; set; }
        public string Title { get; set;}
        public List<Book> Books { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is Category)
            {
                var category  = obj as Category;
                return Title  == category.Title;
            }
            else
            {
                return false;
            }
        }
    }
}
