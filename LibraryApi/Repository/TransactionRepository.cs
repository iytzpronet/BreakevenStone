using LibraryApi.Entity;
using Microsoft.EntityFrameworkCore;
namespace LibraryApi.Repository;

public class TransactionRepository : ITransactionRepository
{
    private readonly LibraryContext _context;
    public TransactionRepository(LibraryContext context)
    {
        this._context = context;
    }
    
    public void Add(Transaction transaction)
    {
        _context.Transaction.Add(transaction);
        _context.SaveChanges();
    }
    
    public async Task<List<Transaction>> GetAll()
    {
        return await _context.Transaction.ToListAsync();
    }
    
    public async Task<List<Transaction>> GetCheckoutTransactionsByBookId(Guid id)
    {
        return await _context.Transaction.Where(b => b.BookId == id && b.Type == TransactionType.CHECKOUT).ToListAsync();
    }
}