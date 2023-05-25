using LibraryApi.Controller.Request;

namespace LibraryApi.Entity;

public class Transaction
{
    public Guid Id { get; set; }
    public TransactionType Type { get; set; }
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

public enum TransactionType
{
    CHECKOUT = 0 ,
    RETURN = 1 ,
}
