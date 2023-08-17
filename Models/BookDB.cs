using Dapper;
using System.Data.SqlClient;

namespace BookStore.Models
{
    public class BookDB
    {
        private string connectionString = ("server = Administrator; database = BookStore; user id = reader; password = pass123;");
        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();
            string sql = "select * from Book";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                books = conn.Query<Book>(sql).ToList();
            }
            return books;
        }

        public Book GetBookById(int BookID)
        {
            var book = new Book();
            string sql = " select * from Book WHERE BookID =@BookID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                book = conn.QueryFirst<Book>(sql, new { BookID });
            }

            return book;
        }

        public void DeleteBook(int BookID)
        {
            string sql = "DELETE FROM [Book] WHERE [BookID]= @BookID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Execute(sql, new { BookID });
            }

        }
        public void AddBook(Book newBook)
        {
            if (newBook == null)
            {
                throw new ArgumentNullException(nameof(newBook));
            }

            string sql = @"
                INSERT INTO [Book] (Title, NumberOfPages, CreatedDate, UpdatedDate)
                VALUES (@Title, @NumberOfPages, @CreatedDate, @UpdatedDate)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                newBook.UpdatedDate = DateTime.UtcNow;
                conn.Execute(sql, newBook);
            }
        }



        public void UpdateBook(int id, Book updatedBook)
        {
            if (updatedBook == null)
            {
                throw new ArgumentNullException(nameof(updatedBook));
            }

            string sql = @"
                UPDATE [Book] 
                SET Title = @Title,
                    NumberOfPages = @NumberOfPages,
                    UpdatedDate = @UpdatedDate
                WHERE BookID = @BookID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                updatedBook.UpdatedDate = DateTime.UtcNow;
                updatedBook.BookID = id;

                conn.Execute(sql, updatedBook);
            }
        }












    }
}