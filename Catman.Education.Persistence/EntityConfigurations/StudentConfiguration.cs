namespace Catman.Education.Persistence.EntityConfigurations
{
    using Catman.Education.Application.Entities.Users;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("students");

            builder
                .Property(student => student.GroupId)
                .HasColumnName("group_id");
        }
    }
}
