using LibraryApi.Controller.Request;

namespace LibraryApi.Entity;

public class Transaction
{
    public Guid Id { get; set; }
    public TransactionType type { get; set; }
    public DateTime dueDate { get; set; }
    public Guid userId { get; set; }
    public virtual User user { get; set; }
    public Guid bookId { get; set; }
    public virtual Book book { get; set; }
}

public enum TransactionType
{
    CHECKOUT = 0 ,
    RETURN = 1 ,
}
