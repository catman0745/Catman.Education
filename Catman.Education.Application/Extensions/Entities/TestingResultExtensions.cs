namespace Catman.Education.Application.Extensions.Entities
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities.Testing;
    using Microsoft.EntityFrameworkCore;

    internal static class TestingResultExtensions
    {
        public static Task<bool> ExistsWithKeyAsync(
            this IQueryable<TestingResult> testingResults,
            Guid testId,
            Guid studentId) =>
            testingResults.AnyAsync(testingResult => testingResult.StudentId == studentId &&
                                                     testingResult.TestId == testId);
        
        public static Task<TestingResult> WithKeyAsync(
            this IQueryable<TestingResult> testingResults,
            Guid testId,
            Guid studentId) =>
            testingResults.SingleAsync(testingResult => testingResult.StudentId == studentId &&
                                                        testingResult.TestId == testId);

        public static IQueryable<TestingResult> ForStudent(
            this IQueryable<TestingResult> testingResults,
            Guid studentId) =>
            testingResults.Where(testingResult => testingResult.StudentId == studentId);

        public static IQueryable<TestingResult> OfDiscipline(
            this IQueryable<TestingResult> testingResults,
            Guid disciplineId) =>
            testingResults
                .IncludeTests()
                .Where(testingResult => testingResult.Test.DisciplineId == disciplineId);

        public static IQueryable<TestingResult> IncludeTests(this IQueryable<TestingResult> testingResults) =>
            testingResults.Include(testingResult => testingResult.Test);
    }
}
