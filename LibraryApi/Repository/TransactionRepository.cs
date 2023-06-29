using LibraryApi.Entity;
using LibraryApi.Enumerations;
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

    public void Update(Transaction transaction)
    {
        _context.Transaction.Update(transaction);
        _context.SaveChanges();
    }

    public async Task<Transaction> GetById(Guid id)
    {
        return await _context.Transaction.FirstOrDefaultAsync(u=> u.Id == id);
    }

    public async Task<List<Transaction>> GetAll()
    {
        return await _context.Transaction.ToListAsync();
    }
    
    public async Task<List<Transaction>> GetCheckoutTransactionsByBookId(Guid id)
    {
        return await _context.Transaction.Where(b => b.BookId == id && b.Status == TransactionStatus.Borrowed).ToListAsync();
    }
    
    public async Task<List<Transaction>> GetCheckoutTransactionsByUserId(Guid id)
    {
        return await _context.Transaction.Where(b => b.UserId == id && b.Status == TransactionStatus.Borrowed).ToListAsync();
    }
}