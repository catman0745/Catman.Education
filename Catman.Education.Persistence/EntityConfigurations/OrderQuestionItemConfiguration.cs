namespace Catman.Education.Persistence.EntityConfigurations
{
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OrderQuestionItemConfiguration : IEntityTypeConfiguration<OrderQuestionItem>
    {
        public void Configure(EntityTypeBuilder<OrderQuestionItem> builder)
        {
            builder.ToTable("order_question_items");

            builder
                .Property(answer => answer.OrderIndex)
                .HasColumnName("order_index");

            builder
                .Property(answer => answer.OrderQuestionId)
                .HasColumnName("order_question_id");
        }
    }
}
