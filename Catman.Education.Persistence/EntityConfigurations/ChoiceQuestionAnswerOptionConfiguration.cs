namespace Catman.Education.Persistence.EntityConfigurations
{
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ChoiceQuestionAnswerOptionConfiguration : IEntityTypeConfiguration<ChoiceQuestionAnswerOption>
    {
        public void Configure(EntityTypeBuilder<ChoiceQuestionAnswerOption> builder)
        {
            builder.ToTable("choice_question_answer_options");

            builder
                .Property(answer => answer.IsCorrect)
                .HasColumnName("is_correct");

            builder
                .Property(answer => answer.ChoiceQuestionId)
                .HasColumnName("choice_question_id");
        }
    }
}
