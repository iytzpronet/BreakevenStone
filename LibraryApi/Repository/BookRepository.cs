using LibraryApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Repository;

public class BookRepository : IBookRepository
{
    private readonly LibraryContext _context;

    public BookRepository(LibraryContext context)
    {
        this._context = context;
    }
    
    public void Add(Book book)
    {
        _context.Book.Add(book);
        _context.SaveChanges();
    }

    public async Task<List<Transaction>> Verify(Book book)
    {
       return await _context.Transaction.Where(b => b.BookId == book.Id && b.Type == TransactionType.CHECKOUT).ToListAsync();
    }
    
    public async Task<List<Book>> GetAll()
    {
        return await _context.Book.ToListAsync();
    } 
    
    public async Task<Book> GetById(Guid id)
    {
        return await _context.Book.FirstOrDefaultAsync(x=> x.Id == id);
    } 
    
    public void Update(Book book)
    {
        _context.Book.Update(book);
        _context.SaveChanges();
    }
    
    public void Delete(Book book)
    {
        _context.Book.Remove(book);
        _context.SaveChanges();
    }

}