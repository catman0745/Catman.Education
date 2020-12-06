namespace Catman.Education.Persistence.EntityConfigurations
{
    using Catman.Education.Application.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .Property(student => student.FullName)
                .HasColumnName("full_name")
                .HasMaxLength(40)
                .IsRequired();

            builder
                .Property(student => student.GroupId)
                .HasColumnName("group_id");
        }
    }
}
