using LibraryApi.Mapping;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Entity;

public class LibraryContext:DbContext {
    public DbSet<User> User { get; set; } //declaraçao da entidade dentro do dbcontext

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        modelBuilder.ApplyConfiguration(new UserMapping());
    }

    public LibraryContext(DbContextOptions<LibraryContext> dbContextOptions): base(dbContextOptions)
    {
    }
}