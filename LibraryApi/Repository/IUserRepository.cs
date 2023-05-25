using LibraryApi.Entity;

namespace LibraryApi.Repository;

public interface IUserRepository
{
    Task<List<User>> GetAll();
    Task<User> GetById(Guid Id);
    void Add(User user);
    void Update(User user);
    void Delete(User user);
}