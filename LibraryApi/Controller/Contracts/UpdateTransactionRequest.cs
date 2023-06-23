using LibraryApi.Entity;

namespace LibraryApi.Controller.Request;

public class UpdateTransactionRequest
{
    public TransactionStatus Status { get; set; }
}