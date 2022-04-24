using Data;
using Data.DTOs;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/author")]
    public class AuthorController : ControllerBase
    {
        private readonly LibraryContext _context;
        private readonly IDataRepository<Author> _repository;

        public AuthorController(LibraryContext context, IDataRepository<Author> repository)
        {
            _context = context;
            _repository = repository;
        }

        [HttpGet("index")]
        public IEnumerable<Author> Index()
        {
            var data = _context.Authors.OrderByDescending(p => p.Id);
            return data;
        }

        [HttpPost("create")]
        public async Task<ActionResult> create([FromBody]Author authors) {
            _context.Authors.Add(authors);
            await _context.SaveChangesAsync();
            return Ok(StatusCode(200,"Autor " + authors.FullName + " registrado correctamente"));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id) {
            try
            {
                var authorExists = await _context.Authors.FindAsync(id);
                if (authorExists == null) {
                    return NotFound("autor no encontrado");
                }
                _repository.DeleteAsync(authorExists);
                _repository.SaveAsync(authorExists);
                return Ok();
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = ex.Message });
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> update([FromRoute]int id, [FromBody]Author authors)
        {
            if (id != authors.Id)
            {
                return BadRequest();
            }

            if (!AuthorExists(id))
            {
                return NotFound();
            }

            try
            {
                _repository.UpdateAsync(authors);
                await _repository.SaveAsync(authors);
                return Ok();
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = ex.Message });
            }
        }

        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.Id == id);
        }


    }
}
