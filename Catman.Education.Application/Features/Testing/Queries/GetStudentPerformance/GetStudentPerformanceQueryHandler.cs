namespace Catman.Education.Application.Features.Testing.Queries.GetStudentPerformance
{
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.Models.Testing;
    using Microsoft.EntityFrameworkCore;

    internal class GetStudentPerformanceQueryHandler
        : ResourceRequestHandlerBase<GetStudentPerformanceQuery, StudentPerformance>
    {
        private readonly IApplicationStore _store;
        private readonly ILocalizer _localizer;

        public GetStudentPerformanceQueryHandler(IApplicationStore store, ILocalizer localizer)
        {
            _store = store;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<StudentPerformance>> HandleAsync(
            GetStudentPerformanceQuery getQuery)
        {
            if (!await _store.Students.ExistsWithIdAsync(getQuery.StudentId))
            {
                return NotFound(_localizer.StudentNotFound(getQuery.StudentId));
            }

            var student = await _store.Students
                .Include(s => s.Group)
                .WithIdAsync(getQuery.StudentId);

            var testingResults = await _store.TestingResults
                .Where(tr => tr.StudentId == student.Id)
                .Include(tr => tr.Test)
                .ToListAsync();
            
            var disciplines = await _store.Disciplines
                .Where(discipline => discipline.Grade == student.Group.Grade)
                .Include(d => d.Tests)
                .ToListAsync();

            var disciplinesPerformance = disciplines
                .GroupJoin(
                    testingResults,
                    discipline => discipline.Id,
                    testingResult => testingResult.Test.DisciplineId,
                    (discipline, results) =>
                    {
                        double? coverage = discipline.Tests.Any()
                            ? (double) results.Count() / discipline.Tests.Count
                            : null;

                        double? accuracy = results.Any()
                            ? results.Average(result => result.ActualScore / result.MaxScore)
                            : null;

                        return (
                            Discipline: discipline,
                            Performance: new StudentPerformance.DisciplinePerformance()
                            {
                                TestCoverage = coverage,
                                AverageAccuracy = accuracy
                            }
                        );
                    })
                .ToDictionary(performance => performance.Discipline, performance => performance.Performance);

            var studentPerformance = new StudentPerformance()
            {
                Student = student,
                DisciplinesPerformance = disciplinesPerformance
            };

            return Success(string.Empty, studentPerformance);
        }
    }
}
