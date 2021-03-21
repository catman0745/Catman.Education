namespace Catman.Education.Persistence.EntityConfigurations
{
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ValueQuestionConfiguration : IEntityTypeConfiguration<ValueQuestion>
    {
        public void Configure(EntityTypeBuilder<ValueQuestion> builder)
        {
            builder.ToTable("value_questions");

            builder
                .Property(question => question.CorrectAnswer)
                .HasColumnName("correct_answer")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
