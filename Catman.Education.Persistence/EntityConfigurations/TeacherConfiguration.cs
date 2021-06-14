namespace Catman.Education.Persistence.EntityConfigurations
{
    using System;
    using Catman.Education.Application.Entities.Testing;
    using Catman.Education.Application.Entities.Users;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        private class TeacherDisciplines
        {
            public Guid TeacherId { get; set; }
        
            public Guid DisciplineId { get; set; }
        
            public Teacher Teacher { get; set; }
        
            public Discipline Discipline { get; set; }
        }
    
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("teachers");

            builder
                .HasMany(teacher => teacher.TaughtDisciplines)
                .WithMany(discipline => discipline.Teachers)
                .UsingEntity<TeacherDisciplines>(
                    relationEntity => relationEntity
                        .HasOne(teacherDisciplines => teacherDisciplines.Discipline)
                        .WithMany()
                        .HasForeignKey(teacherDisciplines => teacherDisciplines.DisciplineId),
                    relationEntity => relationEntity
                        .HasOne(teacherDisciplines => teacherDisciplines.Teacher)
                        .WithMany()
                        .HasForeignKey(teacherDisciplines => teacherDisciplines.TeacherId),
                    relationEntity =>
                    {
                        relationEntity.ToTable("teacher_disciplines");

                        relationEntity.HasKey(teacherDisciplines =>
                            new {teacherDisciplines.TeacherId, teacherDisciplines.DisciplineId});
                        
                        relationEntity
                            .Property(teacherDisciplines => teacherDisciplines.TeacherId)
                            .HasColumnName("teacher_id");
                        
                        relationEntity
                            .Property(teacherDisciplines => teacherDisciplines.DisciplineId)
                            .HasColumnName("discipline_id");
                    });
        }
    }
}
