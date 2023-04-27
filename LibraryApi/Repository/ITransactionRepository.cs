using LibraryApi.Entity;

namespace LibraryApi.Repository;

public interface ITransactionRepository
{ 
    public void Add(Transaction transaction);
    Task<List<Transaction>> GetAll();
}