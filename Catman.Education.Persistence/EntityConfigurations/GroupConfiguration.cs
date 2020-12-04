namespace Catman.Education.Persistence.EntityConfigurations
{
    using Catman.Education.Application.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("groups");

            builder
                .HasIndex(group => group.Title)
                .IsUnique();

            builder
                .Property(group => group.Id)
                .HasColumnName("id");

            builder
                .Property(group => group.Title)
                .HasColumnName("title")
                .HasMaxLength(5)
                .IsRequired();
        }
    }
}
