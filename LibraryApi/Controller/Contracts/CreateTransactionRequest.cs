using LibraryApi.Entity;

namespace LibraryApi.Controller.Request;

public class CreateTransactionRequest
{
    public TransactionType Type { get; set; }
    public DateTime DueDate { get; set; }
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
   
    
}