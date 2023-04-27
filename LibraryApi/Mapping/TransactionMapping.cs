using LibraryApi.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApi.Mapping;

    public class TransactionMapping:IEntityTypeConfiguration<Transaction>{
    
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transaction");
            builder.HasKey(t=>t.Id);
            builder.Property(t=>t.type).IsRequired().HasColumnType("varchar(1)");
            builder.Property(t=>t.bookId).IsRequired().HasColumnType("varchar(50)");
            builder.Property(t=>t.userId).IsRequired().HasColumnType("varchar(50)");
            builder.Property(t => t.dueDate).IsRequired().HasColumnType("datetime");
            builder.HasOne<User>(t => t.user);
            builder.HasOne<Book>(t => t.book);
        }
        
    }
