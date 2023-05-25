using LibraryApi.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApi.Mapping;

public class BookMapping:IEntityTypeConfiguration<Book> {
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Book");
        builder.HasKey(b=>b.Id);
        builder.Property(b=>b.Title).IsRequired().HasColumnType("varchar(50)");
        builder.Property(b=>b.Authors).IsRequired().HasColumnType("varchar(50)");
        builder.Property(b => b.TotalPages).IsRequired().HasColumnType("int");
        builder.Property(b => b.ISBN).IsRequired().HasColumnType("varchar(50)");
        builder.Property(b => b.PublishDate).IsRequired().HasColumnType("datetime");
        builder.Property(b => b.ExemplaryBooks).IsRequired().HasColumnType("int");

    }
}