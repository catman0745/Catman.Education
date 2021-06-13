namespace Catman.Education.Application.Abstractions
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities.Testing;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Entities.Users;
    using Microsoft.EntityFrameworkCore;

    public interface IApplicationStore
    {
        DbSet<User> Users { get; }
        
        DbSet<Student> Students { get; }
        
        DbSet<Teacher> Teachers { get; }

        DbSet<Admin> Admins { get; }

        DbSet<Group> Groups { get; }
        
        DbSet<Discipline> Disciplines { get; }
        
        DbSet<Test> Tests { get; }
        
        DbSet<Question> Questions { get; }
        
        DbSet<ChoiceQuestion> ChoiceQuestions { get; }
        
        DbSet<OrderQuestion> OrderQuestions { get; }

        DbSet<ValueQuestion> ValueQuestions { get; }
        
        DbSet<YesNoQuestion> YesNoQuestions { get; }

        DbSet<QuestionItem> QuestionItems { get; }
        
        DbSet<ChoiceQuestionAnswerOption> ChoiceQuestionAnswerOptions { get; }
        
        DbSet<OrderQuestionItem> OrderQuestionItems { get; }

        DbSet<TestingResult> TestingResults { get; }

        Task SaveChangesAsync();
    }
}
