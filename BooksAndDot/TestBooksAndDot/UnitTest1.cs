using BooksAndDot.Controllers.Books;
using BooksAndDot.Models;
using BooksAndDot.Models.Books;
using BooksAndDot.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace TestBooksAndDot
{
    public class UnitTest1 {
        [Fact]
        public async void BooksControllerTest() {
            /* Здесь необходимо создать Mock объект, который содержит
             * тестовые (фейковые) данные для тестирования
             * Для этого установлен и подключён пакет Moq 
             */
            //Создать объект - Arrange
            AppDbContext context = new AppDbContext();
            BooksController books = new BooksController(context);
            var expectedBooks = new List<Book>();

            //Получить данные от объекта - Act
            ActionResult<IEnumerable<Book>> booksResult = await books.GetBooks();

            //Сравнить полученные данные с эталонными - Assert
            var okResult = Assert.IsType<OkObjectResult>(booksResult.Result);
            var model = Assert.IsAssignableFrom<IEnumerable<Book>>(okResult.Value);
            //Assert.Equal(expectedBooks, model);           
            
        }
        [Fact]
        public async void BooksServcesTest() {
            //Подготовка
            AppDbContext context = new AppDbContext();
            BookServices bookServices = new BookServices(context);

            var resultBook = await bookServices.GetBook(123);
            Assert.Null(resultBook);
        }
        [Fact]
        public async void CategoryTest()
        {
            var context = new AppDbContext();
            CategoriesController categories = new CategoriesController(context);
            var expectedCategories = new Category {
                    Id = 1,
                    Title = "Комедия",
                    Books = null
            };

            ActionResult<Category> catResult = 
                await categories.GetCategory(1);

            Assert.NotNull(catResult);
            Assert.IsType<Category>(catResult.Value);
            var model = Assert.IsAssignableFrom<Category>(catResult.Value);
            Assert.Equal(expectedCategories, model);
        }
        [Fact]
        public async void CategoryNotFoundTest()
        {
            var context = new AppDbContext();
            CategoriesController categories = new CategoriesController(context);
            ActionResult<Category> catResult =
                await categories.GetCategory(60);
            Assert.IsType<NotFoundResult>(catResult.Result);
            Assert.Null(catResult.Value);
        }
    }
}
