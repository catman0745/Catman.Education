namespace Catman.Education.Application.Extensions
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Microsoft.EntityFrameworkCore;

    internal static class TestingResultExtensions
    {
        public static Task<bool> ExistsWithKeyAsync(
            this IQueryable<TestingResult> testingResults,
            Guid studentId,
            Guid testId) =>
            testingResults.AnyAsync(testingResult => testingResult.StudentId == studentId &&
                                                     testingResult.TestId == testId);
    }
}
