﻿using BooksAndDot.Models.Books;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BooksAndDot.Models.Orders;
using BooksAndDot.Models.Users;

namespace BooksAndDot.Models {
    public class AppDbContext : DbContext {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<BooksShop> BooksShops { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config  = builder.Build();
            string connString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connString);
            //optionsBuilder.LogTo(System.Console.WriteLine);
        }
    }
}
