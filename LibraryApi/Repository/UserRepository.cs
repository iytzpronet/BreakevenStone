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
}