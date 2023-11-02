using BooksAndDot.Models.Books;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAndDot.Models {
    public interface IBookRepository {
        Task<Book> GetBookById(int id);
        Task<List<Book>> GetBooks();
    }
    public class BookRepository : IBookRepository {
        string connString = null;
        public BookRepository(string connString) {
            this.connString = connString;
        }
        public async Task<Book> GetBookById(int id) {
            using (IDbConnection conn = new SqlConnection(connString)) {
                return await conn.QueryFirstAsync<Book>(
                    "SELECT * FROM Books WHERE id = @id", new { id });                
            }
        }
        public async Task<List<Book>> GetBooks() {
            using (IDbConnection conn = new SqlConnection(connString)) {
                var b = await conn.QueryAsync<Book>("SELECT * FROM Books");
                return b.ToList();
            }
        }
    }
}
