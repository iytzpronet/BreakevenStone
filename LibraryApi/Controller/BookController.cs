using LibraryApi.Controller.Request;
using LibraryApi.Entity;
using LibraryApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controller;

[Route("api/[Controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookRepository _bookRepository;
    private readonly ITransactionRepository _transactionRepository;

    public BookController(IBookRepository bookRepository, ITransactionRepository transactionRepository)
    {
        _bookRepository = bookRepository;
        _transactionRepository = transactionRepository;
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
        _bookRepository.Add(book);
    }

    [HttpGet()]
    public async Task<List<Book>> List()
    {
        return await _bookRepository.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<Book> getbyid(Guid id)
    {
        return await _bookRepository.GetById(id);
    }

    [HttpPut("{id}")]
    public async Task Update(Guid id, CreateBookRequest request)
    {
        var book = await _bookRepository.GetById(id);
        book.Title = request.Title; 
        book.Authors = request.Authors;
        book.TotalPages = request.TotalPages;
        book.PublishDate = request.PublishDate;
        book.ISBN = request.ISBN;
        book.ExemplaryBooks = request.ExemplaryBooks;
        _bookRepository.Update(book);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var book = await _bookRepository.GetById(id);

        if (book == null)
        {
            return NotFound("Id não encontrado.");
        }

        if (await VerifyExistTransaction(id))
        {
            return UnprocessableEntity("existem transaçoes pendentes");
        }
        
        _bookRepository.Delete(book);

        return NoContent();
    }

    private async Task<bool> VerifyExistTransaction(Guid id)
    {
        var bookTransactions = await _transactionRepository.GetCheckoutTransactionsByBookId(id);
        return bookTransactions.Count > 0;
    }
} 