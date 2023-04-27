using LibraryApi.Mapping;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Entity;

public class LibraryContext:DbContext {
    public DbSet<User> User { get; set; }
    public DbSet<Book> Book { get; set; }
    public DbSet<Transaction> Transaction { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookMapping());
        modelBuilder.ApplyConfiguration(new UserMapping());
        modelBuilder.ApplyConfiguration(new TransactionMapping());
    }

    public LibraryContext(DbContextOptions<LibraryContext> dbContextOptions): base(dbContextOptions)
    {
    }
}