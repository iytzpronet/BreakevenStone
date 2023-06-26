using LibraryApi.Entity;
using LibraryApi.Enumerations;

namespace LibraryApi.Controller.Request;

public class UpdateTransactionRequest
{
    public TransactionStatus Status { get; set; }
}