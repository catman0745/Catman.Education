namespace Catman.Education.Persistence.EntityConfigurations
{
    using Catman.Education.Application.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.ToTable("tests");

            builder
                .HasIndex(test => new {test.DisciplineId, test.Title})
                .IsUnique();

            builder
                .Property(test => test.Id)
                .HasColumnName("id");

            builder
                .Property(test => test.Title)
                .HasColumnName("title")
                .HasMaxLength(250)
                .IsRequired();

            builder
                .Property(test => test.DisciplineId)
                .HasColumnName("discipline_id");
        }
    }
}
