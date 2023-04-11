using LibraryApi.Entity;

namespace LibraryApi.Repository;

public interface IUserRepository
{
    void Add(User user);
    Task<List<User>> GetAll();
}