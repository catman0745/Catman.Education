namespace Catman.Education.Persistence.EntityConfigurations
{
    using Catman.Education.Application.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder.ToTable("disciplines");

            builder
                .Property(discipline => discipline.Id)
                .HasColumnName("id");

            builder
                .Property(discipline => discipline.Title)
                .HasColumnName("title")
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
