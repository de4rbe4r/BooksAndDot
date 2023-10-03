using BooksAndDot.Controllers.Books;
using BooksAndDot.Models;
using BooksAndDot.Models.Books;
using BooksAndDot.Services;
using Microsoft.AspNetCore.Mvc;
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
        public void BooksControllerTest() {
            //������� ������ - Arrange
            AppDbContext context = new AppDbContext();
            BooksController books = new BooksController(context);

            //�������� ������ �� ������� - Act
            var result = books.GetBooks();


            //�������� ���������� ������ � ���������� - Assert
            Assert.Equal(TaskStatus.Faulted, result.Status);
        }
        [Fact]
        public async void BooksServcesTest() {
            
        }
    }
}
