using LibraryApi.Entity;
namespace LibraryApi.Repository;
    
    public interface ITransactionRepository
{ 
    void Add(Transaction transaction);
    Task<List<Transaction>> GetAll();
    Task<List<Transaction>> GetCheckoutTransactionsByBookId(Guid id);
}