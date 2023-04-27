using LibraryApi.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApi.Mapping;

public class UserMapping:IEntityTypeConfiguration<User> {
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.name).IsRequired().HasColumnType("varchar(50)");
        builder.Property(u => u.document).IsRequired().HasColumnType("varchar(11)");
        
    }
} 