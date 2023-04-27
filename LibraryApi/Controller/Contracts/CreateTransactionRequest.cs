using LibraryApi.Entity;

namespace LibraryApi.Controller.Request;

public class CreateTransactionRequest
{
    public TransactionType type { get; set; }
    public DateTime dueDate { get; set; }
    public Guid userId { get; set; }
    public virtual User user { get; set; }
    public Guid bookId { get; set; }
    public virtual Book book { get; set; }
}