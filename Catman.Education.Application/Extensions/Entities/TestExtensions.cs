namespace Catman.Education.Application.Extensions.Entities
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities.Testing;
    using Microsoft.EntityFrameworkCore;

    internal static class TestExtensions
    {
        public static Task<bool> ExistsWithTitleAsync(this IQueryable<Test> tests, string title) =>
            tests.AnyAsync(test => test.Title == title);

        public static Task<bool> ExistsWithIdAsync(this IQueryable<Test> tests, Guid id) =>
            tests.AnyAsync(test => test.Id == id);

        public static Task<Test> WithIdAsync(this IQueryable<Test> tests, Guid id) =>
            tests.SingleAsync(test => test.Id == id);

        public static IQueryable<Test> OfDiscipline(this IQueryable<Test> tests, Guid disciplineId) =>
            tests.Where(test => test.DisciplineId == disciplineId);

        public static IQueryable<Test> OtherThan(this IQueryable<Test> tests, Guid testId) =>
            tests.Where(t => t.Id != testId);

        public static IQueryable<Test> IncludeQuestionsWithAnswers(this IQueryable<Test> tests, Guid testId) =>
            tests
                .Include(test => test.Questions.Where(question => question.TestId == testId))
                    .ThenInclude(question => question.Answers);
    }
}
