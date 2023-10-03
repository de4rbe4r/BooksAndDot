using BooksAndDot.Models;
using BooksAndDot.TestData;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAndDot {
    public class Program {
        public static void Main(string[] args) {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            using (AppDbContext db = new AppDbContext()) {
                //db.Database.EnsureDeleted();
                if (db.Database.EnsureCreated()) {
                    TestDataUploader testDataUploader = new TestDataUploader();
                    testDataUploader.LoadTestDataToDb();
                }
               //db.Database.Migrate();
            }
            //TestDataUploader testDataUploader = new TestDataUploader();
            //testDataUploader.LoadTestDataToDb();
            //прочто для примера как работает логгер
            try
            {
                Log.Information("Приложение запущено");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Приложение не запущено!!");
                throw;
            }
            finally {
                Log.CloseAndFlush();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
