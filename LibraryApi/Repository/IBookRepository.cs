using LibraryApi.Entity;
namespace LibraryApi.Repository;

public interface IBookRepository
{
    Task<List<Book>> GetAll();
    Task<Book> GetById(Guid id);
    void Update(Book book);
    void Delete(Book book);
    void Add(Book book);
}