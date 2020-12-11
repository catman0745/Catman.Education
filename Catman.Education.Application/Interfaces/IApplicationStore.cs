namespace Catman.Education.Application.Interfaces
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Microsoft.EntityFrameworkCore;

    public interface IApplicationStore
    {
        DbSet<User> Users { get; }
        
        DbSet<Student> Students { get; }
        
        DbSet<Admin> Admins { get; }

        DbSet<Group> Groups { get; }
        
        DbSet<Discipline> Disciplines { get; }
        
        DbSet<Test> Tests { get; }
        
        DbSet<Question> Questions { get; }
        
        DbSet<Answer> Answers { get; }

        Task SaveChangesAsync();
    }
}
