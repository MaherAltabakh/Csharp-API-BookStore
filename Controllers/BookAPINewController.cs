using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookAPINew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAPINewController : ControllerBase
    {
        // GET: api/<BookAPINewController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            BookDB bookDb = new BookDB();
            List<Book> books = bookDb.GetAllBooks();
            return books;
        }

        // GET api/<BookAPINewController>/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            BookDB bookDb = new BookDB();
            Book book = bookDb.GetBookById(id);
            return book;
        }

        // POST api/<BookAPINewController>
        [HttpPost]
        public void Post([FromBody] Book newBook)
        {
            if (newBook != null)
            {
                BookDB bookDb = new BookDB();
                bookDb.AddBook(newBook); // Assuming you have a method to add a new book to the database
            }
        }

        // PUT api/<BookAPINewController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book updatedBook)
        {
            if (updatedBook != null)
            {
                BookDB bookDb = new BookDB();
                bookDb.UpdateBook(id, updatedBook); // Assuming you have a method to update an existing book
            }
        }

        // DELETE api/<BookAPINewController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            BookDB bookDb = new BookDB();
            bookDb.DeleteBook(id); // Assuming you have a method to delete a book by its ID
        }
    }
}