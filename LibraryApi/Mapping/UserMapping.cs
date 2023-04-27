using LibraryApi.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApi.Mapping;

public class UserMapping:IEntityTypeConfiguration<User> {
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Name).IsRequired().HasColumnType("varchar(50)");
        builder.Property(u => u.Document).IsRequired().HasColumnType("varchar(11)");
        
    }
} 