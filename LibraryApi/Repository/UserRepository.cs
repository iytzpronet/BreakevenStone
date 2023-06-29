using LibraryApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Repository; 

public class UserRepository : IUserRepository
{
    private readonly LibraryContext _context; 
    public UserRepository(LibraryContext context)
    {
        this._context = context;
    }
    
    public void Add(User user)
    {
        _context.User.Add(user);
        _context.SaveChanges();
    }
    
    public async Task<List<User>> GetAll()
    {
        return await _context.User.ToListAsync();
    }
    
    public async Task<User> GetById(Guid id)
    {
        return await _context.User.FirstOrDefaultAsync(x => x.Id == id);
    } 
    
    public void Update(User user)
    {
        _context.User.Update(user);
        _context.SaveChanges();
    }
    
    public void Delete(User user)
    {
        _context.User.Remove(user);
        _context.SaveChanges();
    }
}