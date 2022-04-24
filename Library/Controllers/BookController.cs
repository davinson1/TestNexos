using Data;
using Data.DTOs;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        private readonly LibraryContext _context;
        private readonly IDataRepository<Book> _repository;

        public BookController(LibraryContext context, IDataRepository<Book> repository)
        {
            _context = context;
            _repository = repository;
        }

        [HttpGet("index")]
        public IEnumerable<Book> Index()
        {
            var data = _context.Books.Include(b => b.Author).Include(b => b.Publisher).OrderByDescending(p => p.Id);
            return data;
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create(Book book)
        {
            if (BookMaximunRegister(book.PublisherId))
            {
                return BadRequest(new { errors = new { BookMaximunRegister = "No es posible registrar el libro, se alcanzó el máximo permitido." } });
            }

            try
            {
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = ex.Message });
            }
        }

        private bool BookMaximunRegister(int publisherId)
        {
            var maximunBook = _context.Publishers.Where(e => e.Id == publisherId).First().MaximumBooksRegistered;
            if (maximunBook.Equals("-1"))
            {
                return false;
            }
            else
            {
                if (maximunBook.Equals(_context.Books.Count(e => e.PublisherId == publisherId)))
                {
                    return true;
                }
                return false;
            }
        }

        [HttpPut("update/{id}")]
        public  IActionResult Edit([FromRoute] int id,[FromBody]Book book)
        {
           
            if (id != book.Id)
            {
                return BadRequest();
            }

            try
            {
                _repository.UpdateAsync(book);
                _repository.SaveAsync(book);
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);
                if (book == null)
                {
                    return NotFound();
                }

                _repository.DeleteAsync(book);
                await _repository.SaveAsync(book);

                return Ok(book);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = ex.Message });
            }
        }


    }
}
