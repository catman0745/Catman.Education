namespace Catman.Education.Persistence.EntityConfigurations
{
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OrderQuestionConfiguration : IEntityTypeConfiguration<OrderQuestion>
    {
        public void Configure(EntityTypeBuilder<OrderQuestion> builder)
        {
            builder.ToTable("order_questions");

            builder
                .HasMany(question => question.OrderItems)
                .WithOne(answerOption => answerOption.OrderQuestion)
                .HasForeignKey(answerOption => answerOption.OrderQuestionId);
        }
    }
}
