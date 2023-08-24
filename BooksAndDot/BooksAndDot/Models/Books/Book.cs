﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BooksAndDot.Models.Books {
    public class Book {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearPublish { get; set; }
        public double Price { get; set; }
        [JsonIgnore]
        public List<Author> Authors { get; set; }
        [JsonIgnore]
        public List<Category> Categories { get; set; }
    }
}
