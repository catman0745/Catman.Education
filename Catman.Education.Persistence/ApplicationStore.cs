namespace Catman.Education.Persistence
{
    using System.Threading.Tasks;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Entities.Testing;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Entities.Users;
    using Microsoft.EntityFrameworkCore;

    internal class ApplicationStore : DbContext, IApplicationStore
    {
        public DbSet<User> Users { get; set; }
        
        public DbSet<Student> Students { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Discipline> Disciplines { get; set; }
        
        public DbSet<Test> Tests { get; set; }
        
        public DbSet<Question> Questions { get; set; }

        public DbSet<MultipleChoiceQuestion> MultipleChoiceQuestions { get; set; }

        public DbSet<ValueQuestion> ValueQuestions { get; set; }

        public DbSet<QuestionItem> QuestionItems { get; set; }

        public DbSet<MultipleChoiceQuestionAnswerOption> MultipleChoiceQuestionAnswerOptions { get; set; }

        public DbSet<TestingResult> TestingResults { get; set; }

        public ApplicationStore(DbContextOptions<ApplicationStore> options)
            : base(options)
        {
        }
        
        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationStore).Assembly);
        }
    }
}
