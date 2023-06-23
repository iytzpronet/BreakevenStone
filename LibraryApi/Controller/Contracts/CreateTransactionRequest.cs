using LibraryApi.Entity;

namespace LibraryApi.Controller.Request;

public class CreateTransactionRequest
{
    public TransactionStatus Status { get; set; }
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
   
    
}