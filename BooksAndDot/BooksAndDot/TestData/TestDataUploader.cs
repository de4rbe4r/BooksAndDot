using BooksAndDot.Models;
using BooksAndDot.Models.Books;
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
        public List<Category> Categories { get; set; }
        public List<Author> Authors { get; set; }
        public List<Book> Books { get; set; }

        public TestDataUploader()
        {
            Categories = new List<Category>();
            Authors = new List<Author>();
            Books = new List<Book>();
        }
        public void ReadAuthorsData()
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
                using (AppDbContext appDbContext = new AppDbContext())
                {
                    appDbContext.Authors.AddRange(Authors);
                }
            } catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        public void ReadCategoriesData()
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
                using (AppDbContext appDbContext = new AppDbContext())
                {
                    appDbContext.Categories.AddRange(Categories);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        public void ReadBooksData()
        {
            try
            {
                using (StreamReader reader = new StreamReader(pathCategories))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(';');
                        Books.Add(new Book { Authors.Add(new Author { FirstName = data[0], LastName = data[1] }) });
                    }
                }
                using (AppDbContext appDbContext = new AppDbContext())
                {
                    appDbContext.Categories.AddRange(Categories);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
