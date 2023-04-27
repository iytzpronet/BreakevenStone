using LibraryApi.Entity;

namespace LibraryApi.Repository;

public interface IBookRepository
{
    Task<List<Book>> GetAll();
}