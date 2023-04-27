using LibraryApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Repository;

public class TransactionRepository : ITransactionRepository
{
    private readonly LibraryContext context;

    public TransactionRepository(LibraryContext context)
    {
        this.context = context;
    }

    public void Add(User user)
    {
        context.User.Add(user);
        context.SaveChanges();
    }

    public void Add(Transaction transaction)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Transaction>> GetAll()
    {
        return await context.Transaction.ToListAsync();
    }
}