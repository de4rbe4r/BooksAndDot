using BooksAndDot.Models.Books;
using BooksAndDot.Models.Users;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAndDot.Models.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public double TotalSum { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Book> Books { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}
