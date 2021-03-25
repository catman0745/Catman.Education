namespace Catman.Education.Persistence.EntityConfigurations
{
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ChoiceQuestionConfiguration : IEntityTypeConfiguration<ChoiceQuestion>
    {
        public void Configure(EntityTypeBuilder<ChoiceQuestion> builder)
        {
            builder.ToTable("choice_questions");

            builder
                .HasMany(question => question.AnswerOptions)
                .WithOne(answerOption => answerOption.ChoiceQuestion)
                .HasForeignKey(answerOption => answerOption.ChoiceQuestionId);
        }
    }
}
