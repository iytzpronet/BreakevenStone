using LibraryApi.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApi.Mapping;

    public class TransactionMapping:IEntityTypeConfiguration<Transaction>{
    
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transaction");
            builder.HasKey(t=>t.Id);
            builder.Property(t=>t.Type).IsRequired().HasColumnType("varchar(1)");
            builder.Property(t=>t.BookId).IsRequired().HasColumnType("varchar(50)");
            builder.Property(t=>t.UserId).IsRequired().HasColumnType("varchar(50)");
            builder.Property(t => t.Duedate).IsRequired().HasColumnType("datetime");
            builder.HasOne<User>(t => t.user);
            builder.HasOne<Book>(t => t.book);
        }
         
    }
