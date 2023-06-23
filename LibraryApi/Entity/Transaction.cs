using LibraryApi.Controller.Request;

namespace LibraryApi.Entity;

public class Transaction
{
    public Guid Id { get; set; }
    public TransactionStatus Status { get; set; }
    public DateTime Duedate { get; set; }
    public Guid UserId { get; set; }
    public virtual User user { get; set; }
    public Guid BookId { get; set; }
    public virtual Book book { get; set; }

    public Transaction()
    {
        Id = Guid.NewGuid();
    }
}

public enum TransactionStatus
{
    Borrowed = 0,
    Returned = 1
}