using BooksAndDot.Models;
using BooksAndDot.TestData;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAndDot {
    public class Program {
        public static void Main(string[] args) {
            using (AppDbContext db = new AppDbContext()) {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
            TestDataUploader testDataUploader = new TestDataUploader();
            testDataUploader.ReadAuthorsData();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
