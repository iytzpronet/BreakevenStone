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
        _context.Book.Add(Book);
        _context.SaveChanges();
    }

    public Book Book { get; set; }
    
    Task<List<Book>> IBookRepository.GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<List<Book>> GetAll()
    {
        return await _context.Book.ToListAsync();
    }
}