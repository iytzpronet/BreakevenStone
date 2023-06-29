using LibraryApi.Entity;
namespace LibraryApi.Repository;
    
    public interface ITransactionRepository
{ 
    void Add(Transaction transaction);
    void Update(Transaction update);
    Task<Transaction> GetById(Guid id);
    Task<List<Transaction>> GetAll();
    Task<List<Transaction>> GetCheckoutTransactionsByBookId(Guid id);
    Task<List<Transaction>> GetCheckoutTransactionsByUserId(Guid id);
}