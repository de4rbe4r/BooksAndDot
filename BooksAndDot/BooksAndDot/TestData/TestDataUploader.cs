using BooksAndDot.Models;
using BooksAndDot.Models.Books;
using BooksAndDot.Models.Orders;
using BooksAndDot.Models.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAndDot.TestData
{
    public class TestDataUploader
    {
        private static string pathAuthors = "./TestData/authors.csv";
        private static string pathBooks = "./TestData/books.csv";
        private static string pathCategories = "./TestData/categories.csv";
        private static string pathShops = "./TestData/shops.csv";
        private static string pathUsers = "./TestData/users.csv";
        public List<Category> Categories { get; set; }
        public List<Author> Authors { get; set; }
        public List<Book> Books { get; set; }
        public List<Shop> Shops  { get; set; }
        public List<Cover> Covers { get; set; }
        public List<User> Users { get; set; }
        public List<Role> Roles { get; set; }

        public const string baseCoverPath = "images/covers/";

        public TestDataUploader()
        {
            Categories = new List<Category>();
            Authors = new List<Author>();
            Books = new List<Book>();
            Shops = new List<Shop>();
            Covers = new List<Cover>();
            Users = new List<User>();
            Roles = new List<Role>();
        }
        private void ReadUserData()
        {
            try
            {
                using (StreamReader reader = new StreamReader(pathUsers))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(';');
                        var tempRole = new Role() { 
                            Title = data[4], 
                            Level = Int32.Parse(data[5]) 
                        };
                        Users.Add(new User
                        {
                            FullName = data[0],
                            Email = data[1],
                            Phone = data[2],
                            Password = Convert.ToBase64String(System.Security.Cryptography.MD5.HashData(Encoding.Unicode.GetBytes(data[3]))),
                            Role = tempRole
                        });
                    }
                }
            } catch (Exception ex) { 
                Console.WriteLine("Error: " + ex.Message);  
            }
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
                        Cover tempCover = new Cover { Title = data[6], Path = baseCoverPath + data[6] };
                        if (Authors.Contains(tempAuthor)) tempAuthor = Authors.Find(a => a.Equals(tempAuthor));
                        if (Categories.Contains(tempCategory)) tempCategory = Categories.Find(c => c.Equals(tempCategory));
                        if (Covers.Contains(tempCover)) tempCover = Covers.Find(c => c.Equals(tempCover));

                        Books.Add(new Book {
                            Authors = new List<Author> { tempAuthor },
                            Title = data[2],
                            YearPublish = Int32.Parse(data[3]),
                            Price = Double.Parse(data[4].Replace('.',',')),
                            Categories = new List<Category> { tempCategory },
                            Covers = new List<Cover> { tempCover },
                            Description =  data[7]
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
            ReadUserData();
            
            using (AppDbContext context = new AppDbContext())
            {
                context.Books.AddRange(Books);
                context.Categories.AddRange(Categories);
                context.Authors.AddRange(Authors);
                context.Shops.AddRange(Shops);
                context.Users.AddRange(Users);
                context.Roles.AddRange(Roles);
                
                context.SaveChanges();
            }
        }
    }
}
