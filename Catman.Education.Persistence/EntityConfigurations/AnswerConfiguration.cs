namespace Catman.Education.Persistence.EntityConfigurations
{
    using Catman.Education.Application.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.ToTable("answers");

            builder
                .Property(answer => answer.Id)
                .HasColumnName("id");

            builder
                .Property(answer => answer.Text)
                .HasColumnName("text")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(answer => answer.IsCorrect)
                .HasColumnName("is_correct");

            builder
                .Property(answer => answer.QuestionId)
                .HasColumnName("question_id");
        }
    }
}
