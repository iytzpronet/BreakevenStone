using LibraryApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Repository;

public class UserRepository : IUserRepository
{
    private readonly LibraryContext context;

    public UserRepository(LibraryContext context)
    {
        this.context = context;
    }

    public void Add(User user)
    {
        context.User.Add(user);
        context.SaveChanges();
    }

    public async Task<List<User>> GetAll()
    {
        return await context.User.ToListAsync();
    }

    public async Task<User> GetById(Guid id)
    {
        return await context.User.FirstOrDefaultAsync(x => x.Id == id);
    } 
    public void Update(User user)
    {
        context.User.Update(user);
        context.SaveChanges();
    }
    public void Delete(User user)
    {
        context.User.Remove(user);
        context.SaveChanges();
    }
}