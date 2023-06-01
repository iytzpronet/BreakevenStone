using LibraryApi.Controller.Request;
using LibraryApi.Entity;
using LibraryApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controller;

[Route("api/[Controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookRepository _repository;

    public BookController(IBookRepository repository)
    {
        this._repository = repository;
    }
    
    [HttpPost()]
    public void Add(CreateBookRequest createBookRequest)
    {
        var book = new Book();
        book.Title = createBookRequest.Title;
        book.ISBN = createBookRequest.ISBN;
        book.Authors = createBookRequest.Authors;
        book.PublishDate = createBookRequest.PublishDate;
        book.TotalPages = createBookRequest.TotalPages;
        book.ExemplaryBooks = createBookRequest.ExemplaryBooks;
        _repository.Add(book);
    }
    
    [HttpGet()]
    public async Task<List<Book>> List ()
    {
        return await _repository.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<Book> getbyid(Guid id)
    {
        return await _repository.GetById(id);
    }

    [HttpPut("{id}")]
    public async Task Update(Guid id, CreateBookRequest request)
    {
        var book = await _repository.GetById(id);
        book.Title = request.Title;
        book.Authors = request.Authors;
        book.TotalPages = request.TotalPages;
        book.PublishDate = request.PublishDate;
        book.ISBN = request.ISBN;
        book.ExemplaryBooks = request.ExemplaryBooks;
        _repository.Update(book);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var book = await _repository.GetById(id);

        if (book == null)
        {
            return NotFound("Id não encontrado.");
        }

        var verify = await _repository.Verify(book);
        if (verify.Count > 0)
        {
            return UnprocessableEntity();
        }
        _repository.Delete(book);

        return NoContent();
    }
}   