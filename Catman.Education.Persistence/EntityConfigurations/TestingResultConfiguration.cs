namespace Catman.Education.Persistence.EntityConfigurations
{
    using Catman.Education.Application.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TestingResultConfiguration : IEntityTypeConfiguration<TestingResult>
    {
        public void Configure(EntityTypeBuilder<TestingResult> builder)
        {
            builder.ToTable("testing_results");

            builder.HasKey(testingResult => new {testingResult.StudentId, testingResult.TestId});

            builder
                .Property(testingResult => testingResult.StudentId)
                .HasColumnName("student_id");

            builder
                .Property(testingResult => testingResult.TestId)
                .HasColumnName("test_id");

            builder
                .Property(testingResult => testingResult.MaxScore)
                .HasColumnName("max_score");

            builder
                .Property(testingResult => testingResult.ActualScore)
                .HasColumnName("actual_score");
        }
    }
}
