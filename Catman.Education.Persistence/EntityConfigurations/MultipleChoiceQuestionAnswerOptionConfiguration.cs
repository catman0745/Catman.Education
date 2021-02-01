namespace Catman.Education.Persistence.EntityConfigurations
{
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MultipleChoiceQuestionAnswerOptionConfiguration
        : IEntityTypeConfiguration<MultipleChoiceQuestionAnswerOption>
    {
        public void Configure(EntityTypeBuilder<MultipleChoiceQuestionAnswerOption> builder)
        {
            builder.ToTable("multiple_choice_question_answer_options");

            builder
                .Property(answer => answer.IsCorrect)
                .HasColumnName("is_correct");

            builder
                .Property(answer => answer.MultipleChoiceQuestionId)
                .HasColumnName("multiple_choice_question_id");
        }
    }
}
