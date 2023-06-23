using DateTime = System.DateTime;
using LibraryApi.Controller.Request;
using LibraryApi.Entity;
using LibraryApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controller;

[Route("api/[Controller]")]
[ApiController]
public class TransactionController : ControllerBase
{
    private readonly ITransactionRepository _repository;

    public TransactionController(ITransactionRepository repository)
    {
        this._repository = repository;
    }
    [HttpPost()]
    public void Add(CreateTransactionRequest createTransactionRequest)
    {
        var transaction = new Transaction();
        transaction.Status = createTransactionRequest.Status;
        transaction.Duedate = DateTime.Now.AddDays(7);
        transaction.UserId = createTransactionRequest.UserId;
        transaction.BookId = createTransactionRequest.BookId;
        _repository.Add(transaction);
    }  
    
    [HttpPut()]
    public async Task Update(Guid id,UpdateTransactionRequest request)
    {
        var transaction = await _repository.GetById(id);
        transaction.Status = request.Status;
        _repository.Update(transaction);
    }
    
    [HttpGet()]
    public async Task<List<Transaction>> List ()
    {
        return await _repository.GetAll();
    }
}