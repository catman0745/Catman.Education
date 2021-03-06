namespace Catman.Education.Persistence.EntityConfigurations
{
    using Catman.Education.Application.Entities.Users;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder
                .HasIndex(user => user.Username)
                .IsUnique();

            builder
                .Property(user => user.Id)
                .HasColumnName("id");

            builder
                .Property(user => user.Username)
                .HasColumnName("username")
                .HasMaxLength(30)
                .IsRequired();
        
            builder
                .Property(user => user.FullName)
                .HasColumnName("full_name")
                .HasMaxLength(40)
                .IsRequired();

            builder
                .Property(user => user.Password)
                .HasColumnName("password")
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
