using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BooksAndDot.Models.Books {
    public class Book {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearPublish { get; set; }
        public double Price { get; set; }
        //[Column(TypeName = "nvarchar(2048)")]
        public string Description { get; set; }
        public List<Author> Authors { get; set; }
        public List<Category> Categories { get; set; }
        public List<Cover> Covers { get; set; }
    }
}
