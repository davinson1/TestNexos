using Data;
using Data.DTOs;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/publisher")]
    public class PublishersController : Controller
    {
        private readonly LibraryContext _context;
        private readonly IDataRepository<Publisher> _repository;

        public PublishersController(LibraryContext context, IDataRepository<Publisher> repository)
        {
            _context = context;
            _repository = repository;
        }

        [HttpGet("index")]
        public IEnumerable<Publisher> Index()
        {
            var data = _context.Publishers.OrderByDescending(p => p.Id);
            return data;
        }

        [HttpPost("create")]
        public async Task<ActionResult> create([FromBody] Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            await _context.SaveChangesAsync();
            return Ok(StatusCode(200, "Editorial " + publisher.Name + " registrado correctamente"));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var publisherExists = await _context.Publishers.FindAsync(id);
                if (publisherExists == null)
                {
                    return NotFound("editorial no encontrado");
                }
                _repository.DeleteAsync(publisherExists);
                _repository.SaveAsync(publisherExists);
                return Ok();
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = ex.Message });
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> update([FromRoute] int id, [FromBody]Publisher publisher)
        {
            if (id != publisher.Id)
            {
                return BadRequest();
            }

            if (!PublisherExists(id))
            {
                return NotFound();
            }

            try
            {
                _repository.UpdateAsync(publisher);
                await _repository.SaveAsync(publisher);
                return Ok();
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = ex.Message });
            }
        }

        private bool PublisherExists(int id)
        {
            return _context.Publishers.Any(e => e.Id == id);
        }

    }
}
