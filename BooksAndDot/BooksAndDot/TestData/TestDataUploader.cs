using BooksAndDot.Models;
using BooksAndDot.Models.Books;
using BooksAndDot.Models.Orders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAndDot.TestData
{
    public class TestDataUploader
    {
        private static string pathAuthors = "./TestData/authors.csv";
        private static string pathBooks = "./TestData/books.csv";
        private static string pathCategories = "./TestData/categories.csv";
        private static string pathShops = "./TestData/shops.csv";
        public List<Category> Categories { get; set; }
        public List<Author> Authors { get; set; }
        public List<Book> Books { get; set; }
        public List<Shop> Shops  { get; set; }

        public TestDataUploader()
        {
            Categories = new List<Category>();
            Authors = new List<Author>();
            Books = new List<Book>();
            Shops = new List<Shop>();
        }
        private void ReadAuthorsData()
        {
            try
            {
                using (StreamReader reader = new StreamReader(pathAuthors))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(';');
                        Authors.Add(new Author { FirstName = data[0], LastName = data[1] });
                    }
                }
            } catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        private void ReadCategoriesData()
        {
            try
            {
                using (StreamReader reader = new StreamReader(pathCategories))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Categories.Add(new Category { Title = line});
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        private void ReadBooksData()
        {
            try
            {
                using (StreamReader reader = new StreamReader(pathBooks))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(';');
                        Author tempAuthor = new Author { FirstName = data[0], LastName = data[1] };
                        Category tempCategory = new Category { Title = data[5] };

                        if (Authors.Contains(tempAuthor)) tempAuthor = Authors.Find(a => a.Equals(tempAuthor));
                        if (Categories.Contains(tempCategory)) tempCategory = Categories.Find(c => c.Equals(tempCategory));


                        Books.Add(new Book {
                            Authors = new List<Author> { tempAuthor },
                            Title = data[2],
                            YearPublish = Int32.Parse(data[3]),
                            Price = Double.Parse(data[4].Replace('.',',')),
                            Categories = new List<Category> { tempCategory }
                        });
                    }
                }
            }


            
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        private void ReadShopsData()
        {
            try
            {
                using (StreamReader reader = new StreamReader(pathShops))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(';');
                        
                        Shops.Add(new Shop { Title = data[0], Address = data[1] });
                    }
                }
            }


            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        public void LoadTestDataToDb()
        {
            ReadAuthorsData();
            ReadCategoriesData();
            ReadBooksData();
            ReadShopsData();
            using (AppDbContext context = new AppDbContext())
            {
                context.Books.AddRange(Books);
                context.Categories.AddRange(Categories);
                context.Authors.AddRange(Authors);
                context.Shops.AddRange(Shops);
                context.SaveChanges();
            }
        }
    }
}
