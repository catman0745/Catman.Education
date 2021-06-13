namespace Catman.Education.Persistence.EntityConfigurations
{
    using Catman.Education.Application.Entities.Users;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("teachers");
        }
    }
}
