namespace Catman.Education.Persistence.EntityConfigurations
{
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MultipleChoiceQuestionConfiguration : IEntityTypeConfiguration<MultipleChoiceQuestion>
    {
        public void Configure(EntityTypeBuilder<MultipleChoiceQuestion> builder)
        {
            builder.ToTable("multiple_choice_questions");

            builder
                .HasMany(question => question.AnswerOptions)
                .WithOne(answerOption => answerOption.MultipleChoiceQuestion)
                .HasForeignKey(answerOption => answerOption.MultipleChoiceQuestionId);
        }
    }
}
