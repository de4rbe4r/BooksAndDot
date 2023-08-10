using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAndDot.Models.Users
{
    public class Role
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Level { get; set; }
    }
}
