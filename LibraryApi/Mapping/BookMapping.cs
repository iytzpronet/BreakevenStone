using LibraryApi.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApi.Mapping;

public class BookMapping:IEntityTypeConfiguration<Book> {
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Book");
        builder.HasKey(b=>b.Id);
        builder.Property(b=>b.title).IsRequired().HasColumnType("varchar(50)");
        builder.Property(b=>b.authors).IsRequired().HasColumnType("varchar(50)");
        builder.Property(b => b.totalPages).IsRequired().HasColumnType("int");
        builder.Property(b => b.ISBN).IsRequired().HasColumnType("varchar(50)");
        builder.Property(b => b.publishDate).IsRequired().HasColumnType("datetime");

    }
}