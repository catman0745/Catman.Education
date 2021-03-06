namespace Catman.Education.Persistence.EntityConfigurations
{
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class YesNoQuestionConfiguration : IEntityTypeConfiguration<YesNoQuestion>
    {
        public void Configure(EntityTypeBuilder<YesNoQuestion> builder)
        {
            builder.ToTable("yes_no_questions");

            builder
                .Property(question => question.CorrectAnswer)
                .HasColumnName("correct_answer");
        }
    }
}
