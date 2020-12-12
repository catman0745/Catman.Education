namespace Catman.Education.Persistence.EntityConfigurations
{
    using Catman.Education.Application.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("questions");

            builder
                .Property(question => question.Id)
                .HasColumnName("id");

            builder
                .Property(question => question.Text)
                .HasColumnName("text")
                .HasMaxLength(10000)
                .IsRequired();

            builder
                .Property(question => question.Cost)
                .HasColumnName("cost");

            builder
                .Property(question => question.TestId)
                .HasColumnName("test_id");
        }
    }
}