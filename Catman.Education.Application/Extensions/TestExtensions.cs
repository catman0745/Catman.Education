namespace Catman.Education.Application.Extensions
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Microsoft.EntityFrameworkCore;

    internal static class TestExtensions
    {
        public static Task<bool> ExistsWithTitleAsync(this IQueryable<Test> tests, string title) =>
            tests.AnyAsync(test => test.Title == title);

        public static Task<bool> ExistsWithIdAsync(this IQueryable<Test> tests, Guid id) =>
            tests.AnyAsync(test => test.Id == id);

        public static Task<Test> WithIdAsync(this IQueryable<Test> tests, Guid id) =>
            tests.SingleAsync(test => test.Id == id);

        public static IQueryable<Test> OfDiscipline(this IQueryable<Test> tests, Discipline discipline) =>
            tests.Where(test => test.DisciplineId == discipline.Id);

        public static IQueryable<Test> OtherThan(this IQueryable<Test> tests, Test test) =>
            tests.Where(t => t.Id != test.Id);

        public static IQueryable<Test> IncludeQuestionsWithAnswers(this IQueryable<Test> tests, Guid testId) =>
            tests
                .Include(test => test.Questions.Where(question => question.TestId == testId))
                    .ThenInclude(question => question.Answers);
    }
}
