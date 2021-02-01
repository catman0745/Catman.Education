namespace Catman.Education.Persistence.EntityConfigurations
{
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class QuestionItemConfiguration : IEntityTypeConfiguration<QuestionItem>
    {
        public void Configure(EntityTypeBuilder<QuestionItem> builder)
        {
            builder.ToTable("question_items");

            builder
                .Property(answer => answer.Id)
                .HasColumnName("id");

            builder
                .Property(answer => answer.Text)
                .HasColumnName("text")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(answer => answer.QuestionId)
                .HasColumnName("question_id");
        }
    }
}
