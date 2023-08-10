using BooksAndDot.Models.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAndDot.Models.Orders
{
    public class BooksShop
    {
        public int Id { get; set; }
        public int ShopId { get; set; }
        public int BookId { get; set; }
        public int CountBook { get; set; }
        public Book Book { get; set; }
        public Shop Shop { get; set; }
    }
}
